using GASF.Models.Students;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GASF.ApplicationLogic.Services;
using GASF.ApplicationLogic.Data;
using Microsoft.AspNetCore.Authorization;
using CourseManager.Models.Students;

namespace GASF.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly StudentService studentService;
        public StudentController(UserManager<IdentityUser> userManager, StudentService studentService)
        {
            this.userManager = userManager;
            this.studentService = studentService;
        }



        public ActionResult Index()
        {
            try
            {
                var userId = userManager.GetUserId(User);
                var student = studentService.GetStudentById(userId);
                var studentCourses = studentService.GetStudentCourses(userId);

                var studentGrades = studentService.GetStudentGrade(userId);

                return View(new StudentCoursesViewModel { Student = student, Courses = studentCourses, Grades = studentGrades });
            }
            catch (Exception)
            {
                return BadRequest("Invalid request received ");
            }
        }

        [HttpGet]
        public IActionResult AddCourse()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCourse([FromForm]StudentAddCourseViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userId = userManager.GetUserId(User);
            studentService.AddCourse(userId, model.Name, model.Description);
            return Redirect(Url.Action("Index", "Teacher"));

        }


        [HttpGet]
        public async Task<IActionResult> Details(long? id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            Course gradeView = new Course();
            var userId = userManager.GetUserId(User);
            var student = studentService.GetStudentById(userId);
            //IEnumerable<Course> courses = studentService.GetStudentCourses(userId);
            IEnumerable<Grade> grades = studentService.GetStudentGrade(userId);

            
            gradeView.Grades = grades;
         
            if (student == null)
            {
                return NotFound();
            }

            return View(gradeView);
        }
    }
}
