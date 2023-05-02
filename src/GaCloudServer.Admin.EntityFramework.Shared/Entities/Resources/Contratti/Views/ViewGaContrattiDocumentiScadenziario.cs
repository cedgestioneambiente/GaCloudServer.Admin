using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Contratti.Views
{
    public class ViewGaContrattiDocumentiScadenziario : GenericEntity
    {
        public int Numero { get; set; }
        public long ContrattiSoggettoId { get; set; }
        public string RagioneSociale { get; set; }
        public string Descrizione { get; set; }
        public string CodiceCig { get; set; }
        public string Faldone { get; set; }
        public DateTime? DataScadenza { get; set; }
        public string Modalita { get; set; }
        public string ModalitaId { get; set; }
        public string Tipologia { get; set; }
        public string TipologiaId { get; set; }
        public string Permission { get; set; }
        public string PermissionFriendlyName { get; set; }
        public string PermissionId { get; set; }
        public bool Fornitore { get; set; }
        public bool Cliente { get; set; }
        public int NumAllegati { get; set; }
        public string Stato { get; set; }
        public bool Archiviato { get; set; }
        public bool SoggettoDisabled { get; set; }
    }
}
