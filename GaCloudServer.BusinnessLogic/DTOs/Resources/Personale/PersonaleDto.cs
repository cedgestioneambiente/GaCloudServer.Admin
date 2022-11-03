using GaCloudServer.BusinnessLogic.DTOs.Base;
using System.ComponentModel.DataAnnotations;

namespace GaCloudServer.BusinnessLogic.Dtos.Resources.Personale
{
    #region PersonaleQualifiche

    public class PersonaleQualificaDto : GenericListDto
    {
    }

    public class PersonaleQualificheDto : GenericPagedListDto<PersonaleQualificaDto>
    {
    }
    #endregion

    #region PersonaleAssunzioni
    public class PersonaleAssunzioneDto : GenericListDto
    {
    }

    public class PersonaleAssunzioniDto : GenericPagedListDto<PersonaleAssunzioneDto>
    {
    }
    #endregion

    #region PersonaleDipendenti
    public class PersonaleDipendenteDto : GenericDto
    {
        public string UserId { get; set; }
        public long GlobalSedeId { get; set; }
        public long GlobalCentroCostoId { get; set; }
        public long PersonaleQualificaId { get; set; }
        public long PersonaleAssunzioneId { get; set; }
        public DateTime? DataScadenza { get; set; }
        public string? Preposto { get; set; }

    }

    public class PersonaleDipendentiDto : GenericPagedListDto<PersonaleDipendenteDto>
    { }
    #endregion

    #region PersonaleScadenzeTipi
    public class PersonaleScadenzaTipoDto : GenericListDto
    {
    }

    public class PersonaleScadenzeTipiDto : GenericPagedListDto<PersonaleScadenzaTipoDto>
    {
    }
    #endregion

    #region PersonaleScadenzeDettagli
    public class PersonaleScadenzaDettaglioDto : GenericListDto
    {
    }

    public class PersonaleScadenzeDettagliDto : GenericPagedListDto<PersonaleScadenzaDettaglioDto>
    {
    }
    #endregion

    #region PersonaleDipendentiScadenze
    public class PersonaleDipendenteScadenzaDto : GenericFileDto
    {
        public long PersonaleDipendenteId { get; set; }
        public long PersonaleScadenzaTipoId { get; set; }
        public long PersonaleScadenzaDettaglioId { get; set; }
        public DateTime DataScadenza { get; set; }
    }

    public class PersonaleDipendentiScadenzeDto : GenericPagedListDto<PersonaleDipendenteScadenzaDto>
    {
    }
    #endregion

    #region PersonaleSanzioniMotivi

    public class PersonaleSanzioneMotivoDto : GenericListDto
    {
    }

    public class PersonaleSanzioniMotiviDto : GenericPagedListDto<PersonaleSanzioneMotivoDto>
    {
    }
    #endregion

    #region PersonaleSanzioniDescrizioni

    public class PersonaleSanzioneDescrizioneDto : GenericListDto
    {
    }

    public class PersonaleSanzioniDescrizioniDto : GenericPagedListDto<PersonaleSanzioneDescrizioneDto>
    {
    }
    #endregion

    #region PersonaleSanzioni

    public class PersonaleSanzioneDto : GenericFileDto
    {
        public long PersonaleDipendenteId { get; set; }
        public DateTime Data { get; set; }
        public long PersonaleSanzioneMotivoId { get; set; }
        public long PersonaleSanzioneDescrizioneId { get; set; }
        public string DettaglioSanzione { get; set; }
    }

    public class PersonaleSanzioniDto : GenericPagedListDto<PersonaleSanzioneDto>
    {
    }
    #endregion

    #region PersonaleAbilitazioniTipi

    public class PersonaleAbilitazioneTipoDto : GenericListDto
    {
    }

    public class PersonaleAbilitazioniTipiDto : GenericPagedListDto<PersonaleAbilitazioneTipoDto>
    {
    }
    #endregion

    #region PersonaleAbilitazioni

    public class PersonaleAbilitazioneDto : GenericFileDto
    {
        public long PersonaleDipendenteId { get; set; }
        public long PersonaleAbilitazioneTipoId { get; set; }
        public DateTime DataVisita { get; set; }
        public DateTime DataScadenza { get; set; }
        public string DettaglioAbilitazione { get; set; }
    }

    public class PersonaleAbilitazioniDto : GenericPagedListDto<PersonaleAbilitazioneDto>
    {
    }
    #endregion

    #region PersonaleRetributiviTipi

    public class PersonaleRetributivoTipoDto : GenericListDto
    {
    }

    public class PersonaleRetributiviTipiDto : GenericPagedListDto<PersonaleRetributivoTipoDto>
    {
    }
    #endregion

    #region PersonaleRetributivi

    public class PersonaleRetributivoDto : GenericFileDto
    {
        public long PersonaleDipendenteId { get; set; }
        public DateTime Data { get; set; }
        public long DipendenteRetributivoTipoId { get; set; }
        public string DettaglioRetributivo { get; set; }
    }

    public class PersonaleRetributiviDto : GenericPagedListDto<PersonaleRetributivoDto>
    {
    }
    #endregion

    #region PersonaleArticoliModelli

    public class PersonaleArticoloModelloDto : GenericListDto
    {
    }

    public class PersonaleArticoliModelliDto : GenericPagedListDto<PersonaleArticoloModelloDto>
    {
    }
    #endregion

    #region PersonaleArticoliTipologie

    public class PersonaleArticoloTipologiaDto : GenericListDto
    {
    }

    public class PersonaleArticoliTipologieDto : GenericPagedListDto<PersonaleArticoloTipologiaDto>
    {
    }
    #endregion

    #region PersonaleArticoliDpis

    public class PersonaleArticoloDpiDto : GenericListDto
    {
        public string Caratteristiche { get; set; }
        public bool OmettiStampa { get; set; }
    }

    public class PersonaleArticoliDpisDto : GenericPagedListDto<PersonaleArticoloDpiDto>
    {
    }
    #endregion

    #region PersonaleArticoli

    public class PersonaleArticoloDto : GenericListDto
    {
        public long PersonaleArticoloTipologiaId { get; set; }
        public long PersonaleArticoloModelloId { get; set; }
        public long PersonaleArticoloDpiId { get; set; }
    }

    public class PersonaleArticoliDto : GenericPagedListDto<PersonaleArticoloDto>
    {
    }
    #endregion

    #region PersonaleSchedeConsegne

    public class PersonaleSchedaConsegnaDto : GenericFileDto
    {
        public long PersonaleDipendenteId { get; set; }
        public DateTime Data { get; set; }
        public string Numero { get; set; }
    }

    public class PersonaleSchedeConsegneDto : GenericPagedListDto<PersonaleSchedaConsegnaDto>
    {
    }
    #endregion

    #region PersonaleSchedeConsegneDettagli

    public class PersonaleSchedaConsegnaDettaglioDto : GenericDto
    {
    }

    public class PersonaleSchedeConsegneDettagliDto : GenericPagedListDto<PersonaleSchedaConsegnaDettaglioDto>
    {
    }
    #endregion
}