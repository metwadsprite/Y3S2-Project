using GASF.ApplicationLogic.Abstractions;
using GASF.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace GASF.ApplicationLogic.Services
{
    public class GroupService
    {
        private IGroupRepository groupRepository;
        public GroupService(IGroupRepository groupRepository)
        {
            this.groupRepository = groupRepository;
        }
        public IEnumerable<Group> GetGroupsByCourseId(string courseId)
        {
            Guid courseIdGuid = Guid.Empty;
            if (!Guid.TryParse(courseId, out courseIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }
            return groupRepository.GetGroupsByCourseId(courseIdGuid);
        }
    }
}
