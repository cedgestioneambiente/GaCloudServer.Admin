using GaCloudServer.BusinnessLogic.Dtos.Resources.Comunicati;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.BusinnessLogic.Services.Interfaces
{
    public interface IGaComunicatiService
    {
        #region GaComunicatiDocumenti
        Task<ComunicatiDocumentiDto> GetGaComunicatiDocumentiAsync(int page = 1, int pageSize = 0);
        Task<ComunicatiDocumentoDto> GetGaComunicatiDocumentoByIdAsync(long id);

        Task<long> AddGaComunicatiDocumentoAsync(ComunicatiDocumentoDto dto);
        Task<long> UpdateGaComunicatiDocumentoAsync(ComunicatiDocumentoDto dto);

        Task<bool> DeleteGaComunicatiDocumentoAsync(long id);

        #region Functions
        Task<bool> ValidateGaComunicatiDocumentoAsync(long id, string numero);
        Task<bool> ChangeStatusGaComunicatiDocumentoAsync(long id);
        #endregion

        #endregion

    }
}
