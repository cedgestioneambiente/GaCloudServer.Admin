using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.BusinnessLogic.Helpers
{
    internal class NumberHelper
    {
        public static int ConvertStringToNumber(string input)
        {
            int number = 0;
            bool foundNumber = false;

            foreach (char c in input)
            {
                if (char.IsDigit(c))
                {
                    number = number * 10 + (c - '0');
                    foundNumber = true;
                }
                else if (foundNumber)
                {
                    break;
                }
            }

            return number;
        }
    }
}
