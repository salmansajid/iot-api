using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
    public class ObjectSensorsEntity
    {

        public long ObjectSensorId { get; set; }
        public int SensorID { get; set; }
        public Nullable<int> ObjectID { get; set; }
        public string Name { get; set; }
        public Nullable<bool> Enabled { get; set; }
        public Nullable<bool> SMSAlert { get; set; }
        public Nullable<bool> EmailAlert { get; set; }
        public Nullable<double> A0 { get; set; }
        public Nullable<double> A1 { get; set; }
        public string Contact { get; set; }
        public Nullable<int> Max { get; set; }
        public Nullable<int> Min { get; set; }
        public Nullable<int> CategoryID { get; set; }
    

    }
    public class ObjectSensorsGrid
    {

        public long ObjectSensorId { get; set; }
        public int SensorID { get; set; }
        public int ObjectID { get; set; }
        public string ObjectName { get; set; }
        public string Name { get; set; }
        public bool Enabled { get; set; }
        public bool SMSAlert { get; set; }
        public bool EmailAlert { get; set; }
        public int Max { get; set; }
        public int Min { get; set; }
        public string SourceID { get; set; }
        public string SourceName { get; set; }
        public string Unit { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public string CategoryName { get; set; }
        public bool EnableOrDisable { get; set; }
    }

    public class SensorIDSourceID
    {
        public int SensorID { get; set; }
        public string SourceID { get; set; }
    }
    public class OBJSIDName
    {
        public long ObjectSensorId { get; set; }
        public string Name { get; set; }
    }
    public class ObjNameObjSNameCateNameEntity
    {
        
        public string ObjectName { get; set; }
        public string ObjectSensorName { get; set; }
        public string CategoryName { get; set; }
    }
}
       
      