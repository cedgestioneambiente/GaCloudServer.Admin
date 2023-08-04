using System;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Tasks
{
    public class TasksAction : GenericEntity
    {
        public string Content { get; set; }
        public string Completed { get; set; }
        
        public long TaskItemId { get; set; }

        public TasksItem TasksItem { get; set; }
    }
}