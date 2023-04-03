using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Contratti.Views
{
    public class ViewGaContrattiDocumentiList : GenericEntity
    {
        public long ContrattoSoggettoId { get; set; }
        public int Numero { get; set; }
        public string Faldone { get; set; }
        public string RagioneSociale { get; set; }
        public string Descrizione { get; set; }
        public string CodiceCig { get; set; }
        public string Tipologia { get; set; }
        public DateTime? DataScadenza { get; set; }
        public string Modalita { get; set; }
        public string FileId { get; set; }
        public string FileName { get; set; }
        public string Stato { get; set; }
        public long TipologiaId { get; set; }
        public bool Archiviato { get; set; }
    }
}
