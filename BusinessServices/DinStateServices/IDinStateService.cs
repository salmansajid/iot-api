using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.DinStateServices
{
    public interface IDinStateService
    {
        IEnumerable<uspReport_DinState1Entity> GetDinState1Today(int ObjectId, DateTime Startdate, DateTime Enddate);
    }
}
