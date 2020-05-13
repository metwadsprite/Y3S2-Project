using GASF.ApplicationLogic.Data;
using GASF.ApplicationLogic.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace GASF.EFDataAccess
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        public CourseRepository(StudentRecordDbContext dbContext) : base(dbContext)
        {

        }

        public Course GetCourseById(Guid id)
        {
            return dbContext.Courses
                            .Include(c => c.Exam)
                            .Where(course => course.Id == id)
                            .FirstOrDefault();
        }

        public Course GetCourseByName(string name)
        {
            return dbContext.Courses
                            .Where(course => course.Name == name)
                            .FirstOrDefault();
        }
    }
}
