using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GASF.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //[HttpGet]
        //public IActionResult Students(Guid courseId)
        //{
        //    try
        //    {
        //        var userId = userManager.GetUserId(User);
        //        Teacher teacher = teacherService.GetTeacherByUserId(userId);
        //        Course course = courseService.GetById(courseId.ToString());
        //        IEnumerable<Student> students = teacherService.GetCourseStudents(courseId.ToString());
        //        return RedirectToAction(new TeacherCourseEnrolledStudents { Teacher = teacher, Course = course, Students = students });
        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest("Invalid request received ");
        //    }
        //}
    }
}