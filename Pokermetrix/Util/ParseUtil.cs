using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokermetrix
{
    public static class ParseUtil
    {
        public static double? ToNullableNumber(string text)
        {
            double result;
            try
            {
                result = Convert.ToDouble(text);
                return result;
            }
            catch
            {
                return null;
            }
        }
    }
}
