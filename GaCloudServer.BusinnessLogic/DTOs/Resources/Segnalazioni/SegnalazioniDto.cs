using GaCloudServer.BusinnessLogic.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.BusinnessLogic.DTOs.Resources.Segnalazioni
{
    #region SegnalazioniTipi
    public class SegnalazioniTipoDto : GenericListDto
    {
    }

    public class SegnalazioniTipiDto : GenericPagedListDto<SegnalazioniTipoDto>
    {
    }

    #endregion

    #region SegnalazioniStati
    public class SegnalazioniStatoDto : GenericListDto
    {
    }

    public class SegnalazioniStatiDto : GenericPagedListDto<SegnalazioniStatoDto>
    {
    }

    #endregion

    #region SegnalazioniFotos
    public class SegnalazioniFotoDto : GenericFileDto
    {
        public long SegnalazioniDocumentoId { get; set; }
    }

    public class SegnalazioniFotosDto : GenericPagedListDto<SegnalazioniFotoDto>
    {
    }

    #endregion

    #region SegnalazioniDocumenti
    public class SegnalazioniDocumentoDto : GenericDto
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

    public class SegnalazioniDocumentiDto : GenericPagedListDto<SegnalazioniDocumentoDto>
    {
    }

    #endregion
}
