using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Consorzio
{
    public class ConsorzioComuneDemografia : GenericAuditableEntity
    {
        public long ConsorzioComuneId { get; set; }
        public int Anno2022 { get; set; }
        public int Anno2023 { get; set; }
        public int Anno2024 { get; set; }
        public int Anno2025 { get; set; }
        public int Anno2026 { get; set; }
        public int Anno2027 { get; set; }

        public ConsorzioComune ConsorzioComune { get; set; }
    }
}
