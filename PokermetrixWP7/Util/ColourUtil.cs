using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace PokermetrixWP7.Util
{
    public static class ColourUtil
    {
        public static Color ColorFromHex(string s)
        {
            byte a = System.Convert.ToByte(s.Substring(0, 2), 16);
            byte r = System.Convert.ToByte(s.Substring(2, 2), 16);
            byte g = System.Convert.ToByte(s.Substring(4, 2), 16);
            byte b = System.Convert.ToByte(s.Substring(6, 2), 16);
            return Color.FromArgb(a, r, g, b);
        }

        static char[] hexCodes = {'0', '1', '2', '3', '4', '5', '6', '7',
                                  '8', '9', 'A', 'B', 'C', 'D', 'E', 'F'};

        public static string ColorToARGBHex(Color color)
        {
            byte[] argbBytes = new byte[4];
            argbBytes[0] = color.A;
            argbBytes[1] = color.R;
            argbBytes[2] = color.G;
            argbBytes[3] = color.B;
            char[] chars = new char[argbBytes.Length * 2];
            for (int i = 0; i < argbBytes.Length; i++)
            {
                int intCode = argbBytes[i];
                chars[i * 2] = hexCodes[intCode >> 4];
                chars[i * 2 + 1] = hexCodes[intCode & 0xF];
            }
            return new string(chars);
        }

        public static string ColorToRGBHex(Color color)
        {
            byte[] rgbBytes = new byte[3];
            rgbBytes[0] = color.R;
            rgbBytes[1] = color.G;
            rgbBytes[2] = color.B;
            char[] chars = new char[rgbBytes.Length * 2];
            for (int i = 0; i < rgbBytes.Length; i++)
            {
                int intCode = rgbBytes[i];
                chars[i * 2] = hexCodes[intCode >> 4];
                chars[i * 2 + 1] = hexCodes[intCode & 0xF];
            }
            return new string(chars);
        }

        public static LinearGradientBrush LinearGradientBrushFromHexStrings(string HexString1, string HexString2, double Angle)
        {
            LinearGradientBrush b;
            GradientStopCollection gc;
            GradientStop g1;
            GradientStop g2;

            g1 = new GradientStop();
            g1.Color = ColorFromHex(HexString1);
            g1.Offset = 0.0;

            g2 = new GradientStop();
            g2.Color = ColorFromHex(HexString2);
            g2.Offset = 1.0;

            gc = new GradientStopCollection();
            gc.Add(g1);
            gc.Add(g2);

            b = new LinearGradientBrush(gc, Angle);

            return b;
        }

        public static LinearGradientBrush LinearGradientBrushFromARGB(
            double Angle, int A1, int R1, int G1, int B1, int A2, int R2, int G2, int B2)
        {
            LinearGradientBrush b;
            GradientStopCollection gc;
            GradientStop g1;
            GradientStop g2;

            g1 = new GradientStop();
            g1.Color = Color.FromArgb(MathUtil.IntLimitToByte(A1), MathUtil.IntLimitToByte(R1), MathUtil.IntLimitToByte(G1), MathUtil.IntLimitToByte(B1));
            g1.Offset = 0.0;

            g2 = new GradientStop();
            g2.Color = Color.FromArgb(MathUtil.IntLimitToByte(A2), MathUtil.IntLimitToByte(R2), MathUtil.IntLimitToByte(G2), MathUtil.IntLimitToByte(B2));
            g2.Offset = 1.0;

            gc = new GradientStopCollection();
            gc.Add(g1);
            gc.Add(g2);

            b = new LinearGradientBrush(gc, Angle);

            return b;
        }

        public static Color GradientStopColour(int GradientStop, LinearGradientBrush GradBrush)
        {
            Color c = GradBrush.GradientStops[GradientStop].Color;
            return c;
        }

        public enum KnownColors : uint
        {
            AliceBlue = 0xFFF0F8FF, AntiqueWhite = 0xFFFAEBD7, Aqua = 0xFF00FFFF,
            Aquamarine = 0xFF7FFFD4, Azure = 0xFFF0FFFF, Beige = 0xFFF5F5DC,
            Bisque = 0xFFFFE4C4, Black = 0xFF000000, BlanchedAlmond = 0xFFFFEBCD,
            Blue = 0xFF0000FF, BlueViolet = 0xFF8A2BE2, Brown = 0xFFA52A2A,
            BurlyWood = 0xFFDEB887, CadetBlue = 0xFF5F9EA0, Chartreuse = 0xFF7FFF00,
            Chocolate = 0xFFD2691E, Coral = 0xFFFF7F50, CornflowerBlue = 0xFF6495ED,
            Cornsilk = 0xFFFFF8DC, Crimson = 0xFFDC143C, Cyan = 0xFF00FFFF,
            DarkBlue = 0xFF00008B, DarkCyan = 0xFF008B8B, DarkGoldenrod = 0xFFB8860B,
            DarkGray = 0xFFA9A9A9, DarkGreen = 0xFF006400, DarkKhaki = 0xFFBDB76B,
            DarkMagenta = 0xFF8B008B, DarkOliveGreen = 0xFF556B2F, DarkOrange = 0xFFFF8C00,
            DarkOrchid = 0xFF9932CC, DarkRed = 0xFF8B0000, DarkSalmon = 0xFFE9967A,
            DarkSeaGreen = 0xFF8FBC8F, DarkSlateBlue = 0xFF483D8B, DarkSlateGray = 0xFF2F4F4F,
            LightSalmon = 0xFFFFA07A, LightSeaGreen = 0xFF20B2AA, LightSkyBlue = 0xFF87CEFA,
            LightSlateGray = 0xFF778899, LightSteelBlue = 0xFFB0C4DE, LightYellow = 0xFFFFFFE0,
            Lime = 0xFF00FF00, LimeGreen = 0xFF32CD32, Linen = 0xFFFAF0E6,
            Magenta = 0xFFFF00FF, Maroon = 0xFF800000, MediumAquamarine = 0xFF66CDAA,
            MediumBlue = 0xFF0000CD, MediumOrchid = 0xFFBA55D3, MediumPurple = 0xFF9370DB,
            MediumSeaGreen = 0xFF3CB371, MediumSlateBlue = 0xFF7B68EE, MediumSpringGreen = 0xFF00FA9A,
            MediumTurquoise = 0xFF48D1CC, MediumVioletRed = 0xFFC71585, MidnightBlue = 0xFF191970,
            MintCream = 0xFFF5FFFA, MistyRose = 0xFFFFE4E1, Moccasin = 0xFFFFE4B5,
            NavajoWhite = 0xFFFFDEAD, Navy = 0xFF000080, OldLace = 0xFFFDF5E6,
            Olive = 0xFF808000, OliveDrab = 0xFF6B8E23, Orange = 0xFFFFA500,
            OrangeRed = 0xFFFF4500, Orchid = 0xFFDA70D6, PaleGoldenrod = 0xFFEEE8AA,
            PaleGreen = 0xFF98FB98, PaleTurquoise = 0xFFAFEEEE, PaleVioletRed = 0xFFDB7093,
            PapayaWhip = 0xFFFFEFD5, PeachPuff = 0xFFFFDAB9, Peru = 0xFFCD853F,
            Pink = 0xFFFFC0CB, Plum = 0xFFDDA0DD, PowderBlue = 0xFFB0E0E6,
            Purple = 0xFF800080, Red = 0xFFFF0000, RosyBrown = 0xFFBC8F8F,
            RoyalBlue = 0xFF4169E1, SaddleBrown = 0xFF8B4513, Salmon = 0xFFFA8072,
            SandyBrown = 0xFFF4A460, SeaGreen = 0xFF2E8B57, SeaShell = 0xFFFFF5EE,
            Sienna = 0xFFA0522D, Silver = 0xFFC0C0C0, SkyBlue = 0xFF87CEEB,
            SlateBlue = 0xFF6A5ACD, SlateGray = 0xFF708090, Snow = 0xFFFFFAFA,
            SpringGreen = 0xFF00FF7F, SteelBlue = 0xFF4682B4, Tan = 0xFFD2B48C,
            Teal = 0xFF008080, Thistle = 0xFFD8BFD8, Tomato = 0xFFFF6347,
            Transparent = 0x00FFFFFF, Turquoise = 0xFF40E0D0, Violet = 0xFFEE82EE,
            Wheat = 0xFFF5DEB3, White = 0xFFFFFFFF, WhiteSmoke = 0xFFF5F5F5,
            Yellow = 0xFFFFFF00, YellowGreen = 0xFF9ACD32
        }

        public static T StringToEnum<T>(string value, T defaultValue)
        {
            T enumValue = (Enum.IsDefined(typeof(T), value)) ? (T)Enum.Parse(typeof(T), value, true) : defaultValue;
            return enumValue;
        }

        public static Color FromColorName(string rgbColor)
        {
            uint color = (uint)StringToEnum(rgbColor, KnownColors.Black);
            return Color.FromArgb((byte)(color >> 24),
                                      (byte)(color >> 16),
                                      (byte)(color >> 8),
                                      (byte)color);
        }
    }
}
