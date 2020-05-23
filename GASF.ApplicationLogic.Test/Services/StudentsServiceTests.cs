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
    public class StudentsServiceTests
    {

        [TestMethod]
        public void GetStudentsById_ThrowsEntityNotFound_WhenUserDoesNotExist()
        {
            Mock<IStudentRepository> studentRepository = new Mock<IStudentRepository>();
            StudentsService studentsService = new StudentsService(studentRepository.Object);
            var nonExistingUserId = Guid.NewGuid();
            var existingUserId = Guid.Parse("7299FFCC-435E-4A6D-99DF-57A4D6FBA712");
            var student = new Student
            {
                Id = existingUserId,
                Email = "ab@yahoo.com",
                FirstName = "ala",
                LastName = "bbb"

            };

            studentRepository.Setup(studentRepo => studentRepo.GetStudentById(existingUserId))
                            .Returns(student);

            Assert.ThrowsException<EntityNotFoundException>(() => {
                studentsService.GetStudentById(nonExistingUserId);
            });
        }

        [TestMethod]
        public void GetStudentById_Returns_UserWhenExists()
        {
            Mock<IStudentRepository> studentRepository = new Mock<IStudentRepository>();
            StudentsService studentsService = new StudentsService(studentRepository.Object);
            var existingUserId = Guid.Parse("7299FFCC-435E-4A6D-99DF-57A4D6FBA712");
            Exception throwException = null;
            var student = new Student
            {
                Id = existingUserId,
                Email = "ab@yahoo.com",
                FirstName = "ala",
                LastName = "bbb"

            };

            studentRepository.Setup(studentRepo => studentRepo.GetStudentById(existingUserId))
                            .Returns(student);


            Student user = null;
            //act   
            try
            {
                user = studentsService.GetStudentById(existingUserId);
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
        public void GetStudentsByFirstName_WhenNoFirstName_ReturnAll()
        {
            Mock<IStudentRepository> studentRepository = new Mock<IStudentRepository>();
            StudentsService studentsService = new StudentsService(studentRepository.Object);
            String first_name = "Popescu";

            Student student1 = new Student
            {
                FirstName = "bb",
                LastName = "aa",
                Id = Guid.NewGuid()
            };

            Student student2 = new Student
            {
                FirstName = "cc",
                LastName = "bb",
                Id = Guid.NewGuid()
            };

            ICollection<Student> studentsWithFirstNameNotLike = new Collection<Student>();
            studentsWithFirstNameNotLike.Add(student2);
            studentsWithFirstNameNotLike.Add(student1);

            studentRepository.Setup(studentRepo => studentRepo.GetStudentByFirstName(first_name))
                            .Returns(studentsWithFirstNameNotLike);

            var returnedCollection = studentsService.GetStudentsByFirstName(first_name);

            Assert.AreEqual(studentsWithFirstNameNotLike.Count, returnedCollection.Count());

           } 

        [TestMethod]
        public void GetStudentsByFirstName_ReturnStudents()
        {
            Mock<IStudentRepository> studentRepository = new Mock<IStudentRepository>();
            StudentsService studentsService = new StudentsService(studentRepository.Object);
            String first_name = "Popescu";

            Student student1 = new Student
            {
                FirstName = first_name,
                LastName = "aa",
                Id = Guid.NewGuid()
            };

            Student student2 = new Student
            {
                FirstName = first_name,
                LastName = "bb",
                Id = Guid.NewGuid()
            };

            ICollection<Student> studentsWithFirstNameLike = new Collection<Student>();
            studentsWithFirstNameLike.Add(student2);
            studentsWithFirstNameLike.Add(student1);

            studentRepository.Setup(studentRepo => studentRepo.GetStudentByFirstName(first_name))
                            .Returns(studentsWithFirstNameLike);

            var returnedCollection = studentsService.GetStudentsByFirstName(first_name);

            Assert.AreEqual(studentsWithFirstNameLike.Count, returnedCollection.Count());
        }


    }
}
