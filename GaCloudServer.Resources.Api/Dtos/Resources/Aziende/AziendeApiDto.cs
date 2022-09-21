using GaCloudServer.Resources.Api.Dtos.Base;
using System.ComponentModel.DataAnnotations;

namespace GaCloudServer.Resources.Api.Dtos.Aziende
{
    #region AziendeLista
    public class AziendeListaApiDto : GenericListApiDto
    {
    }

    public class AziendeListeApiDto : GenericPagedListApiDto<AziendeListaApiDto>
    {
    }

    #endregion

}
