using GASF.ApplicationLogic.Abstractions;
using GASF.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace GASF.EFDataAccess
{
    class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(StudentRecordDbContext dbContext) : base(dbContext)
        {

        }
        public Student GetStudentById(Guid Id)
        {
            return dbContext.Students
                            .Where(student => student.Id == Id)
                            .SingleOrDefault();
        }
        public Student GetStudentByFirstName(string FirstName)
        {
            return dbContext.Students
                            .Where(student => student.FirstName == FirstName)
                            .SingleOrDefault();
        }

        public Student GetStudentByCNP(string CNP)
        {
            return dbContext.Students
                            .Where(student => student.CNP == CNP)
                            .SingleOrDefault();
        }

         public ICollection<Student> GetStudentByGroupId(Guid GropupId)
        {
             return dbContext.Students
                              .Where(student => student.Group.GroupId == GropupId)
                              .ToList();
        }
    }
}
