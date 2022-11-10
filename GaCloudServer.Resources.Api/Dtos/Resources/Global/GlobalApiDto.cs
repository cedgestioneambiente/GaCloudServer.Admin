using GaCloudServer.Resources.Api.Dtos.Base;

namespace GaCloudServer.Resources.Api.Dtos.Resources.Global
{
    #region GlobalSedi
    public class GlobalSedeApiDto : GenericListApiDto
    {
    }

    public class GlobalSediApiDto : GenericPagedListApiDto<GlobalSedeApiDto>
    {
    }

    #endregion

    #region GlobalCentriCosti
    public class GlobalCentroCostoApiDto : GenericListApiDto
    {
    }

    public class GlobalCentriCostiApiDto : GenericPagedListApiDto<GlobalCentroCostoApiDto>
    {
    }

    #endregion

    #region GlobalSettori
    public class GlobalSettoreApiDto : GenericListApiDto
    {
    }

    public class GlobalSettoriApiDto : GenericPagedListApiDto<GlobalSettoreApiDto>
    {
    }

    #endregion
}
