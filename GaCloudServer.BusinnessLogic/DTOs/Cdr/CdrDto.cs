using System;
using System.Collections.Generic;
using System.Text;

namespace GaCloudServer.BusinnessLogic.DTOs.Cdr
{
    #region Cdr Account
    //public class CdrAccountDto
    //{
    //    public long Id { get; set; }
    //    public string NomeUtente { get; set; }
    //    public string Password { get; set; }
    //    public long CdrAccountRuoloId { get; set; }
    //    public bool Disabled { get; set; }
    //}

    //public class CdrAccountsDto
    //{
    //    public CdrAccountsDto()
    //    {
    //        Data = new List<CdrAccountDto>();
    //    }

    //    public List<CdrAccountDto> Data { get; set; }

    //    public int TotalCount { get; set; }

    //    public int PageSize { get; set; }
    //}
    #endregion

    #region Cdr Account Ruoli
    //public class CdrAccountRuoloDto
    //{
    //    public long Id { get; set; }
    //    public string Descrizione { get; set; }
    //    public bool Disabled { get; set; }
    //}

    //public class CdrAccountsRuoliDto
    //{
    //    public CdrAccountsRuoliDto()
    //    {
    //        Data = new List<CdrAccountRuoloDto>();
    //    }

    //    public List<CdrAccountRuoloDto> Data { get; set; }

    //    public int TotalCount { get; set; }

    //    public int PageSize { get; set; }
    //}

    #endregion

    #region Cdr App Versione

    //public class CdrAppVersioneDto
    //{
    //    public long Id { get; set; }
    //    public string Versione { get; set; }
    //    public bool Disabled { get; set; }
    //}

    //public class CdrAppsVersioniDto
    //{
    //    public CdrAppsVersioniDto()
    //    {
    //        Data = new List<CdrAppVersioneDto>();
    //    }

    //    public List<CdrAppVersioneDto> Data { get; set; }

    //    public int TotalCount { get; set; }

    //    public int PageSize { get; set; }
    //}

    #endregion

    #region Cdr Centri

    public class CdrCentroDto
    {
        public long Id { get; set; }
        public string Centro { get; set; }
        public string Mail { get; set; }
        public string UserMail { get; set; }
        public bool Disabled { get; set; }
    }

    public class CdrCentriDto
    {
        public CdrCentriDto()
        {
            Data = new List<CdrCentroDto>();
        }

        public List<CdrCentroDto> Data { get; set; }

        public int TotalCount { get; set; }

        public int PageSize { get; set; }
    }

    #endregion

    #region Cdr Cer

    public class CdrCerDto
    {
        public long Id { get; set; }
        public string Cer { get; set; }
        public string Descrizione { get; set; }
        public bool Pericoloso { get; set; }
        public bool Peso { get; set; }
        public bool Qta { get; set; }
        public string Imm { get; set; }
        public bool Disabled { get; set; }

    }

    public class CdrCersDto
    {
        public CdrCersDto()
        {
            Data = new List<CdrCerDto>();
        }

        public List<CdrCerDto> Data { get; set; }

        public int TotalCount { get; set; }

        public int PageSize { get; set; }
    }

    #endregion

    #region Cdr Cer Dettagli

    public class CdrCerDettaglioDto
    {
        public long Id { get; set; }
        public long CdrCerId { get; set; }
        public string Descrizione { get; set; }
        public int PesoDefault { get; set; }
        public bool Disabled { get; set; }
    }

    public class CdrCersDettagliDto
    {
        public CdrCersDettagliDto()
        {
            Data = new List<CdrCerDettaglioDto>();
        }

        public List<CdrCerDettaglioDto> Data { get; set; }

        public int TotalCount { get; set; }

        public int PageSize { get; set; }
    }

    #endregion

    #region Cdr Cer On Centri
    public class CdrCerOnCentroDto
    {
        public long Id { get; set; }
        public long CdrCentroId { get; set; }
        public long CdrCerId { get; set; }
        public bool Disabled { get; set; }
    }

