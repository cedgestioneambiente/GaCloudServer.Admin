using GaCloudServer.BusinnessLogic.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.BusinnessLogic.Dtos.Template
{
    public class PersonaleSchedaConsegnaTemplateDto:GenericPrintDto
    {
        public string Numero { get; set; }
        public string Data { get; set; }
        public string Preposto { get; set; }
        public string Lavoratore { get; set; }
        public string Mansioni { get; set; }
        public List<dynamic> Articoli { get; set; }

    }

    public class ContactCenterTicketIntTemplateDto : GenericPrintDto
    { 
        public string Id { get; set; }
        public string DataTicket { get; set; }
        public string Comune { get; set; }
        public string Indirizzo { get; set; }
        public string Utente { get; set; }
        public string TelefonoMail { get; set; }
        public string TipoTicket { get; set; }
        public string DataStampa { get; set; }
        public string Richiedente { get; set; }
        public string Note1 { get; set; }
        public string Note2 { get; set; }
        public string Provenienza { get; set; }
        public string EseguitoIl { get; set; }
        public string Promemoria { get; set; }
        public string Reclamo { get; set; }
        public string DaFatturare { get; set; }
    }

    public class ContactCenterTicketIngTemplateDto : GenericPrintDto
    {
        public string Id { get; set; }
        public string DataTicket { get; set; }
        public string Comune { get; set; }
        public string Indirizzo { get; set; }
        public string Utente { get; set; }
        public string TelefonoMail { get; set; }
        public string TipoTicket { get; set; }
        public string DataStampa { get; set; }
        public string Richiedente { get; set; }
        public string Note1 { get; set; }
        public string Note2 { get; set; }
        public string Materiali { get; set; }
    }

    public class ContactCenterTicketsIngTemplateDto : GenericPrintDto
    { 
        public string Comune { get; set; }
        public string Data { get; set; }
        public string TipoStampa { get; set; }
        public List<ContactCenterTicketIngTemplateDto> Items { get; set; }
    }

    public class ContactCenterTicketsIntTemplateDto : GenericPrintDto
    {
        public List<ContactCenterTicketIntTemplateDto> Items { get; set; }
    }

    public class ReclamiRegistroItemTemplateDto
    { 
        public string Numeratore { get; set; }
        public string Data { get; set; }
        public string Cliente { get; set; }
        public string Motivo { get; set; }
        public string RispostaEntro { get; set; }
        public string RispostaInviata { get; set; }
        public string AzioniIntraprese { get; set; }
        public string Fondato { get; set; }
        public string Infondato { get; set; }
        public string Note { get; set; }
        public string RispostaDefinitiva { get; set; }

        
    }

    public class ReclamiRegistroItemsTemplateDto : GenericPrintDto
    { 
        public string Anno { get; set; }
        public List<ReclamiRegistroItemTemplateDto> Items { get; set; }
    }

    public class SegnalazioniDocumentoTemplateDto : GenericPrintDto
    {
        public string Numero { get; set; }
        public string Data { get; set; }
        public string Note { get; set; }
        public string Allegato { get; set; }

    }


}
