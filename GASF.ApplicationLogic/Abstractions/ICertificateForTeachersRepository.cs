using GASF.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace GASF.ApplicationLogic.Abstractions
{
   public interface ICertificateForTeachersRepository :IRepository<CertificateForTeacher>
    {
        IEnumerable<CertificateForTeacher> getCertificateForTeacher(Guid Id);
        CertificateForTeacher GetCertificateById(Guid id);
    }
}
