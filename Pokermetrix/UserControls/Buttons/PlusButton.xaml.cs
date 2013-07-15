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
    public partial class PlusButton : UserControl
    {

        public PlusButton()
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
