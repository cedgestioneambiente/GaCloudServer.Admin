using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Emz.Views;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Services.Interfaces
{
    public interface IEmzService
    {

        #region Views
        Task<PagedList<ViewEmzWhiteList>> GetViewEmzWhiteListAsync();
        #endregion


    }
}
