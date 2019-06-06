using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
    public class GroupEntity
    {

        public int GroupID { get; set; }
        public int ClientID { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public Nullable<bool> Deleted { get; set; }
    }
    public class Groups
    {
        public int GroupID { get; set; }
        public int ClientID { get; set; }
        public string ClientName { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public Nullable<bool> Deleted { get; set; }
    }
}
