using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;
using System.ComponentModel;

namespace Pokermetrix
{
    public partial class HandRankDiagram : UserControl//, INotifyPropertyChanged
    {
        Brush suitBrushBlack = new SolidColorBrush(Colors.Black);
        Brush suitBrushRed = Application.Current.Resources["RedBrush"] as Brush;

        #region Dependency Properties
        // SuitHeart Visibility
        public static readonly DependencyProperty SuitHeartVisibilityProperty = DependencyProperty.Register(
            "SuitHeartVisibility",
            typeof(Visibility),
            typeof(HandRankDiagram),
            new PropertyMetadata(Visibility.Collapsed));

        public Visibility SuitHeartVisibility
        {
            get { return (Visibility)GetValue(SuitHeartVisibilityProperty); }
            set { SetValue(SuitHeartVisibilityProperty, value); }
        }

        // SuitClub Visibility
        public static readonly DependencyProperty SuitClubVisibilityProperty = DependencyProperty.Register(
            "SuitClubVisibility",
            typeof(Visibility),
            typeof(HandRankDiagram),
            new PropertyMetadata(Visibility.Collapsed));

        public Visibility SuitClubVisibility
        {
            get { return (Visibility)GetValue(SuitClubVisibilityProperty); }
            set { SetValue(SuitClubVisibilityProperty, value); }
        }

        // SuitSpade Visibility
        public static readonly DependencyProperty SuitSpadeVisibilityProperty = DependencyProperty.Register(
            "SuitSpadeVisibility",
            typeof(Visibility),
            typeof(HandRankDiagram),
            new PropertyMetadata(Visibility.Collapsed));

        public Visibility SuitSpadeVisibility
        {
            get { return (Visibility)GetValue(SuitSpadeVisibilityProperty); }
            set { SetValue(SuitSpadeVisibilityProperty, value); }
        }

        // SuitDiamond Visibility
        public static readonly DependencyProperty SuitDiamondVisibilityProperty = DependencyProperty.Register(
            "SuitDiamondVisibility",
            typeof(Visibility),
            typeof(HandRankDiagram),
            new PropertyMetadata(Visibility.Collapsed));

        public Visibility SuitDiamondVisibility
        {
            get { return (Visibility)GetValue(SuitDiamondVisibilityProperty); }
            set { SetValue(SuitDiamondVisibilityProperty, value); }
        }


        // Rank
        public static readonly DependencyProperty RankProperty = DependencyProperty.Register(
            "Rank",
            typeof(int),
            typeof(HandRankDiagram),
            new PropertyMetadata(-1, new PropertyChangedCallback(OnRankChanged)));

        public int Rank
        {
            get
            {
                return (int)GetValue(RankProperty);
            }
            set
            {
                SetValue(RankProperty, value);
            }
        }

