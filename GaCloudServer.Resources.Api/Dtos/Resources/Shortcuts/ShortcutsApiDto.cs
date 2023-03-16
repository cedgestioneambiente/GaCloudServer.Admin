using GaCloudServer.BusinnessLogic.DTOs.Base;

namespace GaCloudServer.Resources.Api.Dtos.Resources.Shortcuts
{

        public class ShortcutLinkApiDto : GenericDto
        {
            public string Link { get; set; }
            public string Descrizione { get; set; }
            public string Roles { get; set; }

            public ShortcutLinkApiDto() { }
        }

        public class ShortcutLinksApiDto : GenericPagedListDto<ShortcutLinkApiDto>
        {

            public ShortcutLinksApiDto() { }
        }

        public class ShortcutItemApiDto : GenericDto
        {
            public string Label { get; set; }
            public string? Description { get; set; }
            public string Icon { get; set; }
            public long ShortcutLinkId { get; set; }
            public bool UseRouter { get; set; }
            public string UserId { get; set; }

            public ShortcutItemApiDto()
            {
            }
        }

        public class ShortcutItemsApiDto : GenericPagedListDto<ShortcutItemApiDto>
        {
            public ShortcutItemsApiDto() { }
        }
    
}
