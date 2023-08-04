using GaCloudServer.BusinnessLogic.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.BusinnessLogic.DTOs.Resources.Tasks
{
    #region TasksTag
    public class TasksTagDto : GenericDto
    {
        public string? Title { get; set; }
    }

    public class TasksTagsDto : GenericPagedListDto<TasksTagDto>
    {
    }

    #endregion

    #region TasksItem
    public class TasksItemDto : GenericDto
    {
        public string UserId { get; set; }
        public string? Shared { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Notes { get; set; }
        public bool Completed { get; set; }
        public DateTime? DueDate { get; set; }
        public long Priority { get; set; }
        public string Tags { get; set; }
        public long Order { get; set; }
    }

    public class TasksItemsDto : GenericPagedListDto<TasksItemDto>
    {
    }

    #endregion

    #region TasksActions
    public class TasksActionDto : GenericDto
    {
        public string Content { get; set; }
        public bool? Completed { get; set; }
        public long TaskItemId { get; set; }
       
    }

    public class TasksActionsDto : GenericPagedListDto<TasksActionDto>
    {
    }

    #endregion
}
