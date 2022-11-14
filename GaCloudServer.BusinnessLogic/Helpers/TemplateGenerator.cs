using GaCloudServer.BusinnessLogic.Dtos.Template;
using System.Text;

namespace GaCloudServer.BusinnessLogic.Helpers
{
    public static class TemplateGeneratorHelper
    {
        public static string PersonaleSchedaConsegna(PersonaleSchedaConsegnaTemplateDto dto)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Template/PersonaleSchedaConsegna/assets/", "template.html");
            var fileContent = @File.ReadAllText(filePath);
            var sb = new StringBuilder();

            string table = "";
            foreach (var itm in dto.Articoli)
            {
                table += String.Format("<tr>" +
                    "<td style='border: 1px solid #000;padding:5px;'>{0}</td>" +
                    "<td style='border: 1px solid #000;padding:5px;text-align:center;'>{1}</td>" +
                    "<td style='border: 1px solid #000;padding:5px;text-align:center;'>{2}</td>" +
                    "</tr>", itm.Articolo, itm.Taglia, itm.Qta);
            }

            sb.AppendFormat(@fileContent, dto.Numero,dto.Data,dto.Preposto,dto.Lavoratore,dto.Mansioni,table);
            return sb.ToString();
        }
    }
}
