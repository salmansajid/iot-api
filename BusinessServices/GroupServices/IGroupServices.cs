using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessServices.GroupServices
{
    public interface IGroupServices
    {
        GroupEntity GetGroupById(int GroupId);
        IEnumerable<Groups> GetGroupByClientId(int ClientId);
        IEnumerable<Groups> GetAllGroups();
        int CreateGroup(GroupEntity groupEntity);
        bool UpdateGroup(int GroupId, GroupEntity groupEntity);
        bool DeleteGroup(int GroupId, GroupEntity groupEntity);
    }
}
