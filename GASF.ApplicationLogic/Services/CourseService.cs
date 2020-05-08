using GASF.ApplicationLogic.Abstractions;
using GASF.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace GASF.ApplicationLogic.Services
{
    public class CourseService
    {
        private ICourseRepository courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        public Course GetById(Guid courseId)
        {
            //Guid courseIdGuid = Guid.Empty;
            //if (!Guid.TryParse(courseId, out courseIdGuid))
            //{
            //    throw new Exception("Invalid Guid Format");
            //}
            return courseRepository.GetCourseById(courseId);
        }
        
        public Course GetByName(string courseName)
        {
            return courseRepository.GetCourseByName(courseName);
        }
    }
}
