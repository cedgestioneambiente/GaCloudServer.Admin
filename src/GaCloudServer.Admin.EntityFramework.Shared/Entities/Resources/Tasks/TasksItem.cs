using System;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Tasks
{
    public class TasksItem : GenericEntity
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public string Notes { get; set; }
        public bool Completed { get; set; }
        public DateTime? DueDate { get; set; }
        public long Priority { get; set; }
        public string Tags { get; set; }
        public long Order { get; set; }
    }
}