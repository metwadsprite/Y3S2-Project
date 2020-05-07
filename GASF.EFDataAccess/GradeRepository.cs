using System;
using System.Collections.Generic;
using System.Text;
using GASF.ApplicationLogic.Data;
using GASF.ApplicationLogic.Abstractions;
using System.Linq;

namespace GASF.EFDataAccess
{
    public class GradeRepository : BaseRepository<Grade>, IGradeRepository
    {
        public GradeRepository(StudentRecordDbContext dbContext) : base(dbContext)
        {

        }

        public Grade GetGradeById(Guid id)
        {
            return dbContext.Grades
                            .Where(grade => grade.Id == id)
                            .SingleOrDefault();
        }
    }
}
