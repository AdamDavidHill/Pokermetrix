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
    public partial class PositionPicker : UserControl
    {
        public event EventHandler OnPositionSelected;
        public int SelectedPosition { get; set; }

        int btnWidth = 140;
        int btnHeight = 110;

        public PositionPicker()
        {
            InitializeComponent();
            SelectedPosition = 0;
        }

        public void Show(int players)
        {
            leftStackPanel.Children.Clear();
            rightStackPanel.Children.Clear();
            int halfPlayersRoundedDown = (int)Math.Floor(players / 2.0);
            for (int i = 0; i < halfPlayersRoundedDown; i++)
            {
                leftStackPanel.Children.Add(CreateButton(players, i));
            }

            for (int i = halfPlayersRoundedDown; i < players; i++)
            {
                rightStackPanel.Children.Add(CreateButton(players, i));
            }
        }

        Button CreateButton(int players, int index)
        {
            Button b = new Button
            {
                Width = btnWidth,
                Height = btnHeight,
                Tag = index,
                Content = GetButtonLabel(players, index)
            };
            b.Click += Button_Click;

            return b;
        }

        private static string GetButtonLabel(int players, int index)
        {
            if (index == 0)
            {
                return players == 2 ? "BB" : "SB";
            }

            string label = (index + 1).ToString();
            if (index == 1)
            {
                label = players == 2 ? "SB/D" : "BB";
            }
            else if (index == players - 1)
            {
                label = "D";
            }

            return label;
        }

        void Button_Click(object sender, RoutedEventArgs e)
        {
            SelectedPosition = (int)(sender as Button).Tag;
            if (OnPositionSelected != null)
            {
                OnPositionSelected(this, new EventArgs());
            }
        }
    }
}

