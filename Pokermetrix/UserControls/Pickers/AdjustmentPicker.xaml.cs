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

namespace Pokermetrix
{
    public partial class AdjustmentPicker : UserControl
    {
        public event EventHandler OnAdjustmentDone;

        public AdjustmentPicker()
        {
            InitializeComponent();
            this.Visibility = Visibility.Visible;
            this.IsHitTestVisible = false;

            adjustmentTextBox.GotFocus += (s, e) =>
            {
                AutoSelectText(s);
            };
        }

        public string Adjustment { get; set; }

        public void Show(string titleText)
        {
            title.Text = titleText;
            FadeIn();
            adjustmentTextBox.Focus();
        }

        public void HandleHardwareBackButtonPress(CancelEventArgs e)
        {
            if (this.IsHitTestVisible)
            {
                FadeOut();
                e.Cancel = true;
            }
        }

        private void AutoSelectText(object sender)
        {
            TextBox target = sender as TextBox;
            target.Select(0, target.Text.Length);
        }

        private void RaiseAdjustmentDone()
        {
            if (OnAdjustmentDone != null)
            {
                OnAdjustmentDone(this, new EventArgs());
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Adjustment = adjustmentTextBox.Text;
            FadeOut();
            RaiseAdjustmentDone();
        }
    }
}

