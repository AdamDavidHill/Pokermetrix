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
using Microsoft.Devices;

namespace PokermetrixWP7
{
    public partial class CardVisual : UserControl
    {
        // Back Visibility
        public static readonly DependencyProperty BackVisibilityProperty = DependencyProperty.Register(
            "BackVisibility",
            typeof(Visibility),
            typeof(CardVisual),
            new PropertyMetadata(Visibility.Visible));

        public Visibility BackVisibility
        {
            get { return (Visibility)GetValue(BackVisibilityProperty); }
            set { SetValue(BackVisibilityProperty, value); }
        }

        // CardValueShort
        public static readonly DependencyProperty CardValueShortProperty = DependencyProperty.Register(
            "CardValueShortVisibility",
            typeof(string),
            typeof(CardVisual),
            new PropertyMetadata("Q"));

        public string CardValueShort
        {
            get { return (string)GetValue(CardValueShortProperty); }
            set { SetValue(CardValueShortProperty, value); }
        }

        // CardValueFull
        public static readonly DependencyProperty CardValueFullProperty = DependencyProperty.Register(
            "CardValueFullVisibility",
            typeof(string),
            typeof(CardVisual),
            new PropertyMetadata("Queen"));

        public string CardValueFull
        {
            get { return (string)GetValue(CardValueFullProperty); }
            set { SetValue(CardValueFullProperty, value); }
        }

        // ShortTextBrush
        public static readonly DependencyProperty ShortTextBrushProperty = DependencyProperty.Register(
            "ShortTextBrush",
            typeof(Brush),
            typeof(CardVisual),
            new PropertyMetadata(new SolidColorBrush(Colors.Black)));

        public Brush ShortTextBrush
        {
            get { return (Brush)GetValue(ShortTextBrushProperty); }
            set { SetValue(ShortTextBrushProperty, value); }
        }

		
		//
		// Big Suits
		//
		
		// Heart Visibility
        public static readonly DependencyProperty HeartVisibilityProperty = DependencyProperty.Register(
            "HeartVisibility",
            typeof(Visibility),
            typeof(CardVisual),
            new PropertyMetadata(Visibility.Collapsed));

        public Visibility HeartVisibility
        {
            get { return (Visibility)GetValue(HeartVisibilityProperty); }
            set { SetValue(HeartVisibilityProperty, value); }
        }
		
		// Club Visibility
        public static readonly DependencyProperty ClubVisibilityProperty = DependencyProperty.Register(
            "ClubVisibility",
            typeof(Visibility),
            typeof(CardVisual),
            new PropertyMetadata(Visibility.Collapsed));

        public Visibility ClubVisibility
        {
            get { return (Visibility)GetValue(ClubVisibilityProperty); }
            set { SetValue(ClubVisibilityProperty, value); }
        }
		
		// Spade Visibility
        public static readonly DependencyProperty SpadeVisibilityProperty = DependencyProperty.Register(
            "SpadeVisibility",
            typeof(Visibility),
            typeof(CardVisual),
            new PropertyMetadata(Visibility.Collapsed));

        public Visibility SpadeVisibility
        {
            get { return (Visibility)GetValue(SpadeVisibilityProperty); }
            set { SetValue(SpadeVisibilityProperty, value); }
        }
		
		// Diamond Visibility
        public static readonly DependencyProperty DiamondVisibilityProperty = DependencyProperty.Register(
            "DiamondVisibility",
            typeof(Visibility),
            typeof(CardVisual),
            new PropertyMetadata(Visibility.Collapsed));

        public Visibility DiamondVisibility
        {
            get { return (Visibility)GetValue(DiamondVisibilityProperty); }
            set { SetValue(DiamondVisibilityProperty, value); }
        }

		
		//
		// Small Suits
		//
		
		// Heart Visibility
        public static readonly DependencyProperty SmallHeartVisibilityProperty = DependencyProperty.Register(
            "SmallHeartVisibility",
            typeof(Visibility),
            typeof(CardVisual),
            new PropertyMetadata(Visibility.Collapsed));

        public Visibility SmallHeartVisibility
        {
            get { return (Visibility)GetValue(SmallHeartVisibilityProperty); }
            set { SetValue(SmallHeartVisibilityProperty, value); }
        }
		
		// Club Visibility
        public static readonly DependencyProperty SmallClubVisibilityProperty = DependencyProperty.Register(
            "SmallClubVisibility",
            typeof(Visibility),
            typeof(CardVisual),
            new PropertyMetadata(Visibility.Collapsed));

        public Visibility SmallClubVisibility
        {
            get { return (Visibility)GetValue(SmallClubVisibilityProperty); }
            set { SetValue(SmallClubVisibilityProperty, value); }
        }
		
		// Spade Visibility
        public static readonly DependencyProperty SmallSpadeVisibilityProperty = DependencyProperty.Register(
            "SmallSpadeVisibility",
            typeof(Visibility),
            typeof(CardVisual),
            new PropertyMetadata(Visibility.Collapsed));

        public Visibility SmallSpadeVisibility
        {
            get { return (Visibility)GetValue(SmallSpadeVisibilityProperty); }
            set { SetValue(SmallSpadeVisibilityProperty, value); }
        }
		
		// Diamond Visibility
        public static readonly DependencyProperty SmallDiamondVisibilityProperty = DependencyProperty.Register(
            "SmallDiamondVisibility",
            typeof(Visibility),
            typeof(CardVisual),
            new PropertyMetadata(Visibility.Collapsed));

        public Visibility SmallDiamondVisibility
        {
            get { return (Visibility)GetValue(SmallDiamondVisibilityProperty); }
            set { SetValue(SmallDiamondVisibilityProperty, value); }
        }



        public CardVisual()
        {
            InitializeComponent();
            //BackVisibility = Visibility.Collapsed;
        }

        private void CardClicked(object sender, RoutedEventArgs e)
        {
            VibrateController.Default.Start(TimeSpan.FromMilliseconds(5));

            if (OnClick != null)
            {
                OnClick(this, e);
            }
        }
        public event EventHandler OnClick;
    }
}
