using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.BackOffice
{
    public class BackOfficeMargine : GenericEntity
    {
        public double MargineRsu { get; set; }
        public double MargineCarta { get; set; }
        public double MarginePlastica { get; set; }
        public double MargineVetro { get; set; }
        public double MargineUmido { get; set; }
        public double PesoSpecificoRsu { get; set; }
        public double PesoSpecificoCarta { get; set; }
        public double PesoSpecificoPlastica { get; set; }
        public double PesoSpecificoVetro { get; set; }
        public double PesoSpecificoUmido { get; set; }

    }
}
