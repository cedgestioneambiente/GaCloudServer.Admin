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

    #region Contratti Fornitori
    public class ContrattiFornitoreApiDto : GenericApiDto
    {
        public string RagioneSociale { get; set; }
        public string CodiceFiscale { get; set; }
        public string PartitaIva { get; set; }
        public string SedeLegale { get; set; }
        public string RecapitoFatture { get; set; }
        public string Telefono { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
    }

    public class ContrattiFornitoriApiDto : GenericPagedListApiDto<ContrattiFornitoreApiDto>
    {
    }

    #endregion

    #region Contratti Documenti
    public class ContrattiDocumentoApiDto : GenericFileApiDto
    {
        public long ContrattiFornitoreId { get; set; }
        public int Numero { get; set; }
        public string Descrizione { get; set; }
        public string CodiceCig { get; set; }
        public string Faldone { get; set; }
        public DateTime? DataScadenza { get; set; }
        public long ContrattiModalitaId { get; set; }
        public bool Direzione { get; set; }
        public bool Contabilita { get; set; }
        public bool Personale { get; set; }
        public bool Informatica { get; set; }
        public bool Tecnico { get; set; }
        public bool QualitaSicurezza { get; set; }
        public bool Commerciale { get; set; }
        public bool AffariGenerali { get; set; }
        public bool Archiviato { get; set; }
        public long ContrattiServizioId { get; set; }
        public bool Preventivo { get; set; }
        public string PreventivoNumero { get; set; }
        public long ContrattiTipologiaId { get; set; }
    }

    public class ContrattiDocumentiApiDto : GenericPagedListApiDto<ContrattiDocumentoApiDto>
    {
    }

    #endregion

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
