using System;
using System.Collections.Generic;
using System.Text;

namespace GASF.ApplicationLogic.Data
{
    public class Course
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public Guid ExamId { get; set; }
        public Exam Exam { get; set; }
        public ICollection<GroupsCourses> GroupsCourses { get; set; }
    }
}
