using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GASF.ApplicationLogic.Data;
using GASF.EFDataAccess;
using Microsoft.AspNetCore.Identity;
using GASF.ApplicationLogic.Services;
using Microsoft.AspNetCore.Authorization;

namespace GASF.Controllers
{
    [Authorize]
    public class TeachersController : Controller
    {
        

        private readonly UserManager<IdentityUser> userManager;
        private readonly ITeachersService teachersService;
        private readonly ICertificateForTeachersService certificateForTeachersService;
        private readonly ISecretaryService secretaryService;


        public TeachersController(UserManager<IdentityUser> userManager, ITeachersService teachersService,
             ICertificateForTeachersService certificateForTeachersService,ISecretaryService secretaryService)
        {
            this.userManager = userManager;
            this.teachersService = teachersService;
            this.certificateForTeachersService = certificateForTeachersService;
            this.secretaryService = secretaryService;
        }


        // GET: Teachers
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Teacher> teachers = teachersService.GetAllTeachers();
            return View(teachers);
        }


        // GET: Teachers/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var teacher = teachersService.GetTeacherById(id);

            return View(teacher);
        }

        // GET: Teachers/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Teachers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,Phone,BirthDate")] Teacher teacher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            teachersService.AddTeacher(teacher);
            return Redirect(Url.Action("Index", "Teachers"));
        }


        // GET: Teachers/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var teacher = teachersService.GetTeacherById(id);
            return View(teacher);
        }


        // POST: Teachers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,FirstName,LastName,Email,Phone,BirthDate")] Teacher teacher)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            teachersService.EditTeacher(id, teacher);
            return View(teacher);
        }

        // GET: Teachers/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var teacher = teachersService.GetTeacherById(id);
            return View(teacher);
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            teachersService.DeleteTeacher(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: Teachers/CreateCertificate
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> CreateCertificate(Guid Id, [Bind("Title,Message,Date")] CertificateForTeacher certificateForTeacher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var userId = userManager.GetUserId(User);
            var secretaryId = secretaryService.GetSecretaryByUserId(userId);

            certificateForTeachersService.createCertificateForTeacher(certificateForTeacher, Id,secretaryId.Id);
            //
            return Redirect(Url.Action("Index", "Teachers"));
        }


        [HttpGet]
        public IActionResult CreateCertificate()
        {
            return View();
        }
        // GET: Teachers/Certification//Details/5
        [HttpGet]
        public async Task<IActionResult> CertificateDetails(Guid id)
        {
            var certificate = certificateForTeachersService.GetCertificateById(id);
            var teacher = teachersService.GetTeacherById(certificate.IdTeacher);
            var secretary = secretaryService.GetSecretaryById(certificate.IdSecretary);
            CertificateForTeacherView certificateForTeacherView = new CertificateForTeacherView()
            {
                CertificateForTeacher = certificate,
                Teacher = teacher,
                secretary = secretary
            };
            return View(certificateForTeacherView);
        }

        // GET: Certifications
        [HttpGet]
        public async Task<IActionResult> AllCertificates(Guid id)
        {

            IEnumerable<CertificateForTeacher> certificates = certificateForTeachersService.GetCertificatesForTeacher(id);
            return View(certificates);
        }

    }
}