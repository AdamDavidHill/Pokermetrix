using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using System;
using System.Windows;
using System.Windows.Controls;

namespace PokermetrixWP7
{
    public partial class About : UserControl
    {
        public About()
        {
            InitializeComponent();
        }

        private void EmailButton_Click(object sender, RoutedEventArgs e)
        {
            EmailComposeTask emailComposeTask = new EmailComposeTask();
            emailComposeTask.To = "poweredby@dootrix.com";
            emailComposeTask.Subject = "Pokermetrix Feedback";
            emailComposeTask.Show();
        }

        private void ReviewButton_Click(object sender, RoutedEventArgs e)
        {
            MarketplaceReviewTask marketplaceReviewTask = new MarketplaceReviewTask();
            marketplaceReviewTask.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WebBrowserTask webBrowserTask = new WebBrowserTask();
            webBrowserTask.Uri = new Uri("http://dootrix.com?src=pokermetrix");
            webBrowserTask.Show();
        }

        private void LiveModeButton_OnClick(object sender, EventArgs e)
        {
            // Prevents app turning off due to inactivity - undesirable during a game
            PhoneApplicationService.Current.UserIdleDetectionMode = LiveModeButton.IsChecked ? IdleDetectionMode.Disabled : IdleDetectionMode.Enabled;
            LiveModeText.Text = LiveModeButton.IsChecked ? "LIVE mode is ON" : "LIVE mode is OFF";
        }
    }
}
