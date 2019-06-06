using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
    public class SensorObjectGroupEntity
    {
        public int SensorObjectGroupID { get; set; }
        public Nullable<int> ROUT { get; set; }
        public Nullable<int> ROUTCurrent { get; set; }
        public Nullable<int> ROUTVoltage { get; set; }
        public Nullable<int> ROUTStatus { get; set; }
        public Nullable<int> ROUTFault { get; set; }
    }

    public class SensorIDEntity
    {
        public int SensorID { get; set; }
        public int ObjectSensorID { get; set; }

    }


}
