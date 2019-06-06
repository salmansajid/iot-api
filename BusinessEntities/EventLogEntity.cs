using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
    public class EventLogEntity
    {
        //public long EventLogID { get; set; }
        //public Nullable<long> PMID { get; set; }
        //public Nullable<long> PMDATAID { get; set; }
        //public Nullable<int> ObjectID { get; set; }
        //public Nullable<System.DateTime> DeviceDateTime { get; set; }
        //public Nullable<long> ObjectSensorId { get; set; }
        //public string VALUE { get; set; }
        //public Nullable<int> SensorID { get; set; }
        //public Nullable<bool> Valid { get; set; }
        //public Nullable<System.DateTime> DateTimeStamp { get; set; }
        public Nullable<int> SensorID { get; set; }
        public long EventLogID { get; set; }
        public Nullable<long> PMID { get; set; }
        public Nullable<long> PMDATAID { get; set; }
        public Nullable<int> ObjectID { get; set; }
        public Nullable<System.DateTime> DeviceDateTime { get; set; }
        public Nullable<long> ObjectSensorId { get; set; }
        public string VALUE { get; set; }
      
        public Nullable<bool> Valid { get; set; }
        public Nullable<System.DateTime> DateTimeStamp { get; set; }

    }

    public class Object_EventLogEntity
    {
        public Nullable<int> ObjectID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Value { get; set; }
        public Nullable<int> SensorID { get; set; }
        public Nullable<System.DateTime> DateTimeStamp { get; set; }
    }
}
