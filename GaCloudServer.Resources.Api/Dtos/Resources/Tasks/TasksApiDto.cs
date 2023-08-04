using GaCloudServer.BusinnessLogic.DTOs.Base;
using GaCloudServer.Resources.Api.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Resources.Api.Dtos.Resources.Tasks
{
    #region TasksTag
    public class TasksTagApiDto : GenericApiDto
    {
        public string? Title { get; set; }
    }

    public class TasksTagsApiDto : GenericPagedListApiDto<TasksTagApiDto>
    {
    }

    #endregion

    #region TasksItem
    public class TasksItemApiDto : GenericApiDto
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

    public class TasksItemsApiDto : GenericPagedListApiDto<TasksItemApiDto>
    {
    }

    #endregion

    #region TasksAction
    public class TasksActionApiDto : GenericApiDto
    {
        public string Content { get; set; }
        public bool? Completed { get; set; }
        public long TaskItemId { get; set; }
       
    }

    public class TasksActionsApiDto : GenericPagedListApiDto<TasksActionApiDto>
    {
    }

    #endregion
}

