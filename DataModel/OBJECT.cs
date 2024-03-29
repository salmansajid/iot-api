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
    
    public partial class OBJECT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OBJECT()
        {
            this.CommandExecuteHistories = new HashSet<CommandExecuteHistory>();
            this.CommandsQueues = new HashSet<CommandsQueue>();
            this.EventConfigurations = new HashSet<EventConfiguration>();
            this.EventLogs = new HashSet<EventLog>();
            this.ObjectCommands = new HashSet<ObjectCommand>();
            this.ObjectGroups = new HashSet<ObjectGroup>();
            this.ObjectLastStatus = new HashSet<ObjectLastStatu>();
            this.ObjectSensors = new HashSet<ObjectSensor>();
            this.ObjectSensors1 = new HashSet<ObjectSensor>();
        }
    
        public int ObjectID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double LAT { get; set; }
        public double LONG { get; set; }
        public long IMEI { get; set; }
        public long SimNumber { get; set; }
        public string FirmWareVersion { get; set; }
        public string HardwareVersion { get; set; }
        public bool EnableOrDisable { get; set; }
        public Nullable<int> ClientID { get; set; }
        public string Contact { get; set; }
        public Nullable<bool> RelayStatus { get; set; }
        public string ObjectType { get; set; }
        public Nullable<bool> Deleted { get; set; }
        public Nullable<System.DateTime> DeleteDateTime { get; set; }
        public Nullable<int> TavlClient { get; set; }
        public Nullable<int> TavlGroup { get; set; }
        public string TavlIP { get; set; }
        public Nullable<bool> TavlStatus { get; set; }
        public Nullable<int> AttendanceClient { get; set; }
        public string AttendanceIP { get; set; }
        public Nullable<bool> AttendanceStatus { get; set; }
        public string SurveillanceIP { get; set; }
        public Nullable<bool> SurveillanceStatus { get; set; }
        public System.DateTime CreatedDatetime { get; set; }
    
        public virtual Client Client { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CommandExecuteHistory> CommandExecuteHistories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CommandsQueue> CommandsQueues { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EventConfiguration> EventConfigurations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EventLog> EventLogs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ObjectCommand> ObjectCommands { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ObjectGroup> ObjectGroups { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ObjectLastStatu> ObjectLastStatus { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ObjectSensor> ObjectSensors { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ObjectSensor> ObjectSensors1 { get; set; }
    }
}
