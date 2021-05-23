using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackingSystem.Models
{
    public class BugTrackerUser
    {
        [Key]
        public string BugTrackerUserID { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        [Range(0, 50)]
        public int Age { get; set; }

        [InverseProperty("Developer")]
        public virtual ICollection<Ticket> AssignedTickets { get; set; }

        [InverseProperty("Submitter")]
        public virtual ICollection<Ticket> SubmittedTickets { get; set; }

        public int? ProjectID { get; set; }
        [ForeignKey("ProjectID")]
        public virtual Project Project { get; set; }
        

        [InverseProperty("Manager")]
        public virtual Project ManagedProject { get; set; }

        public virtual ICollection<Notification> Notifications { get; set; }


        [NotMapped]
        public Role Role { get; set; }

        public BugTrackerUser()
        {
            AssignedTickets = new HashSet<Ticket>();
            Notifications = new HashSet<Notification>();
        }
    }
}
