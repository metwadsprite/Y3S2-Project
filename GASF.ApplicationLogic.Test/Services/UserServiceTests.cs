

using System;
using GASF.ApplicationLogic.Abstractions;
using GASF.ApplicationLogic.Data;
using GASF.ApplicationLogic.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GASF.ApplicationLogic.Test.Services
{
    [TestClass]
    public class UserServiceTests
    {
        [TestMethod]
        public void TestIsUserSecretary()
        {
            var secretaryRepoMock = new Mock<ISecretaryRepository>();
            var studentRepoMock = new Mock<IStudentRepository>();
            var teacherRepoMock = new Mock<ITeacherRepository>();

            var testGuid = Guid.NewGuid();
            secretaryRepoMock.SetupSequence(repo => repo.GetSecretaryByUserId(testGuid))
                .Returns(new Secretary())
                .Throws(new InvalidOperationException());

            var userService = new UserService(
                secretaryRepoMock.Object,
                studentRepoMock.Object,
                teacherRepoMock.Object
            );
             
             Assert.IsTrue(userService.IsUserSecretary(testGuid));
             Assert.IsFalse(userService.IsUserSecretary(testGuid));
        }

        [TestMethod]
        public void TestIsUserStudent()
        {
            var secretaryRepoMock = new Mock<ISecretaryRepository>();
            var studentRepoMock = new Mock<IStudentRepository>();
            var teacherRepoMock = new Mock<ITeacherRepository>();

            var testGuid = Guid.NewGuid();
            studentRepoMock.SetupSequence(repo => repo.GetStudentByUserId(testGuid))
                .Returns(new Student())
                .Throws(new InvalidOperationException());

            var userService = new UserService(
                secretaryRepoMock.Object,
                studentRepoMock.Object,
                teacherRepoMock.Object
            );

            Assert.IsTrue(userService.IsUserStudent(testGuid));
            Assert.IsFalse(userService.IsUserStudent(testGuid));
        }

        [TestMethod]
        public void TestIsUserTeacher()
        {
            var secretaryRepoMock = new Mock<ISecretaryRepository>();
            var studentRepoMock = new Mock<IStudentRepository>();
            var teacherRepoMock = new Mock<ITeacherRepository>();

            var testGuid = Guid.NewGuid();
            teacherRepoMock.SetupSequence(repo => repo.GetTeacherByUserId(testGuid))
                .Returns(new Teacher())
                .Throws(new InvalidOperationException());

            var userService = new UserService(
                secretaryRepoMock.Object,
                studentRepoMock.Object,
                teacherRepoMock.Object
            );

            Assert.IsTrue(userService.IsUserTeacher(testGuid));
            Assert.IsFalse(userService.IsUserTeacher(testGuid));
        }
    }
}