using GaCloudServer.BusinnessLogic.DTOs.Base;

namespace GaCloudServer.BusinnessLogic.Dtos.Resources.Shortcuts
{
    public class QuickLinkDto : GenericDto
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Descrizione { get; set; }
        public string Link { get; set; }
        public string Icon { get; set; }
        public int Order { get; set; }
    }

    public class QuickLinksDto : GenericPagedListDto<QuickLinkDto>
    {
    }
}
