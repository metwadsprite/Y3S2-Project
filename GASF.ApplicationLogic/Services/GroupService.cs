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

        public IEnumerable<Group> GetAll()
        {
            return groupRepository.GetAll();
        }

        public void Add(Group group)
        {
            groupRepository.Add(group);
        }

        public Group GetById(Guid groupId)
        {
            return groupRepository.GetById(groupId);
        }

        public void Delete(Group group)
        {
            groupRepository.Delete(group);
        }

        public void Update(Group group)
        {
            groupRepository.Update(group);
        }
    }
}
