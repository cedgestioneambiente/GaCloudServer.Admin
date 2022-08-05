using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces
{
    public interface IUnitOfWork
    {
        int SaveChanges();
        Task<int> SaveChangesAsync();
        void DetachEntity<T>(T entity);
    }
}
