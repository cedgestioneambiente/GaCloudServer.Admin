using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Autorizzazioni.Views;
using GaCloudServer.BusinnessLogic.DTOs.Autorizzazioni;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.BusinnessLogic.Services.Interfaces
{
    public interface IGaAutorizzazioniService
    {
        #region GaAutorizzazioniTipi
        Task<AutorizzazioniTipiDto> GetGaAutorizzazioniTipiAsync(int page = 1, int pageSize = 0);
        Task<AutorizzazioniTipoDto> GetGaAutorizzazioniTipoByIdAsync(long id);

        Task<long> AddGaAutorizzazioniTipoAsync(AutorizzazioniTipoDto dto);
        Task<long> UpdateGaAutorizzazioniTipoAsync(AutorizzazioniTipoDto dto);

        Task<bool> DeleteGaAutorizzazioniTipoAsync(long id);

        #region Functions
        Task<bool> ValidateGaAutorizzazioniTipoAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaAutorizzazioniTipoAsync(long id);
        #endregion

        #endregion

        #region GaAutorizzazioniDocumenti
        Task<AutorizzazioniDocumentiDto> GetGaAutorizzazioniDocumentiAsync(int page = 1, int pageSize = 0);
        Task<AutorizzazioniDocumentoDto> GetGaAutorizzazioniDocumentoByIdAsync(long id);

        Task<long> AddGaAutorizzazioniDocumentoAsync(AutorizzazioniDocumentoDto dto);
        Task<long> UpdateGaAutorizzazioniDocumentoAsync(AutorizzazioniDocumentoDto dto);

        Task<bool> DeleteGaAutorizzazioniDocumentoAsync(long id);

        #region Functions
        Task<bool> ValidateGaAutorizzazioniDocumentoAsync(long id, string descrizione);
        Task<bool> ChangeStatusGaAutorizzazioniDocumentoAsync(long id);
        #endregion

        #region Views
        Task<PagedList<ViewGaAutorizzazioniDocumenti>> GetViewGaAutorizzazioniDocumentiAsync(bool all=true);
        #endregion

        #endregion

        #region GaAutorizzazioniAllegati
        Task<AutorizzazioniAllegatiDto> GetGaAutorizzazioniAllegatiByDocumentoIdAsync(long allegatiDocumentoId);
        Task<AutorizzazioniAllegatoDto> GetGaAutorizzazioniAllegatoByIdAsync(long id);

        Task<long> AddGaAutorizzazioniAllegatoAsync(AutorizzazioniAllegatoDto dto);
        Task<long> UpdateGaAutorizzazioniAllegatoAsync(AutorizzazioniAllegatoDto dto);

        Task<bool> DeleteGaAutorizzazioniAllegatoAsync(long id);
        #endregion


    }
}
