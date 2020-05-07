using GASF.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace GASF.ApplicationLogic.Services
{
   public interface ICertificatesForStudentsService
    {
         IEnumerable<CertificateForStudent> GetCertificatesForStudent(Guid studentId);
         CertificateForStudent GetCertificateById(Guid id);

        CertificateForStudent createCertificateForStudent(CertificateForStudent certificateForStudent, Guid Id,Guid secretaryId);
    }
}
