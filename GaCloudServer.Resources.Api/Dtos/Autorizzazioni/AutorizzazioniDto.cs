using System;
using System.Collections.Generic;
using System.Text;

namespace GaCloudServer.Resources.Api.Dtos.Autorizzazioni
{
    #region Autorizzazioni Tipo
    public class AutorizzazioneTipoApiDto
    {
        public long Id { get; set; }
        public string Descrizione { get; set; }
        public bool Disabled { get; set; }

        public AutorizzazioneTipoApiDto() {
            Descrizione = string.Empty;
        }
    }

    public class AutorizzazioniTipiApiDto
    {
        public AutorizzazioniTipiApiDto()
        {
            Data = new List<AutorizzazioneTipoApiDto>();
        }

        public List<AutorizzazioneTipoApiDto> Data { get; set; }

        public int TotalCount { get; set; }

        public int PageSize { get; set; }
    }

    #endregion

}
