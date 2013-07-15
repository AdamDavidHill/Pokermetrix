using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokermetrix
{
    public static class HandRankFactory
    {
        public static ObservableCollection<HandRank> HandRanks()
        {
            ObservableCollection<HandRank> result = new ObservableCollection<HandRank>();

            result.Add(new HandRank() { RankIndex = 0, LineOne = "Royal Flush", LineTwo = "A, K, Q, J, 10 with matching suits", LineThree = "" });
            result.Add(new HandRank() { RankIndex = 1, LineOne = "Straight Flush", LineTwo = "5 consecutive cards of matching suits", LineThree = "Ace can only be low" });
            result.Add(new HandRank() { RankIndex = 2, LineOne = "Four of a Kind", LineTwo = "4 cards of matching denominations", LineThree = "" });
            result.Add(new HandRank() { RankIndex = 3, LineOne = "Full House", LineTwo = "3 cards of matching denomination and 2 of another matching denomination", LineThree = "" });
            result.Add(new HandRank() { RankIndex = 4, LineOne = "Flush", LineTwo = "5 cards of matching suit", LineThree = "" });
            result.Add(new HandRank() { RankIndex = 5, LineOne = "Straight", LineTwo = "5 consecutive cards of mixed suits", LineThree = "Ace can be high or low" });
            result.Add(new HandRank() { RankIndex = 6, LineOne = "Three of a Kind", LineTwo = "3 cards of matching denomination", LineThree = "" });
            result.Add(new HandRank() { RankIndex = 7, LineOne = "Two Pair", LineTwo = "2 cards of matching denomination plus 2 other cards of a different matching denomination", LineThree = "" });
            result.Add(new HandRank() { RankIndex = 8, LineOne = "Pair", LineTwo = "2 cards of matching denomination", LineThree = "" });
            result.Add(new HandRank() { RankIndex = 9, LineOne = "High Card", LineTwo = "The highest of 5 cards", LineThree = "" });

            return result;
        }
    }
}
