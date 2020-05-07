using GASF.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GASF.Models.Courses
{
    public class TeacherCoursesViewModel
    {
        public Teacher Teacher { get; set; }
        public IEnumerable<Course> Courses { get; set; }
    }
}
