using GaCloudServer.BusinnessLogic.DTOs.Base;

namespace GaCloudServer.BusinnessLogic.Dtos.Resources.Aziende
{
    #region AziendeListe
    public class AziendeListaDto : GenericListDto
    {
        public string? DescrizioneBreve { get; set; }
        public bool ContactCenterTicket { get; set; }
    }

    public class AziendeListeDto : GenericPagedListDto<AziendeListaDto>
    {
    }

    #endregion
}