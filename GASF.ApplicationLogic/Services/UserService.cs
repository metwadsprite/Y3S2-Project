using System;
using GASF.ApplicationLogic.Abstractions;
using GASF.ApplicationLogic.Data;

namespace GASF.ApplicationLogic.Services
{
    public class UserService
    {
        private readonly ISecretaryRepository secretaryRepository;
        private readonly IStudentRepository studentRepository;
        private readonly ITeacherRepository teacherRepository;

        public UserService(ISecretaryRepository secretaryRepo,
            IStudentRepository studentRepo,
            ITeacherRepository teacherRepo
        ) {
            this.secretaryRepository = secretaryRepo;
            this.studentRepository = studentRepo;
            this.teacherRepository = teacherRepo;
        }

        public bool IsUserSecretary(Guid userId)
        {
            try
            {
                secretaryRepository.GetSecretaryByUserId(userId);
            }
            catch (InvalidOperationException)
            {
                return false;
            }
            return true;
        }

        public bool IsUserStudent(Guid userId)
        {
            try
            {
                studentRepository.GetStudentByUserId(userId);
            }
            catch (InvalidOperationException)
            {
                return false;
            }
            return true;
        }

        public bool IsUserTeacher(Guid userId)
        {
            try
            {
                teacherRepository.GetTeacherByUserId(userId);
            }
            catch (InvalidOperationException)
            {
                return false;
            }
            return true;
        }

        // Functinality should be handled thorugh a backoffice application
        // This is purely for testing purposes
        public void MakeUserSecretary(Guid userId)
        {
            if (IsUserSecretary(userId)) {
                return;
            }
            var secretary = new Secretary {
                UserId = userId,
                FirstName = "Admin",
                LastName = "Admin",
                Email = "admin@gasf.com",
                PhoneNumber = "000000000"
            };

            secretaryRepository.Add(secretary);
        }
    }
}