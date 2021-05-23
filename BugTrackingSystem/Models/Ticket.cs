using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackingSystem.Models
{
    public enum PriorityType
    {
        Low = 0,
        Moderate = 1,
        High = 2,
        Extreme = 3
    }
    public enum StatusType
    {
        Open = 0,
        InProgress = 1,
        Struggling = 2,
        Complete = 3
    }
    public class Ticket
    {
        [Key]
        public int TicketID { get; set; }

        [Required(ErrorMessage = "You must provide a description for the ticket")]
        public string Description { get; set; }

        public PriorityType Priority { get; set; }

        public StatusType Status { get; set; }

        //public bool? Accepted { get; set; }

        public int ProjectID { get; set; }
        public virtual Project Project { get; set; }

        public string DeveloperID { get; set; }
        [ForeignKey("DeveloperID")]
        public virtual BugTrackerUser Developer { get; set; }

        public string SubmitterID { get; set; }
        [ForeignKey("SubmitterID")]
        public virtual BugTrackerUser Submitter { get; set; }
    }
}
