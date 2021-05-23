using BugTrackingSystem.Data;
using BugTrackingSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackingSystem.Repositories
{
    public class ProjectRepo
    {
        private readonly BugTrackerDbContext db;
        public ProjectRepo(BugTrackerDbContext injectedContext)
        {
            db = injectedContext;
        }
        public Project GetProjectByManager(string Manager)
        {
            return db.Projects.Include(u => u.Developers).Include(u => u.Manager).FirstOrDefault(u => u.ManagerID == Manager);
        }
        public Project GetProjectByManagerWithTickets(string Manager)
        {
            return db.Projects.Include(u => u.Developers).Include(u => u.Manager).Include(u=>u.Tickets).FirstOrDefault(u => u.ManagerID == Manager);
        }
        public List<Project> GetAllProjectsWuthTickets()
        {
            return db.Projects.Include(p => p.Tickets).Include(p=>p.Developers).ToList();
        }
    }
}
