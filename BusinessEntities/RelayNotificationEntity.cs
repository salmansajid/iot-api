﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
    public class RelayNotificationEntity
    {
        public int RelaynotificationID { get; set; }
        public string Message { get; set; }
        public Nullable<System.DateTime> DateTime { get; set; }
        public Nullable<int> ClientID { get; set; }
        public Nullable<int> GroupID { get; set; }
        public Nullable<int> ObjectID { get; set; }
        public string CategoryName { get; set; }
        public Nullable<bool> State { get; set; }
    }
}
