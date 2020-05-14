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
using System.Collections;

namespace GASF.Controllers
{
    [Authorize(Policy = "Teacher")]
    public class TeacherController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly TeacherService teacherService;
        private readonly CourseService courseService;
        private readonly StudentService studentService;

        public TeacherController(UserManager<IdentityUser> userManager, TeacherService teacherService, CourseService courseService, StudentService studentService)
        {
            this.userManager = userManager;
            this.teacherService = teacherService;
            this.courseService = courseService;
            this.studentService = studentService;
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
                List<Grade> grades = new List<Grade>();
                foreach(var s in students)
                {
                    grades.Add(studentService.GetStudentExamGrade(s.Id.ToString(), course.Exam.Id.ToString()));
                }
                return View(new TeacherCourseEnrolledStudents { Teacher = teacher, Course = course, Students = students, Grades = grades });
            }
            catch (Exception)
            {
                return BadRequest("Invalid request received ");
            }
        }
        [HttpPost]
        //public IActionResult Students([FromForm]IEnumerable TeacherCourseEnrolledStudents)
        //{

        //}
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
                try
                {
                    teacherService.AddExam(exam.Course.Name, exam.Date);
                    return RedirectToAction(nameof(Index));
                }
                catch(Exception)
                {
                    return BadRequest("You shold give a valid name for the exam's course.");
                }
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