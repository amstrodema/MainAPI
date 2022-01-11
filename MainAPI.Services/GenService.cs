using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainAPI.Services
{
   public class GenService
    {
        public static string Gen10DigitCode()
        {
            string val = "";
            for (int i = 0; i < 10; i++)
            {
                if (i < 3)
                {
                    val += RandomCapsAlpha();
                }
                else if (i < 6)
                {
                    val += RandomDigit();
                }
                else
                {
                    val += RandomSmallAlpha();
                }
            }

            return val;
        }
        public static string Gen10CapsDigitCode()
        {
            string val = "";
            for (int i = 0; i < 10; i++)
            {
                if (i < 3)
                {
                    val += RandomCapsAlpha();
                }
                else if (i < 6)
                {
                    val += RandomDigit();
                }
                else
                {
                    val += RandomCapsAlpha();
                }
            }

            return val;
        }

        private static int RandomDigit()
        {
            Random ran = new Random();
            return ran.Next(9);
        }

        private static string RandomCapsAlpha()
        {
            Random ran = new Random();
            int index = ran.Next(0, 26);
            string alphaList = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return alphaList.ElementAt(index).ToString();
        }
        private static string RandomSmallAlpha()
        {
            Random ran = new Random();
            int index = ran.Next(0, 26);
            string alphaList = "abcdefghijklmnopqrstuvwxyz";
            return alphaList.ElementAt(index).ToString();
        }

    }
}
