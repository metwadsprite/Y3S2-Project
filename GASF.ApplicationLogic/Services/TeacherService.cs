using GASF.ApplicationLogic.Abstractions;
using GASF.ApplicationLogic.Data;
using GASF.ApplicationLogic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GASF.ApplicationLogic.Services
{
    public class TeacherService
    {
        private ITeacherRepository teacherRepository;
        private ICourseRepository courseRepository;

        public TeacherService(ITeacherRepository teacherRepository, ICourseRepository courseRepository)
        {
            this.teacherRepository = teacherRepository;
            this.courseRepository = courseRepository;
        }

        public IEnumerable<Course> GetCourses(string userId)
        {
            Guid userIdGuid = Guid.Empty;
            if (!Guid.TryParse(userId, out userIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }

            return courseRepository.GetAll()
                            .Where(course => course.Teacher != null && course.Teacher.UserId == userIdGuid)
                            .AsEnumerable();
        }

        public Teacher GetTeacherByUserId(string userId)
        {
            Guid userIdGuid = Guid.Empty;
            if (!Guid.TryParse(userId, out userIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }
            return teacherRepository.GetTeacherByUserId(userIdGuid);
        }

        public void AddCourse(string userId, string courseName, string courseDescription)
        {
            Guid userIdGuid = Guid.Empty;
            if (!Guid.TryParse(userId, out userIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }
            Teacher teacher = teacherRepository.GetTeacherByUserId(userIdGuid);
            if (teacher == null)
            {
                throw new EntityNotFoundException(userIdGuid);
            }
            courseRepository.Add(new Course() { Id = Guid.NewGuid(), Teacher = teacher, Name = courseName, Description = courseDescription });
        }
    }
}
