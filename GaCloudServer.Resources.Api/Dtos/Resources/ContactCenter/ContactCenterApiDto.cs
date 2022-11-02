using GaCloudServer.Resources.Api.Dtos.Base;

namespace GaCloudServer.Resources.Api.Dtos.Resources.ContactCenter
{

        #region ContactCenterComuni
        public class ContactCenterComuneApiDto : GenericListApiDto
        {
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
            //da implementare
            public DateTime DataTicket { get; set; }
            public DateTime? EseguitoIl { get; set; }
            public DateTime? DataEsecuzione { get; set; }
            public long ContactCenterStatoRichiestaId { get; set; }
            public long ContactCenterProvenienzaId { get; set; }
            public long GlobalSedeId { get; set; }
            public string RichiedenteId { get; set; }
            public bool Inviato { get; set; }
            public string Materiali { get; set; }
            public bool Promemoria { get; set; }
            public bool DaFatturare { get; set; }
            public bool Stampato { get; set; }
            public string TelefonoMail { get; set; }
            public string TipoTicket { get; set; }
            public string Note1 { get; set; }
            public string Note2 { get; set; }
            public string Note3 { get; set; }
            public bool Reclamo { get; set; }
        }

        public class ContactCenterTicketsApiDto : GenericPagedListApiDto<ContactCenterTicketApiDto>
        {
        }

        #endregion
    
}
