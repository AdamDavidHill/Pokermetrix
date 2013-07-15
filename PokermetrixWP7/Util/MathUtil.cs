using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokermetrixWP7.Util
{
    public static class MathUtil
    {
        public static byte IntLimitToByte(int i)
        {
            if (i > 255) i = 255;
            if (i < 0) i = 0;
            return (byte)i;
        }
    }
}
