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
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
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
    }

    public class ProgettiJobsDto : GenericPagedListDto<ProgettiJobDto>
    {
    }
    #endregion

    


}

