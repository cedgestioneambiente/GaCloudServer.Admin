using GaCloudServer.BusinnessLogic.DTOs.Base;

namespace GaCloudServer.BusinnessLogic.Dtos.Resources.Dashboard
{
    public class DashboardTypeDto:GenericDto
    {
        public string Descrizione { get; set; }
        public string Type { get; set; }

        public DashboardTypeDto() { }
    }

    public class DashboardTypesDto : GenericPagedListDto<DashboardTypeDto>
    {

        public DashboardTypesDto() { }
    }

    public class DashboardSectionDto : GenericListDto
    {
        public DashboardSectionDto()
        {
        }
    }

    public class DashboardSectionsDto : GenericPagedListDto<DashboardSectionDto>
    {
        public DashboardSectionsDto() { }
    }

    public class DashboardItemDto : GenericDto
    {
        public long DashboardSectionId { get; set; }
        public long DashboardTypeId { get; set; }
        public string Title { get; set; }
        public string Descrizione { get; set; }
        public string Script { get; set; }
        public string Roles { get; set; }

        public DashboardItemDto() { }
    }

    public class DashboardItemsDto : GenericPagedListDto<DashboardItemDto>
    {

        public DashboardItemsDto() { }
    }

    public class DashboardStoreDto : GenericDto
    {
        public string Descrizione { get; set; }
        public string Script { get; set; }
        public long QueryBuilderSectionId { get; set; }
        public string Roles { get; set; }

        public DashboardStoreDto() { }
    }

    public class DashboardStoresDto : GenericPagedListDto<DashboardStoreDto>
    {

        public DashboardStoresDto() { }
    }


}

