using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using GaCloudServer.BusinnessLogic.DTOs.Base;
using GaCloudServer.Resources.Api.Dtos.Base;

namespace GaCloudServer.Resources.Api.Dtos.Crm
{
    #region CrmEventsApiDto
    public class CrmEventApiDto : GenericApiDto
    {
        public string CodAzi { get; set; }
        public string CodCli { get; set; }
        public string NumCon { get; set; }
        public string Partita { get; set; }
        public string CpRowNum { get; set; }
        public DateTime DateSchedule { get; set; }
        public DateTime DataRichiesta { get; set; }
        public string RagSo { get; set; }
        public string CodFis { get; set; }
        public string? Telefono { get; set; }
        public string? Cellulare { get; set; }
        public string? Email { get; set; }
        public string? Pec { get; set; }
        public long TipoId { get; set; }
        public string Tipo { get; set; }
        public string Citta { get; set; }
        public string Indirizzo { get; set; }
        public string NumCiv { get; set; }
        public string? CodZona { get; set; }
        public bool Domest { get; set; }
        public long CrmEventStateId { get; set; }
        public long CrmEventAreaId { get; set; }
        public int CrmTicketId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string? NotaAnagrafica { get; set; }
        public bool Sended { get; set; }
        public string? NotaOperatore { get; set; }
        public long? Duration { get; set; }

        public bool RitardoCausaUtente { get; set; }
        public bool RitardoCausaAzienda { get; set; }
    }

    public class CrmEventsApiDto : GenericPagedListApiDto<CrmEventApiDto>
    {
    }

    #endregion

    #region CrmEventStatesApiDto
    public class CrmEventStateApiDto : GenericListApiDto
    {
        
    }

    public class CrmEventStatesApiDto : GenericPagedListApiDto<CrmEventStateApiDto>
    {
    }

    #endregion

    #region CrmEventAreasApiDto
    public class CrmEventAreaApiDto : GenericListApiDto
    {
        public string Days { get; set; }
        public string Color { get; set; }
    }

    public class CrmEventAreasApiDto : GenericPagedListApiDto<CrmEventAreaApiDto>
    {
    }

    #endregion

    #region CrmEventComuneApiDto
    public class CrmEventComuneApiDto : GenericListApiDto
    {
        public string CodAzi { get; set; }
        public long Duration{ get; set; }
    }

    public class CrmEventComuniApiDto : GenericPagedListApiDto<CrmEventComuneApiDto>
    {
    }

    #endregion

    #region CrmEventDevices
    public class CrmEventDeviceApiDto : GenericEntity
    {
        public long CrmEventId { get; set; }
        public int CrmTicketId { get; set; }
        public string? Identi1 { get; set; }
        public string? Identi2 { get; set; }
        public string TipCon { get; set; }
        public string DesCon { get; set; }
        public bool Selected { get; set; }
        public bool Completed { get; set; }
        public bool SostLuch { get; set; }

    }

    public class CrmEventDevicesApiDto : GenericPagedListDto<CrmEventDeviceApiDto>
    {
    }
    #endregion

    #region CrmTicketsApiDto
    public class CrmTicketApiDto : GenericApiDto
    {
        public DateTime DataTicket { get; set; }
        public DateTime DataRichiesta { get; set; }
        public long CrmEventComuneId { get; set; }
        public string Utente { get; set; }
        public string CodCli { get; set; }
        public string NumCon { get; set; }
        public string Partita { get; set; }
        public string Prg { get; set; }
        public string? CodSdi { get; set; }
        public string CfPiva { get; set; }
        public string Via { get; set; }
        public string? NumCiv { get; set; }
        public string? CodZona{ get;set; }
        public long ContactCenterProvenienzaId { get; set; }
        public string? Telefono { get; set; }
        public string? Cellulare { get; set; }
        public string? Email { get; set; }
        public string? EmailPec { get; set; }
        public long ContactCenterTipoRichiestaId { get; set; }
        public DateTime? DataChiusura { get; set; }
        public long ContactCenterStatoRichiestaId { get; set; }
        public string Creator { get; set; }
        public string Assignee { get; set; }
        public string? NoteCrm { get; set; }
        public string? NoteOperatore { get; set; }
        public string? Tributo { get; set; }
    }

    public class CrmTicketsApiDto : GenericPagedListApiDto<CrmTicketApiDto>
    {
    }

    #endregion

    #region CrmTicketAllegatiApiDto
    public class CrmTicketAllegatoApiDto : GenericFileApiDto
    {
        public long CrmTicketId { get; set; }
        public string Descrizione { get; set; }
    }

    public class CrmTicketAllegatiApiDto : GenericPagedListDto<CrmTicketAllegatoApiDto>
    {
    }

    #endregion

    public class CrmSendMailApiDto 
    { 
        public long id { get; set; }
        public string userId { get; set; }
        public string userName { get; set; }
        public string mailingList { get; set; }
    
    }

    public class CrmDuplicateTicketsApiDto
    {
        public long[] ticketsId { get; set; }
        public string userId { get; set; }
    }

}
