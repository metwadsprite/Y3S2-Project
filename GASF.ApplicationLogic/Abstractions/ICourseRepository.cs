using System;
using System.Collections.Generic;
using System.Text;
using GASF.ApplicationLogic.Data;

namespace GASF.ApplicationLogic.Abstractions
{
    public interface ICourseRepository : IRepository<Course>
    {
        Course GetCourseById(Guid id);
        Course GetCourseByName(string name);
    }
}