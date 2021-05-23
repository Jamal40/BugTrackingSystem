using BugTrackingSystem.Data;
using BugTrackingSystem.Models;
using BugTrackingSystem.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BugTrackingSystem.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly BugTrackerDbContext db;
        private readonly ManipulateRoles rolesManipulator;
        public AccountController(BugTrackerDbContext injectedContext, ManipulateRoles manipulateRoles)
        {
            db = injectedContext;
            rolesManipulator = manipulateRoles;
        }
        public async Task Login(string returnUrl = "/")
        {
            Trace.WriteLine(returnUrl);
            await HttpContext.ChallengeAsync("Auth0", new AuthenticationProperties() { RedirectUri = returnUrl });
        }

        [Authorize]
        public async Task Logout()
        {
            await HttpContext.SignOutAsync("Auth0", new AuthenticationProperties
            {
                RedirectUri = Url.Action("Index", "Home")
            });
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }


        [Authorize]
        public IActionResult Claims()
        {
            return View();
        }

        [Authorize]
        public IActionResult Profile()
        {
            return View(new UserProfileViewModel()
            {
                UserID = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value,
                Name = User.Identity.Name,
                EmailAddress = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value,
                ProfileImage = User.Claims.FirstOrDefault(c => c.Type == "picture")?.Value
            });
        }

        public IActionResult SignUpRedirect(string state, string UserID)
        {
            if (db.BugTrackerUsers.Any(u=>u.BugTrackerUserID == UserID.Replace("_", "|")))
            {
                return Redirect($"https://dev-5rw-rtkk.eu.auth0.com/continue?state={state}");
            }
            BugTrackerUser user = new BugTrackerUser();
            user.BugTrackerUserID = UserID.Replace("_", "|");
            ViewBag.state = state;
            return View(user);
        }

        [HttpPost]
        public IActionResult SignUpRedirect(string state, BugTrackerUser _User)
        {
            if (ModelState.IsValid)
            {
                db.BugTrackerUsers.Add(_User);

                db.SaveChanges();

                rolesManipulator.AssignRoleToUser(_User.BugTrackerUserID, RolesIDs.SubmitterID);

                return Redirect($"https://dev-5rw-rtkk.eu.auth0.com/continue?state={state}");
            }

            ViewBag.state = state;
            return View(_User);
        }
    }
}
