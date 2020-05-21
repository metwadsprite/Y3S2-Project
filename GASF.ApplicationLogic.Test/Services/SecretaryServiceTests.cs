
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
    [TestClass]
    public class SecretaryServiceTests
    {
        [TestMethod]
        public void GetSecretaryByUserId_ThrowsException_WhenUserIdHasInvalidValue()
        {
            //arrange
           
            Mock<ISecretaryRepository> secretaryRepoMock = new Mock<ISecretaryRepository>();
            
            SecretaryService secretaryService = new SecretaryService(secretaryRepoMock.Object);
            var badUserId = "jkajsdkasj dkj daksdj as";
            //act            
            //assert
            Assert.ThrowsException<Exception>(() => {
                secretaryService.GetSecretaryByUserId(badUserId);
            });
        }

        [TestMethod]
        public void GetSecretaryByUserId_ThrowsEntityNotFound_WhenUserDoesNotExist()
        {
            Mock<ISecretaryRepository> secretaryRepoMock = new Mock<ISecretaryRepository>();

            var nonExistingUserId = "7299FFCC-435E-4A6D-99DF-57A4D6FBA747";
            var existingUserId = Guid.Parse("7299FFCC-435E-4A6D-99DF-57A4D6FBA712");

            var secretary = new Secretary
            {
                Id = existingUserId,
                Email = "blabla@mail.com",
                FirstName = "BlaBla",
                LastName = "LastBlaBla",
                UserId = existingUserId
            };

            secretaryRepoMock.Setup(teacherRepo => teacherRepo.GetSecretaryByUserId(existingUserId))
                            .Returns(secretary);

            SecretaryService secretaryService = new SecretaryService(secretaryRepoMock.Object);

            //act            
            //assert
            Assert.ThrowsException<EntityNotFoundException>(() => {
                secretaryService.GetSecretaryByUserId(nonExistingUserId);
            });
        }

        [TestMethod]
        public void GetSecretaryByUserId_Returns_UserWhenExists()
        {
            Mock<ISecretaryRepository> secretaryRepoMock = new Mock<ISecretaryRepository>();
            var existingUserId = Guid.Parse("7299FFCC-435E-4A6D-99DF-57A4D6FBA712");
            Exception throwException = null;
            var secretary = new Secretary
            {
                Id = existingUserId,
                Email = "blabla@mail.com",
                FirstName = "BlaBla",
                LastName = "LastBlaBla",
                UserId = existingUserId
            };

            secretaryRepoMock.Setup(teacherRepo => teacherRepo.GetSecretaryByUserId(existingUserId))
                            .Returns(secretary);

            SecretaryService teacherService = new SecretaryService(secretaryRepoMock.Object);
            Secretary user = null;
            //act   
            try
            {
                user = teacherService.GetSecretaryByUserId(existingUserId.ToString());
            }
            catch (Exception e)
            {
                throwException = e;
            }
            //assert
            Assert.IsNull(throwException, $"Exception was thrown");
            Assert.IsNotNull(user);
        }
    }
}
