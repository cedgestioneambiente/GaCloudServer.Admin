using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.BackOffice.Views
{
    public class ViewGaBackOfficeUtenzeZone : GenericEntity
    {
        public string Comune { get; set; }
        public string Indirizzo { get; set; }
        public string Descri { get; set; }

    }
}
