using System;
using System.Collections.Generic;
using System.Text;
using GASF.ApplicationLogic.Data;

namespace GASF.ApplicationLogic.Abstractions
{
    public interface IExamRepository : IRepository<Exam>
    {
        ICollection<Exam> GetGroupExams(Guid groupId);
        ICollection<Exam> GetTeacherExams(Guid teacherId);
        ICollection<Exam> GetExamByDate(DateTime date);
    }
}
