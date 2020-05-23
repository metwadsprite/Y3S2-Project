using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GASF.ApplicationLogic.Data
{
    public class Secretary
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public ICollection<Student> Students { get; private set; }
        public ICollection<SchoolFee> Fees { get; private set; }

        //public Secretary()
        //{
        //    Students = new List<Student>();
        //    Fees = new List<SchoolFee>();
        //}

        //public IReadOnlyCollection<Student> GetTotalFeesForEachStudents(double fee)
        //{ 
        //    var studentList = new List<Student>();
        //    foreach(var student in Students)
        //    {
        //        var totalFee = Fees.Where(f => f.StudentId == student.Id)
        //                            .Sum(f => f.Value);

        //    }
        //    return studentList.AsReadOnly();
        //}
    }
}
