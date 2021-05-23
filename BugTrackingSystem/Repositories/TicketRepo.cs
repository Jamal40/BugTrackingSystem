using BugTrackingSystem.Data;
using BugTrackingSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackingSystem.Repositories
{
    public class TicketRepo
    {
        private readonly BugTrackerDbContext db;

        public TicketRepo(BugTrackerDbContext injectedContext)
        {
            db = injectedContext;
        }

        public List<Ticket> GetAllTickets()
        {
            return db.Tickets.Include(t => t.Developer).Include(t => t.Project).ThenInclude(p=>p.Developers).Include(t => t.Submitter).ToList();
        }
        public void AddTicket(Ticket ticket)
        {
            db.Add(ticket);
            db.SaveChanges();
        }

        public Ticket GetTicketById(int? id)
        {
            return db.Tickets.Include(t => t.Developer).Include(t => t.Project).Include(t => t.Submitter).FirstOrDefault(t => t.TicketID == id);
        }
        public void UpdateTicket(Ticket ticket)
        {
            db.Update(ticket);
            db.SaveChanges();
        }
    }
}
