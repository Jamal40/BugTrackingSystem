using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BugTrackingSystem.Data;
using BugTrackingSystem.Models;
using BugTrackingSystem.Repositories;
using System.Security.Claims;

namespace BugTrackingSystem.Controllers
{
    public class TicketController : Controller
    {
        private readonly BugTrackerDbContext _context;
        private readonly TicketRepo ticketRepo;
        private readonly UserRepo userRepo;
        private readonly ManipulateRoles rolesManipulator;

        public TicketController(BugTrackerDbContext context, TicketRepo _ticketRepo, UserRepo _userRepo, ManipulateRoles _userManipulator)
        {
            _context = context;
            ticketRepo = _ticketRepo;
            userRepo = _userRepo;
            rolesManipulator = _userManipulator;
        }

        public IActionResult Index(string searchText)
        {
            var AllTickets = ticketRepo.GetAllTickets();
            List<Ticket> ShownTickets = new List<Ticket>();

            if (!String.IsNullOrEmpty(searchText))
            {
                AllTickets = AllTickets.Where(t => t.Description.Contains(searchText)).ToList();
            }

            string CureentUserID = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            BugTrackerUser CurrentUser = userRepo.GetUserByID_IncludeManagedProject(CureentUserID);
            Role CurrentUserRole = rolesManipulator.GetUserRoles(CureentUserID);

            if (CurrentUserRole.ID == RolesIDs.SubmitterID)
            {
                ShownTickets = AllTickets.Where(t => t.SubmitterID == CureentUserID).ToList();
            }
            if (CurrentUserRole.ID == RolesIDs.ManagerID)
            {
                ShownTickets = AllTickets.Where(t => t.ProjectID == CurrentUser.ManagedProject.ProjectID).ToList();
                return View("ManagerTicketsIndex", ShownTickets);
            }
            if (CurrentUserRole.ID == RolesIDs.DeveloperID)
            {
                ShownTickets = AllTickets.Where(t => t.DeveloperID == CurrentUser.BugTrackerUserID).ToList();
                return View("DeveloperTicketsIndex", ShownTickets);
            }

            return View(ShownTickets);
        }

        public IActionResult Create()
        {
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ProjectID", "ProjectName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("TicketID,Description,ProjectID")] Ticket ticket)
        {
            ticket.SubmitterID = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            ticket.Status = StatusType.Open;
            ticket.Priority = PriorityType.Low;

            if (ModelState.IsValid)
            {
                ticketRepo.AddTicket(ticket);
                return RedirectToAction(nameof(Index));
            }

            ViewData["ProjectID"] = new SelectList(_context.Projects, "ProjectID", "ProjectName", ticket.ProjectID);
            return View(ticket);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var ticket = ticketRepo.GetTicketById(id);
            if (ticket == null)
            {
                return NotFound();
            }
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ProjectID", "ProjectName", ticket.ProjectID);
            return View(ticket);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("TicketID,Description,ProjectID")] Ticket ticket)
        {


            if (id != ticket.TicketID)
            {
                return NotFound();
            }



            if (ModelState.IsValid)
            {
                try
                {
                    var ticketToUpdate = ticketRepo.GetTicketById(id);
                    ticketToUpdate.Description = ticket.Description;
                    ticketToUpdate.ProjectID = ticket.ProjectID;
                    ticketRepo.UpdateTicket(ticketToUpdate);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.TicketID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ProjectID", "ProjectName", ticket.ProjectID);
            return View(ticket);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = ticketRepo.GetTicketById(id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult AssigneTicketToDeveloper(string DeveloperID, int TicketID)
        {
            userRepo.AssignTicketToDeveloper(DeveloperID, TicketID);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult ChangeTicketStatus(int Status, int TicketID)
        {
            userRepo.ChangeTicketStatus(Status, TicketID);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult ChangeTicketPriority(int Priority, int TicketID)
        {
            userRepo.ChangeTicketPriority(Priority, TicketID);
            return RedirectToAction(nameof(Index));
        }

        private bool TicketExists(int id)
        {
            return _context.Tickets.Any(e => e.TicketID == id);
        }
    }
}
