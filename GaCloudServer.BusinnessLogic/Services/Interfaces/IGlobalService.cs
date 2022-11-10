using GaCloudServer.BusinnessLogic.DTOs.Resources.Global;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.BusinnessLogic.Services.Interfaces
{
    public interface IGlobalService
    {
        #region GlobalSedi
        Task<GlobalSediDto> GetGlobalSediAsync(int page = 1, int pageSize = 0);
        Task<GlobalSedeDto> GetGlobalSedeByIdAsync(long id);

        Task<long> AddGlobalSedeAsync(GlobalSedeDto dto);
        Task<long> UpdateGlobalSedeAsync(GlobalSedeDto dto);

        Task<bool> DeleteGlobalSedeAsync(long id);

        #region Functions
        Task<bool> ValidateGlobalSedeAsync(long id, string descrizione);
        Task<bool> ChangeStatusGlobalSedeAsync(long id);
        #endregion

        #endregion

        #region GlobalCentriCosti
        Task<GlobalCentriCostiDto> GetGlobalCentriCostiAsync(int page = 1, int pageSize = 0);
        Task<GlobalCentroCostoDto> GetGlobalCentroCostoByIdAsync(long id);

        Task<long> AddGlobalCentroCostoAsync(GlobalCentroCostoDto dto);
        Task<long> UpdateGlobalCentroCostoAsync(GlobalCentroCostoDto dto);

        Task<bool> DeleteGlobalCentroCostoAsync(long id);

        #region Functions
        Task<bool> ValidateGlobalCentroCostoAsync(long id, string descrizione);
        Task<bool> ChangeStatusGlobalCentroCostoAsync(long id);
        #endregion

        #endregion

        #region GlobalSettori
        Task<GlobalSettoriDto> GetGlobalSettoriAsync(int page = 1, int pageSize = 0);
        Task<GlobalSettoreDto> GetGlobalSettoreByIdAsync(long id);

        Task<long> AddGlobalSettoreAsync(GlobalSettoreDto dto);
        Task<long> UpdateGlobalSettoreAsync(GlobalSettoreDto dto);

        Task<bool> DeleteGlobalSettoreAsync(long id);

        #region Functions
        Task<bool> ValidateGlobalSettoreAsync(long id, string descrizione);
        Task<bool> ChangeStatusGlobalSettoreAsync(long id);
        #endregion

        #endregion
    }
}
