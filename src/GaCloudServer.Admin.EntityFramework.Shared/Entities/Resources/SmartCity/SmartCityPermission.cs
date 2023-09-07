using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.SmartCity
{
    public class SmartCityPermission : GenericEntity
    {
        public string UserId { get; set; }
        public string Permissions { get; set; }

    }
}
