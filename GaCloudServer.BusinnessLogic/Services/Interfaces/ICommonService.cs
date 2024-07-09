using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Crm.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Preventivi.Views;
using GaCloudServer.BusinnessLogic.Dtos.Common;
using GaCloudServer.BusinnessLogic.DTOs.Resources.Preventivi;
using GaCloudServer.Shared;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Services.Interfaces
{
    public interface ICommonService
    {


        #region CommonGauges
        public Task<PageResponse<CommonGaugeDto>> GetCommonGaugesAsync(PageRequest request);
        public Task<CommonGaugeDto> GetCommonGaugeByIdAsync(long id);
        public Task<long> CreateCommonGaugeAsync(CommonGaugeDto model);
        public Task<long> UpdateCommonGaugeAsync(long id, CommonGaugeDto model);
        public Task<bool> DeleteCommonGaugeAsync(long id);

        #endregion

        #region CommonIvaCodes
        public Task<PageResponse<CommonIvaCodeDto>> GetCommonIvaCodesAsync(PageRequest request);
        public Task<CommonIvaCodeDto> GetCommonIvaCodeByIdAsync(long id);
        public Task<long> CreateCommonIvaCodeAsync(CommonIvaCodeDto model);
        public Task<long> UpdateCommonIvaCodeAsync(long id, CommonIvaCodeDto model);
        public Task<bool> DeleteCommonIvaCodeAsync(long id);

        #endregion

        #region CommonBankAccounts
        public Task<PageResponse<CommonBankAccountDto>> GetCommonBankAccountsAsync(PageRequest request);
        public Task<CommonBankAccountDto> GetCommonBankAccountByIdAsync(long id);
        public Task<long> CreateCommonBankAccountAsync(CommonBankAccountDto model);
        public Task<long> UpdateCommonBankAccountAsync(long id, CommonBankAccountDto model);
        public Task<bool> DeleteCommonBankAccountAsync(long id);

        #endregion

    }
}

