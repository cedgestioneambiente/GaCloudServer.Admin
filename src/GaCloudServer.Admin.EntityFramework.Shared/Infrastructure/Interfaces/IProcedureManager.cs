using System.Collections.Generic;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces
{
    public interface IProcedureManager<T>
        where T:class
    {
        Task<IList<T>> ExecStoreProcedureWithParamsAsync(string query, params object[] parameters);
        IEnumerable<T> ExecStoreProcedureWithParams(string query, params object[] parameters);
        Task<IList<T>> ExecStoreProcedureAsync(string query);
        IEnumerable<T> ExecStoreProcedure(string query);

        // Fire and forget (async)
        void ExecStoreProcedureNoResultWithParamsAsync(string query, params object[] parameters);
        void ExecStoreNoResultWithParamsProcedure(string query, params object[] parameters);

        // Fire and forget
        void ExecStoreNoResultProcedureAsync(string query);
        void ExecStoreNoResultProcedure(string query);

    }
}
