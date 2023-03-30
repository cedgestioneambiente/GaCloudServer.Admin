using System;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Tasks
{
    public class TasksTag : GenericEntity
    {
        public string? Title { get; set; }
    }
}