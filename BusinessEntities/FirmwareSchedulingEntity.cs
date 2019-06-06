using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class FirmwareSchedulingEntity
    {
        public int FSID { get; set; }
        public Nullable<int> ClientId { get; set; }
        public Nullable<int> ObjectId { get; set; }
        public string SimNumber { get; set; }
        public string Command { get; set; }
        public string ExecutionTime { get; set; }
        public System.DateTime DateTimeStamp { get; set; }
    }
}
