using GASF.ApplicationLogic.Abstractions;
using GASF.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace GASF.EFDataAccess
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(StudentRecordDbContext dbContext) : base(dbContext)
        {

        }
        public Student GetStudentById(Guid Id)
        {
            return dbContext.Students
                            .Include(s => s.Group)
                            .Where(student => student.Id == Id)
                            .SingleOrDefault();
        }
        public ICollection<Student> GetStudentByFirstName(string FirstName)
        {
            return dbContext.Students
                            .Where(student => student.FirstName == FirstName)
                            .ToList();
        }

        public Student GetStudentByCNP(string CNP)
        {
            return dbContext.Students
                            .Where(student => student.CNP == CNP)
                            .SingleOrDefault();
        }

        public IEnumerable<Grade> GetStudentGrades(Guid id)
        {
            return dbContext.Grades.Where(grade => grade.StudentId == id);
        }

        public IEnumerable<Course> GetStudentCourses(Guid id)
        {
            var groupId = GetStudentById(id).Group.GroupId;

            var groupCourseList = dbContext.GroupsCourses.Where(groupCourse => groupCourse.GroupId == groupId);

            List<Course> courseList = new List<Course>();
            foreach (var groupCourse in groupCourseList)
            {
                Course course = dbContext.Courses
                    .Include(c => c.Teacher)
                    .Include(c => c.Exam)
                    .Where(c => c.Id == groupCourse.CourseId).SingleOrDefault();
                courseList.Add(course);
            }

            return courseList.AsEnumerable();
        }

        //public SchoolFee GetSchoolFee(Guid id)
        //{
        //    return dbContext.SchoolFees.Where(fee => fee.IdStudent == id).SingleOrDefault();
        //}
        public IEnumerable<SchoolFee> GetSchoolFee(Guid id)
        {
            return dbContext.SchoolFees.Where(fee => fee.IdStudent == id);
        }

        public Student GetByUserId(Guid Id)
        {
            return dbContext.Students.Where(student => student.UserId == Id).SingleOrDefault();
        }
        public ICollection<Student> GetStudentByGroupId(Guid GropupId)
        {
            return dbContext.Students
                              .Where(student => student.Group.GroupId == GropupId)
                              .ToList();
        }

    }
}