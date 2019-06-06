using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
    public class ObjectGroupEntity
    {
        public int ObjectGroupID { get; set; }
        public int ObjectID { get; set; }
        public int GroupID { get; set; }
    }
    public class ObjectGroups
    {
        public int ObjectGroupID { get; set; }
        public string ObjectName { get; set; }
        public string GroupName { get; set; }
    }
}
