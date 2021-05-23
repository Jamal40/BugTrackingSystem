using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackingSystem.Models
{
    public class UserProfileViewModel
    {
        public string UserID { get; set; }

        public string EmailAddress { get; set; }

        public string Name { get; set; }

        public string ProfileImage { get; set; }
    }
}
