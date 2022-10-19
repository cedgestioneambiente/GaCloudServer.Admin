using GaCloudServer.BusinnessLogic.DTOs.Base;

namespace GaCloudServer.BusinnessLogic.Dtos.Resources.Cdr
{
    #region CdrCentri

    public class CdrCentroDto:GenericDto
    {
        public string? Centro { get; set; }
        public string? Mail { get; set; }
        public string? UserMail { get; set; }
    }

    public class CdrCentriDto:GenericPagedListDto<CdrCentroDto>
    {
        
    }

    #endregion

    #region CdrComuni

    public class CdrComuneDto : GenericDto
    {
        public string? Comune { get; set; }
    }

    public class CdrComuniDto : GenericPagedListDto<CdrComuneDto>
    {

    }

    #endregion

    #region CdrCers

    public class CdrCerDto : GenericDto
    {
        public string? Cer { get; set; }
        public string? Descrizione { get; set; }
        public string? Imm { get; set; }
        public bool? Pericoloso { get; set; }
        public bool? Peso { get; set; }
        public bool? Qta { get; set; }
    }

    public class CdrCersDto : GenericPagedListDto<CdrCerDto>
    {

    }

    #endregion

    #region CdrCersDettagli

    public class CdrCerDettaglioDto : GenericDto
    {
        public long CdrCerId { get; set; }
        public string? Descrizione { get; set; }
        public int PesoDefault { get; set; }
    }

    public class CdrCersDettagliDto : GenericPagedListDto<CdrCerDettaglioDto>
    {

    }

    #endregion

    #region CdrCersOnCentri

    public class CdrCerOnCentroDto : GenericDto
    {
        public long CdrCentroId { get; set; }
        public long CdrCerId { get; set; }
    }

    public class CdrCersOnCentriDto : GenericPagedListDto<CdrCerOnCentroDto>
    {

    }

    #endregion

    #region CdrComuniOnCentri

    public class CdrComuneOnCentroDto : GenericDto
    {
        public long CdrCentroId { get; set; }
        public long CdrComuneId { get; set; }
    }

    public class CdrComuniOnCentriDto : GenericPagedListDto<CdrComuneOnCentroDto>
    {

    }

    #endregion

    #region CdrConferimenti

    public class CdrConferimentoDto : GenericDto
    {
        public string UserId { get; set; }
        public DateTime Data { get; set; }
        public string CfPiva { get; set; }
        public bool Anagrafica { get; set; }
        public bool Ditta { get; set; }
        public long CdrCentroId { get; set; }
        public string CdrComuneId { get; set; }
        public long CdrCerId { get; set; }
        public long CdrCerDettaglioId { get; set; }
        public double Peso { get; set; }
        public int Quantita { get; set; }
        public string Targa { get; set; }
        public string Note { get; set; }
        public string CdrUtenteId { get; set; }
        public string NumCon { get; set; }
        public string Partita { get; set; }
        public bool Noleggio { get; set; }
    }

    public class CdrConferimentiDto : GenericPagedListDto<CdrConferimentoDto>
    {

    }

    #endregion

    #region CdrRichiesteViaggi

    public class CdrRichiestaViaggioDto : GenericDto
    {
        public DateTime Data { get; set; }
        public string UserId { get; set; }
        public long CdrCentroId { get; set; }
        public long CdrCerId { get; set; }
        public long CdrStatoRichiestaId { get; set; }
        public DateTime? DataChiusura { get; set; }
        public double PesoPresunto { get; set; }
        public double PesoDestino { get; set; }
        public string Note { get; set; }
        public bool Inviata { get; set; }
    }

    public class CdrRichiesteViaggiDto : GenericPagedListDto<CdrRichiestaViaggioDto>
    {

    }

    #endregion

    #region CdrStatiRichieste

    public class CdrStatoRichiestaDto : GenericListDto
    {
    }

    public class CdrStatiRichiesteDto : GenericPagedListDto<CdrStatoRichiestaDto>
    {

    }

    #endregion

    #region CdrUtenti

    public class CdrUtenteDto : GenericDto
    {
        public string RagioneSociale { get; set; }
        public string CfPiva { get; set; }
        public long CdrComuneId { get; set; }
        public string Indirizzo { get; set; }
        public bool Ditta { get; set; }
        public bool InserimentoUtente { get; set; }
        public bool Approvato { get; set; }
    }

    public class CdrUtentiDto : GenericPagedListDto<CdrUtenteDto>
    {

    }

    #endregion

}