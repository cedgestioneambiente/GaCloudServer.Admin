using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GaCloudServer.BusinnessLogic.Helpers
{
    public static class ODataFilterConverter
    {
        public static string ConvertToDynamicLinq(string odataFilter)
        {
            if (string.IsNullOrWhiteSpace(odataFilter))
                return string.Empty;

            string result = odataFilter;

            // Operator replacements
            result = Regex.Replace(result, @"\beq\b", "==", RegexOptions.IgnoreCase);
            result = Regex.Replace(result, @"\bne\b", "!=", RegexOptions.IgnoreCase);
            result = Regex.Replace(result, @"\band\b", "&&", RegexOptions.IgnoreCase);
            result = Regex.Replace(result, @"\bor\b", "||", RegexOptions.IgnoreCase);

            // contains(field,'value') -> field != null && field.ToLower().Contains("value".ToLower())
            result = Regex.Replace(result, @"contains\((\w+),\s*'([^']*)'\)",
                m => $"{m.Groups[1].Value} != null && {m.Groups[1].Value}.ToLower().Contains(\"{m.Groups[2].Value.ToLower()}\")",
                RegexOptions.IgnoreCase);

            return result;
        }
    }

}
