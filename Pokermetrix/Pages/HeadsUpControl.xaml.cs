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
using Microsoft.Phone.Tasks;

namespace Pokermetrix
{
    public partial class HeadsUpControl : UserControl
    {
        #region Instance Variables
        CardPicker cardPickerControl;
        AdjustmentPicker adjustmentPicker;
        double bigBlind = 400;
        double stack = 10000;
        double blindsRemaining = 10000 / (400 * 1.5);
        bool adjustmentIsIncremental = false;
        bool opponentAllIn = false;
        bool isTouchingCards = false;
        bool hasBeenDealtOnce = false;
        #endregion /Instance Variables

        #region Properties
        public bool IsSuited { get; set; }
        public bool HideValues { get; set; }
        public Card CardA { get; set; }
        public Card CardB { get; set; }
        #endregion /Properties

        #region Constructor & Init
        public HeadsUpControl()
        {
            InitializeComponent();
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

            adjustmentPicker.OnAdjustmentDone += (s, e) =>
            {
                stack += (ParseUtil.ToNullableNumber(adjustmentPicker.Adjustment) ?? 0) * (adjustmentIsIncremental ? 1 : -1);
                stackSizeTextBox.Text = stack.ToString();
                Refresh();
            };

            stackSizeTextBox.GotFocus += (s, e) =>
            {
                AutoSelectText(s);
            };

            bigBlindSizeTextBox.GotFocus += (s, e) =>
            {
                AutoSelectText(s);
            };
        }

        private void AutoSelectText(object sender)
        {
            TextBox target = sender as TextBox;
            target.Select(0, target.Text.Length);
        }

        public void SetPickers(CardPicker cardPicker, AdjustmentPicker adjustmentPickerControl)
        {
            adjustmentPicker = adjustmentPickerControl;
            cardPickerControl = cardPicker;
            WireEvents();
            Refresh();
        }
        #endregion /Constructor & Init

        #region Back Button Funcationality
        public void OnBackKeyPress(CancelEventArgs e)
        {
            cardPickerControl.HandleHardwareBackButtonPress(e);
            adjustmentPicker.HandleHardwareBackButtonPress(e);
        }
        #endregion /Back Button Functionality

        #region Actions
        private void btnOpponentIsAllIn_OnClick(object sender, EventArgs e)
        {
            opponentAllIn = btnOpponentIsAllIn.IsChecked;
            Refresh();
        }

        private void stackSizeTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            stack = ParseUtil.ToNullableNumber(stackSizeTextBox.Text) ?? stack;
            Refresh();
        }

        private void bigBlindSizeTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            bigBlind = ParseUtil.ToNullableNumber(bigBlindSizeTextBox.Text) ?? bigBlind;
            Refresh();
        }

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
            blindsRemaining = stack / (bigBlind * 1.5);
            Hand hand = HandUtil.HandFromCards(CardA, CardB, IsSuited);

            if (NashEQData.Data != null)
            {

                double threshold = NashEQData.Data[(int)hand][opponentAllIn ? 1 : 0];
                bool goAllIn = blindsRemaining < threshold;
                double featuredMeasure = Math.Min(blindsRemaining, 20);

                // Values
                if (darkQualitativeRange != null)
                {
                    darkQualitativeRange.Length = 20.0 / featuredMeasure;
                    lightQualitativeRange.Length = 20 - darkQualitativeRange.Length;
                }

                bulletGraph.FeaturedMeasure = Math.Min(threshold, 20);
                bulletGraph.ComparativeMeasure = featuredMeasure;
                cardAButton.CardValueFull = CardA.ToString();
                cardAButton.CardValueShort = HandUtil.CardAsBackgroundString(CardA);
                cardBButton.CardValueFull = CardB.ToString();
                cardBButton.CardValueShort = HandUtil.CardAsBackgroundString(CardB);
                lblStrength.Text = goAllIn ? opponentAllIn ? "Call" : "Shove" : "Fold";
                blindsRemainingTextBlock.Text = blindsRemaining > 20 ? "20+" : String.Format("{0:0.#}", blindsRemaining);
                grdSuited.Visibility = HideValues ? Visibility.Collapsed : CardA == CardB ? Visibility.Collapsed : Visibility.Visible;
                hideShowButton.ShowVisibility = HideValues ? Visibility.Visible : Visibility.Collapsed;
                hideShowButton.HideVisibility = HideValues ? Visibility.Collapsed : Visibility.Visible;
                btnSuited.IsChecked = IsSuited;
                btnSuited.Refresh();

                // Colour
                bulletGraph.FeaturedMeasureBrush = goAllIn ? (Brush)Application.Current.Resources["GreenBrush"] : (Brush)Application.Current.Resources["RedBrush"];
            }

            // Visibility
            Visibility valueVisibility = HideValues ? Visibility.Collapsed : Visibility.Visible;
            Visibility reverseVisibility = HideValues ? Visibility.Visible : Visibility.Collapsed;
            lblStrength.Visibility = valueVisibility;
            cardAButton.BackVisibility = reverseVisibility;
            cardBButton.BackVisibility = reverseVisibility;
            UpdateCardHighlightVisibility();
            hideShowButton.Visibility = hasBeenDealtOnce ? Visibility.Visible : Visibility.Collapsed;
            chartGrid.Visibility = valueVisibility;
            tapToDealText.Visibility = reverseVisibility;

            // Trial
            //trialOverlay.Visibility = TrialUtil.IsTrial ? Visibility.Visible : Visibility.Collapsed;
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

        private void PlusButton_OnClick(object sender, EventArgs e)
        {
            adjustmentIsIncremental = true;
            adjustmentPicker.Show("Increase stack by");
        }

        private void MinusButton_OnClick(object sender, EventArgs e)
        {
            adjustmentIsIncremental = false;
            adjustmentPicker.Show("Decrease stack by");
        }

        private void BuyItNowButton_Click(object sender, RoutedEventArgs e)
        {
            new MarketplaceDetailTask().Show();
        }
    }
}
