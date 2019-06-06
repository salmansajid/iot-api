using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class SwitchesReportEntity
    {
        public int SwitchID { get; set; }
        public Nullable<int> ObjectID { get; set; }
        public string Name { get; set; }
        public Nullable<double> Current { get; set; }
        public Nullable<double> Voltage { get; set; }
        public Nullable<double> Power { get; set; }
        public Nullable<double> Unit { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<bool> Fault { get; set; }
        public string TotalTime { get; set; }
        public Nullable<double> TotalTime_Decimal { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
        public Nullable<int> C_SensorId { get; set; }
        public Nullable<int> V_SensorId { get; set; }
        public Nullable<int> S_SensorId { get; set; }
        public Nullable<System.DateTime> DateTimeStamp { get; set; }
        public Nullable<int> LocationID { get; set; }
    }
    public class CurrentDateCON_SW_ReportEntity
    {
        public string Name { get; set; }
        public Nullable<double> Value { get; set; }
        public Nullable<int> sensorId { get; set; }
    }
    public class CurrentDateCONTROL_SW_ReportEntity
    {
        public Nullable<int> ObjectID { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public int Fault { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
        public string TotalTime { get; set; }
        public int SensorID { get; set; }
    }
}
