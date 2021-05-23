using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BugTrackingSystem.Data;
using BugTrackingSystem.Models;
using Microsoft.AspNetCore.Authorization;
using RestSharp;
using BugTrackingSystem.Repositories;

namespace BugTrackingSystem.Controllers
{
    public class AdminController : Controller
    {
        private readonly BugTrackerDbContext _context;
        private readonly ManipulateRoles rolesManipulator;
        private readonly ManipulateUsers usersManipulator;
        public AdminController(BugTrackerDbContext context, ManipulateRoles manipulateRoles, ManipulateUsers manipulateUsers)
        {
            _context = context;
            rolesManipulator = manipulateRoles;
            usersManipulator = manipulateUsers;
        }

        // GET: BugTrackerUsers
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var users = await _context.BugTrackerUsers.ToListAsync();
            foreach (var user in users)
            {
                user.Role = rolesManipulator.GetUserRoles(user.BugTrackerUserID);
            }
            return View(users);
        }

        // GET: BugTrackerUsers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bugTrackerUser = await _context.BugTrackerUsers
                .FirstOrDefaultAsync(m => m.BugTrackerUserID == id);
            if (bugTrackerUser == null)
            {
                return NotFound();
            }

            return View(bugTrackerUser);
        }

        // GET: BugTrackerUsers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bugTrackerUser = await _context.BugTrackerUsers.FirstOrDefaultAsync(u => u.BugTrackerUserID == id);

            if (bugTrackerUser == null)
            {
                return NotFound();
            }

            bugTrackerUser.Role = rolesManipulator.GetUserRoles(id);

            return View(bugTrackerUser);
        }

        // POST: BugTrackerUsers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("BugTrackerUserID,Name,Age")] BugTrackerUser bugTrackerUser, string role)
        {


            if (id != bugTrackerUser.BugTrackerUserID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Role currentUserRole = rolesManipulator.GetUserRoles(bugTrackerUser.BugTrackerUserID);

                    if (currentUserRole.ID != role)
                    {
                        rolesManipulator.DeleteRoleFromUser(bugTrackerUser.BugTrackerUserID, currentUserRole.ID);
                        rolesManipulator.AssignRoleToUser(bugTrackerUser.BugTrackerUserID, role);
                    }

                    _context.Update(bugTrackerUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BugTrackerUserExists(bugTrackerUser.BugTrackerUserID))
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
            return View(bugTrackerUser);
        }

        // GET: BugTrackerUsers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bugTrackerUser = await _context.BugTrackerUsers
                .FirstOrDefaultAsync(m => m.BugTrackerUserID == id);
            if (bugTrackerUser == null)
            {
                return NotFound();
            }

            return View(bugTrackerUser);
        }

        // POST: BugTrackerUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            usersManipulator.DeleteUser(id);
            var bugTrackerUser = await _context.BugTrackerUsers.FindAsync(id);
            _context.BugTrackerUsers.Remove(bugTrackerUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BugTrackerUserExists(string id)
        {
            return _context.BugTrackerUsers.Any(e => e.BugTrackerUserID == id);
        }

    }
}
