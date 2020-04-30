using GASF.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace GASF.ApplicationLogic.Services
{
   public interface ITeachersService
    {
        IEnumerable<Teacher> GetAllTeachers();

        Teacher GetTeacherById(Guid id);

        void AddTeacher(Teacher teacher);

        void EditTeacher(Guid id, Teacher teacher);

        void DeleteTeacher(Guid id);
    }
}
