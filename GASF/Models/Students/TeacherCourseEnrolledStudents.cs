using GASF.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GASF.Models.Students
{
    public class TeacherCourseEnrolledStudents
    {
        public Teacher Teacher { get; set; }
        public Course Course { get; set; }
        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<Grade> Grades { get; set; }
    }
}
