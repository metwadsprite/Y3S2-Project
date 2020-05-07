using GASF.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace GASF.ApplicationLogic.Abstractions
{
   public interface ICertificateForSudentsRepository : IRepository<CertificateForStudent>
    {
        IEnumerable<CertificateForStudent> getCertificateForStudent(Guid studentId);
        CertificateForStudent GetCertificateById(Guid id);
    }
}
