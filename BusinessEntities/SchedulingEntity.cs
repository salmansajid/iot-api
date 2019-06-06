using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
    public class SchedulingEntity
    {
        public int SchedulingID { get; set; }
        public int ObjectId { get; set; }
        public string ScheduleTime { get; set; }
        public int CommandID { get; set; }
        public Nullable<bool> EnableOrDisable { get; set; }
        public Nullable<int> Days { get; set; }
    }
    public class FederalHolidayEntity
    {
        public int HolidaysID { get; set; }
        public string Holidays { get; set; }
        public Nullable<System.DateTime> FullDate { get; set; }
        public Nullable<bool> Enabled { get; set; }
        public Nullable<int> GroupID { get; set; }
    }
    public class SensorSchedulingEntity
    {
        
        public int ObjectID { get; set; }
        public int CommandID { get; set; }
        public Nullable<System.DateTime> ScheduleTime { get; set; }
        public Nullable<bool> EnableOrDisable { get; set; }
        public Nullable<int>  Days { get; set; }
        public string Name { get; set; }
        public int SensorID { get; set; }

    }
}
