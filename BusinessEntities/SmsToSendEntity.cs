using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class SmsToSendEntity
        {
            public string DestinationNumber { get; set; }
            public string Message { get; set; }
            public Nullable<int> ClientId { get; set; }
            public Nullable<int> ObjectId { get; set; }
            public string ExecutionTime { get; set; }
        }

}
