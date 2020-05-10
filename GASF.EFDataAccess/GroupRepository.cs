using GASF.ApplicationLogic.Abstractions;
using GASF.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GASF.EFDataAccess
{
    public class GroupRepository : BaseRepository<Group>, IGroupRepository
    {

        public GroupRepository(StudentRecordDbContext dbContext): base(dbContext)
        {
        }

        public IEnumerable<Group> GetGroupsByCourseId(Guid id)
        {
            return dbContext.Groups
                            .Where(group => group.GroupCourses.Any(gc => gc.CourseId == id))
                            .AsEnumerable();
        }

        public Group GetGroupForStudent(Student student)
        {
            return dbContext.Groups.Where(group =>
                group.Students.Contains(student)
            ).Single();
        }

        public Group GetById(Guid groupId)
        {
            return dbContext.Groups.Where(group =>
                group.GroupId == groupId
            ).Single();
        }
    }
}