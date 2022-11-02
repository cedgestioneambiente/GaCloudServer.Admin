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
}
