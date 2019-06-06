using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
    public class EventConfigurationEntity
    {
        public int EventConfigID { get; set; }
        public Nullable<long> ObjectSensorID { get; set; }
        public Nullable<int> ObjectID { get; set; }
        public double Min { get; set; }
        public double MAX { get; set; }
        public int Condition { get; set; }
        public Nullable<bool> EnableOrDisable { get; set; }
        public Nullable<double> A0 { get; set; }
        public Nullable<double> A1 { get; set; }
        public string Contact { get; set; }
        public string Units { get; set; }
        public string Format { get; set; }
    
    }
    public class EventConfigurationGridEntity
    {
        public int EventConfigID { get; set; }
        public Nullable<long> ObjectSensorID { get; set; }
        public Nullable<int> ObjectID { get; set; }
        public double Min { get; set; }
        public double MAX { get; set; }
        public int Condition { get; set; }
        public string Contact { get; set; }
        public string Name { get; set; }
        public string SensorName { get; set; }
        public Nullable<bool> EnableOrDisable { get; set; }
    
    }
    public class EventConfigurationLocationEntity
    {
        public long objectsensorId { get; set; }
        public string Location { get; set; }
        public int sensorId { get; set; }
}
}
