using System;
using System.Collections.Generic;
using System.Text;
using GASF.ApplicationLogic.Data;

namespace GASF.ApplicationLogic.Abstractions
{
    public interface IGroupRepository : IRepository<Group>
    {
        IEnumerable<Group> GetGroupsByCourseId(Guid id);
    }
}
