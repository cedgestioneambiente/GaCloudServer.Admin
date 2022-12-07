using GaCloudServer.Resources.Api.Dtos.Base;
using System.ComponentModel.DataAnnotations;

namespace GaCloudServer.Resources.Api.Dtos.Csr
{
    #region CsrCodiciCers
    public class CsrCodiceCerApiDto : GenericListApiDto
    {
        public string Codice { get; set; }
        public string? Modalita { get; set; }
    }

    public class CsrCodiciCersApiDto : GenericPagedListApiDto<CsrCodiceCerApiDto>
    {
    }

    #endregion

    #region CsrComuni
    public class CsrComuneApiDto : GenericListApiDto
    {
    }

    public class CsrComuniApiDto : GenericPagedListApiDto<CsrComuneApiDto>
    {
    }

    #endregion

    #region CsrDestinatari
    public class CsrDestinatarioApiDto : GenericApiDto
    {
        public string RagioneSociale { get; set; }
        public string Indirizzo { get; set; }
    }

    public class CsrDestinatariApiDto : GenericPagedListApiDto<CsrDestinatarioApiDto>
    {
    }

    #endregion

    #region CsrProduttori
    public class CsrProduttoreApiDto : GenericApiDto
    {
        public string RagioneSociale { get; set; }
        public string Colore { get; set; }
    }

    public class CsrProduttoriApiDto : GenericPagedListApiDto<CsrProduttoreApiDto>
    {
    }

    #endregion

    #region CsrRegistrazioni
    public class CsrRegistrazioneApiDto : GenericApiDto
    {
        public DateTime Data { get; set; }
        public long CsrComuneId { get; set; }
        public long CsrCodiceCerId { get; set; }
        public long CsrDestinatarioId { get; set; }
        public long CsrTrasportatoreId { get; set; }
        public int PesoTotale { get; set; }
        public string Operazione { get; set; }
    }

    public class CsrRegistrazioniApiDto : GenericPagedListApiDto<CsrRegistrazioneApiDto>
    {
    }

    #endregion

    #region CsrRegistrazioniPesi
    public class CsrRegistrazionePesoApiDto : GenericApiDto
    {
        public long CsrProduttoreId { get; set; }
        public long CsrCodiceCerId { get; set; }
        public long CsrDestinatarioId { get; set; }
        public long CsrTrasportatoreId { get; set; }
        public long CsrComuneId { get; set; }
        public int Percentuale { get; set; }
        public double Peso { get; set; }
        public long CsrRegistrazioneId { get; set; }
    }

    public class CsrRegistrazioniPesiApiDto : GenericPagedListApiDto<CsrRegistrazionePesoApiDto>
    {
    }

    #endregion

    #region CsrRipartizioniPercentuali
    public class CsrRipartizionePercentualeApiDto : GenericApiDto
    {
        public long CsrComuneId { get; set; }
        public long CsrProduttoreId { get; set; }
        public int Percentuale { get; set; }
    }

    public class CsrRipartizioniPercentualiApiDto : GenericPagedListApiDto<CsrRipartizionePercentualeApiDto>
    {
    }

    #endregion

    #region CsrTrasportatori
    public class CsrTrasportatoreApiDto : GenericApiDto
    {
        public string RagioneSociale { get; set; }
        public string Indirizzo { get; set; }
    }

    public class CsrTrasportatoriApiDto : GenericPagedListApiDto<CsrTrasportatoreApiDto>
    {
    }

    #endregion

    //Internal
    public class CsrExportApiDto
    {
        public int anno { get; set; }
        public List<int> comuni { get; set; }
    }

}
