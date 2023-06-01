using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Crm;
using GaCloudServer.BusinnessLogic.DTOs.Base;

namespace GaCloudServer.BusinnessLogic.Dtos.Resources.Crm
{
    #region Crm Events
    public class CrmEventDto : GenericEntity
    {
        public string CodAzi { get; set; }
        public string CodCli { get; set; }
        public string NumCon { get; set; }
        public string CpRowNum { get; set; }
        public DateTime DateSchedule { get; set; }
        public string RagSo { get; set; }
        public string Telefono { get; set; }
        public string Cellulare { get; set; }
        public string Email { get; set; }
        public string Pec { get; set; }
        public string Tipo { get; set; }
        public string Citta { get; set; }
        public string Indirizzo { get; set; }
        public string NumCiv { get; set; }
        public bool Domest { get; set; }
        public long CrmEventStateId { get; set; }
        public long CrmEventAreaId { get; set; }
        public int CrmTicketId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string NotaAnagrafica { get; set; }
        public bool Sended { get; set; }
        public string NotaOperatore { get; set; }
        public DateTime? DataCessazione { get; set; }
        public long? Duration { get; set; }
    }

    public class CrmEventsDto : GenericPagedListDto<CrmEventDto>
    {
    }

    #endregion

    #region CrmEventStates
    public class CrmEventStateDto : GenericListEntity
    {
        
    }

    public class CrmEventStatesDto : GenericPagedListDto<CrmEventStateDto>
    {
    }

    #endregion

    #region CrmEventAreas
    public class CrmEventAreaDto : GenericListEntity
    {
        public string Days { get; set; }
        public string Color { get; set; }
    }

    public class CrmEventAreasDto : GenericPagedListDto<CrmEventAreaDto>
    {
    }

    #endregion

    #region CrmEventComuni
    public class CrmEventComuneDto : GenericListEntity
    {
        public string CodAzi { get; set; }
        public long Duration { get; set; }
    }

    public class CrmEventComuniDto : GenericPagedListDto<CrmEventComuneDto>
    {
    }

    #endregion

    #region CrmEventDevices
    public class CrmEventDeviceDto : GenericEntity
    {
        public long CrmEventId { get; set; }
        public int CrmTicketId { get; set; }
        public string Identi1 { get; set; }
        public string Identi2 { get; set; }
        public int TipCon { get; set; }
        public string DesCon { get; set; }
        public bool Selected { get; set; }
        public bool Completed { get; set; }

    }

    public class CrmEventDevicesDto : GenericPagedListDto<CrmEventDeviceDto>
    {
    }
    #endregion

    #region Crm Tickets
    public class CrmTicketDto : GenericEntity
    {
        public DateTime DataTicket { get; set; }
        public DateTime DataRichiesta { get; set; }
        public long CrmEventComuneId { get; set; }
        public string Utente { get; set; }
        public string CodCli { get; set; }
        public string NumCon { get; set; }
        public string Partita { get; set; }
        public string Prg { get; set; }
        public string CfPiva { get; set; }
        public string Via { get; set; }
        public string NumCiv { get; set; }
        public long ContactCenterProvenienzaId { get; set; }
        public string? Telefono { get; set; }
        public string? Cellulare { get; set; }
        public string? Email { get; set; }
        public long ContactCenterTioRichiestaId { get; set; }
        public DateTime? DataChiusura { get; set; }
        public long ContactCenterStatoRichiestaId { get; set; }
        public string Creator { get; set; }
        public string Assignee { get; set; }
        public string? NoteCrm { get; set; }
        public string? NoteOperatore { get; set; }
    }

    public class CrmTicketsDto : GenericPagedListDto<CrmTicketDto>
    {
    }

    #endregion

    public class CrmChangeEventStateDto
    { 
        public long id { get; set; }
        public int crmId { get; set; }
        public long state { get; set; }
    }

}


