using GaCloudServer.BusinnessLogic.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.BusinnessLogic.Dtos.Resources.Ost
{
    public class OstTicketSummaryDto
    {
        public int year { get; set; }
        public int total { get; set; }
        public int totalClosed { get; set; }
        public int totalOverdue { get; set; }
        public int totalNewFromYesterday { get; set; }
        public int totalOpen { get; set; }
        public int totalWorked { get; set; }
        public int totalClosedFromYesterday { get; set; }
        public int totalNewToday { get; set; }

        public OstTicketSummaryDto() { }
    }

    public class OstTicketDistribution
    {
        public List<string> labels { get; set; }
        public List<int> series { get; set; }
        public int totalOpen { get; set; }
        public int totalClosed { get; set; }

        public OstTicketDistribution() { }
    }

    public class OstTicketStatistics
    {
        public double ticketMidTime { get; set; }
        public double ticketMidDay { get; set; }
        public double ticketSlaOpen { get; set; }
        public double ticketSlaClosed { get; set; }
        public double ticketMidClosedDay { get; set; }
        public double tickedMidOverdue { get; set; }
        public List<string> labels { get; set; }
        public List<int> twOpen { get; set; }
        public List<int> twClosed { get; set; }
        public List<int> lwOpen { get; set; }
        public List<int> lwClosed { get; set; }

        public OstTicketStatistics()
        {
            this.labels = new List<string>();
            this.twOpen = new List<int>();
            this.twClosed = new List<int>();
            this.lwClosed = new List<int>();
            this.lwOpen = new List<int>();
        }
    }
}

