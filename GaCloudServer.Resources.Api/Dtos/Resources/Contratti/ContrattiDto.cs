using GaCloudServer.Resources.Api.Dtos.Base;
using System.ComponentModel.DataAnnotations;

namespace GaCloudServer.Resources.Api.Dtos.Contratti
{
    #region Contratti Permessi
    public class ContrattiPermessoApiDto : GenericListApiDto
    {
    }

    public class ContrattiPermessiApiDto : GenericPagedListApiDto<ContrattiPermessoApiDto>
    {
    }

    #endregion

    #region Contratti Servizi
    public class ContrattiServizioApiDto : GenericListApiDto
    {
    }

    public class ContrattiServiziApiDto : GenericPagedListApiDto<ContrattiServizioApiDto>
    {
    }

    #endregion

    #region Contratti Tipologie
    public class ContrattiTipologiaApiDto : GenericListApiDto
    {
    }

    public class ContrattiTipologieApiDto : GenericPagedListApiDto<ContrattiTipologiaApiDto>
    {
    }

    #endregion

    #region Contratti UtentiOnPermessi
    public class ContrattiUtenteOnPermessoApiDto : GenericListApiDto
    {
        public long ContrattiPermessoId { get; set; }

    }

    public class ContrattiUtentiOnPermessiApiDto : GenericPagedListApiDto<ContrattiUtenteOnPermessoApiDto>
    {
    }

    #endregion
}
