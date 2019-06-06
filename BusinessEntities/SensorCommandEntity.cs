using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
    public class SensorCommandEntity
    {
        public int ID { get; set; }
        public Nullable<int> CommandID { get; set; }
        public Nullable<int> SensorID { get; set; }
        public string Description { get; set; }
    }
}
