namespace GaCloudServer.Resources.Api.Helpers
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
                table += "<th style='padding:10px;text-align:left;border-bottom:solid 1px #666'>" + column + "</th>";
            }

            table += "</tr>" +
                "</thead>" +
                "<tbody>";

            foreach (var row in rows)
            {
                table += "<tr>";
                foreach (var value in row)
                {
                    table += "<td style='padding:10px;border-bottom:solid 1px #666'>" + value + "</td>";
                }
                table += "</tr>";
            }

            table += "</tbody>" +
                "</table>";

            return table;


        }

        public static string GenerateList(List<string> descriptors, List<string> details)
        {
            var list = "<div style='width:100%'>";
            for (int i = 0; i < descriptors.Count; i++)
            {
                list += "<p style='margin: 0; font-size: 14px; line-height: 18px'>" + descriptors.ElementAt(i) + " : " + details.ElementAt(i) + "</p>";
            }

            list += "</div>";
            return list;

        }

        public static string GenerateText(string content)
        {
            var text = "<div style='width:100%'>";
            text += "<p style='margin: 0; font-size: 14px; line-height: 18px'>" + content + "</p>";

            text += "</div>";
            return text;

        }

        public static string GenerateTextAndButton(string content,string buttonLink)
        {
            var text = "<div style='width:100%'>";
            text += "<p style='margin: 0; font-size: 14px; line-height: 18px'>" + content + "</p>";


            text += "</div>";
            return text;

        }
    }
}
