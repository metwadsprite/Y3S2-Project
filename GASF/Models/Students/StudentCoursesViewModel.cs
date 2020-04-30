using GASF.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GASF.Models.Students
{
    public class StudentCoursesViewModel
    {
        public Student Student { get; set; }
        public IEnumerable<Course> Courses { get; set; }
       public IEnumerable<Grade> Grades { get; set; }
        public SchoolFee SchoolFee { get; internal set; }
    }
}
