using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Common;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using GaCloudServer.BusinnessLogic.Dtos.Common;
using GaCloudServer.BusinnessLogic.Mappers;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Shared;

namespace GaCloudServer.BusinnessLogic.Services
{
    public class CommonService : ICommonService
    {

        protected readonly IGenericRepository<Gauge> commonGaugesRepo;
        protected readonly IGenericRepository<IvaCode> commonIvaCodesRepo;
        protected readonly IGenericRepository<BankAccount> commonBankAccountsRepo;

        public CommonService(
            IGenericRepository<Gauge> commonGaugesRepo,
            IGenericRepository<IvaCode> commonIvaCodesRepo,
            IGenericRepository<BankAccount> commonBankAccountsRepo
            )
        {
            this.commonGaugesRepo = commonGaugesRepo;  
            this.commonIvaCodesRepo= commonIvaCodesRepo;
            this.commonBankAccountsRepo = commonBankAccountsRepo;
        }


        #region Gauges
        public async Task<PageResponse<CommonGaugeDto>> GetCommonGaugesAsync(PageRequest request )
        {
            var entities = await commonGaugesRepo.GetAsync(request);
            var dtos = entities.ToModel<PageResponse<CommonGaugeDto>>();
            return dtos;
        }

        public async Task<CommonGaugeDto> GetCommonGaugeByIdAsync(long id)
        {
            var entity = await commonGaugesRepo.GetAsync(id,new GetRequest());
            var dto = entity.ToModel<CommonGaugeDto>();
            return dto;
        }

        public async Task<long> CreateCommonGaugeAsync(CommonGaugeDto dto)
        {
            var entity = dto.ToEntity<Gauge>();
            var reponse = await commonGaugesRepo.CreateAsync(entity);
            return entity.Id;
        }

        public async Task<long> UpdateCommonGaugeAsync(long id, CommonGaugeDto dto)
        {
            var entity = dto.ToEntity<Gauge>();
            var response = await commonGaugesRepo.UpdateAsync(entity);
            return response.Id;

        }

        public async Task<bool> DeleteCommonGaugeAsync(long id)
        {
            await commonGaugesRepo.DeleteAsync(id);

            return true;
        }

        #endregion

        #region IvaCodes
        public async Task<PageResponse<CommonIvaCodeDto>> GetCommonIvaCodesAsync(PageRequest request)
        {
            var entities = await commonIvaCodesRepo.GetAsync(request);
            var dtos = entities.ToModel<PageResponse<CommonIvaCodeDto>>();
            return dtos;
        }

        public async Task<CommonIvaCodeDto> GetCommonIvaCodeByIdAsync(long id)
        {
            var entity = await commonIvaCodesRepo.GetAsync(id, new GetRequest());
            var dto = entity.ToModel<CommonIvaCodeDto>();
            return dto;
        }

        public async Task<long> CreateCommonIvaCodeAsync(CommonIvaCodeDto dto)
        {
            var entity = dto.ToEntity<IvaCode>();
            var reponse = await commonIvaCodesRepo.CreateAsync(entity);
            return entity.Id;
        }

        public async Task<long> UpdateCommonIvaCodeAsync(long id, CommonIvaCodeDto dto)
        {
            var entity = dto.ToEntity<IvaCode>();
            var response = await commonIvaCodesRepo.UpdateAsync(entity);
            return response.Id;

        }

        public async Task<bool> DeleteCommonIvaCodeAsync(long id)
        {
            await commonIvaCodesRepo.DeleteAsync(id);

            return true;
        }

        #endregion

        #region BankAccounts
        public async Task<PageResponse<CommonBankAccountDto>> GetCommonBankAccountsAsync(PageRequest request)
        {
            var entities = await commonBankAccountsRepo.GetAsync(request);
            var dtos = entities.ToModel<PageResponse<CommonBankAccountDto>>();
            return dtos;
        }

        public async Task<CommonBankAccountDto> GetCommonBankAccountByIdAsync(long id)
        {
            var entity = await commonBankAccountsRepo.GetAsync(id, new GetRequest());
            var dto = entity.ToModel<CommonBankAccountDto>();
            return dto;
        }

        public async Task<long> CreateCommonBankAccountAsync(CommonBankAccountDto dto)
        {
            var entity = dto.ToEntity<BankAccount>();
            var reponse = await commonBankAccountsRepo.CreateAsync(entity);
            return entity.Id;
        }

        public async Task<long> UpdateCommonBankAccountAsync(long id, CommonBankAccountDto dto)
        {
            var entity = dto.ToEntity<BankAccount>();
            var response = await commonBankAccountsRepo.UpdateAsync(entity);
            return response.Id;

        }

        public async Task<bool> DeleteCommonBankAccountAsync(long id)
        {
            await commonBankAccountsRepo.DeleteAsync(id);

            return true;
        }

        #endregion
    }
}
