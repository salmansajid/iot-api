using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class ObjLastEntity
    {
        public int StatusID { get; set; }
        public Nullable<long> PMID { get; set; }
        public Nullable<int> ObjectID { get; set; }
        public string DeviceIP { get; set; }
        public bool DeviceStatus { get; set; }
        public System.DateTime ConnectionDatetime { get; set; }
        public Nullable<int> Priority { get; set; }
        public int DevicePort { get; set; }
        public Nullable<System.DateTime> LastRecordReceived { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }
    }
}
