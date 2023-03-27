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
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Class { get; set; }
        public string Link { get; set; }
        public int Miles { get; set; }
        public string Res { get; set; }
        public string Comp { get; set; }
        public int Group { get; set; }
        public int Parent { get; set; }
        public int Open { get; set; }
        public string Depend { get; set; }
        public string Caption { get; set; }
        public string Notes { get; set; }
        public int Priority { get; set; }

        public long ProgettiWorkId { get; set; }
    }

    public class ProgettiJobsApiDto : GenericPagedListApiDto<ProgettiJobApiDto>
    {
    }
    #endregion
}
