using GaCloudServer.BusinnessLogic.DTOs.Base;

namespace GaCloudServer.BusinnessLogic.Dtos.Resources.System
{
    #region SystemVersions
    public class SystemVersionDto : GenericDto
    {
        public string Versione { get; set; }
        public DateTime DataRilascio { get; set; }
        public string NuoveFunzionalita { get; set; }
        public string Modifiche { get; set; }
    }

    public class SystemVersionsDto : GenericPagedListDto<SystemVersionDto>
    {
    }

    #endregion
}