using GaCloudServer.Resources.Api.Dtos.Base;

namespace GaCloudServer.Resources.Api.Dtos.Resources.ContactCenter
{

        #region ContactCenterComuni
        public class ContactCenterComuneApiDto : GenericListApiDto
        {
            public string CodAzi { get; set; }
        }

        public class ContactCenterComuniApiDto : GenericPagedListApiDto<ContactCenterComuneApiDto>
        {
        }

        #endregion

        #region ContactCenterProvenienze
        public class ContactCenterProvenienzaApiDto : GenericListApiDto
        {
        }

        public class ContactCenterProvenienzeApiDto : GenericPagedListApiDto<ContactCenterProvenienzaApiDto>
        {
        }

        #endregion

        #region ContactCenterStatiRichieste
        public class ContactCenterStatoRichiestaApiDto : GenericListApiDto
        {
        }

        public class ContactCenterStatiRichiesteApiDto : GenericPagedListApiDto<ContactCenterStatoRichiestaApiDto>
        {
        }

        #endregion

        #region ContactCenterTipiRichieste
        public class ContactCenterTipoRichiestaApiDto : GenericListApiDto
        {
            public bool Ingombranti { get; set; }
        }

        public class ContactCenterTipiRichiesteApiDto : GenericPagedListApiDto<ContactCenterTipoRichiestaApiDto>
        {
        }

        #endregion

        #region ContactCenterMails
        public class ContactCenterMailApiDto : GenericListApiDto
        {
            public string Mail { get; set; }
        }

        public class ContactCenterMailsApiDto : GenericPagedListApiDto<ContactCenterMailApiDto>
        {
        }

        #endregion

        #region ContactCenterAllegati
        public class ContactCenterAllegatoApiDto : GenericFileApiDto
        {
            public long ContactCenterTicketId { get; set; }
            public string Descrizione { get; set; }
        

        public ContactCenterAllegatoApiDto()
        {
            Descrizione = string.Empty;
        }

        }
        public class ContactCenterAllegatiApiDto : GenericPagedListApiDto<ContactCenterAllegatoApiDto>
            {

            }
        
        #endregion

        #region ContactCenterMailsOnTickets
    public class ContactCenterMailOnTicketApiDto : GenericApiDto
        {
            public long ContactCenterTicketId { get; set; }
            public long ContactCenterMailId { get; set; }
            public string MailAddress { get; set; }
            public DateTime Data { get; set; }
        }

        public class ContactCenterMailsOnTicketsApiDto : GenericPagedListApiDto<ContactCenterMailOnTicketApiDto>
        {
        }

        #endregion

        #region ContactCenterTickets
        public class ContactCenterTicketApiDto : GenericApiDto
        {
        public string Utente { get; set; }
        public string NumCon { get; set; }
        public string Partita { get; set; }
        public string? CfPiva { get; set; }
        public string Via { get; set; }
        public string? NumCiv { get; set; }
        public string? Zona { get; set; }
        public DateTime DataTicket { get; set; }
        public DateTime? EseguitoIl { get; set; }
        public DateTime? DataEsecuzione { get; set; }
        public long ContactCenterStatoRichiestaId { get; set; }
        public long ContactCenterProvenienzaId { get; set; }
        public long ContactCenterComuneId { get; set; }
        public long AziendeListaId { get; set; }
        public string? ComuneAltro { get; set; }
        public long GlobalSedeId { get; set; }
        public string UserId { get; set; }
        public bool Inviato { get; set; }
        public string? Materiali { get; set; }
        public bool Promemoria { get; set; }
        public bool DaFatturare { get; set; }
        public bool Stampato { get; set; }
        public string TelefonoMail { get; set; }
        public long ContactCenterTipoRichiestaId { get; set; }
        public string? Note1 { get; set; }
        public string? Note2 { get; set; }
        public string? Note3 { get; set; }
        public bool Reclamo { get; set; }
    }

        public class ContactCenterTicketsApiDto : GenericPagedListApiDto<ContactCenterTicketApiDto>
        {
        }

    #endregion


    //Internal
    public class ContactCenterIngByDateFilterApiDto
    {
        public long comuneId { get; set; }
        public DateTime dataEsecuzione { get; set; }
    }

    public class ContactCenterSendMailApiDto
    {
        public long id { get; set; }
        public string userid { get; set; }
        public string userName { get; set; }
        public long[] mailList { get; set; }
        public string mailNote { get; set; }
    }

    public class ContactCenterDuplicateTicketsApiDto
    {
        public long[] ticketsId { get; set; }
        public string userId { get; set; }
        public bool stampato { get; set; }
    }

    public class ContactCenterStatusTicketsApiDto
    {
        public long[] ticketsId { get; set; }
    }

    public class ContactCenterIngPrintFilterApiDto
    {
        public long comuneId { get; set; }
        public string comuneAltro { get; set; }
        public DateTime? dataEsecuzione { get; set; }
        public int tipoStampa { get; set; }
        public bool all { get; set; }
    }

    public class ContactCenterIntPrintFilterApiDto
    {
        public long? fromId { get; set; }
        public long? toId { get; set; }
        public DateTime? fromDate { get; set; }
        public DateTime? toDate { get; set; }
        public bool all { get; set; }
    }
}
