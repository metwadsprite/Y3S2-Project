using System;
using System.Collections.Generic;
using System.Text;

namespace GASF.ApplicationLogic.Data
{
    public class SchoolFee
    {
        public Guid Id { get; set; }

        public Student Student { get; set; }

        public Guid StudentId { get; set; }

        public DateTime DueDate { get; set; }

        public int Value { get; set; }
    }
}
