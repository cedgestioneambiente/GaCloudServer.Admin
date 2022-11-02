using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Segnalazioni.Views
{
    public class ViewGaSegnalazioniDocumenti : GenericEntity
    {
        public long TipoId { get; set; }
        public string Tipo { get; set; }
        public string Note { get; set; }
        public float Longitudine { get; set; }
        public float Latitudine { get; set; }
        public string Indirizzo { get; set; }
        public DateTime DataOra { get; set; }
        public string UserId { get; set; }
        public string User { get; set; }
        public long StatoId { get; set; }
        public string Stato { get; set; }
        public bool Sanzione { get; set; }
        public string NoteSanzione { get; set; }
        public string NoteGestione { get; set; }
    }
}
