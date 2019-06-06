using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
    public class FeatureEntity
    {
        public int FeatureID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public Nullable<int> ParentId { get; set; }
        public string Class { get; set; }
    }

    public class LoginFeaturesByLogins
    {
        public int RoleID { get; set; }
        public int LoginID { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }        
        public string Class { get; set; }
        public int FeatureID { get; set; }
        public Nullable<int> ParentId { get; set; }
    }
}
