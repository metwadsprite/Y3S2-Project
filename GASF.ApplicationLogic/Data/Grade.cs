using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GASF.ApplicationLogic.Data
{
    public class Grade
    {
        public Guid Id { get; set; }
        [Range(1, 10)]
        public int Score { get; set; }
        public Guid ExamId { get; set; }
        public Exam Exam { get; set; }
        public Guid StudentId { get; set; }
        public Student Student { get; set; }
    }
}
