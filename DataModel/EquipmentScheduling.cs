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
    using System.Collections.Generic;
    
    public partial class EquipmentScheduling
    {
        public int SchedulingID { get; set; }
        public Nullable<int> ObjectId { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public Nullable<int> Days { get; set; }
        public Nullable<int> ObjectSensorId { get; set; }
        public Nullable<bool> EnableOrDisable { get; set; }
        public string DaysName { get; set; }
    }
}