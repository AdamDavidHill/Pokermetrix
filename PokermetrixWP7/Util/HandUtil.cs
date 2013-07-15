using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace PokermetrixWP7
{
    public static class HandUtil
    {
        public static Hand HandFromCards(Card cardA, Card cardB, bool suited)
        {
            Card minCard = (Card)Math.Min((int)cardA, (int)cardB); 
            Card maxCard = (Card)Math.Max((int)cardA, (int)cardB);
            string minCardString = CardAsSingleCharacter(minCard);
            string maxCardString = CardAsSingleCharacter(maxCard);
            string suitedString = suited && minCardString != maxCardString ? "s" : string.Empty;
            string cardString = "x" + maxCardString + minCardString + suitedString;
            return (Hand)Enum.Parse(typeof(Hand), cardString, true);
        }

        public static string CardAsSingleCharacter(Card card)
        {
            switch (card)
            {
                case Card.Two:
                    return "2";
                case Card.Three:
                    return "3";
                case Card.Four:
                    return "4";
                case Card.Five:
                    return "5";
                case Card.Six:
                    return "6";
                case Card.Seven:
                    return "7";
                case Card.Eight:
                    return "8";
                case Card.Nine:
                    return "9";
                case Card.Ten:
                    return "T";
                case Card.Jack:
                    return "J";
                case Card.Queen:
                    return "Q";
                case Card.King:
                    return "K";
                case Card.Ace:
                    return "A";
                default:
                    throw new ArgumentException("Card not recognised");
            }
        }

        public static string CardAsBackgroundString(Card card)
        {
            return card == Card.Ten ? "10" : CardAsSingleCharacter(card);
        }
    }
}
