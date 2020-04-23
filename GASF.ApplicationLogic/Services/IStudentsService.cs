using GASF.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace GASF.ApplicationLogic.Services
{
    public interface IStudentsService
    {
        IEnumerable<Student> GetAllStudents();

        Student GetStudentById(Guid id);

        void AddStudent(Student student);

        void EditStudent(Guid id, Student student);

        void DeleteStudent(Guid id);
    }
}
