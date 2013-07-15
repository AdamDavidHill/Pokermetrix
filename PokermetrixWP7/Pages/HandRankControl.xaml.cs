using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Collections.ObjectModel;

namespace PokermetrixWP7
{
    public partial class HandRankControl : UserControl
    {
        public ObservableCollection<HandRank> HandRanks { get; set; }

        public HandRankControl()
        {
            InitializeComponent();

            HandRanks = HandRankFactory.HandRanks();
        }
    }
}
