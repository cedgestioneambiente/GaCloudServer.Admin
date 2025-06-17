using GaCloudServer.BusinnessLogic.DTOs.Base;

namespace GaCloudServer.BusinnessLogic.DTOs.Resources.Identity
{

    public class ViewUserIdentityDto : GenericDto
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }

    public class ViewUserIdentitiesDto : GenericPagedListDto<ViewUserIdentityDto>
    {

    }

}
