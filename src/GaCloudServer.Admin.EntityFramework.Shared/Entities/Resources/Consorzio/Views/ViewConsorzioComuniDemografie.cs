using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Consorzio.Views
{
    public class ViewConsorzioComuniDemografie : GenericListEntity
    {
        public int Anno2022 { get; set; }
        public int Anno2023 { get; set; }
        public int Anno2024 { get; set; }
        public int Anno2025 { get; set; }
        public int Anno2026 { get; set; }
        public int Anno2027 { get; set; }
        public string Cap { get; set; }
        public long ConsorzioComuneId { get; set; }
        public string Istat { get; set; }
        public string Provincia { get; set; }
        public string Regione { get; set; }

    }
}
