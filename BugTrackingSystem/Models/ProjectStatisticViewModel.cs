using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackingSystem.Models
{
    public class ProjectStatisticViewModel
    {
        public string ProjectName { get; set; }
        public int AssignedTicketsCount { get; set; }
        public int UnassignedTickectsCount { get; set; }
        public int  DevelopersCount { get; set; }
    }
}
