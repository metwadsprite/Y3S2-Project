using System;
using System.Collections.Generic;
using System.Text;

namespace GASF.ApplicationLogic.Data
{
    class CertificateForStudent
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }

        public String Message { get; set; }

        public int IdStudent { get; set; }
        public Student Student { get; set; }

        public int IdSecretary { get; set; }

        public Secretary Secretary { get; set; }
    }
}
