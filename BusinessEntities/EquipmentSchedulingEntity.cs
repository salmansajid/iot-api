using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
    public class EquipmentSchedulingEntity
    {
        public int SchedulingID { get; set; }
        public Nullable<int> ObjectId { get; set; }
        public string DaysName { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public Nullable<int> Days { get; set; }
        public Nullable<int> ObjectSensorId { get; set; }
        public Nullable<bool> EnableOrDisable { get; set; }

    }

    public class sp_EquipmentSchedulingEntity
    {
        public int SchedulingId { get; set; }
        public string DaysName { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public Nullable<int> Days { get; set; }
        public string Name { get; set; }
        public Nullable<int> ObjectSensorId { get; set; }
        public Nullable<bool> EnableOrDisable { get; set; }
        public Nullable<int> sensorID { get; set; }
    }

}