using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GASF.ApplicationLogic.Data;
using GASF.EFDataAccess;
using Microsoft.AspNetCore.Authorization;

namespace GASF.Controllers
{
    [Authorize(Policy = "Secretary")]
    public class GroupsCoursesController : Controller
    {
       
        private readonly StudentRecordDbContext _context;

        public GroupsCoursesController(StudentRecordDbContext context)
        {
            _context = context;
        }

        // GET: GroupsCourses/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Id");
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "GroupId");
            return View();
        }

        // POST: GroupsCourses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] GroupsCourses groupsCourses)
        {
            if (ModelState.IsValid)
            {
                if (GroupsCoursesExists(groupsCourses.CourseId, groupsCourses.GroupId))
                {
                    return Redirect(Url.Action("Index", "Course"));
                }
                groupsCourses.GroupId = Guid.NewGuid();
                _context.Add(groupsCourses);
                await _context.SaveChangesAsync();
                return Redirect(Url.Action("Index", "Course"));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Id", groupsCourses.CourseId);
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "GroupId", groupsCourses.GroupId);
            return View(groupsCourses);
        }

        //// GET: GroupsCourses
        //public async Task<IActionResult> Index()
        //{
        //    var studentRecordDbContext = _context.GroupsCourses.Include(g => g.Course).Include(g => g.Group);
        //    return View(await studentRecordDbContext.ToListAsync());
        //}

        //// GET: GroupsCourses/Details/5
        //public async Task<IActionResult> Details(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var groupsCourses = await _context.GroupsCourses
        //        .Include(g => g.Course)
        //        .Include(g => g.Group)
        //        .FirstOrDefaultAsync(m => m.GroupId == id);
        //    if (groupsCourses == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(groupsCourses);
        //}



        //// GET: GroupsCourses/Edit/5
        //public async Task<IActionResult> Edit(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var groupsCourses = await _context.GroupsCourses.FindAsync(id);
        //    if (groupsCourses == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Id", groupsCourses.CourseId);
        //    ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "GroupId", groupsCourses.GroupId);
        //    return View(groupsCourses);
        //}

        //// POST: GroupsCourses/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(Guid id, [Bind("Id,CourseId,GroupId")] GroupsCourses groupsCourses)
        //{
        //    if (id != groupsCourses.GroupId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(groupsCourses);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!GroupsCoursesExists(groupsCourses.GroupId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Id", groupsCourses.CourseId);
        //    ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "GroupId", groupsCourses.GroupId);
        //    return View(groupsCourses);
        //}

        //// GET: GroupsCourses/Delete/5
        //public async Task<IActionResult> Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var groupsCourses = await _context.GroupsCourses
        //        .Include(g => g.Course)
        //        .Include(g => g.Group)
        //        .FirstOrDefaultAsync(m => m.GroupId == id);
        //    if (groupsCourses == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(groupsCourses);
        //}

        //// POST: GroupsCourses/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(Guid id)
        //{
        //    var groupsCourses = await _context.GroupsCourses.FindAsync(id);
        //    _context.GroupsCourses.Remove(groupsCourses);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool GroupsCoursesExists(Guid courseId, Guid groupId)
        {
            return _context.GroupsCourses.Any(e => e.CourseId == courseId && e.GroupId==groupId);
        }
    }
}
