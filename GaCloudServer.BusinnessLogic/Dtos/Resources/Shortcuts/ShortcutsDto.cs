using GaCloudServer.BusinnessLogic.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.BusinnessLogic.Dtos.Resources.Shortcuts
{
    public class ShortcutLinkDto:GenericDto
    {
        public string Link { get; set; }
        public string Descrizione { get; set; }
        public string Roles { get; set; }

        public ShortcutLinkDto() { }
    }

    public class ShortcutLinksDto:GenericPagedListDto<ShortcutLinkDto>
    {

        public ShortcutLinksDto() { }
    }

    public class ShortcutItemDto:GenericDto
    {
        public string Label { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public long ShortcutLinkId { get; set; }
        public bool UseRouter { get; set; }
        public string UserId { get; set; }

        public ShortcutItemDto()
        {
        }
    }

    public class ShortcutItemsDto:GenericPagedListDto<ShortcutItemDto>
    {
        public ShortcutItemsDto() { }
    }
}

