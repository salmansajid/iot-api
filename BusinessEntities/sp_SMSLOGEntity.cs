using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class sp_SMSLOGEntity
    {
        public string Device { get; set; }
        public string Location { get; set; }
        public Nullable<double> Sensor { get; set; }
        public Nullable<System.DateTime> Variatoin_Time { get; set; }
        public Nullable<int> SensorID { get; set; }
        public string SensorName { get; set; }
    }
}
