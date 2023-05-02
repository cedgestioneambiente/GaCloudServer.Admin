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

    #region Contratti Modalita
    public class ContrattiModalitaApiDto : GenericListApiDto
    {
    }

    public class ContrattiModalitasApiDto : GenericPagedListApiDto<ContrattiModalitaApiDto>
    {
    }

    #endregion

    #region Contratti Soggetti
    public class ContrattiSoggettoApiDto : GenericApiDto
    {
        public string RagioneSociale { get; set; }
        public string? CodiceFiscale { get; set; }
        public string PartitaIva { get; set; }
        public string? SedeLegale { get; set; }
        public string? RecapitoFatture { get; set; }
        public string? Telefono { get; set; }
        public string? Fax { get; set; }
        public string? Email { get; set; }
        public bool Fornitore { get; set; }
        public bool Cliente { get; set; }
    }

    public class ContrattiSoggettiApiDto : GenericPagedListApiDto<ContrattiSoggettoApiDto>
    {
    }

    #endregion

    #region Contratti Documenti
    public class ContrattiDocumentoApiDto : GenericApiDto
    {
        public long ContrattiSoggettoId { get; set; }
        public int Numero { get; set; }
        public string Descrizione { get; set; }
        public string? CodiceCig { get; set; }
        public string? Faldone { get; set; }
        public DateTime DataScadenza { get; set; }
        public string ContrattiModalita { get; set; }
        public string ContrattiTipologia { get; set; }
        public string Permissions { get; set; }
        public bool Archiviato { get; set; }
        public int SogliaAvviso { get; set; }

    }

    public class ContrattiDocumentiApiDto : GenericPagedListApiDto<ContrattiDocumentoApiDto>
    {
    }

    #endregion

    #region Contratti DocumentiAllegati
    public class ContrattiDocumentoAllegatoApiDto : GenericFileApiDto
    {
        public long ContrattiDocumentoId { get; set; }
        public string Descrizione { get; set; }

    }

    public class ContrattiDocumentiAllegatiApiDto : GenericPagedListApiDto<ContrattiDocumentoAllegatoApiDto>
    {
    }
    #endregion

    //Internal
    public class ContrattiFilterApiDto
    { 
        public long id { get; set; }
        public string roles { get; set; }
        public string tipologie { get; set; }
        public bool archiviato { get; set; }
    }


    #region ContrattiDocumentiRequest
    public class ContrattiDocumentiRequestApiDto
    {
        public string userId { get; set; }
        public List<string> userRoles { get; set; }
        public long fornitoreId { get; set; }
        public bool archiviato { get; set; }
    }
    #endregion

    #region ContrattiDocumentiListRequest
    public class ContrattiDocumentiListRequestApiDto
    {
        public string userId { get; set; }
        public List<string> userRoles { get; set; }
        public long mode { get; set; }
    }
    #endregion

}
