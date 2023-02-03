using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.BackOffice.Views;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.BusinnessLogic.Services.Interfaces
{
    public interface IGaBackOfficeService
    {
        #region BackOfficeComuni
        Task<PagedList<ViewGaBackOfficeComuni>> GetViewGaBackOfficeComuniAsync();
        #endregion

        #region BackOfficeUtenze
        Task<PagedList<ViewGaBackOfficeUtenzeGrouped>> GetViewGaBackOfficeUtenzeGroupedByCodAziAndRagCliCfAsync(string codAzi, string ragCliCf);
        #endregion

        #region BackOfficeNdUtenze

        #region Views
        Task<PagedList<ViewGaBackOfficeNdUtenze>> GetViewGaBackOfficeNdUtenzeByCodAziAsync(string codAzi);
        Task<PagedList<ViewGaBackOfficeNdUtenze>> GetViewGaBackOfficeNdUtenzeByCodAziAndNumConAsync(string codAzi, string numCon);
        Task<PagedList<ViewGaBackOfficeNdUtenzeGrouped>> GetViewGaBackOfficeNdUtenzeGroupedByCodAziAsync(string codAzi);
        Task<PagedList<ViewGaBackOfficeNdUtenzeGrouped>> GetViewGaBackOfficeNdUtenzeGroupedByCodAziAndRagCliCfAsync(string codAzi, string ragCliCf);
        #endregion

        #endregion

        #region BackOfficeContenitori
        Task<PagedList<ViewGaBackOfficeContenitoriLetture>> GetViewGaBackOfficeContenitoriLettureByIdentiAsync(string identi);
        Task<PagedList<ViewGaBackOfficeContenitoriLetture>> GetViewGaBackOfficeContenitoriLettureByComuneAndNumConAsync(string codComune,string numCon);
        #endregion


    }
}
