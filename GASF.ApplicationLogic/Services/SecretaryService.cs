using GASF.ApplicationLogic.Abstractions;
using GASF.ApplicationLogic.Data;
using GASF.ApplicationLogic.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace GASF.ApplicationLogic.Services
{
   public class SecretaryService : ISecretaryService
    {
        ISecretaryRepository secretaryRepository;

        public SecretaryService (ISecretaryRepository secretaryRepository)
        {
            this.secretaryRepository = secretaryRepository;
        }

        public Secretary GetSecretaryByUserId(string userId)
        {
            Guid userIdGuid = Guid.Empty;
            if (!Guid.TryParse(userId, out userIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }

            var teacher = secretaryRepository.GetSecretaryByUserId(userIdGuid);
            if (teacher == null)
            {
                throw new EntityNotFoundException(userIdGuid);
            }

            return teacher;
        }

        public Secretary GetSecretaryById(Guid Id)
        {
            return secretaryRepository.GetSecretaryById(Id);
        }
    }
}
