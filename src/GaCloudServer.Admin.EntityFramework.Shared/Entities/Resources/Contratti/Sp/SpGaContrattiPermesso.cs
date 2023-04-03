using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Contratti
{
    public class SpGaContrattiPermesso : GenericEntity
    {
        public long ContrattiSoggettoId { get; set; }
        public int Numero { get; set; }
        public string Descrizione { get; set; }
        public string Faldone { get; set; }
        public DateTime? DataScadenza { get; set; }
        public string Modalita { get; set; }
        public string Servizio { get; set; }
        public string Tipologia { get; set; }
        public string FileId { get; set; }
        public string FileName { get; set; }
        public string Stato { get; set; }
        public bool Archiviato { get; set; }
    }
}