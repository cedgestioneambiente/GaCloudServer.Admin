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
        #region CdrCentro
        Task<CdrCentriDto> GetGaCdrCentriAsync(int page = 1, int pageSize = 10, bool all = true);
        Task<CdrCentroDto> GetGaCdrCentroByIdAsync(long id);

        Task<long> AddGaCdrCentroAsync(CdrCentroDto dto);
        Task<long> UpdateGaCdrCentroAsync(CdrCentroDto dto);

        Task<bool> DeleteGaCdrCentroAsync(long id);

        #region Functions
        Task<bool> CheckIsUniqueGaCdrCentroAsync(long id, string centro);
        #endregion

        #endregion

        #region CdrCer
        Task<CdrCersDto> GetGaCdrCersAsync(int page = 1, int pageSize = 10);
        Task<CdrCerDto> GetGaCdrCerByIdAsync(long id);

        Task<long> AddGaCdrCerAsync(CdrCerDto dto);
        Task<long> UpdateGaCdrCerAsync(CdrCerDto dto);

        Task<bool> DeleteGaCdrCerAsync(long id);

        #region Functions
        Task<bool> CheckIsUniqueGaCdrCerAsync(long id, string cer);
        #endregion

        #endregion

        #region CdrCerDettaglio
        Task<CdrCersDettagliDto> GetGaCdrCersDettagliAsync(long cerId, int page = 1, int pageSize = 10);
        Task<CdrCerDettaglioDto> GetGaCdrCerDettaglioByIdAsync(long id);

        Task<long> AddGaCdrCerDettaglioAsync(CdrCerDettaglioDto dto);
        Task<long> UpdateGaCdrCerDettaglioAsync(CdrCerDettaglioDto dto);

        Task<bool> DeleteGaCdrCerDettaglioAsync(long id);
        #endregion

        #region CdrCerOnCentro

        #region Functions
        Task<bool> UpdateGaCdrCerOnCentroAsync(long cerId, long centroId);
        #endregion

        #region Views
        //Task<PagedList<ViewGaCdrCerOnCentro>> GetViewGaCdrCersOnCentroAsync(long id);
        #endregion

        #endregion

        #region CdrComune
        Task<CdrComuniDto> GetGaCdrComuniAsync(int page = 1, int pageSize = 0);
        Task<CdrComuneDto> GetGaCdrComuneByIdAsync(long id);

        Task<long> AddGaCdrComuneAsync(CdrComuneDto dto);
        Task<long> UpdateGaCdrComuneAsync(CdrComuneDto dto);

        Task<bool> DeleteGaCdrComuneAsync(long id);

        #region Functions
        Task<bool> CheckIsUniqueGaCdrComuneAsync(long id, string comune);
        #endregion

        #region Views
        //Task<PagedList<ViewGaCdrComune>> GetViewGaCdrComuniAsync(int page = 1, int pageSize = 0);

        #endregion

        #endregion

        #region CdrComuneOnCentro

        #region Functions
        Task<bool> UpdateGaCdrComuneOnCentroAsync(long comuneId, long centroId);
        #endregion

        #region Views
        //Task<PagedList<ViewGaCdrComuneOnCentro>> GetViewGaCdrComuniOnCentroAsync(long id);
        #endregion

        #endregion
    }
}
