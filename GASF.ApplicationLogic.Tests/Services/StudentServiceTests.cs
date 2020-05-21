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

namespace GASF.ApplicationLogic.Tests.Services
{
    [TestClass]
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
            StudentService studentService = new StudentService(studentRepoMoq.Object, courseRepoMoq.Object, teacherRepoMoq.Object, gradeRepoMoq.Object);
            var invalidID = "aaa";

            //act


            //assert
            Assert.ThrowsException<Exception>(() => {
                studentService.GetByUserId(invalidID);
            });
        }
        [TestMethod]
        public void GetStudentByUserId_ThrowsEntityNotFound_WhenUserDoesNotExist()
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

        [TestMethod]
        public void GetStudentByUserId_Returns_UserWhenExists()
        {
            Mock<IStudentRepository> studentRepoMoq = new Mock<IStudentRepository>();
            Mock<IGradeRepository> gradeRepoMoq = new Mock<IGradeRepository>();
            Mock<ICourseRepository> courseRepoMoq = new Mock<ICourseRepository>();
            Mock<ITeacherRepository> teacherRepoMoq = new Mock<ITeacherRepository>();

            var exisitingUser = Guid.Parse("fc341c44-0e52-4189-80c3-a4797bd60d02");

            Exception throwException = null;
            var studentService = new StudentService(studentRepoMoq.Object, courseRepoMoq.Object, teacherRepoMoq.Object, gradeRepoMoq.Object);
            Student user = null;
            //act   
            try
            {
                user = studentService.GetByUserId(exisitingUser.ToString());
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
        public void GetStudentCourses_ThrowsException_WhenInvalidValue()
        {
            Mock<IStudentRepository> studentRepoMoq = new Mock<IStudentRepository>();
            Mock<IGradeRepository> gradeRepoMoq = new Mock<IGradeRepository>();
            Mock<ICourseRepository> courseRepoMoq = new Mock<ICourseRepository>();
            Mock<ITeacherRepository> teacherRepoMoq = new Mock<ITeacherRepository>();
            StudentService studentService = new StudentService(studentRepoMoq.Object, courseRepoMoq.Object, teacherRepoMoq.Object, gradeRepoMoq.Object);
            var invalidID = "abcde";

            Assert.ThrowsException<Exception>(() =>
            {
                studentService.GetStudentCourses(invalidID);
            });
        }


        [TestMethod]
        public void GetSchoolFee_ReturnSchoolFee_WhenUserIdHasInvalidValue()
        {

            Mock<IStudentRepository> studentRepoMoq = new Mock<IStudentRepository>();
            Mock<IGradeRepository> gradeRepoMoq = new Mock<IGradeRepository>();
            Mock<ICourseRepository> courseRepoMoq = new Mock<ICourseRepository>();
            Mock<ITeacherRepository> teacherRepoMoq = new Mock<ITeacherRepository>();


            StudentService studentService = new StudentService(studentRepoMoq.Object, courseRepoMoq.Object, teacherRepoMoq.Object, gradeRepoMoq.Object);
            var exisitingUser = Guid.Parse("fc341c44-0e52-4189-80c3-a4797bd60d02");
            var invalidID = "aaa";
            SchoolFee schoolFee1 = new SchoolFee
            {
                Value = 8,
                Id = exisitingUser,
            };

            SchoolFee schoolFee2 = new SchoolFee
            {
                Value = 9,
                Id = exisitingUser,
            };

            ICollection<SchoolFee> schoolFeeByUserId = new Collection<SchoolFee>();
            schoolFeeByUserId.Add(schoolFee1);
            schoolFeeByUserId.Add(schoolFee2);
            studentRepoMoq.Setup(studentRepo => studentRepo.GetSchoolFee(exisitingUser))


                               .Returns(schoolFeeByUserId);

            Assert.ThrowsException<Exception>(() =>
            {
                studentService.GetSchoolFee(invalidID);
            });
        }

            public void GetSchoolFee_ReturnSchoolFee_WhenUserIdHasValidValue()
            {
                Mock<IStudentRepository> studentRepoMoq = new Mock<IStudentRepository>();
                Mock<IGradeRepository> gradeRepoMoq = new Mock<IGradeRepository>();
                Mock<ICourseRepository> courseRepoMoq = new Mock<ICourseRepository>();
                Mock<ITeacherRepository> teacherRepoMoq = new Mock<ITeacherRepository>();


                StudentService studentService = new StudentService(studentRepoMoq.Object, courseRepoMoq.Object, teacherRepoMoq.Object, gradeRepoMoq.Object);
                var exisitingUser = Guid.Parse("fc341c44-0e52-4189-80c3-a4797bd60d02");

                SchoolFee schoolFee1 = new SchoolFee
                {
                    Value = 8,
                    Id = exisitingUser,
                };

                SchoolFee schoolFee2 = new SchoolFee
                {
                    Value = 9,
                    Id = exisitingUser,
                };

                ICollection<SchoolFee> schoolFeeByUserId = new Collection<SchoolFee>();
                schoolFeeByUserId.Add(schoolFee1);
                schoolFeeByUserId.Add(schoolFee2);
                studentRepoMoq.Setup(studentRepo => studentRepo.GetSchoolFee(exisitingUser))


                                   .Returns(schoolFeeByUserId);


                var list = studentService.GetSchoolFee(exisitingUser.ToString());
                Assert.AreEqual(schoolFeeByUserId.Count, list.Count());
            }
        }
    }

    

