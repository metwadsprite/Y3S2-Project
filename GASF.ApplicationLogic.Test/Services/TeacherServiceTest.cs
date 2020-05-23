using GASF.ApplicationLogic.Abstractions;
using GASF.ApplicationLogic.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;
using System.Collections.Generic;
using System.Text;
using GASF.ApplicationLogic.Data;
using GASF.ApplicationLogic.Exceptions;

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
    }
}
