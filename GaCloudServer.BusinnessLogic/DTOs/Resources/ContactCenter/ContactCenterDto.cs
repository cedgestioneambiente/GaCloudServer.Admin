using GaCloudServer.BusinnessLogic.DTOs.Base;

namespace GaCloudServer.BusinnessLogic.Dtos.Resources.ContactCenter
{
    #region ContactCenterComuni
    public class ContactCenterComuneDto : GenericListDto
    {
    }

    public class ContactCenterComuniDto : GenericPagedListDto<ContactCenterComuneDto>
    {
    }

    #endregion

    #region ContactCenterProvenienze
    public class ContactCenterProvenienzaDto : GenericListDto
    {
    }

    public class ContactCenterProvenienzeDto : GenericPagedListDto<ContactCenterProvenienzaDto>
    {
    }

    #endregion

    #region ContactCenterStatiRichieste
    public class ContactCenterStatoRichiestaDto : GenericListDto
    {
    }

    public class ContactCenterStatiRichiesteDto : GenericPagedListDto<ContactCenterStatoRichiestaDto>
    {
    }

    #endregion

    #region ContactCenterTipiRichieste
    public class ContactCenterTipoRichiestaDto : GenericListDto
    {
        public bool Ingombranti { get; set; }
    }

    public class ContactCenterTipiRichiesteDto : GenericPagedListDto<ContactCenterTipoRichiestaDto>
    {
    }

    #endregion

    #region ContactCenterMails
    public class ContactCenterMailDto : GenericListDto
    {
        public string Mail { get; set; }
    }

    public class ContactCenterMailsDto : GenericPagedListDto<ContactCenterMailDto>
    {
    }

    #endregion

    #region ContactCenterAllegati
    public class ContactCenterAllegatoDto : GenericFileDto
    {
        public long ContactCenterTicketId { get; set; }
        public string Descrizione { get; set; }
    }

    public class ContactCenterAllegatiDto : GenericPagedListDto<ContactCenterAllegatoDto>
    {
    }

    #endregion

    #region ContactCenterMailsOnTickets
    public class ContactCenterMailOnTicketDto : GenericDto
    {
        public long ContactCenterTicketId { get; set; }
        public long ContactCenterMailId { get; set; }
        public string MailAddress { get; set; }
        public DateTime Data { get; set; }
    }

    public class ContactCenterMailsOnTicketsDto : GenericPagedListDto<ContactCenterMailOnTicketDto>
    {
    }

    #endregion

    #region ContactCenterTickets
    public class ContactCenterTicketDto : GenericDto
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

    public class ContactCenterTicketsDto : GenericPagedListDto<ContactCenterTicketDto>
    {
    }

    #endregion
}