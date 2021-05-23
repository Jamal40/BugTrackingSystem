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
using Microsoft.AspNetCore.Authorization;

namespace BugTrackingSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProjectController : Controller
    {
        private readonly BugTrackerDbContext _context;
        private readonly ManipulateRoles rolesManipulator;

        public ProjectController(BugTrackerDbContext context, ManipulateRoles manipulateRoles)
        {
            _context = context;
            rolesManipulator = manipulateRoles;
        }


        public async Task<IActionResult> Index()
        {
            var bugTrackerDbContext = _context.Projects.Include(p => p.Manager);
            return View(await bugTrackerDbContext.ToListAsync());
        }

        [AllowAnonymous]
        [Authorize(Roles="Admin,Manager")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .Include(p => p.Manager)
                .FirstOrDefaultAsync(m => m.ProjectID == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }


        public IActionResult Create()
        {
            List<BugTrackerUser> Managers = new List<BugTrackerUser>();

            foreach (BugTrackerUser user in _context.BugTrackerUsers)
            {
                if (rolesManipulator.GetUserRoles(user.BugTrackerUserID).ID == RolesIDs.ManagerID)
                {
                    Managers.Add(user);
                }
            }

            ViewData["ManagerID"] = new SelectList(Managers, "BugTrackerUserID", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectID,ProjectName,ManagerID")] Project project)
        {
            if (ModelState.IsValid)
            {
                _context.Add(project);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            List<BugTrackerUser> Managers = new List<BugTrackerUser>();

            foreach (BugTrackerUser user in _context.BugTrackerUsers)
            {
                if (rolesManipulator.GetUserRoles(user.BugTrackerUserID).ID == RolesIDs.ManagerID)
                {
                    Managers.Add(user);
                }
            }

            ViewData["ManagerID"] = new SelectList(Managers, "BugTrackerUserID", "Name");
            return View(project);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            List<BugTrackerUser> Managers = new List<BugTrackerUser>();

            foreach (BugTrackerUser user in _context.BugTrackerUsers)
            {
                if (rolesManipulator.GetUserRoles(user.BugTrackerUserID).ID == RolesIDs.ManagerID)
                {
                    Managers.Add(user);
                }
            }

            ViewData["ManagerID"] = new SelectList(Managers, "BugTrackerUserID", "Name");
            return View(project);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectID,ProjectName,ManagerID")] Project project)
        {
            if (id != project.ProjectID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.ProjectID))
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
            List<BugTrackerUser> Managers = new List<BugTrackerUser>();

            foreach (BugTrackerUser user in _context.BugTrackerUsers)
            {
                if (rolesManipulator.GetUserRoles(user.BugTrackerUserID).ID == RolesIDs.ManagerID)
                {
                    Managers.Add(user);
                }
            }

            ViewData["ManagerID"] = new SelectList(Managers, "BugTrackerUserID", "Name");
            return View(project);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .Include(p => p.Manager)
                .FirstOrDefaultAsync(m => m.ProjectID == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.ProjectID == id);
        }
    }
}
