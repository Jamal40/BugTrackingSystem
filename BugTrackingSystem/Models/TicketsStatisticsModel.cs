using BugTrackingSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackingSystem.Models
{
    public class TicketsStatisticsModel
    {
        public int OpenTicketsCount { get; set; }
        public int InProgressTicketsCount { get; set; }
        public int StrugglingTicketsCount { get; set; }
        public int CompleteTicketCount { get; set; }

        public int LowPriorityTicketsCount { get; set; }
        public int ModeratePriorityTicketsCount { get; set; }
        public int HightPriorityTicketsCount { get; set; }
        public int ExtremePriorityTicketsCount { get; set; }

        public int AssignedTicketsCount { get; set; }
        public int UnassignedTicketsCount { get; set; }

        public List<ProjectStatisticViewModel> Projects { get; set; }
    }
}
