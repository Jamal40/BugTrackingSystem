using BugTrackingSystem.Data;
using BugTrackingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackingSystem.Repositories
{
    public class NotificationRepo
    {
        private readonly BugTrackerDbContext db;

        public NotificationRepo(BugTrackerDbContext injectedContext)
        {
            db = injectedContext;
        }

        public void AddNotificationToUser (string message, string link, string userId)
        {
            Notification addedNotification = new Notification
            {
                Message = message,
                Link = link, 
                UserID = userId
            };
            db.Notifications.Add(addedNotification);
            db.SaveChanges();
        }
    }
}
