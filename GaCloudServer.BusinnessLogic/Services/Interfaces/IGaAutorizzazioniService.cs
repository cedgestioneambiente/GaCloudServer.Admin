using GaCloudServer.BusinnessLogic.DTOs.Autorizzazioni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.BusinnessLogic.Services.Interfaces
{
    public interface IGaAutorizzazioniService
    {
        #region GaAutorizzazioniTipo
        Task<AutorizzazioniTipiDto> GetGaAutorizzazioniTipiAsync(int page = 1, int pageSize = 0);
        Task<AutorizzazioneTipoDto> GetGaAutorizzazioneTipoByIdAsync(long id);

        Task<long> AddGaAutorizzazioneTipoAsync(AutorizzazioneTipoDto dto);
        Task<long> UpdateGaAutorizzazioneTipoAsync(AutorizzazioneTipoDto dto);

        Task<bool> DeleteGaAutorizzazioneTipoAsync(long id);

        #region Functions
        Task<bool> CheckIsUniqueGaAutorizzazioneTipoAsync(long id, string descrizione);
        #endregion

        #endregion
    }
}
