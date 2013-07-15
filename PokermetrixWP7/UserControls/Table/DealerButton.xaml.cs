using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace PokermetrixWP7
{
    public partial class DealerButton : UserControl
    {
        // Dealer Visibility
        public static readonly DependencyProperty DealerVisibilityProperty = DependencyProperty.Register(
            "DealerVisibility",
            typeof(Visibility),
            typeof(DealerButton),
            new PropertyMetadata(Visibility.Visible));

        public Visibility DealerVisibility
        {
            get { return (Visibility)GetValue(DealerVisibilityProperty); }
            set { SetValue(DealerVisibilityProperty, value); }
        }

        // Small Blind Visibility
        public static readonly DependencyProperty SmallBlindVisibilityProperty = DependencyProperty.Register(
            "SmallBlindVisibility",
            typeof(Visibility),
            typeof(DealerButton),
            new PropertyMetadata(Visibility.Collapsed));

        public Visibility SmallBlindVisibility
        {
            get { return (Visibility)GetValue(SmallBlindVisibilityProperty); }
            set { SetValue(SmallBlindVisibilityProperty, value); }
        }

        // Big Blind Visibility
        public static readonly DependencyProperty BigBlindVisibilityProperty = DependencyProperty.Register(
            "BigBlindVisibility",
            typeof(Visibility),
            typeof(DealerButton),
            new PropertyMetadata(Visibility.Collapsed));

        public Visibility BigBlindVisibility
        {
            get { return (Visibility)GetValue(BigBlindVisibilityProperty); }
            set { SetValue(BigBlindVisibilityProperty, value); }
        }

        // ExtraSmall Blind Visibility
        public static readonly DependencyProperty ExtraSmallBlindVisibilityProperty = DependencyProperty.Register(
            "ExtraSmallBlindVisibility",
            typeof(Visibility),
            typeof(DealerButton),
            new PropertyMetadata(Visibility.Collapsed));

        public Visibility ExtraSmallBlindVisibility
        {
            get { return (Visibility)GetValue(ExtraSmallBlindVisibilityProperty); }
            set { SetValue(ExtraSmallBlindVisibilityProperty, value); }
        }

        public DealerButton()
        {
            InitializeComponent();
        }
    }
}
