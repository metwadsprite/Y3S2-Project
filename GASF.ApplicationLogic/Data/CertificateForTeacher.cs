using System;
using System.Collections.Generic;
using System.Text;

namespace GASF.ApplicationLogic.Data
{
    public class CertificateForTeacher
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }

        public String Message { get; set; }
       
        public Guid IdTeacher { get; set; }
        public Teacher Teacher { get; set; }

        public Guid IdSecretary { get; set; }

        public Secretary Secretary { get; set; }
    }
}
