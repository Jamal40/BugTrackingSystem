using BugTrackingSystem.Data;
using BugTrackingSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackingSystem.Repositories
{
    public class UserRepo
    {
        private readonly BugTrackerDbContext db;
        private readonly ManipulateRoles rolesManipulator;

        public UserRepo(BugTrackerDbContext injectedContext, ManipulateRoles _roleManipulator)
        {
            db = injectedContext;
            rolesManipulator = _roleManipulator;
        }

        public List<BugTrackerUser> GetAllAvailableDevelopers()
        {
            List<BugTrackerUser> AvailableDevelopers = new List<BugTrackerUser>();

            foreach (BugTrackerUser user in db.BugTrackerUsers)
            {
                if (rolesManipulator.GetUserRoles(user.BugTrackerUserID).ID == RolesIDs.DeveloperID
                    && user.ProjectID == null)
                {
                    AvailableDevelopers.Add(user);
                }
            }
            return AvailableDevelopers;
        }

        public BugTrackerUser GetUserByID_IncludeProject(string UserID)
        {
            return db.BugTrackerUsers.Include(u => u.Project).FirstOrDefault(u => u.BugTrackerUserID == UserID);
        }
        public BugTrackerUser GetUserByID_IncludeManagedProject(string UserID)
        {
            return db.BugTrackerUsers.Include(u => u.ManagedProject).FirstOrDefault(u => u.BugTrackerUserID == UserID);
        }
        public BugTrackerUser GetUserByID_IncludeNotifications(string UserID)
        {
            return db.BugTrackerUsers.Include(u => u.Notifications).FirstOrDefault(u => u.BugTrackerUserID == UserID);
        }

        public BugTrackerUser GetUserByID(string UserID)
        {
            return db.BugTrackerUsers.FirstOrDefault(u => u.BugTrackerUserID == UserID);
        }

        public void UpdateDeveloperProject(string UserID, int? ProjectID)
        {
            var developer = db.BugTrackerUsers.FirstOrDefault(u => u.BugTrackerUserID == UserID);
            developer.ProjectID = ProjectID;
            db.SaveChanges();
        }
        public void AssignTicketToDeveloper(string DeveloperID, int TicketID)
        {
            db.Tickets.Find(TicketID).DeveloperID = DeveloperID;
            db.SaveChanges();
        }
        public void ChangeTicketStatus(int Status, int TicketID)
        {
            db.Tickets.Find(TicketID).Status = (StatusType)Status;
            db.SaveChanges();
        }

        internal void ChangeTicketPriority(int Priority, int TicketID)
        {
            db.Tickets.Find(TicketID).Priority = (PriorityType)Priority;
            db.SaveChanges();
        }
    }
}
