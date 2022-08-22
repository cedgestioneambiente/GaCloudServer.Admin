using System;
using System.Collections.Generic;
using System.Text;

namespace GaCloudServer.Resources.Api.Dtos.Cdr
{
    #region Cdr Account
    //public class CdrAccountApiDto
    //{
    //    public long Id { get; set; }
    //    public string NomeUtente { get; set; }
    //    public string Password { get; set; }
    //    public long CdrAccountRuoloId { get; set; }
    //    public bool Disabled { get; set; }
    //}

    //public class CdrAccountsApiDto
    //{
    //    public CdrAccountsApiDto()
    //    {
    //        Data = new List<CdrAccountApiDto>();
    //    }

    //    public List<CdrAccountApiDto> Data { get; set; }

    //    public int TotalCount { get; set; }

    //    public int PageSize { get; set; }
    //}
    #endregion

    #region Cdr Account Ruoli
    //public class CdrAccountRuoloApiDto
    //{
    //    public long Id { get; set; }
    //    public string Descrizione { get; set; }
    //    public bool Disabled { get; set; }
    //}

    //public class CdrAccountsRuoliApiDto
    //{
    //    public CdrAccountsRuoliApiDto()
    //    {
    //        Data = new List<CdrAccountRuoloApiDto>();
    //    }

    //    public List<CdrAccountRuoloApiDto> Data { get; set; }

    //    public int TotalCount { get; set; }

    //    public int PageSize { get; set; }
    //}

    #endregion

    #region Cdr App Versione

    //public class CdrAppVersioneApiDto
    //{
    //    public long Id { get; set; }
    //    public string Versione { get; set; }
    //    public bool Disabled { get; set; }
    //}

    //public class CdrAppsVersioniApiDto
    //{
    //    public CdrAppsVersioniApiDto()
    //    {
    //        Data = new List<CdrAppVersioneApiDto>();
    //    }

    //    public List<CdrAppVersioneApiDto> Data { get; set; }

    //    public int TotalCount { get; set; }

    //    public int PageSize { get; set; }
    //}

    #endregion

    #region Cdr Centri

    public class CdrCentroApiDto
    {
        public long Id { get; set; }
        public string Centro { get; set; }
        public string Mail { get; set; }
        public string UserMail { get; set; }
        public bool Disabled { get; set; }
    }

    public class CdrCentriApiDto
    {
        public CdrCentriApiDto()
        {
            Data = new List<CdrCentroApiDto>();
        }

        public List<CdrCentroApiDto> Data { get; set; }

        public int TotalCount { get; set; }

        public int PageSize { get; set; }
    }

    #endregion

    #region Cdr Cer

    public class CdrCerApiDto
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

    public class CdrCersApiDto
    {
        public CdrCersApiDto()
        {
            Data = new List<CdrCerApiDto>();
        }

        public List<CdrCerApiDto> Data { get; set; }

        public int TotalCount { get; set; }

        public int PageSize { get; set; }
    }

    #endregion

    #region Cdr Cer Dettagli

    public class CdrCerDettaglioApiDto
    {
        public long Id { get; set; }
        public long CdrCerId { get; set; }
        public string Descrizione { get; set; }
        public int PesoDefault { get; set; }
        public bool Disabled { get; set; }
    }

    public class CdrCersDettagliApiDto
    {
        public CdrCersDettagliApiDto()
        {
            Data = new List<CdrCerDettaglioApiDto>();
        }

        public List<CdrCerDettaglioApiDto> Data { get; set; }

        public int TotalCount { get; set; }

        public int PageSize { get; set; }
    }

    #endregion

    #region Cdr Cer On Centri
    public class CdrCerOnCentroApiDto
    {
        public long Id { get; set; }
        public long CdrCentroId { get; set; }
        public long CdrCerId { get; set; }
        public bool Disabled { get; set; }
    }

    public class CdrCersOnCentriApiDto
    {
        public CdrCersOnCentriApiDto()
        {
            Data = new List<CdrCerOnCentroApiDto>();
        }

        public List<CdrCerOnCentroApiDto> Data { get; set; }

        public int TotalCount { get; set; }

        public int PageSize { get; set; }
    }

    #endregion

    #region Cdr Cer Comuni

    public class CdrComuneApiDto
    {
        public long Id { get; set; }
        public string Comune { get; set; }
        public bool Disabled { get; set; }
    }

    public class CdrComuniApiDto
    {
        public CdrComuniApiDto()
        {
            Data = new List<CdrComuneApiDto>();
        }

        public List<CdrComuneApiDto> Data { get; set; }

        public int TotalCount { get; set; }

        public int PageSize { get; set; }
    }

    #endregion

    #region Cdr Comuni On Centri
    public class CdrComuneOnCentroApiDto
    {
        public long Id { get; set; }
        public long CdrCentroId { get; set; }
        public long CdrComuneId { get; set; }
        public bool Disabled { get; set; }
    }

