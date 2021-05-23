using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackingSystem.Models
{
    public class Notification
    {
        public int ID { get; set; }
        public string Message { get; set; }
        public string Link { get; set; }

        public string UserID { get; set; }
        [ForeignKey("UserID")]
        public BugTrackerUser User { get; set; }
    }
}
