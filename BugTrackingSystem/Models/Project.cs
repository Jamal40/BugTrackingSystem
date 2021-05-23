using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackingSystem.Models
{
    public class Project
    {
        [Key]
        public int ProjectID { get; set; }
        
        [Required(AllowEmptyStrings =false, ErrorMessage ="You need to provide a name for the project.")]
        [Display(Name ="Project Name")]
        public string ProjectName { get; set; }

        [Required]
        public string ManagerID { get; set; }

        [ForeignKey("ManagerID")]
        public virtual BugTrackerUser Manager { get; set; }

        [InverseProperty("Project")]
        public virtual ICollection<BugTrackerUser> Developers { get; set; }

        public ICollection<Ticket> Tickets { get; set; }

        public Project()
        {
            Developers = new HashSet<BugTrackerUser>();
            Tickets = new HashSet<Ticket>();
        }
    }
}
