using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.BackOffice;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.BackOffice.Sp;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.BackOffice.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Contratti;
using GaCloudServer.BusinnessLogic.Dtos.Resources.BackOffice;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Contratti;
using GaCloudServer.BusinnessLogic.Mappers;
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
        Task<PagedList<ViewGaBackOfficeUtenzePartiteGrp>> GetViewGaBackOfficeUtenzePartiteGrpByCodAziAndFilterAsync(string codAzi, string filter);
        Task<ViewGaBackOfficeUtenze> GetViewGaBackOfficeUtenzaByCpAziAndNumConAsync(string cpAzi, string numCon);
        Task<PagedList<ViewGaBackOfficeUtenze>> GetViewGaBackOfficeUtenzeByCpAziAndFilterAsync(string cpAzi, string filter);
        Task<PagedList<ViewGaBackOfficeUtenzePartite>> GetViewGaBackOfficeUtenzePartiteByCpAziAndNumConAsync(string cpAzi, string numCon);
        Task<PagedList<ViewGaBackOfficeUtenzePartiteVariazioni>> GetViewGaBackOfficeUtenzePartiteVariazioniByCpAziAndNumConAndPartitaAsync(string cpAzi, string numCon, string partita);
        Task<PagedList<ViewGaBackOfficeUtenzePartiteDetail>> GetViewGaBackOfficeUtenzePartiteByCpAziAndIndirizzoAsync(string cpAzi,string via, int startNumCiv,int endNumCiv);
        Task<PagedList<ViewGaBackOfficeUtenzeDispositivi>> GetViewGaBackOfficeUtenzeDispositiviByCpAziAndNumConAsync(string cpAzi, string numCon);
        Task<PagedList<ViewGaBackOfficeUtenzeDispositivi>> GetViewGaBackOfficeUtenzeDispositiviByCpAziAndNumConAndPartitaAsync(string cpAzi, string numCon, string partita);
        Task<PagedList<ViewGaBackOfficeUtenzeZone>> GetViewGaBackOfficeUtenzeZoneAsync();


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

        #region BackOfficeNovi
        Task<PagedList<ViewGaBackOfficeUtenzeNovi>> GetViewGaBackOfficeUtenzeNoviAsync(string filter);
        #endregion

        #region BackOfficeRecipes
        Task<BackOfficeDocRecipesDto> GetGaBackOfficeDocRecipesAsync(int page = 1, int pageSize = 0);
        Task<BackOfficeDocReceiptDto> GetGaBackOfficeDocRecipesByIdAsync(long id);
        Task<BackOfficeDocRecipesDto> GetGaBackOfficeDocRecipesByCodCliAndNumConAsync(string codCli,string numCon);
        Task<long> AddGaBackOfficeDocReceiptAsync(BackOfficeDocReceiptDto dto);
        Task<long> UpdateGaBeckOfficeDocReceiptAsync(BackOfficeDocReceiptDto dto);
        Task<bool> DeleteGaBackOfficeDocReceiptAsync(long id);

        #endregion

        #region BackOfficeInsolutoTariNovi
        Task<PagedList<ViewGaBackOfficeInsolutoTariNovi>> GetViewGaBackOfficeInsolutoTariNoviByFilterAsync(string codCli, string numCon);

        #endregion

        #region BackOfficeCli
        Task<PagedList<ViewGaBackOfficeUtenzeCliFat>> GetViewGaBackOfficeUtenzaCliFatByFilterAsync(string codCli);
        Task<PagedList<ViewGaBackOfficeUtenzeCliSed>> GetViewGaBackOfficeUtenzaCliSedByFilterAsync(string codCli);
        #endregion


    }
}
