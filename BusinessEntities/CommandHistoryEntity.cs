using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
    public class CommandHistoryEntity
    {
        public long CommandHistoryID { get; set; }
        public int ObjectId { get; set; }
        public int Source { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public System.DateTime DateTimeStamp { get; set; }
        public int CommandsQueueID { get; set; }
        public int CommandID { get; set; }
        public string Response { get; set; }
        public Nullable<int> StateSMS { get; set; }
        public Nullable<int> AlertState { get; set; }
    }
    public class sp_GetNONAlertStateEntity
    {
        public long CommandHistoryID { get; set; }
        public int ObjectId { get; set; }
        public string Name { get; set; }
        public System.DateTime DateTimeStamp { get; set; }
        public string EmailNo_1 { get; set; }
        public int CommandsQueueID { get; set; }
        public int CommandID { get; set; }
        public string Response { get; set; }
        public Nullable<int> AlertState { get; set; }
        public string DeviceName { get; set; }
    }
}
