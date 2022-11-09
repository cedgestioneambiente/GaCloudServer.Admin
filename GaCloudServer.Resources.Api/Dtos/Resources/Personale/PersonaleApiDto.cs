using GaCloudServer.Resources.Api.Dtos.Base;


namespace GaCloudServer.Resources.Api.Dtos.Resources.Personale
{
        #region PersonaleQualifiche

        public class PersonaleQualificaApiDto : GenericListApiDto
        {
        }

        public class PersonaleQualificheApiDto : GenericPagedListApiDto<PersonaleQualificaApiDto>
        {
        }
        #endregion

        #region PersonaleAssunzioni
        public class PersonaleAssunzioneApiDto : GenericListApiDto
        {
        }

        public class PersonaleAssunzioniApiDto : GenericPagedListApiDto<PersonaleAssunzioneApiDto>
        {
        }
        #endregion

        #region PersonaleDipendenti
        public class PersonaleDipendenteApiDto : GenericApiDto
        {
            public string UserId { get; set; }
            public long GlobalSedeId { get; set; }
            public long GlobalCentroCostoId { get; set; }
            public long PersonaleQualificaId { get; set; }
            public long PersonaleAssunzioneId { get; set; }
            public DateTime? DataScadenza { get; set; }
            public string? Preposto { get; set; }

        }

        public class PersonaleDipendentiApiDto : GenericPagedListApiDto<PersonaleDipendenteApiDto>
        { 
        }
    #endregion

        #region PersonaleScadenzeTipi
        public class PersonaleScadenzaTipoApiDto : GenericListApiDto
        {
        }

        public class PersonaleScadenzeTipiApiDto : GenericPagedListApiDto<PersonaleScadenzaTipoApiDto>
        {
        }
        #endregion

        #region PersonaleScadenzeDettagli
        public class PersonaleScadenzaDettaglioApiDto : GenericListApiDto
        {
        }

        public class PersonaleScadenzeDettagliApiDto : GenericPagedListApiDto<PersonaleScadenzaDettaglioApiDto>
        {
        }
        #endregion

        #region PersonaleScadenze
        public class PersonaleScadenzaApiDto : GenericFileApiDto
        {
            public long PersonaleDipendenteId { get; set; }
            public long PersonaleScadenzaTipoId { get; set; }
            public long PersonaleScadenzaDettaglioId { get; set; }
            public DateTime DataScadenza { get; set; }
        }

        public class PersonaleScadenzeApiDto : GenericPagedListApiDto<PersonaleScadenzaApiDto>
        {
        }
    #endregion

        #region PersonaleSanzioniMotivi

        public class PersonaleSanzioneMotivoApiDto : GenericListApiDto
        {
        }

        public class PersonaleSanzioniMotiviApiDto : GenericPagedListApiDto<PersonaleSanzioneMotivoApiDto>
        {
        }
        #endregion

        #region PersonaleSanzioniDescrizioni

        public class PersonaleSanzioneDescrizioneApiDto : GenericListApiDto
        {
        }

        public class PersonaleSanzioniDescrizioniApiDto : GenericPagedListApiDto<PersonaleSanzioneDescrizioneApiDto>
        {
        }
        #endregion

        #region PersonaleSanzioni

        public class PersonaleSanzioneApiDto : GenericFileApiDto
        {
            public long PersonaleDipendenteId { get; set; }
            public DateTime Data { get; set; }
            public long PersonaleSanzioneMotivoId { get; set; }
            public long PersonaleSanzioneDescrizioneId { get; set; }
            public string? DettaglioSanzione { get; set; }
        }

        public class PersonaleSanzioniApiDto : GenericPagedListApiDto<PersonaleSanzioneApiDto>
        {
        }
        #endregion

        #region PersonaleAbilitazioniTipi

        public class PersonaleAbilitazioneTipoApiDto : GenericListApiDto
        {
        }

