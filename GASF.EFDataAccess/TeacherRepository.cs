using GASF.ApplicationLogic.Abstractions;
using GASF.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GASF.EFDataAccess
{
    public class TeacherRepository : BaseRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(StudentRecordDbContext dbContext) : base(dbContext)
        {

        }
        Teacher GetTeacherByName(string LastName)
        {
            return dbContext.Teachers
                            .Where(teacher => teacher.LastName == LastName)
                            .SingleOrDefault();
        }
    }
}
