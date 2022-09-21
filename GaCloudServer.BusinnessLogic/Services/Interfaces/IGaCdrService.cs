using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Cdr.Views;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Cdr;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;
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

        #region Views
        //Task<PagedList<ViewGaCdrComuni>> GetViewGaCdrComuniAsync(bool all = true);
        #endregion

        #endregion

        #region GaCdrCers
        Task<CdrCersDto> GetGaCdrCersAsync(int page = 1, int pageSize = 0);
        Task<CdrCerDto> GetGaCdrCerByIdAsync(long id);

        Task<long> AddGaCdrCerAsync(CdrCerDto dto);
        Task<long> UpdateGaCdrCerAsync(CdrCerDto dto);

        Task<bool> DeleteGaCdrCerAsync(long id);

        #region Functions
        Task<bool> ValidateGaCdrCerAsync(long id, string centro);
        Task<bool> ChangeStatusGaCdrCerAsync(long id);
        #endregion

        #endregion

        #region GaCdrCersDettagli
        Task<CdrCersDettagliDto> GetGaCdrCersDettagliAsync(int page = 1, int pageSize = 0);
        Task<CdrCerDettaglioDto> GetGaCdrCerDettaglioByIdAsync(long id);

        Task<long> AddGaCdrCerDettaglioAsync(CdrCerDettaglioDto dto);
        Task<long> UpdateGaCdrCerDettaglioAsync(CdrCerDettaglioDto dto);

        Task<bool> DeleteGaCdrCerDettaglioAsync(long id);

        #region Functions
        Task<bool> ValidateGaCdrCerDettaglioAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaCdrCerDettaglioAsync(long id);
        #endregion

        #endregion

        #region GaCdrCersOnCentri

        Task<CdrCersDto> GetGaCdrCersOnCentriAsync(long id);
        Task<bool> UpdateGaCdrCerOnCentroAsync(long cerId, long centroId);

        #region Views
        Task<PagedList<ViewGaCdrCersOnCentri>> GetViewGaCdrCersOnCentriAsync(long id);
        #endregion

        #endregion

        #region GaCdrComuniOnCentri
        Task<bool> UpdateGaCdrComuneOnCentroAsync(long comuneId, long centroId);

        #region Views
        Task<PagedList<ViewGaCdrComuniOnCentri>> GetViewGaCdrComuniOnCentriAsync(long id);
        #endregion

        #endregion

        #region GaCdrConferimenti
        Task<CdrConferimentiDto> GetGaCdrConferimentiAsync(int page = 1, int pageSize = 0);
        Task<CdrConferimentoDto> GetGaCdrConferimentoByIdAsync(long id);

        Task<long> AddGaCdrConferimentoAsync(CdrConferimentoDto dto);
        Task<long> UpdateGaCdrConferimentoAsync(CdrConferimentoDto dto);

        Task<bool> DeleteGaCdrConferimentoAsync(long id);

        #region Functions
        Task<int> ValidateGaCdrConferimentoAsync(CdrConferimentoDto dto);
        #endregion

        #endregion

    }
}
