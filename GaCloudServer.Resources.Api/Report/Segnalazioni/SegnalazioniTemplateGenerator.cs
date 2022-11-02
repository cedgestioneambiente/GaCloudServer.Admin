using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GaCloudServer.Resources.Api.Report.Segnalazioni
{
    public static class SegnalazioniTemplateGenerator
    {
        public static string GetHTMLString(string header,string table)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Report/Segnalazioni/assets/", "template.html");
            var fileContent = @File.ReadAllText(filePath);
            var sb = new StringBuilder();

            sb.AppendFormat(@fileContent,header,table);
            return sb.ToString();
        }
    }
}
