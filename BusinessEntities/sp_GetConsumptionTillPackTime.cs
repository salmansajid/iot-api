using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
    public class sp_GetConsumptionTillPackTime
    {
        public string SourceName { get; set; }
        public int SEN { get; set; }
        public string value { get; set; }
        public System.DateTime ReceivedDateTimeStamp { get; set; }
    }
}
