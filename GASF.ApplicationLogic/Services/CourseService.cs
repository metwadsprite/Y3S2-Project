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

        public Course GetById(string courseId)
        {
            Guid courseIdGuid = Guid.Empty;
            if (!Guid.TryParse(courseId, out courseIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }
            return courseRepository.GetCourseById(courseIdGuid);
        }
        
    }
}
