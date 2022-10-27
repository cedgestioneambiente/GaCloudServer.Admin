using GaCloudServer.Resources.Api.Dtos.Base;

namespace GaCloudServer.Resources.Api.Dtos.Segnalazioni
{
    #region SegnalazioniTipi
    public class SegnalazioniTipoApiDto : GenericListApiDto
    {
    }

    public class SegnalazioniTipiApiDto : GenericPagedListApiDto<SegnalazioniTipoApiDto>
    {
    }

    #endregion

    #region SegnalazioniStati
    public class SegnalazioniStatoApiDto : GenericListApiDto
    {
    }

    public class SegnalazioniStatiApiDto : GenericPagedListApiDto<SegnalazioniStatoApiDto>
    {
    }

    #endregion

    #region SegnalazioniFotos
    public class SegnalazioniFotoApiDto : GenericFileApiDto
    {
        public long SegnalazioniDocumentoId { get; set; }
    }

    public class SegnalazioniFotosApiDto : GenericPagedListApiDto<SegnalazioniFotoApiDto>
    {
    }

    #endregion

    #region SegnalazioniDocumenti
    public class SegnalazioniDocumentoApiDto : GenericApiDto
    {
        public long SegnalazioniTipoId { get; set; }
        public long SegnalazioniStatoId { get; set; }
        public string Note { get; set; }
        public float Longitudine { get; set; }
        public float Latitudine { get; set; }
        public string Indirizzo { get; set; }
        public DateTime DataOra { get; set; }
        public string ImgFolder { get; set; }
        public string UserId { get; set; }
        public bool Sanzione { get; set; }
        public string NoteSanzione { get; set; }
        public string NoteGestione { get; set; }
    }

    public class SegnalazioniDocumentiApiDto : GenericPagedListApiDto<SegnalazioniDocumentoApiDto>
    {
    }

    #endregion
}