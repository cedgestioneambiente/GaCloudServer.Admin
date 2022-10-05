using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.BackOffice
{
    public class BackOfficeParametroOnCategoria : GenericEntity
    {
        public string TipoId { get; set; }
        public string Descrizione { get; set; }
        public double KgMqAnnui { get; set; }
        public double KgMqSmaltimento { get; set; }
        public double KgMqSmaltimentoGg { get; set; }
        public double KgMqRecupero { get; set; }
        public double KgMqRecuperoGg { get; set; }
        public double PercentualeCarta { get; set; }
        public double PercentualePlastica { get; set; }
        public double PercentualeVetro { get; set; }
        public double PercentualeUmido { get; set; }
        public double Costo { get; set; }
        public double Kc { get; set; }
        public double Kd { get; set; }
        public int NumeroSvuotamenti { get; set; }
        public double TFissa { get; set; }
        public double TVarCalcolata { get; set; }
        public double TVarMisurata { get; set; }

    }
}
