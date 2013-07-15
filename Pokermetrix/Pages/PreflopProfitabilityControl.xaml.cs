using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Media;
using System.Windows.Input;

namespace Pokermetrix
{
    public partial class PreflopProfitabilityControl : UserControl
    {
        #region Properties
        public bool IsSuited { get; set; }
        public bool HideValues { get; set; }
        public Card CardA { get; set; } 
        public Card CardB { get; set; }
        public int Players { get; set; }
        public ObservableCollection<Player> TablePlayers { get; set; }
        public ObservableCollection<DealerButton> TableButtons { get; set; }
        #endregion /Properties

        #region Instance Variables
        CardPicker cardPickerControl;
        int positionIndex = 0;
        double expectedValue = 0;
        bool isTouchingCards = false;
        bool hasBeenDealtOnce = false;
        #endregion /Instance Variables

        #region Constructor & Init
        public PreflopProfitabilityControl()
        {
            InitializeComponent();

            // Data Init
            TablePlayers = new ObservableCollection<Player>();
            TableButtons = new ObservableCollection<DealerButton>();

            // Poker setup
            Players = 6;
            CardA = Card.Ace;
            CardB = Card.Ace;
            IsSuited = false;
            HideValues = true;
            Refresh();
        }

        private void WireEvents()
        {
            cardPickerControl.OnCardASelected += (s, e) =>
            {
                CardA = cardPickerControl.SelectedCardA;
            };

            cardPickerControl.OnCardBSelected += (s, e) =>
            {
                CardB = cardPickerControl.SelectedCardB;
                hasBeenDealtOnce = true;
                Refresh();
                RaiseOnCardStatusChanged();
            };
        }

        public void SetCardPicker(CardPicker cardPicker)
        {
            cardPickerControl = cardPicker;
            WireEvents();
        }
        #endregion /Constructor & Init

        #region Back Button Funcationality
        public void OnBackKeyPress(CancelEventArgs e)
        {
            cardPickerControl.HandleHardwareBackButtonPress(e);
        }
        #endregion /Back Button Functionality

        #region Actions
        private void btnSuited_OnClick(object sender, EventArgs e)
        {
            if (btnSuited == null)
            {
                return;
            }

            IsSuited = btnSuited.IsChecked;
            Refresh();
            RaiseOnCardStatusChanged();
        }

        private void PlayersInc(object sender, EventArgs e)
        {
            if (Players == 10)
            {
                return;
            }

            Players++;
            positionIndex = PositionUtil.Cap(positionIndex, Players);
            Refresh();
        }

        private void PlayersDec(object sender, EventArgs e)
        {
            if (Players == 2)
            {
                return;
            }

            Players--;
            positionIndex = PositionUtil.Cap(positionIndex, Players);
            Refresh();
        }

        private void NewHand(object sender, EventArgs e)
        {
            isTouchingCards = false;
            UpdateCardHighlightVisibility();
            HideValues = false;
            cardPickerControl.Show(CardA);
        }

        private void HideShow(object sender, EventArgs e)
        {
            HideValues = !HideValues;
            Refresh();
            RaiseOnCardStatusChanged();
        }

        private void cardsFingerDown(object sender, MouseButtonEventArgs e)
        {
            isTouchingCards = true;
            UpdateCardHighlightVisibility();
        }
        #endregion /Actions

