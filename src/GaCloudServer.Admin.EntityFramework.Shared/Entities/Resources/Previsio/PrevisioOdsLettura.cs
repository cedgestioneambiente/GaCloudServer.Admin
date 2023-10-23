using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Previsio
{
    public class PrevisioOdsLettura : GenericListEntity
    {
        public string IdServizio { get; set; }
        public string FileName { get; set; }
        public string ErrDescription { get; set; }
        public bool Elaborato { get; set; }

    }
}