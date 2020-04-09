using System;
using System.Collections.Generic;
using System.Text;
using GASF.ApplicationLogic.Data;

namespace GASF.ApplicationLogic.Abstractions
{
    public interface IGroupRepository : IRepository<Group>
    {
        ICollection<Group> GetStudentFromGroup(Guid studentId);

    }
}
