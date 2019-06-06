using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessServices.ObjectGroupServices
{
    public interface IObjectGroupServices
    {
        ObjectGroupEntity GetObjectGroupById(int ObjectGroupId);
        IEnumerable<ObjectGroups> GetAllObjectGroups();
        IEnumerable<ObjectGroups> GetAllObjectGroupbyObjectId(int ObjectId);
        int CreateObjectGroup(ObjectGroupEntity objectgroupEntity);
        bool UpdateObjectGroup(int ObjectGroupId, ObjectGroupEntity objectgroupEntity);
        bool DeleteObjectGroup(int ObjectGroupId);
    }
}
