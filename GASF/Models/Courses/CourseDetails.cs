using GASF.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GASF.Models.Courses
{
    public class CourseDetails
    {
        public Course Course { get; set; }

        public Teacher Teacher { get; set; }

        public IEnumerable<Group> Groups { get; set; }
    }
}
