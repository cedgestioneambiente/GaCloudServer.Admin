using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.BusinnessLogic.Dtos.Custom
{
    public class GanttItemDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public int? Start { get; set; }
        public int? End { get; set; }
        public string? Group_id { get; set; }
        public string? Links { get; set; }
        public bool? Draggable { get; set; }
        public bool? ItemDraggable { get; set; }
        public bool? Linkable { get; set; }
        public bool? Expandable { get; set; }
        public long ParentId { get; set; }
        public string? Color { get; set; }
        public string? Type { get; set; }
        public double? Progress { get; set; }
        public long ProgettiWorkId { get; set; }
        public string? Resources { get; set; }
        public int? Priority { get; set; }
        public virtual List<GanttItemDto> Children { get; set; }
        public bool? Completed { get; set; }
        public bool? Approved { get; set; }
        public string? Info { get; set; }
        public double? WorkedDays { get; set; }
        public double? TotalDays { get; set; }
        public string? ProgressDays { get; set; }
        public double ProgressByDays { get; set; }
    }

    public class DownloadProgressDto
    { 
        public string message { get; set; }
        public int progress { get; set; }
        public string? timer { get; set; }
    }

    public class PercentValidateDto
    { 
        public double percent { get; set; }
        public long foundId { get; set; }
        public dynamic? obj { get; set; }

    }
}
