using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wingine
{
    public static class ClassExtensions
    {
        public static string GetStringForMaxLength(this string str, float maxLength, Graphics g, Font font, out string resultant)
        {
            string ep = "";
            int index = 0;

            while (!string.IsNullOrEmpty(str) && g.MeasureString(ep, font).Width < maxLength && index < str.Length)
            {
                if(index < str.Length - 1 && g.MeasureString(ep + str[index + 1].ToString(), font).Width > maxLength)
                {
                    break;
                }

                ep += str[index].ToString();

                index++;
            }

            resultant = str.Remove(0, ep.Length);
            return ep;
        }
    }
}
