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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace GASF.Controllers
{
    
    public class StudentsController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IStudentsService studentsService;
        private readonly ICertificatesForStudentsService certificateForStudentsService;
        private readonly ISecretaryService secretaryService;

        public StudentsController(UserManager<IdentityUser> userManager, IStudentsService studentsService,
           ICertificatesForStudentsService certificateForStudentsService, ISecretaryService secretaryService)
        {
            this.studentsService = studentsService;
            this.userManager = userManager;
            this.certificateForStudentsService = certificateForStudentsService;
            this.secretaryService = secretaryService;
        }

        // GET: Students
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Student> students = studentsService.GetAllStudents();
            return View(students);
        }

        // GET: Students/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var student = studentsService.GetStudentById(id);

            return View(student);
        }

        // GET: Students/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,Adress,Phone,BirthDate,CNP")] Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            studentsService.AddStudent(student);
            return Redirect(Url.Action("Index", "Students"));
        }

        // GET: Students/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var student = studentsService.GetStudentById(id);
            return View(student);
        }

        // POST: Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,FirstName,LastName,Email,Adress,Phone,BirthDate,CNP")] Student student)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            studentsService.EditStudent(id, student);
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var student = studentsService.GetStudentById(id);
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            studentsService.DeleteStudent(id);
            return RedirectToAction(nameof(Index));
        }

        // GET: Students/CreateCertificate
        [HttpGet]
        public IActionResult CreateCertificate()
        {
            return View();
        }

        // POST: Students/CreateCertificate
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> CreateCertificate(Guid Id,[Bind("Title,Message,Date")] CertificateForStudent certificateForStudent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var userId = userManager.GetUserId(User);
            var secretaryId = secretaryService.GetSecretaryByUserId(userId);
            certificateForStudentsService.createCertificateForStudent(certificateForStudent, Id, secretaryId.Id) ;
            //
            return Redirect(Url.Action("Index", "Students"));
        }

        // GET: Students/Details/5
        [HttpGet]
        public async Task<IActionResult> CertificateDetails(Guid id)
        {
            var certificate = certificateForStudentsService.GetCertificateById(id);
            var studentC = studentsService.GetStudentById(certificate.IdStudent);
            var secretary = secretaryService.GetSecretaryById(certificate.IdSecretary);

            CertificateForStudentView certificateForStudentView = new CertificateForStudentView()
            {
                certificateForStudent = certificate,
                student=studentC,
                secretary=secretary
                
              
            };
            return View(certificateForStudentView);
        }

        // GET: Students
        [HttpGet]
        public async Task<IActionResult> AllCertificates(Guid id)
        {

            IEnumerable<CertificateForStudent> certificates = certificateForStudentsService.GetCertificatesForStudent(id);
            return View(certificates);
        }
    }
}