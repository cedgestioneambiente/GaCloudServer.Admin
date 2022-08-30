using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.SqlServer.Helpers
{
    public static class MigrationHelper
    {
        public static string CommandToString(string migration, string script)
        {
            return File.ReadAllText(migration + script);
        }
    }
}
