using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using PokermetrixWP7.Resources;
using System.Windows;

namespace PokermetrixWP7
{
    public class SampleDataViewModel : INotifyPropertyChanged
    {
        public SampleDataViewModel()
        {
            HandRanks = new ObservableCollection<HandRank>();
            AboutItems = new ObservableCollection<HandRank>();
            TableButtons = new ObservableCollection<DealerButton>();
            TablePlayers = new ObservableCollection<Player>();
        }

        public ObservableCollection<HandRank> HandRanks { get; private set; }
        public ObservableCollection<HandRank> AboutItems { get; private set; }
        public ObservableCollection<DealerButton> TableButtons { get; private set; }
        public ObservableCollection<Player> TablePlayers { get; private set; }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        public void LoadData()
        {
            // Hand ranks
            HandRanks.Add(new HandRank() { RankIndex = 0, LineOne = "Royal Flush", LineTwo = "A, K, Q, J, 10 with matching suits", LineThree = "" });
            HandRanks.Add(new HandRank() { RankIndex = 1, LineOne = "Straight Flush", LineTwo = "5 consecutive cards of matching suits", LineThree = "Ace can only be low" });
            HandRanks.Add(new HandRank() { RankIndex = 2, LineOne = "Four of a Kind", LineTwo = "4 cards of matching denominations", LineThree = "" });
            HandRanks.Add(new HandRank() { RankIndex = 3, LineOne = "Full House", LineTwo = "3 cards of matching denomination and 2 of another matching denomination", LineThree = "" });
            HandRanks.Add(new HandRank() { RankIndex = 4, LineOne = "Flush", LineTwo = "5 cards of matching suit", LineThree = "" });
            HandRanks.Add(new HandRank() { RankIndex = 5, LineOne = "Straight", LineTwo = "5 consecutive cards of mixed suits", LineThree = "Ace can be high or low" });
            HandRanks.Add(new HandRank() { RankIndex = 6, LineOne = "Three of a Kind", LineTwo = "3 cards of matching denomination", LineThree = "" });
            HandRanks.Add(new HandRank() { RankIndex = 7, LineOne = "Two Pair", LineTwo = "2 cards of matching denomination plus 2 other cards of a different matching denomination", LineThree = "" });
            HandRanks.Add(new HandRank() { RankIndex = 8, LineOne = "Pair", LineTwo = "2 cards of matching denomination", LineThree = "" });
            HandRanks.Add(new HandRank() { RankIndex = 9, LineOne = "High Card", LineTwo = "The highest of 5 cards", LineThree = "" });

            // About Items
            AboutItems.Add(new HandRank() { RankIndex = 0, LineOne = "Royal Flush", LineTwo = "A, K, Q, J, 10 with matching suits", LineThree = "" });
            AboutItems.Add(new HandRank() { RankIndex = 1, LineOne = "Straight Flush", LineTwo = "5 consecutive cards of matching suits", LineThree = "Ace can only be low" });
            AboutItems.Add(new HandRank() { RankIndex = 2, LineOne = "Four of a Kind", LineTwo = "4 cards of matching denominations", LineThree = "" });
            AboutItems.Add(new HandRank() { RankIndex = 3, LineOne = "Full House", LineTwo = "3 cards of matching denomination and 2 of another matching denomination", LineThree = "" });
            AboutItems.Add(new HandRank() { RankIndex = 4, LineOne = "Flush", LineTwo = "5 cards of matching suit", LineThree = "" });
            AboutItems.Add(new HandRank() { RankIndex = 5, LineOne = "Straight", LineTwo = "5 consecutive cards of mixed suits", LineThree = "Ace can be high or low" });
            AboutItems.Add(new HandRank() { RankIndex = 6, LineOne = "Three of a Kind", LineTwo = "3 cards of matching denomination", LineThree = "" });
            AboutItems.Add(new HandRank() { RankIndex = 7, LineOne = "Two Pair", LineTwo = "2 cards of matching denomination plus 2 other cards of a different matching denomination", LineThree = "" });
            AboutItems.Add(new HandRank() { RankIndex = 8, LineOne = "Pair", LineTwo = "2 cards of matching denomination", LineThree = "" });
            AboutItems.Add(new HandRank() { RankIndex = 9, LineOne = "High Card", LineTwo = "The highest of 5 cards", LineThree = "" });

            // Blind buttons
            TableButtons.Add(new DealerButton() { BigBlindVisibility = Visibility.Collapsed, ExtraSmallBlindVisibility = Visibility.Collapsed, SmallBlindVisibility = Visibility.Visible, DealerVisibility = Visibility.Collapsed });
            TableButtons.Add(new DealerButton() { BigBlindVisibility = Visibility.Visible, ExtraSmallBlindVisibility = Visibility.Collapsed, SmallBlindVisibility = Visibility.Collapsed, DealerVisibility = Visibility.Collapsed });
            TableButtons.Add(new DealerButton() { BigBlindVisibility = Visibility.Collapsed, ExtraSmallBlindVisibility = Visibility.Collapsed, SmallBlindVisibility = Visibility.Collapsed, DealerVisibility = Visibility.Collapsed });
            TableButtons.Add(new DealerButton() { BigBlindVisibility = Visibility.Collapsed, ExtraSmallBlindVisibility = Visibility.Collapsed, SmallBlindVisibility = Visibility.Collapsed, DealerVisibility = Visibility.Collapsed });
            TableButtons.Add(new DealerButton() { BigBlindVisibility = Visibility.Collapsed, ExtraSmallBlindVisibility = Visibility.Collapsed, SmallBlindVisibility = Visibility.Collapsed, DealerVisibility = Visibility.Collapsed });
            TableButtons.Add(new DealerButton() { BigBlindVisibility = Visibility.Collapsed, ExtraSmallBlindVisibility = Visibility.Collapsed, SmallBlindVisibility = Visibility.Collapsed, DealerVisibility = Visibility.Collapsed });
            TableButtons.Add(new DealerButton() { BigBlindVisibility = Visibility.Collapsed, ExtraSmallBlindVisibility = Visibility.Collapsed, SmallBlindVisibility = Visibility.Collapsed, DealerVisibility = Visibility.Collapsed });
            TableButtons.Add(new DealerButton() { BigBlindVisibility = Visibility.Collapsed, ExtraSmallBlindVisibility = Visibility.Collapsed, SmallBlindVisibility = Visibility.Collapsed, DealerVisibility = Visibility.Collapsed });
            TableButtons.Add(new DealerButton() { BigBlindVisibility = Visibility.Collapsed, ExtraSmallBlindVisibility = Visibility.Collapsed, SmallBlindVisibility = Visibility.Collapsed, DealerVisibility = Visibility.Collapsed });
            TableButtons.Add(new DealerButton() { BigBlindVisibility = Visibility.Collapsed, ExtraSmallBlindVisibility = Visibility.Collapsed, SmallBlindVisibility = Visibility.Collapsed, DealerVisibility = Visibility.Visible });

            // Players
            TablePlayers.Add(new Player() { SelectedVisibility = Visibility.Collapsed, UnselectedVisibility = Visibility.Visible });
            TablePlayers.Add(new Player() { SelectedVisibility = Visibility.Collapsed, UnselectedVisibility = Visibility.Visible });
            TablePlayers.Add(new Player() { SelectedVisibility = Visibility.Collapsed, UnselectedVisibility = Visibility.Visible });
            TablePlayers.Add(new Player() { SelectedVisibility = Visibility.Collapsed, UnselectedVisibility = Visibility.Visible });
            TablePlayers.Add(new Player() { SelectedVisibility = Visibility.Collapsed, UnselectedVisibility = Visibility.Visible });
            TablePlayers.Add(new Player() { SelectedVisibility = Visibility.Visible, UnselectedVisibility = Visibility.Collapsed });
            TablePlayers.Add(new Player() { SelectedVisibility = Visibility.Collapsed, UnselectedVisibility = Visibility.Visible });
            TablePlayers.Add(new Player() { SelectedVisibility = Visibility.Collapsed, UnselectedVisibility = Visibility.Visible });
            TablePlayers.Add(new Player() { SelectedVisibility = Visibility.Collapsed, UnselectedVisibility = Visibility.Visible });
            TablePlayers.Add(new Player() { SelectedVisibility = Visibility.Collapsed, UnselectedVisibility = Visibility.Visible });

            this.IsDataLoaded = true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion /INotifyPropertyChanged
    }
}