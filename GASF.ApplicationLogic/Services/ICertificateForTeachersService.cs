using GASF.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace GASF.ApplicationLogic.Services
{
    public interface ICertificateForTeachersService
    {
        IEnumerable<CertificateForTeacher> GetCertificatesForTeacher(Guid id);
        CertificateForTeacher GetCertificateById(Guid id);
        void createCertificateForTeacher(CertificateForTeacher certificateForTeacher, Guid id, Guid SecretaryId);
    }
}
