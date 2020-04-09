using System;
using System.Collections.Generic;
using System.Text;
using GASF.ApplicationLogic.Data;

namespace GASF.ApplicationLogic.Abstractions
{
    public interface ITeacherRepository : IRepository<Teacher>
    {
        Teacher GetTeacherByName(string LastName);

        Teacher GetTeacherById(Guid Id);
    }
}
