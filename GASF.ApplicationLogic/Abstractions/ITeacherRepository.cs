using System;
using System.Collections.Generic;
using System.Text;

namespace GASF.ApplicationLogic.Abstractions
{
    class ITeacherRepository : IRepository<Teacher>
    {
        Teacher GetTeacherByName(string LastName);

        Teacher GetTeacherById(Guid Id);
    }
}
