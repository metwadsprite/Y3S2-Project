using GASF.ApplicationLogic.Abstractions;
using GASF.ApplicationLogic.Data;
using Microsoft.EntityFrameworkCore;
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
        public Teacher GetTeacherById(Guid Id)
        {
            return dbContext.Teachers
                             .Where(teacher => teacher.Id == Id)
                             .SingleOrDefault();
        }

        public Teacher GetTeacherByName(string LastName, string FirstName)
        {
            return dbContext.Teachers
                            .Where(teacher => teacher.LastName == LastName && teacher.LastName == FirstName )
                            .SingleOrDefault();
        }

        public Teacher GetTeacherByUserId(Guid userId)
        {
            return dbContext.Teachers
                            .Where(teacher => teacher.UserId == userId)
                            .Single();
        }

        public IEnumerable<Student> GetTeacherCourseStudents(Guid courseId)
        {
            var groups = dbContext.Groups.Include(g => g.GroupCourses);

            List<Student> students = new List<Student>();
            foreach(var group in groups)
            {
                if (group.GroupCourses.Any(g => g.CourseId == courseId))
                {
                    IEnumerable<Student> studList = dbContext.Students
                        .Where(s => s.Group.GroupId == group.GroupId)
                        .AsEnumerable();
                    students.AddRange(studList);
                }
            }
            return students;
        }
    }
}
