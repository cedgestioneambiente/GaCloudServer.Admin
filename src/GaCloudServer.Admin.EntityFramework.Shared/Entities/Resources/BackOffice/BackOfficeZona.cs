using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.BackOffice
{
    public class BackOfficeZona : GenericEntity
    {
        public string Descrizione { get; set; }
        public int CadenzaRsu { get; set; }
        public int CadenzaCarta { get; set; }
        public int CadenzaPlastica { get; set; }
        public int CadenzaUmido { get; set; }
        public int CadenzaVetro { get; set; }

    }
}
