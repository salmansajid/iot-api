using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessServices.StoreProcedures
{
    public interface IStoreProcedureServices
    {
         IEnumerable<sp_GetConsumptionTillPackTime> GetRouteValuesbyPKT(int ObjectID, int CurrentID, int VoltageID);
         IEnumerable<sp_SMSLOGEntity> GetSMSLogbyObj_SEN(int ObjectID, int ObjectSensorID, DateTime StartTime, DateTime EndTime);
    }
}