    public class CdrCersOnCentriDto
    {
        public CdrCersOnCentriDto()
        {
            Data = new List<CdrCerOnCentroDto>();
        }

        public List<CdrCerOnCentroDto> Data { get; set; }

        public int TotalCount { get; set; }

        public int PageSize { get; set; }
    }

    #endregion

    #region Cdr Cer Comuni

    public class CdrComuneDto
    {
        public long Id { get; set; }
        public string Comune { get; set; }
        public bool Disabled { get; set; }
    }

    public class CdrComuniDto
    {
        public CdrComuniDto()
        {
            Data = new List<CdrComuneDto>();
        }

        public List<CdrComuneDto> Data { get; set; }

        public int TotalCount { get; set; }

        public int PageSize { get; set; }
    }

    #endregion

    #region Cdr Comuni On Centri
    public class CdrComuneOnCentroDto
    {
        public long Id { get; set; }
        public long CdrCentroId { get; set; }
        public long CdrComuneId { get; set; }
        public bool Disabled { get; set; }
    }

    public class CdrComuniOnCentriDto
    {
        public CdrComuniOnCentriDto()
        {
            Data = new List<CdrComuneOnCentroDto>();
        }

        public List<CdrComuneOnCentroDto> Data { get; set; }

        public int TotalCount { get; set; }

        public int PageSize { get; set; }
    }

    #endregion

    #region Cdr Comunicazioni

    //public class CdrComunicazioneDto
    //{
    //    public long Id { get; set; }
    //    public DateTime Data { get; set; }
    //    public string Titolo { get; set; }
    //    public string Contenuto { get; set; }
    //    public int Destinazione { get; set; }
    //    public bool Disabled { get; set; }
    //}

    //public class CdrComunicazioniDto
    //{
    //    public CdrComunicazioniDto()
    //    {
    //        Data = new List<CdrComunicazioneDto>();
    //    }

    //    public List<CdrComunicazioneDto> Data { get; set; }

    //    public int TotalCount { get; set; }

    //    public int PageSize { get; set; }
    //}

    #endregion

    #region Cdr Comunicazioni Lette
    //public class CdrComunicazioneLettaDto
    //{
    //    public long Id { get; set; }
    //    public string UserId { get; set; }
    //    public long CdrComunicazioneId { get; set; }
    //    public bool Disabled { get; set; }
    //}

    //public class CdrComunicazioniLetteDto
    //{
    //    public CdrComunicazioniLetteDto()
    //    {
    //        Data = new List<CdrComunicazioneLettaDto>();
    //    }

    //    public List<CdrComunicazioneLettaDto> Data { get; set; }

    //    public int TotalCount { get; set; }

    //    public int PageSize { get; set; }
    //}

    #endregion

    #region Cdr Conferimenti

    //public class CdrConferimentoDto
    //{
    //    public long Id { get; set; }
    //    public string UserId { get; set; }
    //    public DateTime Data { get; set; }
    //    public string CfPiva { get; set; }
    //    public bool Anagrafica { get; set; }
    //    public bool Ditta { get; set; }
    //    public long CdrCentroId { get; set; }
    //    public string CdrComuneId { get; set; }
    //    public long CdrCerId { get; set; }
    //    public long CdrCerDettaglioId { get; set; }
    //    public double Peso { get; set; }
    //    public int Quantita { get; set; }
    //    public string Targa { get; set; }
    //    public string Note { get; set; }
    //    public string CdrUtenteId { get; set; }
    //    public string NumCon { get; set; }
    //    public string Partita { get; set; }
    //    public bool Disabled { get; set; }
    //    public bool Noleggio { get; set; }
    //}

    //public class CdrConferimentiDto
    //{
    //    public CdrConferimentiDto()
    //    {
    //        Data = new List<CdrConferimentoDto>();
    //    }

    //    public List<CdrConferimentoDto> Data { get; set; }

    //    public int TotalCount { get; set; }

    //    public int PageSize { get; set; }
    //}

    #endregion

    #region Cdr Richieste Svuotamenti

