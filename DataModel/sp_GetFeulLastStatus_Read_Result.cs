//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataModel
{
    using System;
    
    public partial class sp_GetFeulLastStatus_Read_Result
    {
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
}
