using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GASF.Models.Grades
{
    public class TeacherAddGradeViewModel
    {
        public int Score { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        public string CourseName { get; set; }
    }
}
