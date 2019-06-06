using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
    public class PMessageEntity
    {

        public long PMID { get; set; }
        public System.DateTime DateTimeStamp { get; set; }
        public int ObjectID { get; set; }
        public bool Valid { get; set; }
        public Nullable<bool> Deleted { get; set; }
        public Nullable<System.DateTime> DeleteDateTime { get; set; }
    }
}
