using System.IO;
using System.Text;

namespace GaCloudServer.Resources.Api.Report.ReclamiRegistro
{
    public static class ReclamiRegistroTemplateGenerator
    {
        public static string GetHTMLString(string anno,string table_content)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Report/ReclamiRegistro/assets/", "template.html");
            var fileContent = @File.ReadAllText(filePath);
            var sb = new StringBuilder();

            sb.AppendFormat(@fileContent, anno,table_content);
            return sb.ToString();
        }
    }
}
