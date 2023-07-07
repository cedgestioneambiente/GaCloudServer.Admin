using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GaCloudServer.Resources.Api.Report.EcSegnalazioni
{
    public static class EcSegnalazioniTemplateGenerator
    {
        public static string GetHTMLString(string header,string table)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Report/EcSegnalazioni/assets/", "template.html");
            var fileContent = @File.ReadAllText(filePath);
            var sb = new StringBuilder();

            sb.AppendFormat(@fileContent,header,table);
            return sb.ToString();
        }
    }
}
