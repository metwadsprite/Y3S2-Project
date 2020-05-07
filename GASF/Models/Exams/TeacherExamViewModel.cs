using GASF.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GASF.Models.Exams
{
    public class TeacherExamViewModel
    {
        public Teacher Teacher { get; set; }
        public IEnumerable<Exam> Exams { get; set; }
    }
}
