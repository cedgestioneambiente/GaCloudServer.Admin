using System;
using System.Collections.Generic;
using System.Text;

namespace GaCloudServer.BusinnessLogic.Dtos.Resources.Contratti
{
    #region Contratti Permessi
    public class ContrattoPermessoDto
    {
        public long Id { get; set; }
        public string Descrizione { get; set; }
        public bool Disabled { get; set; }

        public ContrattoPermessoDto() {
            Descrizione = string.Empty;
        }
    }

    public class ContrattiPermessiDto
    {
        public ContrattiPermessiDto()
        {
            Data = new List<ContrattoPermessoDto>();
        }

        public List<ContrattoPermessoDto> Data { get; set; }

        public int TotalCount { get; set; }

        public int PageSize { get; set; }
    }

    #endregion

    #region Contratti Servizi
    public class ContrattoServizioDto
    {
        public long Id { get; set; }
        public string Descrizione { get; set; }
        public bool Disabled { get; set; }

        public ContrattoServizioDto()
        {
            Descrizione = string.Empty;
        }
    }

    public class ContrattiServiziDto
    {
        public ContrattiServiziDto()
        {
            Data = new List<ContrattoServizioDto>();
        }

        public List<ContrattoServizioDto> Data { get; set; }

        public int TotalCount { get; set; }

        public int PageSize { get; set; }
    }

    #endregion

    #region Contratti Tipologie
    public class ContrattoTipologiaDto
    {
        public long Id { get; set; }
        public string Descrizione { get; set; }
        public bool Disabled { get; set; }

        public ContrattoTipologiaDto()
        {
            Descrizione = string.Empty;
        }
    }

    public class ContrattiTipologieDto
    {
        public ContrattiTipologieDto()
        {
            Data = new List<ContrattoTipologiaDto>();
        }

        public List<ContrattoTipologiaDto> Data { get; set; }

        public int TotalCount { get; set; }

        public int PageSize { get; set; }
    }

    #endregion

    #region Contratti UtentiOnPermessi
    public class ContrattoUtenteOnPermessoDto
    {
        public long Id { get; set; }
        public string Descrizione { get; set; }
        public long ContrattoPermessoId { get; set; }
        public bool Disabled { get; set; }

        public ContrattoUtenteOnPermessoDto()
        {
            Descrizione = string.Empty;
        }
    }

    public class ContrattiUtentiOnPermessiDto
    {
        public ContrattiUtentiOnPermessiDto()
        {
            Data = new List<ContrattoUtenteOnPermessoDto>();
        }

        public List<ContrattoUtenteOnPermessoDto> Data { get; set; }

        public int TotalCount { get; set; }

        public int PageSize { get; set; }
    }

    #endregion
}
