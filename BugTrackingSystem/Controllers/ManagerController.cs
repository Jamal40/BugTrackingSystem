using BugTrackingSystem.Models;
using BugTrackingSystem.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BugTrackingSystem.Controllers
{
    [Authorize(Roles = "Manager")]
    public class ManagerController : Controller
    {
        private readonly ProjectRepo projectRepo;
        private readonly UserRepo userRepo;
        private readonly ManipulateUsers usersManipulator;
        private readonly NotificationRepo notificationRepo;

        public ManagerController(ProjectRepo _projectRepo, UserRepo _userRepo, ManipulateUsers _usersManipulator, NotificationRepo _notificationRepo)
        {
            projectRepo = _projectRepo;
            userRepo = _userRepo;
            usersManipulator = _usersManipulator;
            notificationRepo = _notificationRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Main()
        {
            return View();
        }
        [HttpGet]
        public IActionResult DevelopersInProject()
        {
            string currentUserID = User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier).Value;
            Project CurrentProject = projectRepo.GetProjectByManager(currentUserID);
            List<BugTrackerUser> AllAvailableDevelopers = userRepo.GetAllAvailableDevelopers();
            ViewBag.AllDevelopers = AllAvailableDevelopers; /* new SelectList(AllAvailableDevelopers, "BugTrackerUserID", "Name");*/
            ViewBag.ExistingDevelopers = CurrentProject.Developers.ToList();
            return View(CurrentProject);
        }

        [HttpPost]
        public IActionResult AssignDevelopersToProject(string newdevs)
        {
            string[] AssignedDevelopersIDs = newdevs.Split("_");

            string currentUserID = User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier).Value;
            Project CurrentProject = projectRepo.GetProjectByManager(currentUserID);

            foreach (string DeveloeprID in AssignedDevelopersIDs)
            {
                if (DeveloeprID != String.Empty)
                {
                    //notificationRepo.AddNotificationToUser("You have been assigned to a project", "", DeveloeprID);
                    userRepo.UpdateDeveloperProject(DeveloeprID, CurrentProject.ProjectID);
                }
            }

            return RedirectToAction("DevelopersInProject", "Manager");
        }

        [HttpPost]
        public IActionResult RemoveDevelopersFromProject(string removed_devs)
        {
            string[] AssignedDevelopersIDs = removed_devs.Split("_");

            foreach (string DeveloeprID in AssignedDevelopersIDs)
            {
                if (DeveloeprID != string.Empty)
                {
                    userRepo.UpdateDeveloperProject(DeveloeprID, null);
                }

            }

            return RedirectToAction("DevelopersInProject", "Manager");
        }

        //[HttpGet]
        //public IActionResult TicketsInProject()
        //{
        //    string currentUserID = User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier).Value;
        //    Project CurrentProject = projectRepo.GetProjectByManagerWithTickets(currentUserID);
        //    List<Ticket> unassignedTickets = CurrentProject.Tickets.Where(t => t.DeveloperID == null).ToList(); 
        //    ViewBag.AllDevelopers = AllAvailableDevelopers; /* new SelectList(AllAvailableDevelopers, "BugTrackerUserID", "Name");*/
        //    ViewBag.ExistingDevelopers = CurrentProject.Developers.ToList();
        //    return View(CurrentProject);
        //}
    }
}
