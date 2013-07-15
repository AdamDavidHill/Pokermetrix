using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Devices;

namespace PokermetrixWP7
{
    public partial class AddRemovePlayerButton : UserControl
    {
        // Plus Visibility
        public static readonly DependencyProperty PlusVisibilityProperty = DependencyProperty.Register(
            "PlusVisibility",
            typeof(Visibility),
            typeof(AddRemovePlayerButton),
            new PropertyMetadata(Visibility.Collapsed));

        public Visibility PlusVisibility
        {
            get { return (Visibility)GetValue(PlusVisibilityProperty); }
            set { SetValue(PlusVisibilityProperty, value); }
        }

        // Minus Visibility
        public static readonly DependencyProperty MinusVisibilityProperty = DependencyProperty.Register(
            "MinusVisibility",
            typeof(Visibility),
            typeof(AddRemovePlayerButton),
            new PropertyMetadata(Visibility.Collapsed));

        public Visibility MinusVisibility
        {
            get { return (Visibility)GetValue(MinusVisibilityProperty); }
            set { SetValue(MinusVisibilityProperty, value); }
        }

        public AddRemovePlayerButton()
        {
            InitializeComponent();
        }

        private void ButtonClicked(object sender, RoutedEventArgs e)
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
