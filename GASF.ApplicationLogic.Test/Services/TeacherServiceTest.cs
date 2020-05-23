using GASF.ApplicationLogic.Abstractions;
using GASF.ApplicationLogic.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;
using System.Collections.Generic;
using System.Text;
using GASF.ApplicationLogic.Data;
using GASF.ApplicationLogic.Exceptions;
using System.Linq;
using System.Reflection;

namespace GASF.ApplicationLogic.Test.Services
{
    [TestClass]
    public class TeacherServiceTest
    {
        [TestMethod]
        public void GetById_ThrowsException_WhenTeacherIdHasInvalidValue()
        {
            Mock<ITeacherRepository> teacherRepoMock = new Mock<ITeacherRepository>();
            Mock<ICourseRepository> courseRepoMock = new Mock<ICourseRepository>();
            Mock<IExamRepository> examRepoMock = new Mock<IExamRepository>();
            TeacherService teacherService = new TeacherService(teacherRepoMock.Object, courseRepoMock.Object, examRepoMock.Object);
            var invalidUserId = "blabla hah dfghj ps";

            Assert.ThrowsException<Exception>(() => {
                teacherService.GetById(invalidUserId);
            });
        }
        [TestMethod]
        public void GetById_Returns_TeacherWhenExists()
        {
            Mock<ITeacherRepository> teacherRepoMock = new Mock<ITeacherRepository>();
            Mock<ICourseRepository> courseRepoMock = new Mock<ICourseRepository>();
            Mock<IExamRepository> examRepoMock = new Mock<IExamRepository>();
            var id = Guid.Parse("f216e1eb-128b-4c31-930d-4fb400d885cc");
            Exception throwException = null;

            var teacher = new Teacher
            {
                Id = id,
                Email = "mail@mail.com",
                FirstName = "Ion",
                LastName = "Popescu",
                Phone = "0720202020",
                UserId = id
            };

            teacherRepoMock.Setup(teacherRepo => teacherRepo.GetTeacherById(id))
                            .Returns(teacher);

            TeacherService teacherService = new TeacherService(teacherRepoMock.Object, courseRepoMock.Object, examRepoMock.Object);
            teacher = null;

            try
            {
                teacher = teacherService.GetById(id.ToString());
            }
            catch (Exception e)
            {
                throwException = e;
            }

            Assert.IsNull(throwException, $"Exception thrown.");
            Assert.IsNotNull(teacher);
        }
        [TestMethod]
        public void GetTeacherByUserId_ThrowsException_WhenUserIdHasInvalidValue()
        {
            Mock<ITeacherRepository> teacherRepoMock = new Mock<ITeacherRepository>();
            Mock<ICourseRepository> courseRepoMock = new Mock<ICourseRepository>();
            Mock<IExamRepository> examRepoMock = new Mock<IExamRepository>();
            TeacherService teacherService = new TeacherService(teacherRepoMock.Object, courseRepoMock.Object, examRepoMock.Object);
            var invalidUserId = "blabla hah dfghj ps";

            Assert.ThrowsException<Exception>(() => {
                teacherService.GetTeacherByUserId(invalidUserId);
            });
        }

        [TestMethod]
        public void GetTeacherByUserId_ThrowsEntityNotFound_WhenUserDoesNotExist()
        {
            Mock<ITeacherRepository> teacherRepoMock = new Mock<ITeacherRepository>();
            Mock<IExamRepository> examRepoMock = new Mock<IExamRepository>();
            Mock<ICourseRepository> courseRepoMock = new Mock<ICourseRepository>();
            var nonExistingUserId = "f216e1eb-128b-4c31-930d-4fb400d333cc";
            var existingUserId = Guid.Parse("f216e1eb-128b-4c31-930d-4fb400d885cc");

            var teacher = new Teacher
            {
                Id = existingUserId,
                Email = "mail@mail.com",
                FirstName = "Ion",
                LastName = "Popescu",
                Phone = "0720202020",
                BirthDate = DateTime.Now,
                UserId = existingUserId
            };

            teacherRepoMock.Setup(teacherRepo => teacherRepo.GetTeacherByUserId(existingUserId))
                            .Returns(teacher);

            TeacherService teacherService = new TeacherService(teacherRepoMock.Object, courseRepoMock.Object, examRepoMock.Object);

            Assert.ThrowsException<EntityNotFoundException>(() => {
                teacherService.GetTeacherByUserId(nonExistingUserId);
            });
        }

