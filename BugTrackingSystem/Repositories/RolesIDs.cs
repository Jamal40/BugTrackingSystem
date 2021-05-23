using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackingSystem.Repositories
{
    public static class RolesIDs
    {
        public static string AdminID { get; }
        public static string SubmitterID { get; }
        public static string DeveloperID { get; set; }
        public static string ManagerID { get; set; }
        static RolesIDs()
        {
            AdminID = "rol_HEU5egsj03k5nJL5";
            SubmitterID = "rol_jefBQ1w7ifZdD90u";
            DeveloperID = "rol_YKcjAvjme7r8PdnQ";
            ManagerID = "rol_t35mXcejYSrV6ZfB";

        }
    }
}
