using System;
using System.Collections.Generic;
using System.Text;

namespace GASF.ApplicationLogic.Data
{
    class SchoolFee
    {
        public Guid Id { get; set; }

        public Guid IdStudent { get; set; }

        public Student Student { get; set; }

        public DateTime DueDate { get; set; }

        public int Value { get; set; }
    }
}
