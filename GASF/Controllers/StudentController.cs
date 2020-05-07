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
                var student = studentService.GetByUserId(userId);
                var studentCourses = studentService.GetStudentCourses(student.Id.ToString());
                var studentGrades = studentService.GetStudentGrade(student.Id.ToString());
                var schoolFee = studentService.GetSchoolFee(student.Id.ToString());

                return View(new StudentCoursesViewModel { Student = student, Courses = studentCourses, Grades = studentGrades, SchoolFee = schoolFee });
            }
            catch (Exception e)
            {
                return BadRequest("Invalid request received ");
            }
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
            var student = studentService.GetByUserId(userId);
            //IEnumerable<Course> courses = studentService.GetStudentCourses(userId);
            IEnumerable<Grade> grades = studentService.GetStudentGrade(userId);


            gradeView.Grades = grades;

            if (student == null)
            {
                return NotFound();
            }

            return View(gradeView);
        }

        //[HttpGet]
        //public IActionResult GetStudentCourses()
        //{
        //    return View();
        //}
    }
}
