using CourseManager.ApplicationLogic.Exceptions;
using GASF.ApplicationLogic.Abstractions;
using GASF.ApplicationLogic.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GASF.ApplicationLogic.Services
{
    public class StudentService
    {
        private ITeacherRepository teacherRepository;
        private ICourseRepository courseRepository;
        private IStudentRepository studentRepository;
        private IGradeRepository gradeRepository;

        public StudentService(IStudentRepository studentRepository, ICourseRepository courseRepository, ITeacherRepository teacherRepository, IGradeRepository gradeRepository)
        {
            this.teacherRepository = teacherRepository;
            this.courseRepository = courseRepository;
            this.studentRepository = studentRepository;
            this.gradeRepository = gradeRepository;
        }

        public Student GetStudentById(string Id)
        {
            Guid userIdGuid = Guid.Empty;
            if (!Guid.TryParse(Id, out userIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }

            var teacher = studentRepository.GetStudentById(userIdGuid);
            if (teacher == null)
            {
                throw new EntityNotFoundException(userIdGuid);
            }

            return teacher;
        }
        
        public IEnumerable<Course> GetStudentCourses(string userId)
        {
            Guid userIdGuid = Guid.Empty;
            if (!Guid.TryParse(userId, out userIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }

            return courseRepository.GetAll()
                            .Where(course => course.Teacher != null && course.Teacher.Id == userIdGuid)
                            .AsEnumerable();
        }


        public IEnumerable<Grade> GetStudentGrade(string userId)
        {
            Guid userIdGuid = Guid.Empty;
            if (!Guid.TryParse(userId, out userIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }

            return gradeRepository.GetAll()
                            .Where(score => score.Student!= null && score.Student.Id == userIdGuid)
                            .AsEnumerable();
        }


        public void AddCourse(string userId, string courseName, string courseDescription)
        {
            Guid userIdGuid = Guid.Empty;
            if (!Guid.TryParse(userId, out userIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }
            var teacher = studentRepository.GetStudentById(userIdGuid);
            if (teacher == null)
            {
                throw new EntityNotFoundException(userIdGuid);
            }
            courseRepository.Add(new Course() { Id = Guid.NewGuid(), Name = courseName, Description = courseDescription });
        }
    }
}
