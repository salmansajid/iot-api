using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class uspGet_EquipmentConsumptionByDTModel
    {
        public string Name { get; set; }
        public Nullable<decimal> Current { get; set; }
        public Nullable<decimal> Voltage { get; set; }
        public Nullable<decimal> Power { get; set; }
        public Nullable<decimal> Unit { get; set; }
        public string TotalTime { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
    }
}
