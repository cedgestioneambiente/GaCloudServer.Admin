using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Reclami
{
    public class ReclamiTipoOrigine : GenericListAuditableEntity
    {
        public string DescrizioneBreve { get; set; }
    }
}
