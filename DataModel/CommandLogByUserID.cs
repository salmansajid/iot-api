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
    
    public partial class CommandLogByUserID
    {
        public int LogID { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> ObjectID { get; set; }
        public Nullable<int> SensorID { get; set; }
        public Nullable<int> CommandID { get; set; }
        public Nullable<System.DateTime> DateTimeStamp { get; set; }
    }
}