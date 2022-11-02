using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Segnalazioni.Ec
{
    public class EcSegnalazioniDocumento : GenericEntity
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


        public EcSegnalazioniTipo SegnalazioniTipo { get; set; }
        public EcSegnalazioniStato SegnalazioniStato { get; set; }
    }
}
