using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Previsio.Views;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Services.Interfaces
{
    public interface IGaPrevisioService
    {

        #region PrevisioOdsReport
        Task<PagedList<ViewGaPrevisioOdsReport>> GetViewGaPrevisioOdsReportByDateAsync(DateTime dateStart,DateTime dateEnd);
        #endregion

    }
}
