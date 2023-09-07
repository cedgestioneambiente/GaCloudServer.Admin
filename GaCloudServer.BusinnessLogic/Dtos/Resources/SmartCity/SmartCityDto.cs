using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.BackOffice.Views;
using GaCloudServer.BusinnessLogic.DTOs.Base;

namespace GaCloudServer.BusinnessLogic.Dtos.Resources.SmartCity
{
    #region SmartCityPermissions
    public class SmartCityPermissionDto:GenericDto
    {
        public string UserId { get; set; }
        public string Permissions { get; set; }
    }

    public class SmartCityPermissionsDto : GenericPagedListDto<SmartCityPermissionDto>
    {
    }
    #endregion

}
