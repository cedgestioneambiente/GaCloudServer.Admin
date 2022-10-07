using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.PrenotazioneAuto
{
    public class PrenotazioneAutoRegistrazione:GenericEntity
    {
        public string Colore { get; set; }
        public DateTime DataInizio { get; set; }
        public DateTime DataFine { get; set; }
        public bool InteraGiornata { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string RealeUtilizzatore { get; set; }
        public long PrenotazioneAutoVeicoloId { get; set; }

        public PrenotazioneAutoVeicolo PrenotazioneAutoVeicolo { get; set; }
    }
}
