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
using GASF.Models.Courses;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace GASF.Controllers
{
    [Authorize]
    public class TeacherController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly TeacherService teacherService;
        public TeacherController(UserManager<IdentityUser> userManager, TeacherService teacherService)
        {
            this.userManager = userManager;
            this.teacherService = teacherService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                var userId = userManager.GetUserId(User);
                Teacher teacher = teacherService.GetTeacherByUserId(userId);
                IEnumerable<Course> teacherCourses = teacherService.GetCourses(userId);

                return View(new TeacherCoursesViewModel { Teacher = teacher, Courses = teacherCourses });
            }
            catch (Exception)
            {
                return BadRequest("Invalid request received ");
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm]TeacherAddCourseViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var userId = userManager.GetUserId(User);
            teacherService.AddCourse(userId, model.Name, model.Description);
            return Redirect(Url.Action("Index", "Teacher"));
        }
    }
}
