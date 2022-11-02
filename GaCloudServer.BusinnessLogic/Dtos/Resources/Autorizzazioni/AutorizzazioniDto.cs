using GaCloudServer.BusinnessLogic.DTOs.Base;

namespace GaCloudServer.BusinnessLogic.Dtos.Resources.Autorizzazioni
{
    #region AutorizzazioniTipi
    public class AutorizzazioniTipoDto : GenericListDto
    {
    }

    public class AutorizzazioniTipiDto : GenericPagedListDto<AutorizzazioniTipoDto>
    {
    }

    #endregion

    #region AutorizzazioniDocumenti
    public class AutorizzazioniDocumentoDto : GenericDto
    {
        public string Numero { get; set; }
        public string RagioneSociale { get; set; }
        public string Indirizzo { get; set; }
        public long AutorizzazioniTipoId { get; set; }
        public DateTime DataRilascio { get; set; }
        public DateTime DataScadenza { get; set; }
        public int Preavviso { get; set; }
        public bool Archiviata { get; set; }

        public AutorizzazioniDocumentoDto()
        {
            Numero = String.Empty;
            RagioneSociale = String.Empty;
            Indirizzo = String.Empty;
        }
    }

    public class AutorizzazioniDocumentiDto : GenericPagedListDto<AutorizzazioniDocumentoDto>
    {
    }

    #endregion

    #region AutorizzazioniAllegati
    public class AutorizzazioniAllegatoDto : GenericFileDto
    {
        public long AutorizzazioniDocumentoId { get; set; }
        public string Descrizione { get; set; }

        public AutorizzazioniAllegatoDto()
        {
            Descrizione = string.Empty;
        }
    }

    public class AutorizzazioniAllegatiDto : GenericPagedListDto<AutorizzazioniAllegatoDto> { }
    #endregion

}
