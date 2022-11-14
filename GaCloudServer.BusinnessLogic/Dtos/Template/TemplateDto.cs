using GaCloudServer.BusinnessLogic.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.BusinnessLogic.Dtos.Template
{
    public class PersonaleSchedaConsegnaTemplateDto:GenericPrintDto
    {
        public string Numero { get; set; }
        public string Data { get; set; }
        public string Preposto { get; set; }
        public string Lavoratore { get; set; }
        public string Mansioni { get; set; }
        public List<dynamic> Articoli { get; set; }

    }
}
