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

namespace Pokermetrix
{
    public partial class HideShowButton : UserControl
    {
        // Hide Visibility
        public static readonly DependencyProperty HideVisibilityProperty = DependencyProperty.Register(
            "HideVisibility",
            typeof(Visibility),
            typeof(HideShowButton),
            new PropertyMetadata(Visibility.Visible));

        public Visibility HideVisibility
        {
            get { return (Visibility)GetValue(HideVisibilityProperty); }
            set { SetValue(HideVisibilityProperty, value); }
        }

        // Show Visibility
        public static readonly DependencyProperty ShowVisibilityProperty = DependencyProperty.Register(
            "ShowVisibility",
            typeof(Visibility),
            typeof(HideShowButton),
            new PropertyMetadata(Visibility.Visible));

        public Visibility ShowVisibility
        {
            get { return (Visibility)GetValue(ShowVisibilityProperty); }
            set { SetValue(ShowVisibilityProperty, value); }
        }

        public HideShowButton()
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
