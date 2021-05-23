using BugTrackingSystem.Models;
using BugTrackingSystem.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BugTrackingSystem.Controllers
{
    [AllowAnonymous]
    public class StatisticController : Controller
    {
        private readonly TicketRepo ticketRepo;
        private readonly ProjectRepo projectRepo;

        public StatisticController(TicketRepo injectedTicktRepo, ProjectRepo injectedProjectRepo)
        {
            ticketRepo = injectedTicktRepo;
            projectRepo = injectedProjectRepo;
        }

        public IActionResult Developer()
        {
            string CurrentUserID = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            List<Ticket> RelatedTickets = ticketRepo.GetAllTickets().Where(t => t.DeveloperID == CurrentUserID).ToList();

            TicketsStatisticsModel TSM = new TicketsStatisticsModel
            {
                OpenTicketsCount = RelatedTickets.Where(t => t.Status == StatusType.Open).Count(),
                InProgressTicketsCount = RelatedTickets.Where(t => t.Status == StatusType.InProgress).Count(),
                StrugglingTicketsCount = RelatedTickets.Where(t => t.Status == StatusType.Struggling).Count(),
                CompleteTicketCount = RelatedTickets.Where(t => t.Status == StatusType.Complete).Count(),

                LowPriorityTicketsCount = RelatedTickets.Where(t => t.Priority == PriorityType.Low).Count(),
                ModeratePriorityTicketsCount = RelatedTickets.Where(t => t.Priority == PriorityType.Moderate).Count(),
                HightPriorityTicketsCount = RelatedTickets.Where(t => t.Priority == PriorityType.High).Count(),
                ExtremePriorityTicketsCount = RelatedTickets.Where(t => t.Priority == PriorityType.Extreme).Count(),
            };
            return View(TSM);
        }

        public IActionResult Manager()
        {
            string CurrentUserID = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            int ProjectID = projectRepo.GetProjectByManager(CurrentUserID).ProjectID;

            List<Ticket> RelatedTickets = ticketRepo.GetAllTickets().Where(t => t.ProjectID == ProjectID).ToList();

            TicketsStatisticsModel TSM = new TicketsStatisticsModel
            {
                OpenTicketsCount = RelatedTickets.Where(t => t.Status == StatusType.Open).Count(),
                InProgressTicketsCount = RelatedTickets.Where(t => t.Status == StatusType.InProgress).Count(),
                StrugglingTicketsCount = RelatedTickets.Where(t => t.Status == StatusType.Struggling).Count(),
                CompleteTicketCount = RelatedTickets.Where(t => t.Status == StatusType.Complete).Count(),

                LowPriorityTicketsCount = RelatedTickets.Where(t => t.Priority == PriorityType.Low).Count(),
                ModeratePriorityTicketsCount = RelatedTickets.Where(t => t.Priority == PriorityType.Moderate).Count(),
                HightPriorityTicketsCount = RelatedTickets.Where(t => t.Priority == PriorityType.High).Count(),
                ExtremePriorityTicketsCount = RelatedTickets.Where(t => t.Priority == PriorityType.Extreme).Count(),

                AssignedTicketsCount = RelatedTickets.Where(t => t.DeveloperID != null).Count(),
                UnassignedTicketsCount = RelatedTickets.Where(t => t.DeveloperID == null).Count()
            };

            return View(TSM);
        }

        public IActionResult Admin()
        {
            List<Ticket> RelatedTickets = ticketRepo.GetAllTickets().ToList();

            List<Project> Projects = projectRepo.GetAllProjectsWuthTickets();
            List<ProjectStatisticViewModel> ProjectsViewModels = new List<ProjectStatisticViewModel>();
            foreach (Project project in Projects)
            {
                ProjectsViewModels.Add(new ProjectStatisticViewModel
                {
                    ProjectName = project.ProjectName,
                    AssignedTicketsCount = project.Tickets.Where(t => t.DeveloperID != null).Count(),
                    UnassignedTickectsCount = project.Tickets.Where(t => t.DeveloperID == null).Count(),
                    DevelopersCount = project.Developers.Count()
                }
                );
            }

            TicketsStatisticsModel TSM = new TicketsStatisticsModel
            {
                OpenTicketsCount = RelatedTickets.Where(t => t.Status == StatusType.Open).Count(),
                InProgressTicketsCount = RelatedTickets.Where(t => t.Status == StatusType.InProgress).Count(),
                StrugglingTicketsCount = RelatedTickets.Where(t => t.Status == StatusType.Struggling).Count(),
                CompleteTicketCount = RelatedTickets.Where(t => t.Status == StatusType.Complete).Count(),

                LowPriorityTicketsCount = RelatedTickets.Where(t => t.Priority == PriorityType.Low).Count(),
                ModeratePriorityTicketsCount = RelatedTickets.Where(t => t.Priority == PriorityType.Moderate).Count(),
                HightPriorityTicketsCount = RelatedTickets.Where(t => t.Priority == PriorityType.High).Count(),
                ExtremePriorityTicketsCount = RelatedTickets.Where(t => t.Priority == PriorityType.Extreme).Count(),

                Projects = ProjectsViewModels
            };



            return View(TSM);
        }
    }
}
