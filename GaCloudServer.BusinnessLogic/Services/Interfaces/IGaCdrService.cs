using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Cdr.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Models;
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
        Task<CdrCersDettagliDto> GetGaCdrCersDettagliByCerIdAsync(long cerId);
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

        #region Views
        PagedList<ViewGaCdrConferimenti> GetViewGaCdrConferimentiQueryable(GridOperationsModel filterParams);
        Task<PagedList<ViewGaCdrConferimenti>> GetViewGaCdrConferimentiAsync(string numCon, string partita);
        #endregion
        #endregion

        #region CdrRichiesteViaggi
        Task<CdrRichiesteViaggiDto> GetGaCdrRichiesteViaggiAsync(int page = 1, int pageSize = 10);
        Task<CdrRichiestaViaggioDto> GetGaCdrRichiestaViaggioByIdAsync(long id);

        Task<long> AddGaCdrRichiestaViaggioAsync(CdrRichiestaViaggioDto dto);
        Task<long> UpdateGaCdrRichiestaViaggioAsync(CdrRichiestaViaggioDto dto);

        Task<bool> DeleteGaCdrRichiestaViaggioAsync(long id);

        #region Functions
        Task<bool> SetGaCdrRichiestaViaggioSendedAsync(long id);
        #endregion

        #region Views
        PagedList<ViewGaCdrRichiesteViaggi> GetViewGaCdrRichiesteViaggiQueryable(GridOperationsModel filterParams);
        Task<PagedList<ViewGaCdrRichiesteViaggi>> GetViewGaCdrRichiesteViaggi(long centroId, bool all);
        Task<PagedList<ViewGaCdrRichiesteViaggi>> GetViewGaCdrRichiesteViaggi(long centroId, bool all, int currentPage);
        Task<ViewGaCdrRichiesteViaggi> GetViewGaCdrRichiestaViaggio(long id);

        #endregion

        #endregion

        #region GaCdrStatiRichieste
        Task<CdrStatiRichiesteDto> GetGaCdrStatiRichiesteAsync(int page = 1, int pageSize = 0);
        Task<CdrStatoRichiestaDto> GetGaCdrStatoRichiestaByIdAsync(long id);

        Task<long> AddGaCdrStatoRichiestaAsync(CdrStatoRichiestaDto dto);
        Task<long> UpdateGaCdrStatoRichiestaAsync(CdrStatoRichiestaDto dto);

        Task<bool> DeleteGaCdrStatoRichiestaAsync(long id);

        #region Functions
        Task<bool> ValidateGaCdrStatoRichiestaAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaCdrStatoRichiestaAsync(long id);
        #endregion

        #endregion

        #region App
        Task<bool> CheckGaCdrCanUse(string comune, long centroId);
        #endregion

    }
}
