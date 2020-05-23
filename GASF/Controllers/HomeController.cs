using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GASF.Models;
using Microsoft.AspNetCore.Authorization;
using GASF.ApplicationLogic.Services;
using Microsoft.AspNetCore.Identity;

namespace GASF.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserService userService;
        private readonly UserManager<IdentityUser> userManager;

        public HomeController(ILogger<HomeController> logger,
            UserService userService,
            UserManager<IdentityUser> userManager
        ) {
            _logger = logger;
            this.userService = userService;
            this.userManager = userManager;            
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // Functionality should be handled thorugh backoffice
        // This is purely for testing purposes
        public IActionResult MakeMeSecretary()
        {
            userService.MakeUserSecretary(Guid.Parse(userManager.GetUserId(User)));
            return RedirectToAction("Index");
        }
    }
}
