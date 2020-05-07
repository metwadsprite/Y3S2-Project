using GASF.ApplicationLogic.Abstractions;
using GASF.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GASF.EFDataAccess
{
    public class CertificateForTeachersRepository : BaseRepository<CertificateForTeacher>, ICertificateForTeachersRepository
    {
        public CertificateForTeachersRepository(StudentRecordDbContext dbContext) : base(dbContext)
        {

        }
        public CertificateForTeacher GetCertificateById(Guid id)
        {
            return dbContext.TeacherCertificates
                          .Where(certificate => certificate.Id == id)
                          .SingleOrDefault();

        }

        public IEnumerable<CertificateForTeacher> getCertificateForTeacher(Guid id)
        {
            return dbContext.TeacherCertificates
                             .Where(certificate => certificate.IdTeacher == id)
                             .ToList();
        }
    }
}
