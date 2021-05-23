using BugTrackingSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackingSystem.Data
{
    public class BugTrackerDbContext : DbContext
    {
        //public DbSet<Admin> Admins { get; set; }
        //public DbSet<Manager> Managers { get; set; }
        //public DbSet<Developer> Developers { get; set; }
        //public DbSet<Submitter> Submitters { get; set; }
        //public DbSet<Project> Projects { get; set; }
        //public DbSet<BugTrackerRole> BugTrackerRoles { get; set; }
        public DbSet<BugTrackerUser> BugTrackerUsers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public BugTrackerDbContext(DbContextOptions<BugTrackerDbContext> options)
        : base(options)
        {
        }

    }
}
