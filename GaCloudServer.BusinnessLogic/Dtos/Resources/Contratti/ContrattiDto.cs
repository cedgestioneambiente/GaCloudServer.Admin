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

    #region Contratti Modalita
    public class ContrattiModalitaDto : GenericListDto
    {
    }

    public class ContrattiModalitasDto : GenericPagedListDto<ContrattiModalitaDto>
    {
    }

    #endregion

    #region Contratti Soggetti
    public class ContrattiSoggettoDto : GenericDto
    {
        public string RagioneSociale { get; set; }
        public string CodiceFiscale { get; set; }
        public string PartitaIva { get; set; }
        public string SedeLegale { get; set; }
        public string RecapitoFatture { get; set; }
        public string Telefono { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public bool Fornitore { get; set; }
        public bool Cliente { get; set; }
    }

    public class ContrattiSoggettiDto : GenericPagedListDto<ContrattiSoggettoDto>
    {
    }

    #endregion

    #region Contratti Documenti
    public class ContrattiDocumentoDto : GenericDto
    {
        public long ContrattiSoggettoId { get; set; }
        public int Numero { get; set; }
        public string Descrizione { get; set; }
        public string CodiceCig { get; set; }
        public string Faldone { get; set; }
        public DateTime DataScadenza { get; set; }
        public string ContrattiModalita { get; set; }
        public string ContrattiTipologia { get; set; }
        public string Permissions { get; set; }
        public bool Archiviato { get; set; }
        public int SogliaAvviso { get; set; }
    }

    public class ContrattiDocumentiDto : GenericPagedListDto<ContrattiDocumentoDto>
    {
    }

    #endregion

    #region Contratti DocumentiAllegati
    public class ContrattiDocumentoAllegatoDto : GenericFileDto
    {
        public long ContrattiDocumentoId { get; set; }
        public string Descrizione { get; set; }

    }

    public class ContrattiDocumentiAllegatiDto : GenericPagedListDto<ContrattiDocumentoAllegatoDto>
    {
    }

    #endregion

    #region ContrattiDocumentiRequest
    public class ContrattiDocumentiRequestDto
    {
        public string userId { get; set; }
        public List<string> userRoles { get; set; }
        public long soggettoId { get; set; }
        public bool archiviato { get; set; }
    }
    #endregion

    #region ContrattiDocumentiListRequest
    public class ContrattiDocumentiListRequestDto
    {
        public string userId { get; set; }
        public List<string> userRoles { get; set; }
        public long mode { get; set; }
    }
    #endregion
}


