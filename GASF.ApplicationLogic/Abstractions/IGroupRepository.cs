using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace GASF.ApplicationLogic.Abstractions
{
    public interface IGroupRepository : IRpository<Group>
    {
        ICollection<Group> GetStudentFromGroup(Guid studentId);

    }
}
