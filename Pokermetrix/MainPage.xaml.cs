using Microsoft.Phone.Controls;
using System.ComponentModel;
using System.Windows;

namespace Pokermetrix
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();

            this.Loaded += (se, ev) =>
                {
                    preflopProfitabilityControl.OnCardStatusChanged += (s, e) => { headsUpControl.OtherPageChangedCards(preflopProfitabilityControl.CardA, preflopProfitabilityControl.CardB, preflopProfitabilityControl.IsSuited, preflopProfitabilityControl.HideValues); };
                    headsUpControl.OnCardStatusChanged += (s, e) => { preflopProfitabilityControl.OtherPageChangedCards(headsUpControl.CardA, headsUpControl.CardB, headsUpControl.IsSuited, headsUpControl.HideValues); };

                    headsUpControl.OnInfoClick += (s, e) => { headsUpInfo.Show(); };
                    preflopProfitabilityControl.OnInfoClick += (s, e) => { preflopProfitabilityInfo.Show(); };

                    preflopProfitabilityControl.SetCardPicker(cardPickerControl);
                    headsUpControl.SetPickers(cardPickerControlHeadsUp, adjustmentPicker);
                };

            preflopProfitabilityInfo.Visibility = Visibility.Visible;
            headsUpInfo.Visibility = Visibility.Visible;
            adjustmentPicker.Visibility = Visibility.Visible;
            cardPickerControl.Visibility = Visibility.Visible;
            cardPickerControlHeadsUp.Visibility = Visibility.Visible;

            preflopProfitabilityInfo.Opacity = 0;
            headsUpInfo.Opacity = 0;
            adjustmentPicker.Opacity = 0;
            cardPickerControl.Opacity = 0;
            cardPickerControlHeadsUp.Opacity = 0;
        }

        protected override void OnBackKeyPress(CancelEventArgs e)
        {
            base.OnBackKeyPress(e);
            preflopProfitabilityControl.OnBackKeyPress(e);
            headsUpControl.OnBackKeyPress(e);
            preflopProfitabilityInfo.OnBackKeyPress(e);
            headsUpInfo.OnBackKeyPress(e);
        }
    }
}