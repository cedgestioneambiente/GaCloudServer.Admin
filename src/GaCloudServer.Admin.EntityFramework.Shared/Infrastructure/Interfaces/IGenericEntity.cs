using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces
{
    public interface IGenericEntity
    {
        long Id { get; set; }
        bool Disabled { get; set; }
    }
}
