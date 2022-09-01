using GaCloudServer.Resources.Api.Dtos.Base;
using System.ComponentModel.DataAnnotations;

namespace GaCloudServer.Resources.Api.Dtos.Autorizzazioni
{
    #region AutorizzazioniTipo
    public class AutorizzazioniTipoApiDto:GenericListApiDto
    {
    }

    public class AutorizzazioniTipiApiDto:GenericPagedListApiDto<AutorizzazioniTipoApiDto>
    {
    }

    #endregion

    #region AutorizzazioniDocumento
    public class AutorizzazioniDocumentoApiDto:GenericApiDto
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

    public class AutorizzazioniDocumentiApiDto:GenericPagedListApiDto<AutorizzazioniDocumentoApiDto>
    {
    }

    #endregion

    #region AutorizzazioniAllegati
    public class AutorizzazioniAllegatoApiDto : GenericFileApiDto
    { 
        public long AutorizzazioniDocumentoId { get; set; }
        public string Descrizione { get; set; }

        public AutorizzazioniAllegatoApiDto()
        {
            Descrizione = string.Empty;
        }
    }

    public class AutorizzazioniAllegatiApiDto : GenericPagedListApiDto<AutorizzazioniAllegatoApiDto> { }
    #endregion

}
