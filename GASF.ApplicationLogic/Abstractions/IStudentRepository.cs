using System;
using System.Collections.Generic;
using System.Text;

namespace GASF.ApplicationLogic.Abstractions
{
    class IStudentRepository : IRepository<Student>
    {
        Student GetStudentById(Guid Id);

        Student GetStudentByFirstName(string FirstName);

        Student GetStudentByCNP(string CNP);

        ICollection<Student> GetStudentByGroupId(Guid GropupId);

    }
}
