using System;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;


namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.System
{
    public class SystemVersion: GenericEntity
    {
        public string Versione { get; set; }
        public DateTime DataRilascio { get; set; }
        public string NuoveFunzionalita { get; set; }
        public string Modifiche { get; set; }
    }
}