using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.BackOffice.Views
{
    public class ViewGaBackOfficeTipCon : GenericEntity
    {
        public string TipCon { get; set; }
        public string DesCon { get; set; }
        public string TipMat { get; set; }
        public int Lt { get; set; }

    }
}
