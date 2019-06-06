using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
    public class LoginGroupEntity
    {
        public int LoginGroupID { get; set; }
        public int GroupID { get; set; }
        public int LoginID { get; set; }
    
    }
    public class LoginGroups
    {
        public int LoginGroupID { get; set; }
        public string GroupName { get; set; }
        public string LoginName { get; set; }
        public int GroupID { get; set; }
        public int LoginID { get; set; }
    
    }
    
}
