using GaCloudServer.BusinnessLogic.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.BusinnessLogic.DTOs.Resources.Csr
{
    #region CsrCodiciCers
    public class CsrCodiceCerDto : GenericListDto
    {
        public string Codice { get; set; }
        public string Modalita { get; set; }
    }

    public class CsrCodiciCersDto : GenericPagedListDto<CsrCodiceCerDto>
    {
    }

    #endregion

    #region CsrComuni
    public class CsrComuneDto : GenericListDto
    {
    }

    public class CsrComuniDto : GenericPagedListDto<CsrComuneDto>
    {
    }

    #endregion

    #region CsrDestinatari
    public class CsrDestinatarioDto : GenericDto
    {
        public string RagioneSociale { get; set; }
        public string Indirizzo { get; set; }
    }

    public class CsrDestinatariDto : GenericPagedListDto<CsrDestinatarioDto>
    {
    }

    #endregion

    #region CsrProduttori
    public class CsrProduttoreDto : GenericDto
    {
        public string RagioneSociale { get; set; }
        public string Colore { get; set; }
    }

    public class CsrProduttoriDto : GenericPagedListDto<CsrProduttoreDto>
    {
    }

    #endregion

    #region CsrRegistrazioni
    public class CsrRegistrazioneDto : GenericDto
    {
        public DateTime Data { get; set; }
        public long CsrComuneId { get; set; }
        public long CsrCodiceCerId { get; set; }
        public long CsrDestinatarioId { get; set; }
        public long CsrTrasportatoreId { get; set; }
        public int PesoTotale { get; set; }
        public string Operazione { get; set; }
    }

    public class CsrRegistrazioniDto : GenericPagedListDto<CsrRegistrazioneDto>
    {
    }

    #endregion

    #region CsrRegistrazioniPesi
    public class CsrRegistrazionePesoDto : GenericDto
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

    public class CsrRegistrazioniPesiDto : GenericPagedListDto<CsrRegistrazionePesoDto>
    {
    }

    #endregion

    #region CsrRipartizioniPercentuali
    public class CsrRipartizionePercentualeDto : GenericDto
    {
        public long CsrComuneId { get; set; }
        public long CsrProduttoreId { get; set; }
        public int Percentuale { get; set; }
    }

    public class CsrRipartizioniPercentualiDto : GenericPagedListDto<CsrRipartizionePercentualeDto>
    {
    }

    #endregion

    #region CsrTrasportatori
    public class CsrTrasportatoreDto : GenericDto
    {
        public string RagioneSociale { get; set; }
        public string Indirizzo { get; set; }
    }

    public class CsrTrasportatoriDto : GenericPagedListDto<CsrTrasportatoreDto>
    {
    }

    #endregion
}
