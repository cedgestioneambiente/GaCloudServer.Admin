using GaCloudServer.BusinnessLogic.DTOs.Base;

namespace GaCloudServer.BusinnessLogic.Dtos.Resources.Contratti
{
    #region Contratti Permessi
    public class ContrattiPermessoDto : GenericListDto
    {
    }

    public class ContrattiPermessiDto : GenericPagedListDto<ContrattiPermessoDto>
    {
    }

    #endregion

    #region Contratti Servizi
    public class ContrattiServizioDto : GenericListDto
    {
    }

    public class ContrattiServiziDto : GenericPagedListDto<ContrattiServizioDto>
    {
    }

    #endregion

    #region Contratti Tipologie
    public class ContrattiTipologiaDto : GenericListDto
    {
    }

    public class ContrattiTipologieDto : GenericPagedListDto<ContrattiTipologiaDto>
    {
    }

    #endregion

    #region Contratti UtentiOnPermessi
    public class ContrattiUtenteOnPermessoDto : GenericListDto
    {
        public long ContrattiPermessoId { get; set; }

    }

    public class ContrattiUtentiOnPermessiDto : GenericPagedListDto<ContrattiUtenteOnPermessoDto>
    {
    }

    #endregion
}
