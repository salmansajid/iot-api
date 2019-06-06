using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
   public class SensorEntity
    {
        public int SensorID { get; set; }
        public string SourceID { get; set; }
        public string SourceName { get; set; }
        public string Unit { get; set; }
        public bool EnableOrDisable { get; set; }
    }
}
