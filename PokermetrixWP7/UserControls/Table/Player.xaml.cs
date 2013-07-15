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
using System.ComponentModel;

namespace PokermetrixWP7
{
    public partial class Player : UserControl
    {
        // Selected Visibility
        public static readonly DependencyProperty SelectedVisibilityProperty = DependencyProperty.Register(
            "SelectedVisibility",
            typeof(Visibility),
            typeof(Player),
            new PropertyMetadata(Visibility.Collapsed));

        public Visibility SelectedVisibility
        {
            get { return (Visibility)GetValue(SelectedVisibilityProperty); }
            set { SetValue(SelectedVisibilityProperty, value); }
        }

        // Unselected Visibility
        public static readonly DependencyProperty UnselectedVisibilityProperty = DependencyProperty.Register(
            "UnselectedVisibility",
            typeof(Visibility),
            typeof(Player),
            new PropertyMetadata(Visibility.Visible));

        public Visibility UnselectedVisibility
        {
            get { return (Visibility)GetValue(UnselectedVisibilityProperty); }
            set { SetValue(UnselectedVisibilityProperty, value); }
        }

        public Player()
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
