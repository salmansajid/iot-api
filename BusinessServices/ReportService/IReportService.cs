using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.ReportService
{
    public interface IReportService
    {
        IEnumerable<uspGet_EquipmentConsumptionByDTModel> GetConsumptionByDT(int ObjectID, DateTime StartTime, DateTime EndTime);
    }
}
