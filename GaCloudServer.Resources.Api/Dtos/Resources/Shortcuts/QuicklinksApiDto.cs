using GaCloudServer.BusinnessLogic.DTOs.Base;

namespace GaCloudServer.Resources.Api.Dtos.Resources.Shortcuts
{
    public class QuickLinkApiDto : GenericDto
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Descrizione { get; set; }
        public string Link { get; set; }
        public string Icon { get; set; }
    }

    public class QuickLinksApiDto : GenericPagedListDto<QuickLinkApiDto>
    {
    }
}
