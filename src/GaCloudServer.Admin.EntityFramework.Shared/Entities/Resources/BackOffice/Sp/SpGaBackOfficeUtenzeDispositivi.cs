using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.BackOffice.Sp
{
    public class SpGaBackOfficeUtenzeDispositivi:GenericEntity
    {
        public string Identi1 { get; set; }
        public string Identi2 { get; set; }
        public string TipCon { get; set; }
        public string DesCon { get; set; }
        public string TipMat { get; set; }
        public double Lt { get; set; }
        public string DtCon { get; set; }
        public string DtRit { get; set; }
        public string Partita { get; set; }
        public string NumCon { get; set; }
        public int CpRowNum { get; set; }



    }
}
