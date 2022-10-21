using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Reclami.Views
{
    public class ViewGaReclamiRegistri : GenericEntity
    {
        public string Numeratore { get; set; }
        public DateTime Data { get; set; }
        public string Cliente { get; set; }
        public string Motivo { get; set; }
        public DateTime RispostaEntro { get; set; }
        public DateTime? RispostaInviata { get; set; }
        public DateTime? RispostaDefinitiva { get; set; }
        public bool Fondato { get; set; }
        public string Infondato { get; set; }
        public string StatoReclamo { get; set; }
        public string Note { get; set; }
        public string AzioniIntraprese { get; set; }

        public string Avanzamento { get; set; }
    }
}
