using GaCloudServer.Resources.Api.Dtos.Base;

namespace GaCloudServer.BusinnessLogic.Api.Dtos.Resources.System
{
    #region SystemVersions
    public class SystemVersionApiDto : GenericApiDto
    {
        public string Versione { get; set; }
        public DateTime DataRilascio { get; set; }
        public string? NuoveFunzionalita { get; set; }
        public string? Modifiche { get; set; }
    }

    public class SystemVersionsApiDto : GenericPagedListApiDto<SystemVersionApiDto>
    {
    }

    #endregion
}