        public class PersonaleAbilitazioniTipiApiDto : GenericPagedListApiDto<PersonaleAbilitazioneTipoApiDto>
        {
        }
        #endregion

        #region PersonaleAbilitazioni

        public class PersonaleAbilitazioneApiDto : GenericFileApiDto
        {
            public long PersonaleDipendenteId { get; set; }
            public long PersonaleAbilitazioneTipoId { get; set; }
            public DateTime DataVisita { get; set; }
            public DateTime DataScadenza { get; set; }
            public string? DettaglioAbilitazione { get; set; }
        }

        public class PersonaleAbilitazioniApiDto : GenericPagedListApiDto<PersonaleAbilitazioneApiDto>
        {
        }
        #endregion

        #region PersonaleRetributiviTipi

        public class PersonaleRetributivoTipoApiDto : GenericListApiDto
        {
        }

        public class PersonaleRetributiviTipiApiDto : GenericPagedListApiDto<PersonaleRetributivoTipoApiDto>
        {
        }
        #endregion

        #region PersonaleRetributivi

        public class PersonaleRetributivoApiDto : GenericFileApiDto
        {
            public long PersonaleDipendenteId { get; set; }
            public DateTime Data { get; set; }
            public long PersonaleRetributivoTipoId { get; set; }
            public string? DettaglioRetributivo { get; set; }
        }

        public class PersonaleRetributiviApiDto : GenericPagedListApiDto<PersonaleRetributivoApiDto>
        {
        }
        #endregion

        #region PersonaleArticoliModelli

        public class PersonaleArticoloModelloApiDto : GenericListApiDto
        {
        }

        public class PersonaleArticoliModelliApiDto : GenericPagedListApiDto<PersonaleArticoloModelloApiDto>
        {
        }
        #endregion

        #region PersonaleArticoliTipologie

        public class PersonaleArticoloTipologiaApiDto : GenericListApiDto
        {
        }

        public class PersonaleArticoliTipologieApiDto : GenericPagedListApiDto<PersonaleArticoloTipologiaApiDto>
        {
        }
        #endregion

        #region PersonaleArticoliDpis

        public class PersonaleArticoloDpiApiDto : GenericListApiDto
        {
            public string Caratteristiche { get; set; }
            public bool OmettiStampa { get; set; }
        }

        public class PersonaleArticoliDpisApiDto : GenericPagedListApiDto<PersonaleArticoloDpiApiDto>
        {
        }
        #endregion

        #region PersonaleArticoli

        public class PersonaleArticoloApiDto : GenericListApiDto
        {
            public long PersonaleArticoloTipologiaId { get; set; }
            public long PersonaleArticoloModelloId { get; set; }
            public long PersonaleArticoloDpiId { get; set; }
        }

        public class PersonaleArticoliApiDto : GenericPagedListApiDto<PersonaleArticoloApiDto>
        {
        }
        #endregion

        #region PersonaleSchedeConsegne

        public class PersonaleSchedaConsegnaApiDto : GenericFileApiDto
        {
            public long PersonaleDipendenteId { get; set; }
            public DateTime Data { get; set; }
            public string Numero { get; set; }
        }

        public class PersonaleSchedeConsegneApiDto : GenericPagedListApiDto<PersonaleSchedaConsegnaApiDto>
        {
        }
        #endregion

        #region PersonaleSchedeConsegneDettagli

        public class PersonaleSchedaConsegnaDettaglioApiDto : GenericApiDto
        {
        }

        public class PersonaleSchedeConsegneDettagliApiDto : GenericPagedListApiDto<PersonaleSchedaConsegnaDettaglioApiDto>
        {
        }
    #endregion

        //Internal
        public class DipendentiNuovaScheda
        {
            public long Id { get; set; }
            public string Articolo { get; set; }
            public string Dpi { get; set; }
            public string Taglia { get; set; }
            public int Qta { get; set; }
        }


}
