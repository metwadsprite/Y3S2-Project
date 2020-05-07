using System;
using System.Collections.Generic;
using System.Text;
using GASF.ApplicationLogic.Data;

namespace GASF.ApplicationLogic.Abstractions
{
    public interface IStudentRepository : IRepository<Student>
    {
        Student GetStudentById(Guid Id);

        ICollection<Student> GetStudentByFirstName(string FirstName);

        Student GetStudentByCNP(string CNP);

        ICollection<Student> GetStudentByGroupId(Guid GropupId);


    }
}
