using System.Collections.Generic;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces
{
    public interface IQueryManager
    {
        Task<List<object>> ExecQueryWithParamsAsync(string query, params object[] parameters);
        Task<List<object>> ExecQueryAsync(string query);
        Task<List<object>> ExecCSQueryAsync(string query);
        Task<int> ExecCommandAsync(string query);


    }
}
