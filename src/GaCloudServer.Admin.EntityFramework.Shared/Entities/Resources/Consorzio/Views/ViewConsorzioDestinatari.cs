using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Consorzio.Views
{
    public class ViewConsorzioDestinatari : GenericListEntity
    {
        public string Comune { get; set; }
        public string Indirizzo { get; set; }
        public string CdPiva { get; set; }

    }
}