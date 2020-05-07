using GASF.ApplicationLogic.Abstractions;
using GASF.ApplicationLogic.Data;
using GASF.ApplicationLogic.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace GASF.ApplicationLogic.Services
{
   public class CertificateForTeachersService : ICertificateForTeachersService
    {

        private ICertificateForTeachersRepository _certificateForTeachersRepository;
        private ITeacherRepository _teacherRepository;

        public CertificateForTeachersService(ICertificateForTeachersRepository certificateForTeachersRepository,ITeacherRepository teacherRepository)
        {
            _certificateForTeachersRepository = certificateForTeachersRepository;
            _teacherRepository = teacherRepository;
        }

        public void createCertificateForTeacher(CertificateForTeacher certificateForTeacher, Guid id,Guid secretaryId)
        {
            certificateForTeacher.IdTeacher = id;
            certificateForTeacher.Teacher = _teacherRepository.GetTeacherById(id);

            certificateForTeacher.IdSecretary = secretaryId;

            _certificateForTeachersRepository.Add(certificateForTeacher);

        }

        public CertificateForTeacher GetCertificateById(Guid id)
        {
            if (id == null)
            {
                throw new Exception("Teacher id is null");
            }

            var certificate = _certificateForTeachersRepository.GetCertificateById(id);

            if (certificate == null)
            {
                throw new EntityNotFoundException(id);
            }
            return certificate;
        }

        public IEnumerable<CertificateForTeacher> GetCertificatesForTeacher(Guid id)
        {
            if (id == null)
            {
                throw new EntryPointNotFoundException("Teacher id null");
            }
            return _certificateForTeachersRepository.getCertificateForTeacher(id);
        }
    }
}
