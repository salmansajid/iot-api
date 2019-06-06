using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessServices.LoginGroupServices
{
    public interface ILoginGroupServices
    {
        LoginGroupEntity GetLoginGroupById(int LoginGroupId);
        IEnumerable<LoginGroups> GetAllLoginGroups();
        LoginGroupEntity GetLoginGroupByLogin(int LoginId);
        int CreateLoginGroup(LoginGroupEntity logingroupEntity);
        bool UpdateLoginGroup(int LoginGroupId, LoginGroupEntity logingroupEntity);
        bool DeleteLoginGroup(int LoginGroupId);
    }
}
