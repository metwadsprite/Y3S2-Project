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

        public Student GetByUserId(string Id)
        {
            Guid userIdGuid = Guid.Empty;
            if (!Guid.TryParse(Id, out userIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }

            var student = studentRepository.GetByUserId(userIdGuid);

            if (student == null)
            {
                throw new EntityNotFoundException(userIdGuid);
            }

            return student;
        }

        public IEnumerable<Course> GetStudentCourses(string userId)
        {
            Guid userIdGuid = Guid.Empty;
            if (!Guid.TryParse(userId, out userIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }

            return studentRepository?.GetStudentCourses(userIdGuid);
        }


        public IEnumerable<Grade> GetStudentGrade(string userId)
        {
            Guid userIdGuid = Guid.Empty;
            if (!Guid.TryParse(userId, out userIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }
            return studentRepository?.GetStudentGrades(userIdGuid);
        }

        public SchoolFee GetSchoolFee(string id)
        {
            Guid userIdGuid = Guid.Empty;

            if (!Guid.TryParse(id, out userIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }

            return studentRepository?.GetSchoolFee(userIdGuid);
        }
    }
}
