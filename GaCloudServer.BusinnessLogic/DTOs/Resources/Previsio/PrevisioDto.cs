using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using GaCloudServer.BusinnessLogic.DTOs.Base;

namespace GaCloudServer.BusinnessLogic.Dtos.Resources.Previsio
{
    #region PrevisioOdsLetture
    public class PrevisioOdsLetturaDto : GenericListEntity
    {
        public string IdServizio { get; set; }
        public string FileName { get; set; }
        public string ErrDescription { get; set; }
        public bool Elaborato { get; set; }
    }

    public class PrevisioOdsLettureDto : GenericPagedListDto<PrevisioOdsLetturaDto>
    {
    }

    #endregion
}


