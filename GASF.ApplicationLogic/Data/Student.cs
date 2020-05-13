using System;
using System.Collections.Generic;
using System.Text;

namespace GASF.ApplicationLogic.Data
{
    public class Student
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }
        public Guid UserId { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }

        public string Adress { get; set; }

        public string Phone { get; set; }

        public DateTime BirthDate { get; set; }

        public string CNP { get; set; }

        public Group Group { get; set; }
        public Guid GroupId { get; set; }
    }
}
