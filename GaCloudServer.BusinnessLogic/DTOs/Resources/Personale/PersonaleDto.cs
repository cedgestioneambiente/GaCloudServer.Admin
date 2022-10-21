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
        public long MezziPatenteId { get; set; }
        public long MezziPeriodoScadenzaId { get; set; }
        public DateTime? DataScadenza { get; set; }
        public string? Preposto { get; set; }

    }

    public class PersonaleDipendentiDto : GenericPagedListDto<PersonaleDipendenteDto>
    { }
    #endregion
}