using System.Collections.Generic;

namespace GaCloudServer.Jobs.Helpers
{
    public static class HtmlHelpers
    {
        public static string GenerateTable(List<string> columnHeader, List<List<string>> rows)
        {
            var table = "";
            table += "<table style='width:100%,border:1px solid #666'>" +
                "<thead style='text-align:left'>" +
                    "<tr style='border-bottom:solid 1px #666'>";
            foreach (var column in columnHeader)
            {
                table += "<th style='padding:10px;text-align:left;border-bottom:solid 1px #666'>" + column+"</th>";
            }

            table += "</tr>" +
                "</thead>" +
                "<tbody>";

            foreach (var row in rows)
            {
                table += "<tr>";
                foreach (var value in row)
                {
                    table+= "<td style='padding:10px;border-bottom:solid 1px #666'>" + value + "</td>";
                }
                table += "</tr>";
            }

            table += "</tbody>" +
                "</table>";

            return table;


        }
    }
}
