using System;
using System.Collections.Generic;
using System.Text;

namespace GASF.ApplicationLogic.Data
{
    class GroupsCourses
    {
       
        public Course Course { get; set; } 

        public int CourseId { get; set; }

        public Group Group { get; set; }

        public Guid GroupId { get; set; }
    }
}
