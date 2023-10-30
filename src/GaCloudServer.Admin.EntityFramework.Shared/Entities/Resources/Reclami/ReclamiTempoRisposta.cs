using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Reclami
{
    public class ReclamiTempoRisposta : GenericListAuditableEntity
    {
        public int Giorni { get; set; }
    }
}