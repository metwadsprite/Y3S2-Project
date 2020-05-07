using GASF.ApplicationLogic.Abstractions;
using GASF.ApplicationLogic.Data;
using GASF.ApplicationLogic.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace GASF.ApplicationLogic.Services
{
   public class CertificateForStudentsService:ICertificatesForStudentsService
    {
        private ICertificateForSudentsRepository _certificateForStudentsRepository;
        private IStudentRepository studentRepository;

        public CertificateForStudentsService(ICertificateForSudentsRepository certificateForSudentsRepository,IStudentRepository studentRepository)
        {
            _certificateForStudentsRepository = certificateForSudentsRepository;
            this.studentRepository = studentRepository;
        }

        public CertificateForStudent createCertificateForStudent(CertificateForStudent certificateForStudent, Guid Id,Guid secretaryId)
        {
            var student = studentRepository.GetStudentById(Id);
            certificateForStudent.IdStudent = Id;
            certificateForStudent.Student = student;
            certificateForStudent.IdSecretary = secretaryId;

            _certificateForStudentsRepository.Add(certificateForStudent);

            return certificateForStudent;
        }

        public CertificateForStudent GetCertificateById(Guid id)
        {
            if (id == null)
            {
                throw new Exception("Student id is null");
            }

            var certificate = _certificateForStudentsRepository.GetCertificateById(id);

            if (certificate == null)
            {
                throw new EntityNotFoundException(id);
            }
            return certificate;
        }

        public IEnumerable<CertificateForStudent> GetCertificatesForStudent(Guid studentId)
        {
            if (studentId == null)
            {
                throw new EntryPointNotFoundException("Student id null");
            }
            return _certificateForStudentsRepository.getCertificateForStudent(studentId);
        }
    }
}
