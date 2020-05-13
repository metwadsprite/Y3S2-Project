using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GASF.ApplicationLogic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GASF.Controllers
{
    [Authorize(Policy = "Secretary")]
    public class SecretaryController : Controller
    {
        private readonly UserService userService;
        private readonly UserManager<IdentityUser> userManager;

        public SecretaryController(UserService userService, UserManager<IdentityUser> userManager)
        {
            this.userService = userService;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {            
            return View();
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