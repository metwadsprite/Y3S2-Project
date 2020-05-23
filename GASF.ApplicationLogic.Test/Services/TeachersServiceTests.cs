using GASF.ApplicationLogic.Abstractions;
using GASF.ApplicationLogic.Data;
using GASF.ApplicationLogic.Exceptions;
using GASF.ApplicationLogic.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace GASF.ApplicationLogic.Test.Services
{
    [TestClass]
    public class TeachersServiceTests
    {
        [TestMethod]
        public void GetTeachersById_ThrowsEntityNotFound_WhenUserDoesNotExist()
        {
            Mock<ITeacherRepository> teacherRepository = new Mock<ITeacherRepository>();
            TeachersService teachersService = new TeachersService(teacherRepository.Object);
            var nonExistingUserId = Guid.NewGuid();
            var existingUserId = Guid.Parse("7299FFCC-435E-4A6D-99DF-57A4D6FBA712");
            var teacher = new Teacher
            {
                Id = existingUserId,
                Email = "ab@yahoo.com",
                FirstName = "ala",
                LastName = "bbb"

            };

            teacherRepository.Setup(teacherRepo => teacherRepo.GetTeacherById(existingUserId))
                            .Returns(teacher);

            Assert.ThrowsException<EntityNotFoundException>(() => {
                teachersService.GetTeacherById(nonExistingUserId);
            });
        }

        [TestMethod]
        public void GetTeacherById_Returns_UserWhenExists()
        {
            Mock<ITeacherRepository> teacherRepository = new Mock<ITeacherRepository>();
            TeachersService teachersService = new TeachersService(teacherRepository.Object);

            var existingUserId = Guid.Parse("7299FFCC-435E-4A6D-99DF-57A4D6FBA712");
            Exception throwException = null;
            var teacher = new Teacher
            {
                Id = existingUserId,
                Email = "ab@yahoo.com",
                FirstName = "ala",
                LastName = "bbb"

            };

            teacherRepository.Setup(teacherRepo => teacherRepo.GetTeacherById(existingUserId))
                            .Returns(teacher);


            Teacher user = null;
            //act   
            try
            {
                user = teachersService.GetTeacherById(existingUserId);
            }
            catch (Exception e)
            {
                throwException = e;
            }
            //assert
            Assert.IsNull(throwException, $"Exception was thrown");
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void GetAllTeachers_ReturnTeachers()
        {
            Mock<ITeacherRepository> teacherRepository = new Mock<ITeacherRepository>();
            TeachersService teachersService = new TeachersService(teacherRepository.Object);

            Teacher teacher1 = new Teacher
            {
                FirstName = "bb",
                LastName = "aa",
                Id = Guid.NewGuid()
            };

            Teacher teacher2 = new Teacher
            {
                FirstName = "cc",
                LastName = "bb",
                Id = Guid.NewGuid()
            };

            ICollection<Teacher> teachers = new Collection<Teacher>();
            teachers.Add(teacher1);
            teachers.Add(teacher2);

            teacherRepository.Setup(teacherRepo => teacherRepo.GetAll())
                            .Returns(teachers);

            var returnedCollection = teachersService.GetAllTeachers();

            Assert.AreEqual(teachers.Count, returnedCollection.Count());
        }
    }
}
