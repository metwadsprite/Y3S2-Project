using System;
using System.Collections.Generic;
using GASF.ApplicationLogic.Abstractions;
using GASF.ApplicationLogic.Data;
using GASF.ApplicationLogic.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GASF.ApplicationLogic.Tests.Services
{
    [TestClass]
    public class CourseServiceTests
    {
        [TestMethod]
        public void TestGetById()
        {
            var testId = Guid.NewGuid();

            var courseRepoMock = new Mock<ICourseRepository>();
            courseRepoMock.Setup(repo => repo.GetCourseById(testId)).Returns(new Course());

            var courseService = new CourseService(courseRepoMock.Object);

            Assert.IsNotNull(courseService.GetById(testId));
        }

        [TestMethod]
        public void TestGetByName()
        {
            var testName = "test_name";

            var courseRepoMock = new Mock<ICourseRepository>();
            courseRepoMock.Setup(repo => repo.GetCourseByName(testName)).Returns(new Course());

            var courseService = new CourseService(courseRepoMock.Object);

            Assert.IsNotNull(courseService.GetByName(testName));
        }

        [TestMethod]
        public void TestGetAll()
        {
            var testCourse = new Course();
            var testCourseList = new List<Course>();
            testCourseList.Add(testCourse);

            var courseRepoMock = new Mock<ICourseRepository>();
            courseRepoMock.Setup(repo => repo.GetAll()).Returns(testCourseList);

            var courseService = new CourseService(courseRepoMock.Object);

            Assert.AreEqual(testCourseList, courseService.GetAll());
        }
    }
}