    public class CdrComuniOnCentriApiDto
    {
        public CdrComuniOnCentriApiDto()
        {
            Data = new List<CdrComuneOnCentroApiDto>();
        }

        public List<CdrComuneOnCentroApiDto> Data { get; set; }

        public int TotalCount { get; set; }

        public int PageSize { get; set; }
    }

    #endregion

    #region Cdr Comunicazioni

    //public class CdrComunicazioneApiDto
    //{
    //    public long Id { get; set; }
    //    public DateTime Data { get; set; }
    //    public string Titolo { get; set; }
    //    public string Contenuto { get; set; }
    //    public int Destinazione { get; set; }
    //    public bool Disabled { get; set; }
    //}

    //public class CdrComunicazioniApiDto
    //{
    //    public CdrComunicazioniApiDto()
    //    {
    //        Data = new List<CdrComunicazioneApiDto>();
    //    }

    //    public List<CdrComunicazioneApiDto> Data { get; set; }

    //    public int TotalCount { get; set; }

    //    public int PageSize { get; set; }
    //}

    #endregion

    #region Cdr Comunicazioni Lette
    //public class CdrComunicazioneLettaApiDto
    //{
    //    public long Id { get; set; }
    //    public string UserId { get; set; }
    //    public long CdrComunicazioneId { get; set; }
    //    public bool Disabled { get; set; }
    //}

    //public class CdrComunicazioniLetteApiDto
    //{
    //    public CdrComunicazioniLetteApiDto()
    //    {
    //        Data = new List<CdrComunicazioneLettaApiDto>();
    //    }

    //    public List<CdrComunicazioneLettaApiDto> Data { get; set; }

    //    public int TotalCount { get; set; }

    //    public int PageSize { get; set; }
    //}

    #endregion

    #region Cdr Conferimenti

    //public class CdrConferimentoApiDto
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

    //public class CdrConferimentiApiDto
    //{
    //    public CdrConferimentiApiDto()
    //    {
    //        Data = new List<CdrConferimentoApiDto>();
    //    }

    //    public List<CdrConferimentoApiDto> Data { get; set; }

    //    public int TotalCount { get; set; }

    //    public int PageSize { get; set; }
    //}

    #endregion

    #region Cdr Richieste Svuotamenti

    //public class CdrRichiestaSvuotamentoApiDto
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

    //public class CdrRichiesteSvuotamentiApiDto
    //{
    //    public CdrRichiesteSvuotamentiApiDto()
    //    {
    //        Data = new List<CdrRichiestaSvuotamentoApiDto>();
    //    }

    //    public List<CdrRichiestaSvuotamentoApiDto> Data { get; set; }

    //    public int TotalCount { get; set; }

    //    public int PageSize { get; set; }
    //}

    #endregion

    #region Cdr Richieste Viaggi

    //public class CdrRichiestaViaggioApiDto
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

    //public class CdrRichiesteViaggiApiDto
    //{
    //    public CdrRichiesteViaggiApiDto()
    //    {
    //        Data = new List<CdrRichiestaViaggioApiDto>();
    //    }

    //    public List<CdrRichiestaViaggioApiDto> Data { get; set; }

    //    public int TotalCount { get; set; }

    //    public int PageSize { get; set; }
    //}

    #endregion

    #region Cdr Sessioni

    //public class CdrSessioneApiDto
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

    //public class CdrSessioniApiDto
    //{
    //    public CdrSessioniApiDto()
    //    {
    //        Data = new List<CdrSessioneApiDto>();
    //    }

    //    public List<CdrSessioneApiDto> Data { get; set; }

    //    public int TotalCount { get; set; }

    //    public int PageSize { get; set; }
    //}

    #endregion

    #region Cdr Stato Richieste

    //public class CdrStatoRichiestaApiDto
    //{
    //    public long Id { get; set; }
    //    public string Descrizione { get; set; }
    //    public bool Disabled { get; set; }

    //}

    //public class CdrStatiRichiesteApiDto
    //{
    //    public CdrStatiRichiesteApiDto()
    //    {
    //        Data = new List<CdrStatoRichiestaApiDto>();
    //    }

    //    public List<CdrStatoRichiestaApiDto> Data { get; set; }

    //    public int TotalCount { get; set; }

    //    public int PageSize { get; set; }
    //}

    #endregion

    #region Cdr Utenti

    //public class CdrUtenteApiDto
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

    //public class CdrUtentiApiDto
    //{
    //    public CdrUtentiApiDto()
    //    {
    //        Data = new List<CdrUtenteApiDto>();
    //    }

    //    public List<CdrUtenteApiDto> Data { get; set; }

    //    public int TotalCount { get; set; }

    //    public int PageSize { get; set; }
    //}

    #endregion

}