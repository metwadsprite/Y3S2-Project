using System;
using System.Collections.Generic;
using System.Text;

namespace GASF.ApplicationLogic.Data
{
    public class Group
    {
        public Guid GroupId { get; set; }
        public string GroupName { get; set; }
        public string Specialisation { get; set; }
        public ICollection<GroupsCourses> GroupCourses { get; set;}
        public ICollection<Student> Students { get; set; }

    }
}
