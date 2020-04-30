using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GASF.ApplicationLogic.Data;
using GASF.EFDataAccess;
using Microsoft.AspNetCore.Identity;
using GASF.ApplicationLogic.Services;

namespace GASF.Controllers
{
    public class TeachersController : Controller
    {

        private readonly UserManager<IdentityUser> userManager;
        private readonly ITeachersService teachersService;


        public TeachersController(UserManager<IdentityUser> userManager, ITeachersService teachersService)
        {
            this.userManager = userManager;
            this.teachersService = teachersService;
        }


        // GET: Teachers
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Teacher> teachers = teachersService.GetAllTeachers();
            return View(teachers);
        }


        // GET: Teachers/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var teacher = teachersService.GetTeacherById(id);

            return View(teacher);
        }

        // GET: Teachers/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Teachers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,Phone,BirthDate")] Teacher teacher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            teachersService.AddTeacher(teacher);
            return Redirect(Url.Action("Index", "Teachers"));
        }


        // GET: Teachers/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var teacher = teachersService.GetTeacherById(id);
            return View(teacher);
        }


        // POST: Teachers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,FirstName,LastName,Email,Phone,BirthDate")] Teacher teacher)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            teachersService.EditTeacher(id, teacher);
            return View(teacher);
        }

        // GET: Teachers/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var teacher = teachersService.GetTeacherById(id);
            return View(teacher);
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            teachersService.DeleteTeacher(id);
            return RedirectToAction(nameof(Index));
        }

    }
}