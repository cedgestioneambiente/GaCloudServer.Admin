using GaCloudServer.Resources.Api.Dtos.Base;

namespace GaCloudServer.Resources.Api.Dtos.Resources.Previsio
{
    #region PrevisioOdsLetture
    public class PrevisioOdsLetturaApiDto : GenericListApiDto
    {
        public string IdServizio { get; set; }
        public string FileName { get; set; }
        public string ProcDescription { get; set; }
        public string ErrDescription { get; set; }
        public bool Elaborato { get; set; }
        public int Retry { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }

    public class PrevisioOdsLettureApiDto : GenericPagedListApiDto<PrevisioOdsLetturaApiDto>
    {
    }

    #endregion
}