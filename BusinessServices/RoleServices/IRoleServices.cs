using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessServices.RoleServices
{
    public interface IRoleServices
    {
        //RoleEntity GetObjectById(int ObjectId);
        //IEnumerable<ObjectEntity> GetObjectByGroupId(int GroupId);
        //IEnumerable<ObjectEntity> GetObjectByGroupAndLoginId(int GroupID, int LoginID);
        IEnumerable<RoleEntity> GetAllRoles();
        //int CreateObject(ObjectEntity objectEntity);
        //bool UpdateObject(int ObjectId, ObjectEntity objectEntity);
        //bool DeleteObject(int ObjectId);
    }
}
