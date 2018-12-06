using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFLogin
{
    class Helper
    {
        public static string GetNewMac()
        {
            Random r = new Random();
            string result = string.Empty;
            string[] mac = "EC:F4:BB:19:01:52".Split(':');

            for (int i = 0; i < mac.Length; i++)
            {

                short item = short.Parse(r.Next(0, 256).ToString(), System.Globalization.NumberStyles.HexNumber);
                short itemNext = short.Parse(r.Next(0, 256).ToString(), System.Globalization.NumberStyles.HexNumber);
                if (item == 0)
                {
                    item &= itemNext;
                }
                else
                {
                    item ^= itemNext;// (short)(itemNext >> 1);  
                }
                mac[i] = item.ToString("x8").Substring(6, 2);
            }
            for (int i = 0; i < mac.Length; i++)
            {
                if (i == mac.Length - 1)
                {
                    result += mac[i];
                    continue;
                }
                result += mac[i];
                result += ":";
            }
            return result.ToUpper();
        }
    }
}
