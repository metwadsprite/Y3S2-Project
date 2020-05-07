using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GASF.ApplicationLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace GASF.Controllers
{
    public class SecretaryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}