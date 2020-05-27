using System;
using System.Collections.Generic;
using System.Text;
using GASF.ApplicationLogic.Data;

namespace GASF.ApplicationLogic.Abstractions
{
    public interface IGradeRepository : IRepository<Grade>
    {
        Grade GetGradeById(Guid id);
        Grade GetGradeByStudentId(Guid studentId);
    }
}
