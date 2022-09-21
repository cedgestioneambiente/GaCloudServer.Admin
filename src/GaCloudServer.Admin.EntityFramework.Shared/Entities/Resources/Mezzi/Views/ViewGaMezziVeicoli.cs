using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Mezzi.Views
{
    public class ViewGaMezziVeicoli:GenericEntity
    {
        public string Targa { get; set; }
        public string Tipo { get; set; }
        public string Proprietario { get; set; }
        public string Cantiere { get; set; }
        public string AlboGestori { get; set; }
        public string Alimentazione { get; set; }
        public string Patente { get; set; }
        public string Euro { get; set; }
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
