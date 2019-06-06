using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class uspReport_DinState1Entity
    {
        public long ObjectsensorID { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
        public string TotalTime { get; set; }

    }
    public class uspReport_DinStateEntity
    {
        public long ObjectsensorID { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
        public DateTime TotalTime { get; set; }

    }
}
