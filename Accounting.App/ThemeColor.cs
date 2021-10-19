using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.App
{
   public class ThemeColor
    {
        public static List<string> ColorList = new List<string>()
        {
            "#02A8F4",
            "#0170A2",
            "#AACFE0",
            "#0F6716",
            "#5F9963",
            "#A0669C",
            "#A0669C",
            "#D4BBD3",
            "#8D7C8C",
            "#b2beb5",
            "#ffffff",
            "#89cff0",
            "#0087ff",
            "#5fffaf",
        };
        public static Color changeColorBrightness(Color color, double correctionFactory)
        {
            double red = color.R;
            double green = color.G;
            double blue = color.B;

            if (correctionFactory < 0)
            {
                correctionFactory = 1 + correctionFactory;
                red *= correctionFactory;
                green *= correctionFactory;
                blue *= correctionFactory;

            }
            else
            {
                red = (255 - red) * correctionFactory + red;
                green = (255 - green) * correctionFactory + green;
                blue = (255 - blue) * correctionFactory + blue;
            }
            return Color.FromArgb(color.A, (byte)red, (byte)green, (byte)blue);
        }
    }
}
