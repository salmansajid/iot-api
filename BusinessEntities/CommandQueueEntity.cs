using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
    public class CommandQueueEntity
    {
        public int ObjectID { get; set; }
        public int CommandID { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> SensorID { get; set; }
    }
}
