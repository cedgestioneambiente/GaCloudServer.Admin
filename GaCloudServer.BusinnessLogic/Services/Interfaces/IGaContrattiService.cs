using GaCloudServer.BusinnessLogic.Dtos.Resources.Contratti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.BusinnessLogic.Services.Interfaces
{
    public interface IGaContrattiService
    {
        #region GaContrattiPermessi
        Task<ContrattiPermessiDto> GetGaContrattiPermessiAsync(int page = 1, int pageSize = 0);
        Task<ContrattoPermessoDto> GetGaContrattoPermessoByIdAsync(long id);

        Task<long> AddGaContrattoPermessoAsync(ContrattoPermessoDto dto);
        Task<long> UpdateGaContrattoPermessoAsync(ContrattoPermessoDto dto);

        Task<bool> DeleteGaContrattoPermessoAsync(long id);

        #region Functions
        Task<bool> CheckIsUniqueGaContrattoPermessoAsync(long id, string descrizione);
        #endregion

        #endregion

        #region GaContrattiServizi
        Task<ContrattiServiziDto> GetGaContrattiServiziAsync(int page = 1, int pageSize = 0);
        Task<ContrattoServizioDto> GetGaContrattoServizioByIdAsync(long id);

        Task<long> AddGaContrattoServizioAsync(ContrattoServizioDto dto);
        Task<long> UpdateGaContrattoServizioAsync(ContrattoServizioDto dto);

        Task<bool> DeleteGaContrattoServizioAsync(long id);

        #region Functions
        Task<bool> CheckIsUniqueGaContrattoServizioAsync(long id, string descrizione);
        #endregion

        #endregion

        #region GaContrattiTipologie
        Task<ContrattiTipologieDto> GetGaContrattiTipologieAsync(int page = 1, int pageSize = 0);
        Task<ContrattoTipologiaDto> GetGaContrattoTipologiaByIdAsync(long id);

        Task<long> AddGaContrattoTipologiaAsync(ContrattoTipologiaDto dto);
        Task<long> UpdateGaContrattoTipologiaAsync(ContrattoTipologiaDto dto);

        Task<bool> DeleteGaContrattoTipologiaAsync(long id);

        #region Functions
        Task<bool> CheckIsUniqueGaContrattoTipologiaAsync(long id, string descrizione);
        #endregion

        #endregion

        #region GaContrattiUtentiOnPermessi

        #region Functions
        Task<bool> UpdateGaContrattiUtenteOnPermessoAsync(string utenteId, long permessoId);
        #endregion

        #endregion
    }
}
