using GASF.ApplicationLogic.Abstractions;
using GASF.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GASF.EFDataAccess
{
    class GroupRepository : IGroupRepository
    {
        private readonly StudentRecordDbContext dbContext;

        public GroupRepository(StudentRecordDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Group Add(Group itemToAdd)
        {
            dbContext.Groups.Add(itemToAdd);
            dbContext.SaveChanges();

            return itemToAdd;
        }

        public bool Delete(Group itemToDelete)
        {
            dbContext.Groups.Remove(itemToDelete);
            dbContext.SaveChanges();

            return true;
        }

        public IEnumerable<Group> GetAll()
        {
            return dbContext.Groups;
        }

        public IEnumerable<Group> GetGroupsByCourseId(Guid id)
        {
            return dbContext.Groups
                            .Where(group => group.GroupCourses.Any(gc => gc.CourseId == id))
                            .AsEnumerable();
        }
        public Group Update(Group itemToUpdate)
        {
            dbContext.Groups.Update(itemToUpdate);
            dbContext.SaveChanges();

            return itemToUpdate;
        }
    }
}