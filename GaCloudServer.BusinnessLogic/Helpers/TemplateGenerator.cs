using GaCloudServer.BusinnessLogic.Dtos.Template;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
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

        public static string ContactCenterTicketInt(ContactCenterTicketIntTemplateDto dto)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Template/ContactCenterTicketInt/assets/", "template.html");
            var fileContent = @File.ReadAllText(filePath);
            var sb = new StringBuilder();

            sb.AppendFormat(@fileContent, dto.Id, dto.DataTicket,dto.Comune,dto.Indirizzo,dto.Utente,dto.TelefonoMail,dto.TipoTicket,dto.DataStampa,dto.Richiedente,dto.Note1,dto.Note2,dto.Provenienza,
                dto.EseguitoIl,dto.Promemoria,dto.Reclamo,dto.DaFatturare,dto.Zona);
            return sb.ToString();


        }

        public static string ContactCenterTicketIng(ContactCenterTicketIngTemplateDto dto)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Template/ContactCenterTicketIng/assets/", "template.html");
            var fileContent = @File.ReadAllText(filePath);
            var sb = new StringBuilder();

            sb.AppendFormat(@fileContent, dto.Id, dto.DataTicket, dto.Comune, dto.Indirizzo, dto.Utente, dto.TelefonoMail, dto.TipoTicket, dto.DataStampa, dto.Richiedente,
                dto.Note1, dto.Note2, dto.Materiali,dto.Zona);
            return sb.ToString();


        }

        public static string ContactCenterTicketsIng(ContactCenterTicketsIngTemplateDto dto)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Template/ContactCenterTicketsIng/assets/", "template.html");
            var fileContent = @File.ReadAllText(filePath);
            var sb = new StringBuilder();

            string table = "";
            foreach (var itm in dto.Items)
            {
                table+=String.Format("" +
                    "<table class='table-dpi' style='width:97%'>" +
                    "<thead>" +
                    "<tr>" +
                    "<th style='border:1px solid #000;width:10%;'>" +
                    "N°" +
                    "</th>" +
                    "<th style='border:1px solid #000;width:40%;'>" +
                    "Utente" +
                    "</th>" +
                    "<th style='border:1px solid #000;widt:30%;'>" +
                    "Materiale" +
                    "</th>" +
                    "<th style='border:1px solid #000;width:20%;'>" +
                    "Note" +
                    "</th>" +
                    "</tr>" +
                    "</thead>" +
                    "<tbody" +
                    "<tr>" +
                    "<td style='border: 1px solid #000;padding:5px;'>{0}</td>" +
                    "<td style='border: 1px solid #000;padding:5px;'>Richiedente: {1}<br />Telefono: {2}<br />Indirizzo: {3}<br />Zona: {6}</td>" +
                    "<td style='border: 1px solid #000;padding:5px;'>{4}</td>" +
                    "<td style='border: 1px solid #000;padding:5px;'>{5}</td>" +
                    "</tr>" +
                    "</tbody>" +
                    "</table>",
                    itm.Id.ToString(), itm.Utente, itm.TelefonoMail, itm.Indirizzo, itm.Materiali, itm.Note1,itm.Zona);
            }



            sb.AppendFormat(@fileContent,dto.Comune,dto.Data,table,dto.TipoStampa);
            return sb.ToString();


        }

        public static string ContactCenterTicketsInt(ContactCenterTicketsIntTemplateDto dto)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Template/ContactCenterTicketsInt/assets/", "template.html");
            var fileContent = @File.ReadAllText(filePath);
            var sb = new StringBuilder();

            string table = "";
            foreach (var itm in dto.Items)
            {
                table += String.Format(
                        "<div class='header'>" +
                            "<div class='header-logo'>" +
                                "<img class='header-logo-img' src='http://dev.gestioneambiente.net/wwwroot/assets/logo_ga.png' />" +
                                    "</div>" +
                                    "<div class='header-title'>" +
                                        "<b>" +
                                        "REG. CCGA - 01<br />" +
                                        "Richiesta di Intervento" +
                                        "</b>" +
                                    "</div>" +
                                    "<div class='header-title-2'>" +
                                    "<b>" +
                                      "IO.SER. 04<br />" +
                                      "Edizione 2 del 16/01/2018<br />" +
                                      "Revisione 1 del 30/01/2020" +
                                    "</b>" +
                                    "</div>" +
                            "</div>" +
                            "<div class='line-1'>" +
                                "<div class='line-1-col-1'>" +
                                "Richiesta di intervento" +
                                "</div>" +
                                "<div class='line-1-col-2' style='padding-left:5px;'>" +
                                "<b> N° {0}</b>" +
                                "</div>" +
                            "</div>" +
                            "<div class='line-1'>" +
                            "<div class='line-1-col-1'>" +
                            "Data" +
                            "</div>" +
                            "<div class='line-1-col-2' style='padding-left:5px;'>" +
                            "<b> {1}</b>" +
                            "</div>" +
                            "</div>" +
                            "<div class='line-5'>" +
                            "<div class='line-5-col-1'>" +
                              "Tipo Servizio" +
                            "</div>" +
                            "<div class='line-5-col-2'>" +
                                "<b> {6}</b>" +
                            "</div>" +
                            "</div>" +
                              "<div class='content'>" +
                                  "<div class='line-6'>" +
                                    "<table style='width:97%'>" +
                                    "<thead>" +
                                    "<tr>" +
                                    "<th style='border: 1px solid #000;text-align:center;'>DA ESEGUIRE IL:</th>" +
                                    "</tr>" +
                                    "</thead>" +
                                    "<tbody>" +
                                    "<tr>" +
                                    "<td style='border: 1px solid #000;text-align:center;'><b>{7}</b></td>" +
                                    "</tr>" +
                                    "</tbody>" +
                                    "</table>" +
                                  "</div>" +
                                  "<div class='line-2'>" +
                                      "<table style='width:97%;font-size:18px;'>" +
                                          "<tbody>" +
                                              "<tr>" +
                                                  "<td style='border:1px solid #000;width:40%; text-align:left;padding-left:5px;'>" +
                                                      "Comune:" +
                                                  "</td>" +
                                                  "<td style='border:1px solid #000;padding-left:5px;'>{2}</td>" +
                                              "</tr>" +
                                              "<tr>" +
                                                  "<td style='border:1px solid #000;width:40%; text-align:left;padding-left:5px;'>" +
                                                      "Indirizzo:" +
                                                  "</td>" +
                                                  "<td style='border:1px solid #000;padding-left:5px;'>{3}</td>" +
                                              "</tr>" +
                                              "<tr>" +
                                                  "<td style='border:1px solid #000;width:40%; text-align:left;padding-left:5px;'>" +
                                                      "Zona:" +
                                                  "</td>" +
                                                  "<td style='border:1px solid #000;padding-left:5px;'>{16}</td>" +
                                              "</tr>" +
                                          "</tbody>" +
                                      "</table>" +
                                  "</div>" +
                                  "<div class='line-2'>" +
                                      "<table style='width:97%;font-size:18px;'>" +
                                          "<tbody>" +
                                              "<tr>" +
                                                  "<td style='border:1px solid #000;width:40%; text-align:left;padding-left:5px;'>" +
                                                      "Utente:" +
                                                  "</td>" +
                                                  "<td style='border:1px solid #000;padding-left:5px;'>{4}</td>" +
                                              "</tr>" +
                                              "<tr>" +
                                                  "<td style='border:1px solid #000;width:40%; text-align:left;padding-left:5px;'>" +
                                                      "Telefono/Mail:" +
                                                  "</td>" +
                                                  "<td style='border:1px solid #000;padding-left:5px;'>{5}</td>" +
                                              "</tr>" +
                                              "<tr>" +
                                                  "<td style='border:1px solid #000;width:40%; text-align:left;padding-left:5px;'>" +
                                                      "Data Esecuzione:" +
                                                  "</td>" +
                                                  "<td style='border:1px solid #000;padding-left:5px;'>{7}</td>" +
                                              "</tr>" +
                                              "<tr>" +
                                                  "<td style='border:1px solid #000;width:40%; text-align:left;padding-left:5px;'>" +
                                                      "Addetto segnalazione:" +
                                                  "</td>" +
                                                  "<td style='border:1px solid #000;padding-left:5px;'>{8}</td>" +
                                              "</tr>" +
                                              "<tr>" +
                                                  "<td style='border:1px solid #000;width:40%; text-align:left;padding-left:5px;'>" +
                                                      "Provenienza richiesta:" +
                                                  "</td>" +
                                                  "<td style='border:1px solid #000;padding-left:5px;'>{11}</td>" +
                                              "</tr>" +
                                          "</tbody>" +
                                      "</table>" +
                                  "</div>" +
                                  "<div class='line-2'>" +
                                      "<table style='width:97%;font-size:18px;'>" +
                                          "<tbody>" +
                                              "<tr>" +
                                                  "<td style='border:1px solid #000;width:40%; text-align:left;padding-left:5px;'>" +
                                                      "Note Call Center:" +
                                                  "</td>" +
                                                  "<td style='border:1px solid #000;padding-left:5px;'>{9}</td>" +
                                              "</tr>" +
                                              "<tr>" +
                                               "<td style='border:1px solid #000;width:40%; text-align:left;padding-left:5px;'>" +
                                                      "Eseguito il:" +
                                                  "</td>" +
                                                  "<td style='border:1px solid #000;padding-left:5px;'>{12}</td>" +
                                              "</tr>" +
                                                  "<td style='border:1px solid #000;width:40%; text-align:left;padding-left:5px;height:200px;'>" +
                                                      "Note Operatore:" +
                                                  "</td>" +
                                                  "<td style='border:1px solid #000;padding-left:5px;height:200px;'>{10}</td>" +
                                              "</tr>" +
                                          "</tbody>" +
                                      "</table>" +
                                  "</div>" +
                                  "<div class='line-2'>" +
                                      "<table style='width:97%;font-size:18px;'>" +
                                          "<tbody>" +
                                              "<tr>" +
                                                  "<td style='border:1px solid #000;width:33%; text-align:left;padding-left:5px;'>" +
                                                      "Promemoria: {13}" +
                                                  "</td>" +
                                                  "<td style='border:1px solid #000;width:33%;padding-left:5px;'>" +
                                                        "Reclamo: {14}" +
                                                  "</td>" +
                                                  "<td style='border:1px solid #000;width:33%;padding-left:5px;'>" +
                                                        "Da Fatturare: {15}" +
                                                  "</td>" +
                                              "</tr>" +
                                          "</tbody>" +
                                      "</table>" +
                                  "</div>" +
                              "</div>" +
                              "<div style='page-break-before: always;'></div>", itm.Id.ToString(), itm.DataTicket, itm.Comune, itm.Indirizzo, itm.Utente, itm.TelefonoMail,
                        itm.TipoTicket, itm.DataStampa, itm.Richiedente, itm.Note1, itm.Note2, itm.Provenienza, itm.EseguitoIl,
                        itm.Promemoria ,
                        itm.Reclamo ,
                        itm.DaFatturare,
                        itm.Zona
                        );
            }



            sb.AppendFormat(@fileContent, table);
            return sb.ToString();


        }

        public static string ReclamiRegistro(ReclamiRegistroItemsTemplateDto dto)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Template/ReclamiRegistro/assets/", "template.html");
            var fileContent = @File.ReadAllText(filePath);
            var sb = new StringBuilder();

            string table = "";
            foreach (var itm in dto.Items)
            {
                table += String.Format("<tr>" +
                        "<td style='border: 1px solid #000;padding:5px;'>{0}</td>" +
                        "<td style='border: 1px solid #000;padding:5px;min-width:90px;'>{1}</td>" +
                        "<td style='border: 1px solid #000;padding:5px;'>{2}</td>" +
                        "<td style='border: 1px solid #000;padding:5px;'>{3}</td>" +
                        "<td style='border: 1px solid #000;padding:5px;'>{4}</td>" +
                        "<td style='border: 1px solid #000;padding:5px;'>{5}</td>" +
                        "<td style='border: 1px solid #000;padding:5px;'>{10}</td>" +
                        "<td style='border: 1px solid #000;padding:5px;'>{6}</td>" +
                        "<td style='border: 1px solid #000;padding:5px;'>{7}</td>" +
                        "<td style='border: 1px solid #000;padding:5px;'>{8}</td>" +
                        "<td style='border: 1px solid #000;padding:5px;'>{9}</td>" +
                        "</tr>",
                        itm.Numeratore, itm.Data, itm.Cliente,itm.Motivo,
                        itm.RispostaEntro,itm.RispostaInviata,itm.AzioniIntraprese,
                        itm.Fondato,itm.Infondato,itm.Note,
                        itm.RispostaDefinitiva
                        );
            }

            sb.AppendFormat(@fileContent, dto.Anno, table);
            return sb.ToString();
        }

        public static string SegnalazioniDocumento(SegnalazioniDocumentoTemplateDto dto)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Template/SegnalazioniDocumento/assets/", "template.html");
            var fileContent = @File.ReadAllText(filePath);
            var sb = new StringBuilder();

            string header =
                   "<div id='details' class='clearfix'>" +
                   "<div id='client'>" +
                   "<div class='to'>DETTAGLI:</div>" +
                   "<h2 class='name'>" + dto.Tipo + "</h2>" +
                   "<div class='address'>" + dto.User + "</div>" +
                   "</div>" +
                   "<div id='invoice' >" +
                   "<h1> SEGNALAZIONE N°: " + dto.Numero + "</h1>" +
                   "<div class='date'>Data: " + dto.Data.ToString("dd/MM/yyyy HH:mm") + "</div>" +
                   "</div>" +
                   "</div>" +
                   "<div id='notes' class='clearfix'>" +
                   "<div id='notices'>" +
                   "<div> NOTE:</div>" +
                   "<h2 class='name'>" + dto.Note + "</div>" +
                   "</div>" +
                   "<div id='notes' class='clearfix'>" +
                   "<div id='notices'>" +
                   "<div> FOTO:</div>" +
                   "</div>" +
                   "</div>";

            string table = "<div id='photo'>";
            foreach (var itm in dto.Immagini)
            {
                table +=
                        "<div class='detail'>" +
                        "<img src='https://api-res.gestioneambiente.net/api/CloudStorage/DownloadDirectByIdAsync/" + itm + "'>" +
                        "</div>";
            }

            sb.AppendFormat(@fileContent, header, table);
            return sb.ToString();
        }

        public static string CrmEvents(CrmEventsTemplateDto dto)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Template/CrmEvents/assets/", "template.html");
            var fileContent = @File.ReadAllText(filePath);
            var sb = new StringBuilder();

            string table = "";
            foreach (var itm in dto.Items)
            {
                var devices = from x in dto.Devices
                              where x.CrmEventId == itm.Id
                              select x;

                table += String.Format("<div class='content-item page-break'>" +
                    "<table class='table-user'>" +
                    "<thead>" +
                    "<tr>" +
                    "<th style='width:10%;'>" +
                    "Orario" +
                    "</th>" +
                    "<th style='width:45%;'>" +
                    "Utente" +
                    "</th>" +
                    "<th style='widt:45%;'>" +
                    "Note CRM" +
                    "</th>" +
                    "</tr>" +
                    "</thead>" +
                    "<tbody" +
                    "<tr>" +
                    "<td style='padding:5px;'>{0}</td>" +
                    "<td style='padding:5px;'>Richiedente: {1}<br />Telefono: {2}<br />Indirizzo: {3}<br />Comune: {5}</td>" +
                    "<td style='padding:5px;'>{4}</td>" +
                    "</tr>" +
                    "</tbody>" +
                    "</table>",
                    itm.DateSchedule.ToString("HH:mm"), itm.RagSo, itm.Telefono, itm.Indirizzo + " -N°" + itm.NumCiv, itm.NotaAnagrafica, itm.Citta);

                string tableDevices = "" +
                    "<table class='table-device'>" +
                    "<thead>" +
                    "<tr>" +
                    "<th style='width:30%;'>" +
                    "Matricola" +
                    "</th>" +
                    "<th style='width:40%;'>" +
                    "Tipo Contenitore" +
                    "</th>" +
                    "<th style='widt:30%;'>" +
                    "Ritirato" +
                    "</th>" +
                    "</thead>" +
                    "<tbody";

                foreach (var device in devices)
                {
                    tableDevices += string.Format(
                        "<tr>" +
                        "<td style='padding:5px;'>{0}</td>" +
                        "<td style='padding:5px;'>{1}</td>" +
                        "<td style='padding:5px;font-size:20px;'>&#9744;</td>" +
                        "</tr>",device.Identi2,device.DesCon);
                }

                tableDevices += "</tbody>" +
                    "</table>"+
                    "<div class='notes'>"+
                    "<div class='notes-col-1'>"+
                    "Note Operatore"+
                    "</div>"+
                    "</div>" +
                    "</div>";

                table += tableDevices;



            }



            sb.AppendFormat(@fileContent, dto.Area, dto.Data, table);
            return sb.ToString();


        }

        public static string CrmEventsReport(CrmEventsTemplateDto dto)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Template/CrmEventsReport/assets/", "template.html");
            var fileContent = @File.ReadAllText(filePath);
            var sb = new StringBuilder();

            string table = "";
            foreach (var itm in dto.Items)
            {
                var devices = from x in dto.Devices
                              where x.CrmEventId == itm.Id
                              select x;

                table += String.Format("<div class='content-item page-break'>" +
                    "<table class='table-user'>" +
                    "<thead>" +
                    "<tr>" +
                    "<th style='width:10%;'>" +
                    "Orario" +
                    "</th>" +
                    "<th style='width:45%;'>" +
                    "Utente" +
                    "</th>" +
                    "<th style='widt:45%;'>" +
                    "Note CRM" +
                    "</th>" +
                    "</tr>" +
                    "</thead>" +
                    "<tbody" +
                    "<tr>" +
                    "<td style='padding:5px;'>{0}</td>" +
                    "<td style='padding:5px;'>Richiedente: {1}<br />NumCon: {2}<br />Prog: {3}<br />Comune: {5}<br />Indirizzo:{6}</td>" +
                    "<td style='padding:5px;'>{4}</td>" +
                    "</tr>" +
                    "</tbody>" +
                    "</table>",
                    itm.DateSchedule.ToString("HH:mm"), itm.RagSo, itm.NumCon, itm.CpRowNum, itm.NotaAnagrafica, itm.Citta,itm.Indirizzo +", "+itm.NumCiv);

                string tableDevices = "" +
                    "<table class='table-device'>" +
                    "<thead>" +
                    "<tr>" +
                    "<th style='width:30%;'>" +
                    "Matricola" +
                    "</th>" +
                    "<th style='width:40%;'>" +
                    "Tipo Contenitore" +
                    "</th>" +
                    "<th style='widt:30%;'>" +
                    "Ritirato" +
                    "</th>" +
                    "</thead>" +
                    "<tbody";

                foreach (var device in devices)
                {
                    tableDevices += string.Format(
                        "<tr>" +
                        "<td style='padding:5px;'>{0}</td>" +
                        "<td style='padding:5px;'>{1}</td>" +
                        "<td style='padding:5px;font-size:20px;'>&#9744;</td>" +
                        "</tr>", device.Identi2, device.DesCon);
                }

                tableDevices += "</tbody>" +
                    "</table>" +
                    "<div class='notes'>" +
                    "<div class='notes-col-1'>" +
                    "Note Operatore: " +itm.NotaOperatore+""+
                    "</div>" +
                    "</div>" +
                    "</div>";

                table += tableDevices;



            }



            sb.AppendFormat(@fileContent, dto.Area, dto.Data, table);
            return sb.ToString();


        }

        public static string CrmEventRecipt(CrmEventTemplateDto dto)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Template/CrmEventRecipt/assets/", "template.html");
            var fileContent = @File.ReadAllText(filePath);
            var sb = new StringBuilder();

            string table = "";

            var devices = from x in dto.Devices
                          where x.CrmEventId == dto.Item.Id
                          select x;

            table += String.Format("<div class='content-item page-break'>" +
                    "<table class='table-user'>" +
                    "<thead>" +
                    "<tr>" +
                    "<th style='width:99%;'>" +
                    "Utente" +
                    "</th>" +
                    "</tr>" +
                    "</thead>" +
                    "<tbody" +
                    "<tr>" +
                    "<td style='padding:5px;'>Richiedente: <b>{0}</b><br />Comune: <b>{1}</b><br />Indirizzo: <b>{2}</b><br />N° Civico: <b>{3}</b></td>" +
                    "</tr>" +
                    "</tbody>" +
                    "</table>",
                    dto.Item.RagSo, dto.Item.Citta,dto.Item.Indirizzo,dto.Item.NumCiv);

            string tableDevices = "" +
                   "<table class='table-device'>" +
                   "<thead>" +
                   "<tr>" +
                   "<th style='width:30%;'>" +
                   "Matricola" +
                   "</th>" +
                   "<th style='width:40%;'>" +
                   "Tipo Contenitore" +
                   "</th>" +
                   "<th style='widt:30%;'>" +
                   "Ritirato" +
                   "</th>" +
                   "</thead>" +
                   "<tbody";

            foreach (var device in devices)
            {
                tableDevices += string.Format(
                    "<tr>" +
                    "<td style='padding:5px;'>{0}</td>" +
                    "<td style='padding:5px;'>{1}</td>" +
                    "<td style='padding:5px;font-size:20px;'>&#9744;</td>" +
                    "</tr>", device.Identi2, device.DesCon);
            }

            tableDevices += "</tbody>" +
                "</table>" +
                "</div>";

            table += tableDevices;

            sb.AppendFormat(@fileContent,dto.Item.CodAzi.Trim()+dto.Item.CodCli,dto.Item.CodAzi.Trim()+dto.Item.NumCon,  dto.Area, dto.Data,table);
            return sb.ToString();


        }

        public static string CrmEventCloseRecipt(CrmEventTemplateDto dto)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Template/CrmEventCloseRecipt/assets/", "template.html");
            var fileContent = @File.ReadAllText(filePath);
            var sb = new StringBuilder();

            string table = "";

            var devices = from x in dto.Devices
                          where x.CrmEventId == dto.Item.Id
                          select x;

            table += String.Format("<div class='content-item page-break'>" +
                    "<table class='table-user'>" +
                    "<thead>" +
                    "<tr>" +
                    "<th style='width:99%;'>" +
                    "Utente" +
                    "</th>" +
                    "</tr>" +
                    "</thead>" +
                    "<tbody" +
                    "<tr>" +
                    "<td style='padding:5px;'>Richiedente: <b>{0}</b><br />Comune: <b>{1}</b><br />Indirizzo: <b>{2}</b><br />N° Civico: <b>{3}</b></td>" +
                    "</tr>" +
                    "</tbody>" +
                    "</table>",
                    dto.Item.RagSo, dto.Item.Citta, dto.Item.Indirizzo, dto.Item.NumCiv);

            string tableDevices = "" +
                   "<table class='table-device'>" +
                   "<thead>" +
                   "<tr>" +
                   "<th style='width:30%;'>" +
                   "Matricola" +
                   "</th>" +
                   "<th style='width:40%;'>" +
                   "Tipo Contenitore" +
                   "</th>" +
                   "<th style='widt:30%;'>" +
                   "Ritirato" +
                   "</th>" +
                   "</thead>" +
                   "<tbody";

            foreach (var device in devices)
            {
                tableDevices += string.Format(
                    "<tr>" +
                    "<td style='padding:5px;'>{0}</td>" +
                    "<td style='padding:5px;'>{1}</td>" +
                    "<td style='padding:5px;font-size:20px;'>&#9744;</td>" +
                    "</tr>", device.Identi2, device.DesCon);
            }

            tableDevices += "</tbody>" +
                "</table>" +
                "</div>";

            table += tableDevices;

            sb.AppendFormat(@fileContent, dto.Item.CodAzi.Trim() + dto.Item.CodCli, dto.Item.CodAzi.Trim() + dto.Item.NumCon, dto.Area, dto.Data, dto.Item.DataRichiesta.ToString("dd/MM/yyy"), table);
            return sb.ToString();


        }

        public static string CrmEventDefault(CrmEventTemplateDto dto)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Template/CrmEventDefault/assets/", "template.html");
            var fileContent = @File.ReadAllText(filePath);
            var sb = new StringBuilder();

            string table = "";

            sb.AppendFormat(@fileContent, dto.Item.Tipo, dto.Item.CodAzi.Trim() + dto.Item.CodCli, dto.Item.CodAzi.Trim() + dto.Item.NumCon, dto.Area, dto.Data,
                dto.Item.RagSo,dto.Item.CodFis,dto.Item.Citta,dto.Item.Indirizzo+", "+dto.Item.NumCiv+ "- Zona: "+dto.Item.CodZona,dto.Item.Partita,"Tel.: "+dto.Item.Telefono+" - Cel.:"+dto.Item.Cellulare,  dto.Item.NumCon+""+dto.Item.CpRowNum, table);
            return sb.ToString();


        }

        public static string CrmEventCons(CrmEventTemplateDto dto)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Template/CrmEventCons/assets/", "template.html");
            var fileContent = @File.ReadAllText(filePath);
            var sb = new StringBuilder();

            string table = "";

            var devices = from x in dto.Devices
                          where x.CrmEventId == dto.Item.Id
                          select x;

            var devicesContent = "";

            foreach (var device in devices)
            {
                devicesContent += string.Format(
                    "<div class='box-full-col'>" +
                        "<div class='title'>{0}</div>" +
                        "<div class='content'></div>" +
                    "</div>", device.DesCon);
            }

            sb.AppendFormat(@fileContent, dto.Item.Tipo, dto.Item.CodAzi.Trim() + dto.Item.CodCli, dto.Item.CodAzi.Trim() + dto.Item.NumCon, dto.Area, dto.Data,
                dto.Item.RagSo, dto.Item.CodFis, dto.Item.Citta, dto.Item.Indirizzo + ", " + dto.Item.NumCiv + "- Zona: " + dto.Item.CodZona,
                dto.Item.Partita, "Tel.: " + dto.Item.Telefono + " - Cel.:" + dto.Item.Cellulare, 
                dto.Item.NumCon + "" + dto.Item.CpRowNum, devicesContent);
            return sb.ToString();


        }

        public static string CrmEventSost(CrmEventTemplateDto dto)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Template/CrmEventSost/assets/", "template.html");
            var fileContent = @File.ReadAllText(filePath);
            var sb = new StringBuilder();

            string table = "";

            var devices = from x in dto.Devices
                          where x.CrmEventId == dto.Item.Id
                          select x;

            var devicesContent = "";

            foreach (var device in devices)
            {
                devicesContent += string.Format(
                    "<div class='box-full-col'>" +
                        "<div class='title'>{0}</div>" +
                        "<div class='content'></div>" +
                    "</div>", device.DesCon);
            }

            string tableDevices = "" +
                   "<table class='table-device'>" +
                   "<thead>" +
                   "<tr>" +
                   "<th style='width:30%;'>" +
                   "Matricola" +
                   "</th>" +
                   "<th style='width:40%;'>" +
                   "Tipo Contenitore" +
                   "</th>" +
                   "<th style='widt:30%;'>" +
                   "Ritirato" +
                   "</th>" +
                   "</thead>" +
                   "<tbody";

            foreach (var device in devices)
            {
                tableDevices += string.Format(
                    "<tr>" +
                    "<td style='padding:5px;'>{0}</td>" +
                    "<td style='padding:5px;'>{1}</td>" +
                    "<td style='padding:5px;font-size:20px;'>&#9744;</td>" +
                    "</tr>", device.Identi2, device.DesCon);
            }

            tableDevices += "</tbody>" +
                "</table>" +
                "</div>";


            sb.AppendFormat(@fileContent, dto.Item.Tipo, dto.Item.CodAzi.Trim() + dto.Item.CodCli, dto.Item.CodAzi.Trim() + dto.Item.NumCon, dto.Area, dto.Data,
                dto.Item.RagSo, dto.Item.CodFis, dto.Item.Citta, dto.Item.Indirizzo + ", " + dto.Item.NumCiv + "- Zona: " + dto.Item.CodZona,
                dto.Item.Partita, "Tel.: " + dto.Item.Telefono + " - Cel.:" + dto.Item.Cellulare,
                dto.Item.NumCon + "" + dto.Item.CpRowNum, devicesContent,tableDevices);
            return sb.ToString();


        }

        public static string CrmEventRit(CrmEventTemplateDto dto)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Template/CrmEventrIT/assets/", "template.html");
            var fileContent = @File.ReadAllText(filePath);
            var sb = new StringBuilder();

            var devices = from x in dto.Devices
                          where x.CrmEventId == dto.Item.Id
                          select x;

            string tableDevices = "" +
                   "<table class='table-device'>" +
                   "<thead>" +
                   "<tr>" +
                   "<th style='width:30%;'>" +
                   "Matricola" +
                   "</th>" +
                   "<th style='width:40%;'>" +
                   "Tipo Contenitore" +
                   "</th>" +
                   "<th style='widt:30%;'>" +
                   "Ritirato" +
                   "</th>" +
                   "</thead>" +
                   "<tbody";

            foreach (var device in devices)
            {
                tableDevices += string.Format(
                    "<tr>" +
                    "<td style='padding:5px;'>{0}</td>" +
                    "<td style='padding:5px;'>{1}</td>" +
                    "<td style='padding:5px;font-size:20px;'>&#9744;</td>" +
                    "</tr>", device.Identi2, device.DesCon);
            }

            tableDevices += "</tbody>" +
                "</table>" +
                "</div>";


            sb.AppendFormat(@fileContent, dto.Item.Tipo, dto.Item.CodAzi.Trim() + dto.Item.CodCli, dto.Item.CodAzi.Trim() + dto.Item.NumCon, dto.Area, dto.Data,
                dto.Item.RagSo, dto.Item.CodFis, dto.Item.Citta, dto.Item.Indirizzo + ", " + dto.Item.NumCiv + "- Zona: " + dto.Item.CodZona,
                dto.Item.Partita, "Tel.: " + dto.Item.Telefono + " - Cel.:" + dto.Item.Cellulare,
                dto.Item.NumCon + "" + dto.Item.CpRowNum,tableDevices,dto.Item.DataRichiesta.ToString("dd/MM/yyyy"));
            return sb.ToString();


        }
    }
}
