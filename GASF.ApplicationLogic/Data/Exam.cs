using System;
using System.Collections.Generic;
using System.Text;

namespace GASF.ApplicationLogic.Data
{
    public class Exam
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Course Course { get; set; }
        ICollection<Grade> Grades { get; set; }
    }
}
