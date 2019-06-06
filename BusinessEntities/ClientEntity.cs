using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
    public class ClientEntity
    {
        public int ClientID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int OperatorID { get; set; }
        public string Contact { get; set; }
        public string Code { get; set; }
        public bool Enabled { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> ExpireDate { get; set; }
        public bool Deleted { get; set; }
    


    }
}
