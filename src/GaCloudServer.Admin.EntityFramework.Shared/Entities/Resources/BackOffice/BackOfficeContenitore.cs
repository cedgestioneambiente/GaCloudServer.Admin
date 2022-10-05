using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.BackOffice
{
    public class BackOfficeContenitore : GenericEntity
    {
        public string TipCon { get; set; }
        public string Descrizione { get; set; }
        public double Lt { get; set; }

    }
}
