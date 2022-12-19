using GaCloudServer.Resources.Api.Dtos.Base;

namespace GaCloudServer.Resources.Api.Dtos.Aziende
{
    #region AziendeLista
    public class AziendeListaApiDto : GenericListApiDto
    {
        public string? DescrizioneBreve { get; set; }
        public bool ContactCenterTicket { get; set; }
    }

    public class AziendeListeApiDto : GenericPagedListApiDto<AziendeListaApiDto>
    {
    }

    #endregion

}
