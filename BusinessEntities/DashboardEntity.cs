using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class DashboardEntity
    {
        public Nullable<long> PMID { get; set; }
        public Nullable<long> ObjectSensorId { get; set; }
        public string Name { get; set; }
        public string Current { get; set; }
        public string Voltage { get; set; }
        public Nullable<bool> Fault { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<System.DateTime> DateTimeStamp { get; set; }
        public Nullable<int> SensorId { get; set; }
        public string Category { get; set; }
    }
    public class DashboardEntityCurrent
    {
        public float Current { get; set; }
    }
    public class DashboardEntityVoltage
    {
        public float Voltage { get; set; }
    }
    public class DashboardEntityFault
    {
        public Nullable<bool> Fault { get; set; }
    }
}
