using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GASF.ApplicationLogic.Data;
using GASF.ApplicationLogic.Services;
using GASF.EFDataAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace GASF.Controllers
{

    public class StudentsController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IStudentsService studentsService;

        public StudentsController(UserManager<IdentityUser> userManager, IStudentsService studentsService)
        {
            this.studentsService = studentsService;
            this.userManager = userManager;
        }

        // GET: Students
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Student> students = studentsService.GetAllStudents();
            return View(students);
        }

        // GET: Students/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var student = studentsService.GetStudentById(id);

            return View(student);
        }

        // GET: Students/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,Adress,Phone,BirthDate,CNP")] Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            studentsService.AddStudent(student);
            return Redirect(Url.Action("Index", "Students"));
        }

        // GET: Students/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var student = studentsService.GetStudentById(id);
            return View(student);
        }

        // POST: Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,FirstName,LastName,Email,Adress,Phone,BirthDate,CNP")] Student student)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            studentsService.EditStudent(id, student);
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var student = studentsService.GetStudentById(id);
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            studentsService.DeleteStudent(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
