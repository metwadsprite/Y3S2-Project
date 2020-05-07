using GASF.ApplicationLogic.Abstractions;
using GASF.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GASF.EFDataAccess
{
   public class CertificateForStudentsRepository : BaseRepository<CertificateForStudent>, ICertificateForSudentsRepository
    {
        public CertificateForStudentsRepository(StudentRecordDbContext dbContext) : base(dbContext)
        {

        }

        public CertificateForStudent GetCertificateById(Guid id)
        {
            return dbContext.StudentCertificates
                           .Where(certificate => certificate.Id == id)
                           .SingleOrDefault();
                           
        }

        public IEnumerable<CertificateForStudent> getCertificateForStudent(Guid studentId)
        {
            return dbContext.StudentCertificates
                            .Where(certificate => certificate.IdStudent == studentId)
                            .ToList();
                            
        }
    }
}
