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
    public class SchoolFeesController : Controller
    {
        private readonly StudentRecordDbContext _context;

        public SchoolFeesController(StudentRecordDbContext context)
        {
            _context = context;
        }

        // GET: SchoolFees
        public async Task<IActionResult> Index()
        {
            var studentRecordDbContext = _context.SchoolFees.Include(s => s.Student);
            return View(await studentRecordDbContext.ToListAsync());
        }

        // GET: SchoolFees/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schoolFee = await _context.SchoolFees
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schoolFee == null)
            {
                return NotFound();
            }

            return View(schoolFee);
        }

        // GET: SchoolFees/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id");
            return View();
        }

        // POST: SchoolFees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm]SchoolFee schoolFee)
        {
            if (ModelState.IsValid)
            {
                schoolFee.Id = Guid.NewGuid();
                _context.Add(schoolFee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id", schoolFee.StudentId);
            return View(schoolFee);
        }

        // GET: SchoolFees/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schoolFee = await _context.SchoolFees.FindAsync(id);
            if (schoolFee == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id", schoolFee.StudentId);
            return View(schoolFee);
        }

        // POST: SchoolFees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,StudentId,DueDate,Value")] SchoolFee schoolFee)
        {
            if (id != schoolFee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(schoolFee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SchoolFeeExists(schoolFee.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id", schoolFee.StudentId);
            return View(schoolFee);
        }

        // GET: SchoolFees/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schoolFee = await _context.SchoolFees
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schoolFee == null)
            {
                return NotFound();
            }

            return View(schoolFee);
        }

        // POST: SchoolFees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var schoolFee = await _context.SchoolFees.FindAsync(id);
            _context.SchoolFees.Remove(schoolFee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SchoolFeeExists(Guid id)
        {
            return _context.SchoolFees.Any(e => e.Id == id);
        }
    }
}
