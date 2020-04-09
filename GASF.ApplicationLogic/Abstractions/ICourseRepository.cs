using System;
using System.Collections.Generic;
using System.Text;
using GASF.ApplicationLogic.Data;

namespace GASF.ApplicationLogic.Abstractions
{
    interface ICourseRepository : IRepository<Course>
    {
        ICollection<Course> GetTeacherCourses(Guid teacherId);
        ICollection<Course> GetGroupCourses(Guid grouId);
    }
}
