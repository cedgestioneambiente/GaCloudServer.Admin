using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Mezzi.Views
{
    public class ViewGaMezziVeicoli:GenericEntity
    {
        public string Targa { get; set; }
        public string TipoMezzo { get; set; }
        public string ProprietaMezzo { get; set; }
        public string CantiereMezzo { get; set; }
        public string AlboGestori { get; set; }
        public string AlimentazioneMezzo { get; set; }
        public string PatenteMezzo { get; set; }
        public string EuroMezzo { get; set; }
        public string NumeroTelaio { get; set; }
        public int PortataKg { get; set; }
        public int MassaKg { get; set; }
        public int AnnoImmatricolazione { get; set; }
        public bool Ce { get; set; }
        public bool ManualeUsoManutenzione { get; set; }
        public bool CatalogoRicambi { get; set; }
        public bool Garanzia { get; set; }
        public string Note { get; set; }
        public bool CDP { get; set; }
        public bool CDPD { get; set; }
        public DateTime? ScadenzaContratto { get; set; }
        public DateTime? DismessoData { get; set; }
        public bool Dismesso { get; set; }
    }
}
