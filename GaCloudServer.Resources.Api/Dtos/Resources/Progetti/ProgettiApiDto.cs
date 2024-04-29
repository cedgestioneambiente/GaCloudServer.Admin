using GaCloudServer.Resources.Api.Dtos.Base;

namespace GaCloudServer.Resources.Api.ApiDtos.Resources.Progetti
{
    #region ProgettiWorks

    public class ProgettiWorkApiDto : GenericListApiDto
    {
        public string Title { get; set; }
        public string Resources { get; set; }
    }

    public class ProgettiWorksApiDto : GenericPagedListApiDto<ProgettiWorkApiDto>
    {
    }
    #endregion

    #region ProgettiJobs

    public class ProgettiJobApiDto : GenericApiDto
    {
        public string Title { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public string? Group_id { get; set; }
        public string? Links { get; set; }
        public bool Draggable { get; set; }
        public bool Linkable { get; set; }
        public bool Expandable { get; set; }
        public long ParentId { get; set; }
        public string? Color { get; set; }
        public string? Type { get; set; }
        public int? Progress { get; set; }
        public long ProgettiWorkId { get; set; }
        public string? Resources { get; set; }
        public int? Priority { get; set; }
        public bool? Completed { get; set; }
        public bool? Approved { get; set; }
        public string? Info { get; set; }

        public double? TotalDays { get; set; }
        public double? WorkedDays { get; set; }
        public bool? CountDays { get; set; }
        public bool? Internal { get; set; }
        public double? MaxDays { get; set; }
    }

    public class ProgettiJobsApiDto : GenericPagedListApiDto<ProgettiJobApiDto>
    {
    }
    #endregion

    #region ProgettiJobAllegati
    public class ProgettiJobAllegatoApiDto : GenericFileApiDto
    {
        public string Descrizione { get; set; }
        public long ProgettiJobId { get; set; }

    }

    public class ProgettiJobAllegatiApiDto : GenericPagedListApiDto<ProgettiJobAllegatoApiDto>
    {
    }
    #endregion

    #region ProgettiJobTasks
    public class ProgettiJobTaskApiDto : GenericApiDto
    {
        public string? Content { get; set; }
        public bool? Completed { get; set; }
        public long ProgettiJobId { get; set; }

    }

    public class ProgettiJobTasksApiDto : GenericPagedListApiDto<ProgettiJobTaskApiDto>
    {
    }
    #endregion

    #region ProgettiWorkSettings
    public class ProgettiWorkSettingApiDto : GenericApiDto
    {
        public long ProgettiWorkId { get; set; }
        public string UserId { get; set; }
        public bool AddJobNotification { get; set; }
        public bool UpdateJobNotification { get; set; }
        public bool DeleteJobNotification { get; set; }
        public bool WorkStatusMail { get; set; }

    }

    public class ProgettiWorkSettingsApiDto : GenericPagedListApiDto<ProgettiWorkSettingApiDto>
    {
    }
    #endregion

    #region ProgettiJobsUndertakings

    public class ProgettiJobUndertakingApiDto : GenericApiDto
    {
        public string Title { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public long ProgettiJobId { get; set; }
        public string Resources { get; set; }
        public string? Info { get; set; }
        public long ProgettiJobUndertakingStateId { get; set; }
    }

    public class ProgettiJobsUndertakingsApiDto : GenericPagedListApiDto<ProgettiJobUndertakingApiDto>
    {
    }
    #endregion

    #region ProgettiJobsUndertakingsStates

    public class ProgettiJobUndertakingStateApiDto : GenericListApiDto
    {

    }

    public class ProgettiJobsUndertakingsStatesApiDto : GenericPagedListApiDto<ProgettiJobUndertakingStateApiDto>
    {
    }
    #endregion

    #region ProgettiJobsUndertakingsAllegati

    public class ProgettiJobUndertakingAllegatoApiDto : GenericFileApiDto
    {
        public string Descrizione { get; set; }
        public long ProgettiJobUndertakingId { get; set; }

    }

    public class ProgettiJobsUndertakingsAllegatiApiDto : GenericPagedListApiDto<ProgettiJobUndertakingAllegatoApiDto>
    {
    }
    #endregion

}
