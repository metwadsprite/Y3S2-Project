using GASF.ApplicationLogic.Abstractions;
using GASF.ApplicationLogic.Data;
using GASF.ApplicationLogic.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace GASF.ApplicationLogic.Services
{
    public class TeachersService : ITeachersService
    {
        private ITeacherRepository teacherRepository;

        public TeachersService(ITeacherRepository teacherRepository)
        {
            this.teacherRepository = teacherRepository;
        }
        public void AddTeacher(Teacher teacher)
        {
            teacherRepository.Add(teacher);
        }

        public void DeleteTeacher(Guid id)
        {
            if (id == null)
            {
                throw new EntityNotFoundException(id);
            }
            var teacher = teacherRepository.GetTeacherById(id);
            if (teacher == null)
            {
                throw new EntityNotFoundException(id);
            }
            teacherRepository.Delete(teacher);
        }

        public void EditTeacher(Guid id, Teacher teacher)
        {
            if (id != teacher.Id)
            {
                throw new EntityNotFoundException(id);
            }
            teacherRepository.Update(teacher);
        }

        public IEnumerable<Teacher> GetAllTeachers()
        {
            return teacherRepository.GetAll();
        }

        public Teacher GetTeacherById(Guid id)
        {
            if (id == null)
            {
                throw new Exception("Teacher id is null");
            }

            var teacher = teacherRepository.GetTeacherById(id);

            if (teacher == null)
            {
                throw new EntityNotFoundException(id);
            }
            return teacher;
        }
    }
}
