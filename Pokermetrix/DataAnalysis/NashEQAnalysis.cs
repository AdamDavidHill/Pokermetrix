﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokermetrix
{
    public static class NashEQAnalysis
    {        
        public static bool GoAllIn(Hand hand, double remainingBlinds, bool opponentIsAllIn)
        {
            double threshold = NashEQData.Data[(int)hand][opponentIsAllIn ? 1 : 0];
            return remainingBlinds < threshold;
        }
    }
}
