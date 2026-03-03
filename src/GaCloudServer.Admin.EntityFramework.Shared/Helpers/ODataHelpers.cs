using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Helpers
{
    public static class ODataHelpers
    {
        public static string ReplaceDotsOutsideQuotes(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            var sb = new StringBuilder();
            bool insideQuotes = false;

            foreach (var c in input)
            {
                if (c == '\'')
                {
                    insideQuotes = !insideQuotes;
                    sb.Append(c);
                    continue;
                }

                if (c == '.' && !insideQuotes)
                {
                    sb.Append('/');
                }
                else
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }
    }
}
