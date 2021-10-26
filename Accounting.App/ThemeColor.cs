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
            "#004E71",
            "#0170A2",
            "#0186C2",
            "#012443",
            "#7C83FD",
            "#131518",
           
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
