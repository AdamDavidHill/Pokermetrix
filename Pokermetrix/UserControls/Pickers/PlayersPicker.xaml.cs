using System;
using System.Collections.Generic;
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
    public partial class PlayersPicker : UserControl
    {
        public event EventHandler OnPlayersSelected;
        public int SelectedPlayers { get; set; }

        public PlayersPicker()
        {
            InitializeComponent();
            SelectedPlayers = 0;
        }

        void Button_Click(object sender, RoutedEventArgs e)
        {
            SelectedPlayers = Int32.Parse((sender as Button).Content.ToString());
            if (OnPlayersSelected != null)
            {
                OnPlayersSelected(this, new EventArgs());
            }
        }
    }
}

