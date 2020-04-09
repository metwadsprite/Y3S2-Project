using System;
using System.Collections.Generic;
using System.Text;
using GASF.ApplicationLogic.Data;

namespace GASF.ApplicationLogic.Abstractions
{
    interface IGradeRepository : IRepository<Grade>
    {
        Grade GetStudentGrade(Guid examId, Guid studentId);
    }
}
