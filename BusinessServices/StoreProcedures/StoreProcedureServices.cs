using BusinessEntities;
using DataModel.UnitOfWork;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BusinessServices.StoreProcedures
{
    public class StoreProcedureServices : IStoreProcedureServices
    {
        private readonly UnitOfWork _unitOfWork;

        public StoreProcedureServices()
        {
            _unitOfWork = new UnitOfWork();
        }

        public IEnumerable<sp_GetConsumptionTillPackTime> GetRouteValuesbyPKT(int ObjectID, int CurrentID, int VoltageID)
        {
            var RouteValuebyPKT = _unitOfWork.SPGetConsumptionTillPackTime.ExecWithStoreProcedure("sp_GetConsumptionTillPackTime @ObjectID, @Current, @Voltage",
                new SqlParameter("ObjectID", SqlDbType.Int) { Value = ObjectID },
                new SqlParameter("Current", SqlDbType.Int) { Value = CurrentID },
                    new SqlParameter("Voltage", SqlDbType.Int) { Value = VoltageID }
                ).ToList();

            if (RouteValuebyPKT.Any())
            {
                string ser = JsonConvert.SerializeObject(RouteValuebyPKT);
                List<sp_GetConsumptionTillPackTime> data = JsonConvert.DeserializeObject<List<sp_GetConsumptionTillPackTime>>(ser);
                return data;
            }
            else
            {
                return null;
            }
        }


        public IEnumerable<sp_SMSLOGEntity> GetSMSLogbyObj_SEN(int ObjectID, int ObjectSensorID, DateTime StartTime, DateTime EndTime)
        {
            var result = _unitOfWork.SP_smslog_obj_sensorRepository.ExecWithStoreProcedure("sp_smslog_obj_sensor @ObjectID, @ObjectSensor, @ToDate, @FromDate",
                new SqlParameter("ObjectID", SqlDbType.Int) { Value = ObjectID },
                new SqlParameter("ObjectSensor", SqlDbType.Int) { Value = ObjectSensorID },
                new SqlParameter("ToDate", SqlDbType.Date) { Value = StartTime.ToString("yyyy-MM-dd HH:mm:ss.fff") },
                new SqlParameter("FromDate", SqlDbType.Date) { Value = EndTime.ToString("yyyy-MM-dd HH:mm:ss.fff") }).ToList();

            if (result.Any())
            {
                string ser = JsonConvert.SerializeObject(result);
                List<sp_SMSLOGEntity> data = JsonConvert.DeserializeObject<List<sp_SMSLOGEntity>>(ser);
                return data;
            }
            else
            {
                return null;
            }
        }

    }
}
