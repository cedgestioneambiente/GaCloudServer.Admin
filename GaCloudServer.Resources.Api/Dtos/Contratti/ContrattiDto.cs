using System;
using System.Collections.Generic;
using System.Text;

namespace GaCloudServer.Resources.Api.Dtos.Contratti
{
    #region Contratti Permessi
    public class ContrattoPermessoApiDto
    {
        public long Id { get; set; }
        public string Descrizione { get; set; }
        public bool Disabled { get; set; }

        public ContrattoPermessoApiDto() {
            Descrizione = string.Empty;
        }
    }

    public class ContrattiPermessiApiDto
    {
        public ContrattiPermessiApiDto()
        {
            Data = new List<ContrattoPermessoApiDto>();
        }

        public List<ContrattoPermessoApiDto> Data { get; set; }

        public int TotalCount { get; set; }

        public int PageSize { get; set; }
    }

    #endregion

    #region Contratti Servizi
    public class ContrattoServizioApiDto
    {
        public long Id { get; set; }
        public string Descrizione { get; set; }
        public bool Disabled { get; set; }

        public ContrattoServizioApiDto()
        {
            Descrizione = string.Empty;
        }
    }

    public class ContrattiServiziApiDto
    {
        public ContrattiServiziApiDto()
        {
            Data = new List<ContrattoServizioApiDto>();
        }

        public List<ContrattoServizioApiDto> Data { get; set; }

        public int TotalCount { get; set; }

        public int PageSize { get; set; }
    }

    #endregion

    #region Contratti Tipologie
    public class ContrattoTipologiaApiDto
    {
        public long Id { get; set; }
        public string Descrizione { get; set; }
        public bool Disabled { get; set; }

        public ContrattoTipologiaApiDto()
        {
            Descrizione = string.Empty;
        }
    }

    public class ContrattiTipologieApiDto
    {
        public ContrattiTipologieApiDto()
        {
            Data = new List<ContrattoTipologiaApiDto>();
        }

        public List<ContrattoTipologiaApiDto> Data { get; set; }

        public int TotalCount { get; set; }

        public int PageSize { get; set; }
    }

    #endregion

    #region Contratti UtentiOnPermessi
    public class ContrattoUtenteOnPermessoApiDto
    {
        public long Id { get; set; }
        public string Descrizione { get; set; }
        public long ContrattoPermessoId { get; set; }
        public bool Disabled { get; set; }

        public ContrattoUtenteOnPermessoApiDto()
        {
            Descrizione = string.Empty;
        }
    }

    public class ContrattiUtentiOnPermessiApiDto
    {
        public ContrattiUtentiOnPermessiApiDto()
        {
            Data = new List<ContrattoUtenteOnPermessoApiDto>();
        }

        public List<ContrattoUtenteOnPermessoApiDto> Data { get; set; }

        public int TotalCount { get; set; }

        public int PageSize { get; set; }
    }

    #endregion
}
