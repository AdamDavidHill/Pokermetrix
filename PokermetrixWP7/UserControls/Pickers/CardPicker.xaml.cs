using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace PokermetrixWP7
{
    public partial class CardPicker : UserControl
    {
        public event EventHandler OnCardASelected;
        public event EventHandler OnCardBSelected;

        Card previousCardA;
        bool lastCardSelectedWasCardA = false;

        public Card SelectedCardA { get; set; }
        public Card SelectedCardB { get; set; }

        public CardPicker()
        {
            InitializeComponent();
            this.Visibility = Visibility.Visible;
            this.IsHitTestVisible = false;
            SelectedCardA = Card.Ace;
            SelectedCardB = Card.Ace;
        }

        public void Show(Card currentCardA)
        {
            cardAButton.BackVisibility = Visibility.Visible;
            cardBButton.BackVisibility = Visibility.Visible;
            previousCardA = currentCardA;
            FadeIn();
        }

        public void HandleHardwareBackButtonPress(CancelEventArgs e)
        {
            if (this.IsHitTestVisible)
            {
                if (lastCardSelectedWasCardA)
                {
                    cardAButton.BackVisibility = Visibility.Visible;
                    lastCardSelectedWasCardA = false;
                    SelectedCardA = previousCardA;
                    RaiseCardASelected();
                }
                else
                {
                    FadeOut();
                }

                e.Cancel = true;
            }
        }

        private void CardButton_OnClick(object sender, EventArgs e)
        {
            string cardString = (sender as CardVisual).CardValueFull.ToString();
            Card card = (Card)Enum.Parse(typeof(Card), cardString, true);

            if (lastCardSelectedWasCardA)
            {
                SelectedCardB = card;
                cardBButton.CardValueShort = HandUtil.CardAsBackgroundString(card);
                cardBButton.CardValueFull = cardString;
                cardBButton.BackVisibility = Visibility.Collapsed;
                RaiseCardBSelected();
                FadeOut();
            }
            else
            {
                SelectedCardA = card;
                cardAButton.CardValueShort = HandUtil.CardAsBackgroundString(card);
                cardAButton.CardValueFull = cardString;
                cardAButton.BackVisibility = Visibility.Collapsed;
                RaiseCardASelected();
            }

            lastCardSelectedWasCardA = !lastCardSelectedWasCardA;
        }

        private void RaiseCardASelected()
        {
            if (OnCardASelected != null)
            {
                OnCardASelected(this, new EventArgs());
            }
        }

        private void RaiseCardBSelected()
        {
            if (OnCardBSelected != null)
            {
                OnCardBSelected(this, new EventArgs());
            }
        }

        private void FadeIn()
        {
            fadeIn.Begin();
            this.IsHitTestVisible = true;
        }

        private void FadeOut()
        {
            this.IsHitTestVisible = false;
            fadeOut.Begin();
        }
    }
}

