using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.BackOffice.Sp;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.BackOffice.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Contratti;
using GaCloudServer.BusinnessLogic.Dtos.Resources.BackOffice;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Contratti;
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
        Task<BackOfficeComuniCustomDto> GetViewGaBackOfficeComuniCustomAsync();
        #endregion

        #region BackOfficeUtenze

        #region Functions
        Task<BackOfficeMaxContDto> CalcGaBackOfficeMassimali(List<ViewGaBackOfficeUtenzePartite> dtos);
        #endregion
        Task<PagedList<ViewGaBackOfficeUtenzeGrouped>> GetViewGaBackOfficeUtenzeGroupedByCodAziAndRagCliCfAsync(string codAzi, string ragCliCf);
        Task<PagedList<ViewGaBackOfficeUtenze>> GetViewGaBackOfficeUtenzeByCpAziAndFilterAsync(string cpAzi, string filter);
        Task<PagedList<ViewGaBackOfficeUtenzePartite>> GetViewGaBackOfficeUtenzePartiteByCpAziAndNumConAsync(string cpAzi, string numCon);
        Task<PagedList<ViewGaBackOfficeUtenzeDispositivi>> GetViewGaBackOfficeUtenzeDispositiviByCpAziAndNumConAsync(string cpAzi, string numCon);


        #region Sp

        #region Sp
        Task<PagedList<SpGaBackOfficeUtenze>> GetSpGaBackOfficeUtenzeAsync(string cpAzi,string filter);
        Task<PagedList<SpGaBackOfficeUtenzePartite>> GetSpGaBackOfficeUtenzePartiteAsync(string cpAzi,string filter);
        Task<PagedList<SpGaBackOfficeUtenzeDispositivi>> GetSpGaBackOfficeUtenzeDispositiviAsync(string cpAzi,string filter);
        #endregion
        #endregion
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

        #region BackOfficeZone
        Task<List<string>> GetGaBackOfficeZoneComuniAsync();
        Task<List<string>> GetGaBackOfficeZoneVieByComuneAsync(string comune);
        Task<List<string>> GetGaBackOfficeZoneCiviciByComuneAndViaAsync(string comune, string via);
        Task<string> GetGaBackOfficeZoneZonaAsync(string comune, string via, string civico);
        #endregion


    }
}