    //public class CdrRichiestaSvuotamentoDto
    //{
    //    public long Id { get; set; }
    //    public DateTime Data { get; set; }
    //    public string UserId { get; set; }
    //    public long CdrCentroId { get; set; }
    //    public long CdrCerId { get; set; }
    //    public long CdrStatoRichiestaId { get; set; }
    //    public DateTime? DataChiusura { get; set; }
    //    public int PesoDestino { get; set; }
    //    public bool Disabled { get; set; }

    //}

    //public class CdrRichiesteSvuotamentiDto
    //{
    //    public CdrRichiesteSvuotamentiDto()
    //    {
    //        Data = new List<CdrRichiestaSvuotamentoDto>();
    //    }

    //    public List<CdrRichiestaSvuotamentoDto> Data { get; set; }

    //    public int TotalCount { get; set; }

    //    public int PageSize { get; set; }
    //}

    #endregion

    #region Cdr Richieste Viaggi

    //public class CdrRichiestaViaggioDto
    //{
    //    public long Id { get; set; }
    //    public DateTime Data { get; set; }
    //    public string UserId { get; set; }
    //    public long CdrCentroId { get; set; }
    //    public long CdrCerId { get; set; }
    //    public long CdrStatoRichiestaId { get; set; }
    //    public DateTime? DataChiusura { get; set; }
    //    public double PesoPresunto { get; set; }
    //    public double PesoDestino { get; set; }
    //    public string Note { get; set; }
    //    public bool Inviata { get; set; }
    //    public bool Disabled { get; set; }

    //}

    //public class CdrRichiesteViaggiDto
    //{
    //    public CdrRichiesteViaggiDto()
    //    {
    //        Data = new List<CdrRichiestaViaggioDto>();
    //    }

    //    public List<CdrRichiestaViaggioDto> Data { get; set; }

    //    public int TotalCount { get; set; }

    //    public int PageSize { get; set; }
    //}

    #endregion

    #region Cdr Sessioni

    //public class CdrSessioneDto
    //{
    //    public long Id { get; set; }
    //    public string UserId { get; set; }
    //    public string Username { get; set; }
    //    public string DeviceSerial { get; set; }
    //    public DateTime StartDate { get; set; }
    //    public DateTime? EndDate { get; set; }
    //    public bool Active { get; set; }
    //    public long CdrCentroId { get; set; }
    //    public bool Disabled { get; set; }

    //}

    //public class CdrSessioniDto
    //{
    //    public CdrSessioniDto()
    //    {
    //        Data = new List<CdrSessioneDto>();
    //    }

    //    public List<CdrSessioneDto> Data { get; set; }

    //    public int TotalCount { get; set; }

    //    public int PageSize { get; set; }
    //}

    #endregion

    #region Cdr Stato Richieste

    //public class CdrStatoRichiestaDto
    //{
    //    public long Id { get; set; }
    //    public string Descrizione { get; set; }
    //    public bool Disabled { get; set; }

    //}

    //public class CdrStatiRichiesteDto
    //{
    //    public CdrStatiRichiesteDto()
    //    {
    //        Data = new List<CdrStatoRichiestaDto>();
    //    }

    //    public List<CdrStatoRichiestaDto> Data { get; set; }

    //    public int TotalCount { get; set; }

    //    public int PageSize { get; set; }
    //}

    #endregion

    #region Cdr Utenti

    //public class CdrUtenteDto
    //{
    //    public long Id { get; set; }
    //    public string RagioneSociale { get; set; }
    //    public string CfPiva { get; set; }
    //    public long CdrComuneId { get; set; }
    //    public string Indirizzo { get; set; }
    //    public bool Ditta { get; set; }
    //    public bool InserimentoUtente { get; set; }
    //    public bool Approvato { get; set; }
    //    public bool Disabled { get; set; }

    //}

    //public class CdrUtentiDto
    //{
    //    public CdrUtentiDto()
    //    {
    //        Data = new List<CdrUtenteDto>();
    //    }

    //    public List<CdrUtenteDto> Data { get; set; }

    //    public int TotalCount { get; set; }

    //    public int PageSize { get; set; }
    //}

    #endregion


}