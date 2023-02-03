using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.BackOffice.Views
{
    public class ViewGaBackOfficeContenitoriLetture:GenericEntity
    {
        public DateTime DtReg { get; set; }
        public string Ora { get; set; }
        public string Identi1 { get; set; }
        public string Identi2 { get; set; }
        public string? Mezzo { get; set; }
        public decimal? CoordX { get; set; }
        public decimal? CoordY { get; set; }
        public string Confe { get; set; }
        public string CodComune { get; set; }
        public string Comune { get; set; }
        public string NumCon { get; set; }
        public string Partita { get; set; }
        public int PrgCon { get; set; }
        public int CpRowNum { get; set; }
        public string TipCon { get; set; }
        public string DesCon { get; set; }
        public string TipMat { get; set; }
        public string Cessato { get; set; }
        public string Ragso { get; set; }
        public string CodFis { get; set; }
        public string Tributo { get; set; }
        public int NrComp { get; set; }
        public string Cat { get; set; }
        public string DesCat { get; set; }
    }
}
