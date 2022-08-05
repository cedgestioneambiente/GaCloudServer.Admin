using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Configuration
{
    public class ExtendedDatabaseMigrationsConfiguration
    {
        public bool ApplyDatabaseMigrations { get; set; }

        public string ResourcesDbMigrationsAssembly { get; set; }

        public void SetMigrationsAssemblies(string commonMigrationsAssembly)
        {
            ResourcesDbMigrationsAssembly = commonMigrationsAssembly;
        }
    }
}
