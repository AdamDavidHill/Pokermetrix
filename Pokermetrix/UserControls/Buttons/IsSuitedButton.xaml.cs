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
    public partial class IsSuitedButton : UserControl
    {
        public bool IsChecked { get; set; }

        // Check Visibility
        public static readonly DependencyProperty CheckVisibilityProperty = DependencyProperty.Register(
            "CheckVisibility",
            typeof(Visibility),
            typeof(IsSuitedButton),
            new PropertyMetadata(Visibility.Collapsed));

        public Visibility CheckVisibility
        {
            get { return (Visibility)GetValue(CheckVisibilityProperty); }
            set { SetValue(CheckVisibilityProperty, value); }
        }

        // Cross Visibility
        public static readonly DependencyProperty CrossVisibilityProperty = DependencyProperty.Register(
            "CrossVisibility",
            typeof(Visibility),
            typeof(IsSuitedButton),
            new PropertyMetadata(Visibility.Visible));

        public Visibility CrossVisibility
        {
            get { return (Visibility)GetValue(CrossVisibilityProperty); }
            set { SetValue(CrossVisibilityProperty, value); }
        }

        public IsSuitedButton()
        {
            InitializeComponent();
            IsChecked = false;
        }

        private void ButtonClicked(object sender, RoutedEventArgs e)
        {
            IsChecked = !IsChecked;
            Refresh();
            VibrateController.Default.Start(TimeSpan.FromMilliseconds(5));

            if (OnClick != null)
            {
                OnClick(this, e);
            }
        }
        public event EventHandler OnClick;

        public void Refresh()
        {
            CheckVisibility = IsChecked ? Visibility.Visible : Visibility.Collapsed;
            CrossVisibility = IsChecked ? Visibility.Collapsed : Visibility.Visible;
        }
    }
}
