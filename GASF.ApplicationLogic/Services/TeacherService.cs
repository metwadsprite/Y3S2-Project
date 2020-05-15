using GASF.ApplicationLogic.Abstractions;
using GASF.ApplicationLogic.Data;
using GASF.ApplicationLogic.Exceptions;
using Microsoft.AspNetCore.Mvc;
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
        private IExamRepository examRepository;
        //private IGradeRepository gradeRepository;

        public TeacherService(ITeacherRepository teacherRepository, ICourseRepository courseRepository, IExamRepository examRepository)
        {
            this.teacherRepository = teacherRepository;
            this.courseRepository = courseRepository;
            this.examRepository = examRepository;
            //this.gradeRepository = gradeRepository;
        }
        public Teacher GetById(string id)
        {
            Guid idGuid = Guid.Empty;
            if (!Guid.TryParse(id, out idGuid))
            {
                throw new Exception("Invalid Guid Format");
            }

            return teacherRepository.GetTeacherById(idGuid);
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
        public IEnumerable<Student> GetCourseStudents(Guid courseId)
        {
            return teacherRepository.GetTeacherCourseStudents(courseId);
        }
        public IEnumerable<Exam> GetExams(string userId)
        {
            Guid userIdGuid = Guid.Empty;
            if (!Guid.TryParse(userId, out userIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }
            Teacher teacher = GetTeacherByUserId(userId);
            return examRepository.GetTeacherExams(teacher.Id)
                            .AsEnumerable();
        }
        public Teacher GetTeacherByUserId(string userId)
        {
            Guid userIdGuid = Guid.Empty;
            if (!Guid.TryParse(userId, out userIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }
            var teacher = teacherRepository.GetTeacherByUserId(userIdGuid);
            if (teacher == null)
            {
                throw new EntityNotFoundException(userIdGuid);
            }
            return teacher;
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
        public void AddExam(string courseName, DateTime date)
        {
            Course course = courseRepository.GetCourseByName(courseName);
            examRepository.Add(new Exam() { Id = Guid.NewGuid(), Course = course, Date = date});
        }
        //public void EditGrade(Grade grade)
        //{
        //    gradeRepository.Update(grade);
        //}
    }
}
