using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace PokermetrixWP7
{
    public static class PositionUtil
    {
        public static int Cap(int positionIndex, int players)
        {
            return positionIndex > players - 1 ? players - 1 : positionIndex;
        }

        public static int Wrap(int positionIndex, int players)
        {
            int result = positionIndex > players - 1 ? 0 : positionIndex;
            return positionIndex < 0 ? players - 1 : result;
        }
    }
}
