using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.BusinnessLogic.Dtos.Extras.EcoFinder
{
    public class CustomEcoFinderDto
    {
        public class DetailedEventsType:EventsType
        {
            public string tag { get; set; }
            public string matricola { get; set; }
            public string utenza { get; set; }
            public string comune { get; set; }
            public string indirizzo { get; set; }
            public string numCon { get; set; }
            public string partita { get; set; }
            public string tipoContenitore { get; set; }

        }
    }
}
