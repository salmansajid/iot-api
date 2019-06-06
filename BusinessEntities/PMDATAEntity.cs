using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
    public class PMDATAEntity
    {

        public long PMDATAID { get; set; }
        public Nullable<long> PMID { get; set; }
        public Nullable<long> ObjectSensorId { get; set; }
        public string VALUE { get; set; }
    }
}
