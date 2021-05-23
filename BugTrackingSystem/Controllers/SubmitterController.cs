using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTrackingSystem.Controllers
{
    public class SubmitterController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
