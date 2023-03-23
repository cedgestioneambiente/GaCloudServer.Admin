
using GaCloudServer.Resources.Api.Dtos.Base;

namespace GaCloudServer.Resources.Api.ApiDtos.Resources.Dashboard
{

    public class DashboardTypeApiDto : GenericApiDto
    {
        public string Descrizione { get; set; }
        public string Type { get; set; }

        public DashboardTypeApiDto() { }
    }

    public class DashboardTypesApiDto : GenericPagedListApiDto<DashboardTypeApiDto>
    {

        public DashboardTypesApiDto() { }
    }

    public class DashboardSectionApiDto : GenericListApiDto
    {
        public DashboardSectionApiDto()
        {
        }
    }

    public class DashboardSectionsApiDto : GenericPagedListApiDto<DashboardSectionApiDto>
    {
        public DashboardSectionsApiDto() { }
    }

    public class DashboardItemApiDto : GenericApiDto
    {
        public long DashboardSectionId { get; set; }
        public long DashboardTypeId { get; set; }
        public string Title { get; set; }
        public string Descrizione { get; set; }
        public string Script { get; set; }
        public string Roles { get; set; }

        public DashboardItemApiDto() { }
    }

    public class DashboardItemsApiDto : GenericPagedListApiDto<DashboardItemApiDto>
    {

        public DashboardItemsApiDto() { }
    }

    public class DashboardStoreApiDto : GenericApiDto
    {
        public string Descrizione { get; set; }
        public string Script { get; set; }
        public long QueryBuilderSectionId { get; set; }
        public string Roles { get; set; }

        public DashboardStoreApiDto() { }
    }

    public class DashboardStoresApiDto : GenericPagedListApiDto<DashboardStoreApiDto>
    {

        public DashboardStoresApiDto() { }
    }

    public class DashboardQuery
    {
        public string query { get; set; }
    }

}