        [TestMethod]
        public void GetTeacherByUserId_Returns_UserWhenExists()
        {
            Mock<ITeacherRepository> teacherRepoMock = new Mock<ITeacherRepository>();
            Mock<ICourseRepository> courseRepoMock = new Mock<ICourseRepository>();
            Mock<IExamRepository> examRepoMock = new Mock<IExamRepository>();
            var userId = Guid.Parse("f216e1eb-128b-4c31-930d-4fb400d885cc");
            Exception throwException = null;

            var teacher = new Teacher
            {
                Id = userId,
                Email = "mail@mail.com",
                FirstName = "Ion",
                LastName = "Popescu",
                Phone = "0720202020",
                UserId = userId
            };

            teacherRepoMock.Setup(teacherRepo => teacherRepo.GetTeacherByUserId(userId))
                            .Returns(teacher);

            TeacherService teacherService = new TeacherService(teacherRepoMock.Object, courseRepoMock.Object, examRepoMock.Object);
            Teacher user = null;

            try
            {
                user = teacherService.GetTeacherByUserId(userId.ToString());
            }
            catch (Exception e)
            {
                throwException = e;
            }

            Assert.IsNull(throwException, $"Exception thrown.");
            Assert.IsNotNull(user);
        }
        [TestMethod]
        public void GetCourses_ThrowsException_WhenCourseUserIdHasInvalidValue()
        {
            Mock<ITeacherRepository> teacherRepoMock = new Mock<ITeacherRepository>();
            Mock<ICourseRepository> courseRepoMock = new Mock<ICourseRepository>();
            Mock<IExamRepository> examRepoMock = new Mock<IExamRepository>();
            TeacherService teacherService = new TeacherService(teacherRepoMock.Object, courseRepoMock.Object, examRepoMock.Object);
            var invalidUserId = "blabla hah dfghj ps";

            Assert.ThrowsException<Exception>(() => {
                teacherService.GetCourses(invalidUserId);
            });
        }
        [TestMethod]
        public void GetCourses_Returns_Courses()
        {
            Mock<ITeacherRepository> teacherRepoMock = new Mock<ITeacherRepository>();
            Mock<ICourseRepository> courseRepoMock = new Mock<ICourseRepository>();
            Mock<IExamRepository> examRepoMock = new Mock<IExamRepository>();
            var userId = Guid.Parse("f216e1eb-128b-4c31-930d-4fb400d885cc");
            Exception throwException = null;

            var course1 = new Course
            {
                Id = Guid.NewGuid(),
                Description = "description",
                Name = "name"
            };
            var course2 = new Course
            {
                Id = Guid.NewGuid(),
                Description = "description2",
                Name = "name2"
            };

            var teacherCourses = new List<Course>();
            teacherCourses.Add(course1);
            teacherCourses.Add(course2);
            courseRepoMock.Setup(courseRepo => courseRepo.GetTeacherCourses(userId)).Returns(teacherCourses);

            TeacherService teacherService = new TeacherService(teacherRepoMock.Object, courseRepoMock.Object, examRepoMock.Object);
            IEnumerable<Course> returnedCourses = null;

            try
            {
                returnedCourses = teacherService.GetCourses(userId.ToString());
            }
            catch (Exception e)
            {
                throwException = e;
            }

            Assert.IsNull(throwException, $"Exception thrown.");
            Assert.IsNotNull(returnedCourses);
            Assert.AreEqual(teacherCourses.Count, returnedCourses.Count());
            Assert.AreEqual("description", returnedCourses.FirstOrDefault().Description);
        }
        [TestMethod]
        public void GetCourseStudents_Returns_Students()
        {
            Mock<ITeacherRepository> teacherRepoMock = new Mock<ITeacherRepository>();
            Mock<ICourseRepository> courseRepoMock = new Mock<ICourseRepository>();
            Mock<IExamRepository> examRepoMock = new Mock<IExamRepository>();
            var courseId = Guid.Parse("f216e1eb-128b-4c31-930d-4fb400d885cc");
            Exception throwException = null;

            var student1 = new Student
            {
                Id = Guid.NewGuid(),
                Adress = "address",
                FirstName = "Ionel"
            };
            var student2 = new Student
            {
                Id = Guid.NewGuid(),
                Adress = "address2",
                FirstName = "Maria"
            };

            var teacherStudents = new List<Student>();
            teacherStudents.Add(student1);
            teacherStudents.Add(student2);
            teacherRepoMock.Setup(teacherRepo => teacherRepo.GetTeacherCourseStudents(courseId)).Returns(teacherStudents);

            TeacherService teacherService = new TeacherService(teacherRepoMock.Object, courseRepoMock.Object, examRepoMock.Object);
            IEnumerable<Student> returnedStudents = null;

            try
            {
                returnedStudents = teacherService.GetCourseStudents(courseId);
            }
            catch (Exception e)
            {
                throwException = e;
            }

            Assert.IsNull(throwException, $"Exception thrown.");
            Assert.IsNotNull(returnedStudents);
            Assert.AreEqual(teacherStudents.Count, returnedStudents.Count());
            Assert.AreEqual("Ionel", returnedStudents.FirstOrDefault().FirstName);
        }
        [TestMethod]
        public void GetExams_ThrowsException_WhenTeacherIdHasInvalidValue()
        {
            Mock<ITeacherRepository> teacherRepoMock = new Mock<ITeacherRepository>();
            Mock<ICourseRepository> courseRepoMock = new Mock<ICourseRepository>();
            Mock<IExamRepository> examRepoMock = new Mock<IExamRepository>();
            TeacherService teacherService = new TeacherService(teacherRepoMock.Object, courseRepoMock.Object, examRepoMock.Object);
            var invalidTeacherId = "blabla hah dfghj ps";

            Assert.ThrowsException<Exception>(() => {
                teacherService.GetExams(invalidTeacherId);
            });
        }
        [TestMethod]
        public void GetExams_Returns_Exams()
        {
            Mock<ITeacherRepository> teacherRepoMock = new Mock<ITeacherRepository>();
            Mock<ICourseRepository> courseRepoMock = new Mock<ICourseRepository>();
            Mock<IExamRepository> examRepoMock = new Mock<IExamRepository>();
            var teacherId = Guid.Parse("f216e1eb-128b-4c31-930d-4fb400d885cc");
            Exception throwException = null;

            var exam1 = new Exam
            {
                Id = Guid.NewGuid(),
                Date = new DateTime(2020, 08, 08)
            };
            var exam2 = new Exam
            {
                Id = Guid.NewGuid(),
                Date = new DateTime(2020, 07, 07)
            };

            var teacherExams = new List<Exam>();
            teacherExams.Add(exam1);
            teacherExams.Add(exam2);
            examRepoMock.Setup(examRepo => examRepo.GetTeacherExams(teacherId)).Returns(teacherExams);

            TeacherService teacherService = new TeacherService(teacherRepoMock.Object, courseRepoMock.Object, examRepoMock.Object);
            IEnumerable<Exam> returnedExams = null;

            try
            {
                returnedExams = teacherService.GetExams(teacherId.ToString());
            }
            catch (Exception e)
            {
                throwException = e;
            }

            Assert.IsNull(throwException, $"Exception thrown.");
            Assert.IsNotNull(returnedExams);
            Assert.AreEqual(teacherExams.Count, returnedExams.Count());
            Assert.AreEqual(new DateTime(2020, 08, 08), returnedExams.FirstOrDefault().Date);
        }
    }
}
