
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BusinessEntities
{
    public class LoginEntity
    {
        public int LoginID { get; set; }
        public Nullable<int> ClientID { get; set; }
        public Nullable<int> RoleID { get; set; }
        public string User { get; set; }
        public string Comment { get; set; }
        public string Password { get; set; }

    }
    public class Logins
    {
        public int LoginID { get; set; }
        public int ClientID { get; set; }
        public int RoleID { get; set; }
        public string User { get; set; }
        public string Comment { get; set; }
        public string Name { get; set; }
        public string Role { get;  set; } 
        

    }
}
