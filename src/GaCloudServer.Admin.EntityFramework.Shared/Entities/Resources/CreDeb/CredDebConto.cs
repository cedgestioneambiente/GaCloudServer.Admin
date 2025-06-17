using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Identity.Views;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.CreDeb
{
    public class CreDebConto:GenericAuditableEntity
    {
        public string ContoTari { get; set; }
        public string RagioneSociale { get; set; }
        public string CodFis { get; set; }
        public string PIva { get; set; }
        public string ContoNeta { get; set; }

    }

}
