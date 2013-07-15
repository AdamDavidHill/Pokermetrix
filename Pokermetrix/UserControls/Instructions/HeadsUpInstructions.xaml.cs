using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.ComponentModel;

namespace Pokermetrix
{
    public partial class HeadsUpInstructions : UserControl
    {
        public HeadsUpInstructions()
        {
            InitializeComponent();
            this.IsHitTestVisible = false;
        }

        public void OnBackKeyPress(CancelEventArgs e)
        {
            if (this.IsHitTestVisible)
            {
                FadeOut();
                e.Cancel = true;
            }
        }

        public void Show()
        {
            FadeIn();
        }

        private void FadeIn()
        {
            if (!this.IsHitTestVisible)
            {
                fadeIn.Begin();
                this.IsHitTestVisible = true;
            }
        }

        private void FadeOut()
        {
            if (this.IsHitTestVisible)
            {
                this.IsHitTestVisible = false;
                fadeOut.Begin();
            }
        }
    }
}
