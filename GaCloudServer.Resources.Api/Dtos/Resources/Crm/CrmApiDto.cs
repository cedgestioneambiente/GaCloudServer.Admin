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
        public string? UserId { get; set; }
        public string? UserName { get; set; }
        public string NotaAnagrafica { get; set; }
        public bool Sended { get; set; }
        public string? NotaOperatore { get; set; }
        public DateTime? DataCessazione { get; set; }
        public long? Duration { get; set; }
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
        public string Identi1 { get; set; }
        public string Identi2 { get; set; }
        public int TipCon { get; set; }
        public string DesCon { get; set; }
        public bool Selected { get; set; }
        public bool Completed { get; set; }

    }

    public class CrmEventDevicesApiDto : GenericPagedListDto<CrmEventDeviceApiDto>
    {
    }
    #endregion



}