        #region Update UI
        private void Refresh()
        {
            expectedValue = EVAnalysis.CalculateExpectedValue(CardA, CardB, IsSuited, Players, positionIndex);

            // Values
            lblPlayers.Text = Players.ToString();
            cardAButton.CardValueFull = CardA.ToString();
            cardAButton.CardValueShort = HandUtil.CardAsBackgroundString(CardA);
            cardBButton.CardValueFull = CardB.ToString();
            cardBButton.CardValueShort = HandUtil.CardAsBackgroundString(CardB);
            lblStrength.Text = EVAnalysis.CalculateStrength(expectedValue);
            bulletGraph.FeaturedMeasure = expectedValue < 0.5 ? expectedValue : 0.5;
            grdSuited.Visibility = HideValues ? Visibility.Collapsed : CardA == CardB ? Visibility.Collapsed : Visibility.Visible;
            chart.Series[0].ItemsSource = EVAnalysis.CalculcateChartDataAllPositions(Players);
            chart.Series[1].ItemsSource = EVAnalysis.CalculcateChartDataSinglePosition(Players, positionIndex);
            hideShowButton.ShowVisibility = HideValues ? Visibility.Visible : Visibility.Collapsed;
            hideShowButton.HideVisibility = HideValues ? Visibility.Collapsed : Visibility.Visible;
            btnSuited.IsChecked = IsSuited;
            btnSuited.Refresh();

            // Visibility
            Visibility valueVisibility = HideValues ? Visibility.Collapsed : Visibility.Visible;
            Visibility reverseVisibility = HideValues ? Visibility.Visible : Visibility.Collapsed;
            lblStrength.Visibility = valueVisibility;
            bulletGraph.Visibility = valueVisibility;
            chart.Visibility = valueVisibility;
            cappedChartAnnotation.Visibility = valueVisibility;
            cardAButton.BackVisibility = reverseVisibility;
            cardBButton.BackVisibility = reverseVisibility;
            tapToDealText.Visibility = reverseVisibility;
            UpdateCardHighlightVisibility();
            hideShowButton.Visibility = hasBeenDealtOnce ? Visibility.Visible : Visibility.Collapsed;

            // Colour
            bulletGraph.FeaturedMeasureBrush = expectedValue > 0 ? (Brush)Application.Current.Resources["GreenBrush"] : expectedValue < 0 ? (Brush)Application.Current.Resources["RedBrush"] : (Brush)Application.Current.Resources["BlackBrush"];

            // Adjust TablePlayers & TableButtons collection sizes
            while (Players > TablePlayers.Count())
            {
                Player player = new Player { Width = 50, Height = 50 };
                player.OnClick += (s, e) =>
                {
                    positionIndex = (int)(s as Player).Tag;
                    Refresh();
                };
                TablePlayers.Add(player);
            }
            while (TablePlayers.Count() > Players)
            {
                TablePlayers.RemoveAt(TablePlayers.Count() - 1);
            }
            while (Players > TableButtons.Count())
            {
                DealerButton button = new DealerButton { Width = 30, Height = 30 };
                TableButtons.Add(button);
            }
            while (TableButtons.Count() > Players)
            {
                TableButtons.RemoveAt(TableButtons.Count() - 1);
            }

            // Table diagram
            for (int i = 0; i < Players; i++)
            {
                // Adjust Players
                Player player = TablePlayers[i];
                player.SelectedVisibility = i == positionIndex ? Visibility.Visible : Visibility.Collapsed;
                player.UnselectedVisibility = i == positionIndex ? Visibility.Collapsed : Visibility.Visible;
                player.Tag = i;

                // Adjust Buttons
                DealerButton button = TableButtons[i];
                button.DealerVisibility = (Players == 2 && i == 0) || (Players > 2 && i == Players - 1) ? Visibility.Visible : Visibility.Collapsed;
                button.SmallBlindVisibility = i == 0 && Players > 2 ? Visibility.Visible : Visibility.Collapsed;
                button.BigBlindVisibility = (Players > 2 && i == 1) || (Players == 2 && i == 1) ? Visibility.Visible : Visibility.Collapsed;
                button.ExtraSmallBlindVisibility = Players == 2 && i == 0 ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        private void UpdateCardHighlightVisibility()
        {
            Visibility cardHighlightVisibility = isTouchingCards ? Visibility.Visible : Visibility.Collapsed;
        }
        #endregion /Update UI

        #region Cross-Page Synchronisation
        public event EventHandler OnCardStatusChanged;
        private void RaiseOnCardStatusChanged()
        {
            if (OnCardStatusChanged != null)
            {
                OnCardStatusChanged(this, new EventArgs());
            }
        }

        public void OtherPageChangedCards(Card cardA, Card cardB, bool isSuited, bool hideValues)
        {
            CardA = cardA;
            CardB = cardB;
            IsSuited = isSuited;
            HideValues = hideValues;
            hasBeenDealtOnce = true;
            Refresh();
        }
        #endregion /Cross-Page Synchronisation

        #region Help Info
        public event EventHandler OnInfoClick;
        private void InfoButton_OnClick(object sender, EventArgs e)
        {
            if (OnInfoClick != null)
            {
                OnInfoClick(this, new EventArgs());
            }
        }
        #endregion /Help Info
    }
}
