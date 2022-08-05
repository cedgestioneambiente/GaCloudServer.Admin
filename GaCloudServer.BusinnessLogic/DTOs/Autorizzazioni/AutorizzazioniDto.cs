using System;
using System.Collections.Generic;
using System.Text;

namespace GaCloudServer.BusinnessLogic.DTOs.Autorizzazioni
{
    #region Autorizzazioni Tipo
    public class AutorizzazioneTipoDto
    {
        public long Id { get; set; }
        public string Descrizione { get; set; }
        public bool Disabled { get; set; }

        public AutorizzazioneTipoDto() {
            Descrizione = string.Empty;
        }
    }

    public class AutorizzazioniTipiDto
    {
        public AutorizzazioniTipiDto()
        {
            Data = new List<AutorizzazioneTipoDto>();
        }

        public List<AutorizzazioneTipoDto> Data { get; set; }

        public int TotalCount { get; set; }

        public int PageSize { get; set; }
    }

    #endregion

}
