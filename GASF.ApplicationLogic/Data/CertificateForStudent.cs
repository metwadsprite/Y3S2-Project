using System;
using System.Collections.Generic;
using System.Text;

namespace GASF.ApplicationLogic.Data
{
    public class CertificateForStudent
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }

        public String Message { get; set; }

        public Guid IdStudent { get; set; }
        public Student Student { get; set; }

        public Guid IdSecretary { get; set; }

        public Secretary Secretary { get; set; }
    }
}