        private static void OnRankChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as HandRankDiagram).Refresh();
        }
        #endregion Dependency Properties

        public HandRankDiagram()
        {
            InitializeComponent();
        }

        void Refresh()
        {
            switch (Rank)
            {
                case 0: RoyalFlush(); break;
                case 1: StraightFlush(); break;
                case 2: FourOfAKind(); break;
                case 3: FullHouse(); break;
                case 4: Flush(); break;
                case 5: Straight(); break;
                case 6: ThreeOfAKind(); break;
                case 7: TwoPair(); break;
                case 8: Pair(); break;
                case 9: default: HighCard(); break;
            }
        }

        #region Hand diagram setup
        void RoyalFlush()
        {
            List<string> cardValuesShort = new List<string> { "10", "J", "Q", "K", "A" };
            for (int cardIndex = 0; cardIndex < 5; cardIndex++)
            {
                CardVisual control = CardVisualByIndex(cardIndex);
                control.BackVisibility = Visibility.Collapsed;
                control.CardValueFull = string.Empty;
                control.CardValueShort = cardValuesShort[cardIndex];
                control.ClubVisibility = Visibility.Collapsed;
                control.HeartVisibility = Visibility.Collapsed;
                control.DiamondVisibility = Visibility.Collapsed;
                control.SpadeVisibility = Visibility.Visible;
                control.SmallClubVisibility = Visibility.Collapsed;
                control.SmallHeartVisibility = Visibility.Collapsed;
                control.SmallDiamondVisibility = Visibility.Collapsed;
                control.SmallSpadeVisibility = Visibility.Collapsed;
                control.ShortTextBrush = suitBrushBlack;
            }
        }

        void StraightFlush()
        {
            List<string> cardValuesShort = new List<string> { "6", "7", "8", "9", "10" };
            for (int cardIndex = 0; cardIndex < 5; cardIndex++)
            {
                CardVisual control = CardVisualByIndex(cardIndex);
                control.BackVisibility = Visibility.Collapsed;
                control.CardValueFull = string.Empty;
                control.CardValueShort = cardValuesShort[cardIndex];
                control.ClubVisibility = Visibility.Collapsed;
                control.HeartVisibility = Visibility.Collapsed;
                control.DiamondVisibility = Visibility.Visible;
                control.SpadeVisibility = Visibility.Collapsed;
                control.SmallClubVisibility = Visibility.Collapsed;
                control.SmallHeartVisibility = Visibility.Collapsed;
                control.SmallDiamondVisibility = Visibility.Collapsed;
                control.SmallSpadeVisibility = Visibility.Collapsed;
                control.ShortTextBrush = suitBrushRed;
            }
        }

        void FourOfAKind()
        {
            List<string> cardValuesShort = new List<string> { "K", "8", "8", "8", "8" };
            //List<string> cardValuesFull = new List<string> { "King", "Eight", "Eight", "Eight", "Eight" };
            for (int cardIndex = 0; cardIndex < 5; cardIndex++)
            {
                CardVisual control = CardVisualByIndex(cardIndex);
                control.BackVisibility = Visibility.Collapsed;
                control.CardValueFull = string.Empty;
                control.CardValueShort = cardValuesShort[cardIndex];
                control.ClubVisibility = Visibility.Collapsed;
                control.HeartVisibility = Visibility.Collapsed;
                control.DiamondVisibility = Visibility.Collapsed;
                control.SpadeVisibility = Visibility.Collapsed;
                control.SmallClubVisibility = Visibility.Collapsed;
                control.SmallHeartVisibility = Visibility.Collapsed;
                control.SmallDiamondVisibility = Visibility.Collapsed;
                control.SmallSpadeVisibility = Visibility.Collapsed;
                control.ShortTextBrush = cardIndex % 2 == 0 ? suitBrushBlack : suitBrushRed;
            }
        }

        void FullHouse()
        {
            List<string> cardValuesShort = new List<string> { "J", "J", "J", "2", "2" };
            //List<string> cardValuesFull = new List<string> { "Jack", "Jack", "Jack", "Two", "Two" };
            for (int cardIndex = 0; cardIndex < 5; cardIndex++)
            {
                CardVisual control = CardVisualByIndex(cardIndex);
                control.BackVisibility = Visibility.Collapsed;
                control.CardValueFull = string.Empty;
                control.CardValueShort = cardValuesShort[cardIndex];
                control.ClubVisibility = Visibility.Collapsed;
                control.HeartVisibility = Visibility.Collapsed;
                control.DiamondVisibility = Visibility.Collapsed;
                control.SpadeVisibility = Visibility.Collapsed;
                control.SmallClubVisibility = Visibility.Collapsed;
                control.SmallHeartVisibility = Visibility.Collapsed;
                control.SmallDiamondVisibility = Visibility.Collapsed;
                control.SmallSpadeVisibility = Visibility.Collapsed;
                control.ShortTextBrush = cardIndex % 2 == 1 ? suitBrushBlack : suitBrushRed;
            }
        }

        void Flush()
        {
            List<string> cardValuesShort = new List<string> { "A", "K", "Q", "J", "10" };
            for (int cardIndex = 0; cardIndex < 5; cardIndex++)
            {
                CardVisual control = CardVisualByIndex(cardIndex);
                control.BackVisibility = Visibility.Collapsed;
                control.CardValueFull = string.Empty;
                control.CardValueShort = string.Empty;
                control.ClubVisibility = Visibility.Collapsed;
                control.HeartVisibility = Visibility.Collapsed;
                control.DiamondVisibility = Visibility.Collapsed;
                control.SpadeVisibility = Visibility.Collapsed;
                control.SmallClubVisibility = Visibility.Collapsed;
                control.SmallHeartVisibility = Visibility.Visible;
                control.SmallDiamondVisibility = Visibility.Collapsed;
                control.SmallSpadeVisibility = Visibility.Collapsed;
                control.ShortTextBrush = suitBrushRed;
            }
        }

        void Straight()
        {
            List<string> cardValuesShort = new List<string> { "4", "5", "6", "7", "8" };
            //List<string> cardValuesFull = new List<string> { "Four", "Five", "Size", "Seven", "Eight" };
            for (int cardIndex = 0; cardIndex < 5; cardIndex++)
            {
                CardVisual control = CardVisualByIndex(cardIndex);
                control.BackVisibility = Visibility.Collapsed;
                control.CardValueFull = string.Empty;
                control.CardValueShort = cardValuesShort[cardIndex];
                //control.CardValueFull = cardValuesFull[cardIndex];
                control.ClubVisibility = Visibility.Collapsed;
                control.HeartVisibility = Visibility.Collapsed;
                control.DiamondVisibility = Visibility.Collapsed;
                control.SpadeVisibility = Visibility.Collapsed;
                control.SmallClubVisibility = Visibility.Collapsed;
                control.SmallHeartVisibility = Visibility.Collapsed;
                control.SmallDiamondVisibility = Visibility.Collapsed;
                control.SmallSpadeVisibility = Visibility.Collapsed;
                control.Foreground = cardIndex % 2 == 1 ? suitBrushBlack : suitBrushRed;
                control.ShortTextBrush = cardIndex % 2 == 1 ? suitBrushBlack : suitBrushRed;
            }
        }

        void ThreeOfAKind()
        {
            List<string> cardValuesShort = new List<string> { "Q", "7", "5", "5", "5" };
            // List<string> cardValuesFull = new List<string> { "Queen", "Seven", "Five", "Five", "Five" };
            for (int cardIndex = 0; cardIndex < 5; cardIndex++)
            {
                CardVisual control = CardVisualByIndex(cardIndex);
                control.BackVisibility = Visibility.Collapsed;
                control.CardValueFull = string.Empty;
                control.CardValueShort = cardValuesShort[cardIndex];
                control.ClubVisibility = Visibility.Collapsed;
                control.HeartVisibility = Visibility.Collapsed;
                control.DiamondVisibility = Visibility.Collapsed;
                control.SpadeVisibility = Visibility.Collapsed;
                control.SmallClubVisibility = Visibility.Collapsed;
                control.SmallHeartVisibility = Visibility.Collapsed;
                control.SmallDiamondVisibility = Visibility.Collapsed;
                control.SmallSpadeVisibility = Visibility.Collapsed;
                control.ShortTextBrush = cardIndex % 2 == 0 ? suitBrushBlack : suitBrushRed;
            }
        }

        void TwoPair()
        {
            List<string> cardValuesShort = new List<string> { "A", "3", "3", "4", "4" };
            for (int cardIndex = 0; cardIndex < 5; cardIndex++)
            {
                CardVisual control = CardVisualByIndex(cardIndex);
                control.BackVisibility = Visibility.Collapsed;
                control.CardValueFull = string.Empty;
                control.CardValueShort = cardValuesShort[cardIndex];
                control.ClubVisibility = Visibility.Collapsed;
                control.HeartVisibility = Visibility.Collapsed;
                control.DiamondVisibility = Visibility.Collapsed;
                control.SpadeVisibility = Visibility.Collapsed;
                control.SmallClubVisibility = Visibility.Collapsed;
                control.SmallHeartVisibility = Visibility.Collapsed;
                control.SmallDiamondVisibility = Visibility.Collapsed;
                control.SmallSpadeVisibility = Visibility.Collapsed;
                control.ShortTextBrush = cardIndex % 2 == 0 ? suitBrushBlack : suitBrushRed;
            }
        }

        void Pair()
        {
            List<string> cardValuesShort = new List<string> { "10", "9", "7", "Q", "Q" };
            for (int cardIndex = 0; cardIndex < 5; cardIndex++)
            {
                CardVisual control = CardVisualByIndex(cardIndex);
                control.BackVisibility = Visibility.Collapsed;
                control.CardValueFull = string.Empty;
                control.CardValueShort = cardValuesShort[cardIndex];
                control.ClubVisibility = Visibility.Collapsed;
                control.HeartVisibility = Visibility.Collapsed;
                control.DiamondVisibility = Visibility.Collapsed;
                control.SpadeVisibility = Visibility.Collapsed;
                control.SmallClubVisibility = Visibility.Collapsed;
                control.SmallHeartVisibility = Visibility.Collapsed;
                control.SmallDiamondVisibility = Visibility.Collapsed;
                control.SmallSpadeVisibility = Visibility.Collapsed;
                control.ShortTextBrush = cardIndex % 2 == 0 ? suitBrushBlack : suitBrushRed;
            }
        }

        void HighCard()
        {
            List<string> cardValuesShort = new List<string> { "2", "7", "10", "J", "K" };
            for (int cardIndex = 0; cardIndex < 5; cardIndex++)
            {
                CardVisual control = CardVisualByIndex(cardIndex);
                control.BackVisibility = Visibility.Collapsed;
                control.CardValueFull = string.Empty;
                control.CardValueShort = cardValuesShort[cardIndex];
                control.ClubVisibility = Visibility.Collapsed;
                control.HeartVisibility = Visibility.Collapsed;
                control.DiamondVisibility = Visibility.Collapsed;
                control.SpadeVisibility = Visibility.Collapsed;
                control.SmallClubVisibility = Visibility.Collapsed;
                control.SmallHeartVisibility = Visibility.Collapsed;
                control.SmallDiamondVisibility = Visibility.Collapsed;
                control.SmallSpadeVisibility = Visibility.Collapsed;
                control.ShortTextBrush = cardIndex % 2 == 0 ? suitBrushBlack : suitBrushRed;
            }
        }
        #endregion /Hand diagram setup


        #region Helpers

        CardVisual CardVisualByIndex(int index)
        {
            switch (index)
            {
                case 0: return card1;
                case 1: return card2;
                case 2: return card3;
                case 3: return card4;
                case 4:
                default: return card5;
            }
        }
        #endregion /Helpers
    }
}
