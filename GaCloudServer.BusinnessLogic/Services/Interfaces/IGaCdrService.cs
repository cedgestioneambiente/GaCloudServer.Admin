using GaCloudServer.BusinnessLogic.DTOs.Cdr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.BusinnessLogic.Services.Interfaces
{
    public interface IGaCdrService
    {
        #region GaCdrCentri
        Task<CdrCentriDto> GetGaCdrCentriAsync(int page = 1, int pageSize = 0);
        Task<CdrCentroDto> GetGaCdrCentroByIdAsync(long id);

        Task<long> AddGaCdrCentroAsync(CdrCentroDto dto);
        Task<long> UpdateGaCdrCentroAsync(CdrCentroDto dto);

        Task<bool> DeleteGaCdrCentroAsync(long id);

        #region Functions
        Task<bool> ValidateGaCdrCentroAsync(long id, string centro);
        Task<bool> ChangeStatusGaCdrCentroAsync(long id);
        #endregion

        #endregion

        #region GaCdrComuni
        Task<CdrComuniDto> GetGaCdrComuniAsync(int page = 1, int pageSize = 0);
        Task<CdrComuneDto> GetGaCdrComuneByIdAsync(long id);

        Task<long> AddGaCdrComuneAsync(CdrComuneDto dto);
        Task<long> UpdateGaCdrComuneAsync(CdrComuneDto dto);

        Task<bool> DeleteGaCdrComuneAsync(long id);

        #region Functions
        Task<bool> ValidateGaCdrComuneAsync(long id, string centro);
        Task<bool> ChangeStatusGaCdrComuneAsync(long id);
        #endregion

        #endregion
    }
}
