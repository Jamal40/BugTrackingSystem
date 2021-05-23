using BugTrackingSystem.Data;
using BugTrackingSystem.Models;
using BugTrackingSystem.Repositories;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackingSystem.Hubs
{
    public class NotificationHub:Hub
    {
        private readonly NotificationRepo notificationRepo;

        public NotificationHub( NotificationRepo _notificationRepo)
        {
            notificationRepo = _notificationRepo;
        }
        public async Task DeveloperFire(string message, string link, string DeveloperID)
        {
            notificationRepo.AddNotificationToUser(message, link, DeveloperID);

            await Clients.All.SendAsync("broadcastDeveloperFire", message, link, DeveloperID);
        }
    }
}
