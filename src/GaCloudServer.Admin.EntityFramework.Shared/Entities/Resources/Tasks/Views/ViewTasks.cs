using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Tasks.Views
{
    public class ViewTasks:GenericEntity
    {
        public string UserId { get; set; }
        public string Shared { get; set; }
        public string Title { get; set; }
        public string Notes { get; set; }
        public bool Completed { get; set; }
        public DateTime? DueDate { get; set; }
        public long Priority { get; set; }
        public string Type { get; set; }
        public string Tags { get; set; }
        public long Order { get; set; }
        public int Warning { get; set; }
        public string Owner { get; set; }
        public string CompletionStatus { get; set; }
        public string DeadlineStatus { get; set; }
        public string SharedName { get; set; }
    }
}
