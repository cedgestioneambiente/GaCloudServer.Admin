using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Preventivi.Views;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Mezzi;
using GaCloudServer.BusinnessLogic.DTOs.Resources.Preventivi;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Services.Interfaces
{
    public interface IGaPreventiviService
    {
        #region PreventiviAnticipiTipologie
        Task<PreventiviAnticipiTipologieDto> GetGaPreventiviAnticipiTipologieAsync(int page = 1, int pageSize = 0);
        Task<PreventiviAnticipoTipologiaDto> GetGaPreventiviAnticipoTipologiaByIdAsync(long id);

        Task<long> AddGaPreventiviAnticipoTipologiaAsync(PreventiviAnticipoTipologiaDto dto);
        Task<long> UpdateGaPreventiviAnticipoTipologiaAsync(PreventiviAnticipoTipologiaDto dto);

        Task<bool> DeleteGaPreventiviAnticipoTipologiaAsync(long id);

        #region Functions
        Task<bool> ValidateGaPreventiviAnticipoTipologiaAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaPreventiviAnticipoTipologiaAsync(long id);
        #endregion

        #endregion

        #region PreventiviAnticipiPagamenti
        Task<PreventiviAnticipiPagamentiDto> GetGaPreventiviAnticipiPagamentiAsync(int page = 1, int pageSize = 0);
        Task<PreventiviAnticipoPagamentoDto> GetGaPreventiviAnticipoPagamentoByIdAsync(long id);

        Task<long> AddGaPreventiviAnticipoPagamentoAsync(PreventiviAnticipoPagamentoDto dto);
        Task<long> UpdateGaPreventiviAnticipoPagamentoAsync(PreventiviAnticipoPagamentoDto dto);

        Task<bool> DeleteGaPreventiviAnticipoPagamentoAsync(long id);

        #region Functions
        Task<bool> ValidateGaPreventiviAnticipoPagamentoAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaPreventiviAnticipoPagamentoAsync(long id);
        #endregion

        #endregion

        #region PreventiviAnticipi
        Task<PreventiviAnticipiDto> GetGaPreventiviAnticipiAsync(int page = 1, int pageSize = 0);
        Task<PreventiviAnticipoDto> GetGaPreventiviAnticipoByIdAsync(long id);

        Task<long> AddGaPreventiviAnticipoAsync(PreventiviAnticipoDto dto);
        Task<long> UpdateGaPreventiviAnticipoAsync(PreventiviAnticipoDto dto);

        Task<bool> DeleteGaPreventiviAnticipoAsync(long id);

        #region Functions
        Task<bool> ValidateGaPreventiviAnticipoAsync(long id, string numero);
        Task<bool> ChangeStatusGaPreventiviAnticipoAsync(long id);
        Task<bool> SetGaPreventiviAnticipoPagatoAsync(long id);
        #endregion

        #region Views
        Task<PagedList<ViewGaPreventiviAnticipi>> GetViewGaPreventiviAnticipiAsync();
        #endregion

        #endregion

        #region PreventiviAnticipiAllegati
        Task<PreventiviAnticipiAllegatiDto> GetGaPreventiviAnticipiAllegatiByAnticipoAsync(long preventiviAnticipoId);
        Task<PreventiviAnticipoAllegatoDto> GetGaPreventiviAnticipoAllegatoByIdAsync(long id);

        Task<long> AddGaPreventiviAnticipoAllegatoAsync(PreventiviAnticipoAllegatoDto dto);
        Task<long> UpdateGaPreventiviAnticipoAllegatoAsync(PreventiviAnticipoAllegatoDto dto);

        Task<bool> DeleteGaPreventiviAnticipoAllegatoAsync(long id);

        #region Functions
        Task<bool> ValidateGaPreventiviAnticipoAllegatoAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaPreventiviAnticipoAllegatoAsync(long id);
        #endregion

        #endregion
    }
}

