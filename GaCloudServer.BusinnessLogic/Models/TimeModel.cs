using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.BusinnessLogic.Models
{
    public class OpenHoursModel
    {
        public OpenHoursModel(string openHours)
        {
            var openClose = openHours.Split(new[] { ':', ';' });
            StartHour = int.Parse(openClose[0]);
            StartMinute = int.Parse(openClose[1]);
            EndHour = int.Parse(openClose[2]);
            EndMinute = int.Parse(openClose[3]);
        }

        public int StartHour
        {
            get;
            set;
        }

        public int StartMinute { get; set; }

        public int EndHour
        {
            get;
            set;
        }

        public int EndMinute
        {
            get;
            set;
        }
    }
}
