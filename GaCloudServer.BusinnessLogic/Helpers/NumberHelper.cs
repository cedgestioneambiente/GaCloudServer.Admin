using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        public static string CurrencyFormatter(string inputNumber)
        {
            // Convertire la stringa in decimale
            decimal number = decimal.Parse(inputNumber, new CultureInfo("it-IT"));

            // Separare la parte intera e quella decimale
            string[] parts = number.ToString("N2", new CultureInfo("it-IT")).Split(',');

            // Formattare la parte intera con i separatori di migliaia
            string integerPart = parts[0];
            string formattedIntegerPart = String.Format(CultureInfo.InvariantCulture, "{0:N0}", Int64.Parse(integerPart.Replace(".", "")));

            // Formattare la parte decimale per avere sempre due cifre
            string decimalPart = parts[1];
            if (decimalPart.Length < 2)
            {
                decimalPart = decimalPart.PadRight(2, '0');
            }

            // Unire le parti formattate
            return  $"{formattedIntegerPart},{decimalPart} €";
        }

        public static string ConvertToCurrencyString(double value)
        {
            CultureInfo culture = new CultureInfo("it-IT");
            culture.NumberFormat.CurrencySymbol = "€";
            return value.ToString("C2", culture);
        }
    }
}
