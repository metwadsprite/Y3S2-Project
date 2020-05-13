using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GASF.ApplicationLogic.Data;
using GASF.EFDataAccess;
using GASF.Models.Courses;
using GASF.ApplicationLogic.Services;

namespace GASF.Controllers
{
    public class CourseController : Controller
    {
        private readonly CourseService _courseService;
        private readonly GroupService _groupService;
        private readonly StudentRecordDbContext _context;
        public CourseController(CourseService courseService, GroupService groupService,StudentRecordDbContext context)
        {
            _courseService = courseService;
            _groupService = groupService;
            _context = context;
        }

        // GET: Course
        public IActionResult Index()
        {

            return View(_courseService.GetAll());
        }

        // GET: Course/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
           

            var course = _courseService.GetById(id);
           

            var teacher= await _context.Teachers.FirstOrDefaultAsync(m => m.Id == course.TeacherId);

            var groups = _groupService.GetGroupsByCourseId(course.Id);
            CourseDetails courseDetails = new CourseDetails()
            {
                Course = course,
                Teacher = teacher,
                Groups = groups
            };
            return View(courseDetails);
        }

        // GET: Course/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Course/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
           

            _courseService.AddCourse(course);
            return Redirect(Url.Action("Index", "Course"));
        }

        // GET: Course/Edit/5
        public IActionResult Edit(Guid id)
        {


            var course = _courseService.GetById(id);
            
            return View(course);
        }

        // POST: Course/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [FromForm] Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _courseService.EditCourse(course);
            return RedirectToAction("Index");
        }

        // GET: Course/Delete/5
        public IActionResult Delete(Guid id)
        {
            var course = _courseService.GetById(id);
            return View(course);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _courseService.DeleteCourse(id);
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(Guid id)
        {
            return _context.Courses.Any(e => e.Id == id);
        }
    }
}
