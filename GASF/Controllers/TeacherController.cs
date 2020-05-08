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
using Microsoft.AspNetCore.Routing;
using GASF.Models.Exams;
using GASF.Models.Students;

namespace GASF.Controllers
{
    [Authorize]
    public class TeacherController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly TeacherService teacherService;
        private readonly CourseService courseService;
        public TeacherController(UserManager<IdentityUser> userManager, TeacherService teacherService, CourseService courseService)
        {
            this.userManager = userManager;
            this.teacherService = teacherService;
            this.courseService = courseService;
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
        public IActionResult Exams()
        {
            try
            {
                var userId = userManager.GetUserId(User);
                Teacher teacher = teacherService.GetTeacherByUserId(userId);
                IEnumerable<Exam> exams = teacherService.GetExams(userId);
                return View(new TeacherExamViewModel { Teacher = teacher, Exams = exams });
            }
            catch (Exception)
            {
                return BadRequest("Invalid request received ");
            }
        }
        [HttpGet]
        public IActionResult Students(Guid id)
        {
            try
            {
                var userId = userManager.GetUserId(User);
                Teacher teacher = teacherService.GetTeacherByUserId(userId);
                Course course = courseService.GetById(id);
                IEnumerable<Student> students = teacherService.GetCourseStudents(id);
                return View(new TeacherCourseEnrolledStudents { Teacher = teacher, Course = course, Students = students });
            }
            catch (Exception)
            {
                return BadRequest("Invalid request received ");
            }
        }
        [HttpGet]
        public IActionResult ExamCreate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ExamCreate([FromForm]Exam exam)
        {
            if (ModelState.IsValid)
            {
                teacherService.AddExam(exam.Course.Name, exam.Date);
                return RedirectToAction(nameof(Index));
            }
            return View(exam);
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