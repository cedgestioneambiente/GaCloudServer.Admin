using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Progetti;
using GaCloudServer.BusinnessLogic.DTOs.Base;

namespace GaCloudServer.BusinnessLogic.Dtos.Resources.Progetti
{
    #region ProgettiWorks

    public class ProgettiWorkDto : GenericListDto
    {
        public string Title { get; set; }
        public string Resources { get; set; }
    }

    public class ProgettiWorksDto : GenericPagedListDto<ProgettiWorkDto>
    {
    }
    #endregion

    #region ProgettiJobs

    public class ProgettiJobDto : GenericDto
    {
        public string Title { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public string Group_id { get; set; }
        public string Links { get; set; }
        public bool Draggable { get; set; }
        public bool Linkable { get; set; }
        public bool Expandable { get; set; }
        public long ParentId { get; set; }
        public string Color { get; set; }
        public string Type { get; set; }
        public int? Progress { get; set; }
        public long ProgettiWorkId { get; set; }
        public string Resources { get; set; }
        public int? Priority { get; set; }
        public bool? Completed { get; set; }
        public bool? Approved { get; set; }
        public string? Info { get; set; }
    }

    public class ProgettiJobsDto : GenericPagedListDto<ProgettiJobDto>
    {
    }
    #endregion

    #region ProgettiJobAllegati
    public class ProgettiJobAllegatoDto : GenericFileDto
    {
        public string Descrizione { get; set; }
        public long ProgettiJobId { get; set; }

    }

    public class ProgettiJobAllegatiDto : GenericPagedListDto<ProgettiJobAllegatoDto>
    {
    }
    #endregion

    #region ProgettiJobTask
    public class ProgettiJobTaskDto : GenericDto
    {
        public string? Content { get; set; }
        public bool Completed { get; set; }
        public long ProgettiJobId { get; set; }

    }

    public class ProgettiJobTasksDto : GenericPagedListDto<ProgettiJobTaskDto>
    {
    }
    #endregion

    #region ProgettiWorkSettings
    public class ProgettiWorkSettingDto : GenericDto
    {
        public long ProgettiWorkId { get; set; }
        public string UserId { get; set; }
        public bool AddJobNotification { get; set; }
        public bool UpdateJobNotification { get; set; }
        public bool DeleteJobNotification { get; set; }
        public bool WorkStatusMail { get; set; }

    }

    public class ProgettiWorkSettingsDto : GenericPagedListDto<ProgettiWorkSettingDto>
    {
    }
    #endregion

    #region ProgettiJobsUndertakings

    public class ProgettiJobUndertakingDto : GenericDto
    {
        public string Title { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public long ProgettiJobId { get; set; }
        public string Resources { get; set; }
        public string? Info { get; set; }
        public long ProgettiJobUndertakingStateId { get; set; }
    }

    public class ProgettiJobsUndertakingsDto : GenericPagedListDto<ProgettiJobUndertakingDto>
    {
    }
    #endregion

    #region ProgettiJobsUndertakingsStates

    public class ProgettiJobUndertakingStateDto : GenericListDto
    {

    }

    public class ProgettiJobsUndertakingsStatesDto : GenericPagedListDto<ProgettiJobUndertakingStateDto>
    {
    }
    #endregion

    #region ProgettiJobsUndertakingsAllegati

    public class ProgettiJobUndertakingAllegatoDto : GenericFileDto
    {
        public string Descrizione { get; set; }
        public long ProgettiJobUndertakingId { get; set; }

    }

    public class ProgettiJobsUndertakingsAllegatiDto : GenericPagedListDto<ProgettiJobUndertakingAllegatoDto>
    {
    }
    #endregion

    #region Internal

    #endregion




}

