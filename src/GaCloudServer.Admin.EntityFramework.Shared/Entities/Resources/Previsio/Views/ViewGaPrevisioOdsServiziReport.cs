using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Previsio.Views
{
    public class ViewGaPrevisioOdsServiziReport : GenericEntity
    {
        public string IDservizio { get; set; }
        public string Mezzo { get; set; }
        public string Rimorchio { get; set; }
        public string Autista { get; set; }
        public string Operatore { get; set; }
        public DateTime? DataOraIniMezzo { get; set; }
        public DateTime? DataOraFineMezzo { get; set; }
        public DateTime? DataOraIniAutista { get; set; }
        public DateTime? DataOraFineAutista { get; set; }
        public double? KmPartenza { get; set; }
        public double? KmFine { get; set; }
        public string Committente { get; set; }
        public string Servizio { get; set; }
        public string DenominazioneEstesa { get; set; }
        public string CodiceErp { get; set; }
        public string Denominazione { get; set; }
        public string Categoria { get; set; }
        public bool Annullato { get; set; }
        public bool Completo { get; set; }
        public bool Confermato { get; set; }
        public bool FaseConsuntivata { get; set; }
        public string IDFase { get; set; }
    }
}
