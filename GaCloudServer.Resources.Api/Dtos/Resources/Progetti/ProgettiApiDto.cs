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
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
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
    }

    public class ProgettiJobsApiDto : GenericPagedListApiDto<ProgettiJobApiDto>
    {
    }
    #endregion
}
