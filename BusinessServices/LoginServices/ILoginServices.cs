using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntities;


namespace BusinessServices
{
    public interface ILoginServices
    {

        LoginEntity GetLoginById(int LoginId);
        IEnumerable<Logins> GetAllLogins();
        LoginEntity Authenthicate(string User, string password);
        IEnumerable<Logins> GetLoginsNonAdmin();
        IEnumerable<LoginEntity> GetLoginByCode(string Code, string User, string password);
        int CreateLogin(LoginEntity loginEntity);
        bool UpdateLogin(int LoginId, LoginEntity loginEntity);
        bool DeleteLogin(int LoginId);
    }
}
