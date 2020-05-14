using GASF.ApplicationLogic.Abstractions;
using GASF.ApplicationLogic.Data;
using GASF.ApplicationLogic.Exceptions;
using GASF.ApplicationLogic.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace GASF.ApplicationLogic.Tests.Services
{
    [TestClass ]
    public class StudentServiceTests
    {
        [TestMethod]
        public void GetStudentByUserId_ThrowsException_WhenUserIdHasInvalidValue()
        {
            //arrange
            Mock<IStudentRepository> studentRepoMoq = new Mock<IStudentRepository>();
            Mock<IGradeRepository> gradeRepoMoq = new Mock<IGradeRepository>();
            Mock<ICourseRepository> courseRepoMoq = new Mock<ICourseRepository>();
            Mock<ITeacherRepository> teacherRepoMoq = new Mock<ITeacherRepository>();
            StudentService studentService = new StudentService(studentRepoMoq.Object,  courseRepoMoq.Object, teacherRepoMoq.Object, gradeRepoMoq.Object);
            var invalidID = "aaa";
            
            //act


            //assert
            Assert.ThrowsException<Exception>(() => {
             studentService.GetByUserId(invalidID);
            });
        }
        [TestMethod]
        public void GetTeacherByUserId_ThrowsEntityNotFound_WhenUserDoesNotExist()
        {
            Mock<IStudentRepository> studentRepoMoq = new Mock<IStudentRepository>();
            Mock<IGradeRepository> gradeRepoMoq = new Mock<IGradeRepository>();
            Mock<ICourseRepository> courseRepoMoq = new Mock<ICourseRepository>();
            Mock<ITeacherRepository> teacherRepoMoq = new Mock<ITeacherRepository>();


            var nonExisitingUser = "fc341c44-0e52-4189-80c3-a4797bd60d01";
            var exisitingUser = Guid.Parse("fc341c44-0e52-4189-80c3-a4797bd60d02");

            var student = new Student
            {
                Id = exisitingUser,
                Email = "blabla@mail.com",
                FirstName = "BlaBla",
                LastName = "LastBlaBla",
                Phone = "0039947888474",
                UserId = exisitingUser
            };

            studentRepoMoq.Setup(studentRepo => studentRepo.GetByUserId(exisitingUser))


                               .Returns(student);


            StudentService studentService = new StudentService(studentRepoMoq.Object, courseRepoMoq.Object, teacherRepoMoq.Object, gradeRepoMoq.Object);

            //assert
            Assert.ThrowsException<EntityNotFoundException>(() =>
            {
                studentService.GetByUserId(nonExisitingUser);
            });
        }
    }
}
