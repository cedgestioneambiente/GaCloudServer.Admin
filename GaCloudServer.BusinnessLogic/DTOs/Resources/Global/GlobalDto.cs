using GaCloudServer.BusinnessLogic.DTOs.Base;
using System.ComponentModel.DataAnnotations;

namespace GaCloudServer.BusinnessLogic.DTOs.Resources.Global
{
        #region GlobalSedi
        public class GlobalSedeDto : GenericListDto
        {
        }

        public class GlobalSediDto : GenericPagedListDto<GlobalSedeDto>
        {
        }

    #endregion

        #region GlobalCentriCosti
        public class GlobalCentroCostoDto : GenericListDto
        {
        }

        public class GlobalCentriCostiDto : GenericPagedListDto<GlobalCentroCostoDto>
        {
        }

        #endregion
}
