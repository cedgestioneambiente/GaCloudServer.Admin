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
        public string NotaAnagrafica { get; set; }
        public bool Sended { get; set; }
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

    }

    public class CrmEventAreasDto : GenericPagedListDto<CrmEventAreaDto>
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

}


