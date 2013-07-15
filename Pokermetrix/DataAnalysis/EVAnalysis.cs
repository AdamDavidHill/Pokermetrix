using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokermetrix
{
    public static class EVAnalysis
    {
        const double totalHands = 169;

        static List<double> evCategoryValues = new List<double> { -0.5, -0.4, -0.3, -0.2, -0.1, 0, 0.1, 0.2, 0.3, 0.4, 0.5 };
        static double lastEVCategory = evCategoryValues[evCategoryValues.Count - 1];
        static double evCategoryDelta = 0.1;

        public static double CalculateExpectedValue(Card cardA, Card cardB, bool isSuited, int players, int positionIndex)
        {
            Hand hand = HandUtil.HandFromCards(cardA, cardB, isSuited);
            int queryPositionIndex = positionIndex;

            if(players == 2)
            {
                // Heads up data positions are back to front, correct and hide this from application
                positionIndex = 1 - positionIndex;
            }

            return EVData.Data[players][(int)hand][positionIndex];
        }

        public static string CalculateStrength(double expectedValue)
        {
            if (expectedValue < 0)
            {
                return "Fold";
            }
            else if (expectedValue > 0)
            {
                return "Play";
            }
            else if (expectedValue == 0)
            {
                return "Neutral Cards";
            }


            // Old, now redundant
            if (expectedValue < -0.1)
            {
                return "Bad";
            }
            else if (expectedValue < 0)
            {
                return "Weak";
            }
            else if (expectedValue == 0)
            {
                return "Neutral";
            }
            else if (expectedValue < 0.1)
            {
                return "Just playable";
            }
            else if (expectedValue < 0.5)
            {
                return "Playable";
            }
            else
            {
                return "Strong";
            }
        }

        public static List<double> CalculcateChartDataSinglePosition(int players, int positionIndex)
        {
            List<double> handCounts = new List<double>();

            foreach (double evCategory in evCategoryValues)
            {
                int handCount = 0;
                for (int hand = 0; hand < totalHands; hand++)
                {
                    double ev = EVData.Data[players][hand][positionIndex];
                    if (ev > evCategory && ev < evCategoryDelta + evCategory)
                    {
                        handCount++;
                    }
                    else if (ev == lastEVCategory && ev > evCategory)
                    {
                        handCount++;
                    }
                }

                handCounts.Add(handCount);
            }

            return handCounts;
        }

        public static List<double> CalculcateChartDataAllPositions(int players)
        {
            List<double> handCounts = new List<double>();

            foreach (double evCategory in evCategoryValues)
            {
                int handCount = 0;
                for (int positionIndex = 0; positionIndex < players - 1; positionIndex++)
                {
                    for (int hand = 0; hand < totalHands; hand++)
                    {
                        double ev = EVData.Data[players][hand][positionIndex];
                        if (ev > evCategory && ev < evCategoryDelta + evCategory)
                        {
                            handCount++;
                        }
                        else if (ev == lastEVCategory && ev > evCategory)
                        {
                            handCount++;
                        }
                    }
                }

                handCounts.Add(handCount);
            }

            return handCounts;
        }

        // Reference method
        static void LoopAllValues()
        {
            double lowest = 0;
            double highest = 0;

            for (int players = 2; players < 11; players++)
            {
                for (int hand = 0; hand < totalHands; hand++)
                {
                    for (int position = 0; position < players - 1; position++)
                    {
                        lowest = Math.Min(EVData.Data[players][hand][position], lowest);
                        highest = Math.Max(EVData.Data[players][hand][position], highest);
                    }
                }
            }

            double h = highest; // 2.89
            double l = lowest; // 0.43
        }
    }
}
