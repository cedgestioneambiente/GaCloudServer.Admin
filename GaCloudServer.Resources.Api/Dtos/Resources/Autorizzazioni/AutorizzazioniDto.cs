using GaCloudServer.Resources.Api.Dtos.Base;
using System.ComponentModel.DataAnnotations;

namespace GaCloudServer.Resources.Api.Dtos.Autorizzazioni
{
    #region AutorizzazioniTipo
    public class AutorizzazioniTipoApiDto:GenericListDto
    {
    }

    public class AutorizzazioniTipiApiDto:GenericPagedListDto<AutorizzazioniTipoApiDto>
    {
    }

    #endregion

    #region AutorizzazioniDocumento
    public class AutorizzazioniDocumentoApiDto:GenericDto
    {
        [Required(ErrorMessage ="Il campo Numero è obbligatorio")]
        public string Numero { get; set; }
        public string RagioneSociale { get; set; }
        public string Indirizzo { get; set; }
        [Required(ErrorMessage = "Il Tipologia è obbligatorio")]
        public long AutorizzazioniTipoId { get; set; }
        public DateTime DataRilascio { get; set; }
        public DateTime DataScadenza { get; set; }
        public int Preavviso { get; set; }
        public bool Archiviata { get; set; }

        public AutorizzazioniDocumentoApiDto()
        {
            Numero = String.Empty;
            RagioneSociale = String.Empty;
            Indirizzo = String.Empty;
        }
    }

    public class AutorizzazioniDocumentiApiDto:GenericPagedListDto<AutorizzazioniDocumentoApiDto>
    {
    }

    #endregion

    #region AutorizzazioniAllegati
    public class AutorizzazioniAllegatoApiDto : GenericFileDto
    { 
        public long AutorizzazioniDocumentoId { get; set; }
        public string Descrizione { get; set; }

        public AutorizzazioniAllegatoApiDto()
        {
            Descrizione = string.Empty;
        }
    }

    public class AutorizzazioniAllegatiApiDto : GenericPagedListDto<AutorizzazioniAllegatoApiDto> { }
    #endregion

}
