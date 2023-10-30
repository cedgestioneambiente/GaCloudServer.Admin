using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Global;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Mezzi
{
    public class MezziVeicolo: GenericAuditableEntity
    {
        public string Targa { get; set; }
        public string TargaPrecedente { get; set; }
        public string Carro { get; set; }
        public string Attrezzatura { get; set; }
        public int AnnoImmatricolazione { get; set; }
        public string AlboGestori { get; set; }
        public DateTime? ScadenzaContratto { get; set; }
        public string Note { get; set; }
        public string NumeroTelaio { get; set; }
        public int PortataKg { get; set; }
        public int MassaKg { get; set; }
        public bool Dismesso { get; set; }
        public DateTime? DismessoData { get; set; }
        public bool Ce { get; set; }
        public bool ManualeUsoManutenzione { get; set; }
        public bool CatalogoRicambi { get; set; }
        public long MezziTipoId { get; set; }
        public long MezziProprietarioId { get; set; }
        public long GlobalSedeId { get; set; }
        public long MezziClasseId { get; set; }
        public long MezziAlimentazioneId { get; set; }
        public long MezziPatenteId { get; set; }
        public long MezziPeriodoScadenzaId { get; set; }
        public bool Garanzia { get; set; }

        public MezziTipo MezziTipo { get; set; }
        public MezziProprietario MezziProprietario { get; set; }
        public GlobalSede GlobalSede { get; set; }
        public MezziClasse MezziClasse { get; set; }
        public MezziAlimentazione MezziAlimentazione { get; set; }
        public MezziPatente MezziPatente { get; set; }
        public MezziPeriodoScadenza MezziPeriodoScadenza { get; set; }
    }
}
