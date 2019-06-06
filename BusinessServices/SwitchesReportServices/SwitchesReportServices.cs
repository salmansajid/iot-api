using AutoMapper;
using BusinessEntities;
using DataModel;
using DataModel.UnitOfWork;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.SwitchesReportServices
{
    public class SwitchesReportServices : ISwitchesReportServices
    {
         private readonly UnitOfWork _unitOfWork;  
      
         public SwitchesReportServices()  
         {  
             _unitOfWork = new UnitOfWork();  
         }
  
        public IEnumerable<SwitchesReportEntity> GetSwitchesReportByObject(int ObjectId, DateTime StartDate,DateTime EndDate)
        {
            var obj = _unitOfWork.ObjectRepository.GetByID(ObjectId);
            var _Objects = _unitOfWork.SwitchesReportRepository.GetMany(x => x.ObjectID == ObjectId && x.Status == obj.RelayStatus && x.DateTimeStamp >= StartDate && x.DateTimeStamp <= EndDate).OrderBy(x => x.LocationID).OrderBy(x => x.DateTimeStamp);
            if (_Objects != null)
            {
                Mapper.CreateMap<SwitchesReport, SwitchesReportEntity>();
                var SwitchesReportModel = Mapper.Map<List<SwitchesReport>, List<SwitchesReportEntity>>(_Objects.ToList());
                //var _switch = SwitchesReportModel.FirstOrDefault(x => x.Switch == null);
                //_switch.Switch = "ON";
                return SwitchesReportModel;
            }
            return null;
        }

        public IEnumerable<CurrentDateCON_SW_ReportEntity> GetCurrentDateConsumption(int ObjectId, string sensor)
        {
            var Values = _unitOfWork.SPGetCurrentdateConsumptionRepository.ExecWithStoreProcedure(
             "sp_GetCurrentdateConsumption @ObjectId, @sensor",
             new SqlParameter("ObjectId", SqlDbType.Int) { Value = ObjectId },
             new SqlParameter("sensor", SqlDbType.NVarChar) { Value = sensor }
             ).ToList();
            if (Values.Any())
            {
                string ser = JsonConvert.SerializeObject(Values);
                List<CurrentDateCON_SW_ReportEntity> objectdts = JsonConvert.DeserializeObject<List<CurrentDateCON_SW_ReportEntity>>(ser);
                return objectdts;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<CurrentDateCONTROL_SW_ReportEntity> GetCurrentDateControlling(int ObjectId)
        {
            var _Objectstatus = _unitOfWork.ObjectRepository.GetByID(ObjectId);
            var Values = _unitOfWork.SPGetCurrentdateControllingRepository.ExecWithStoreProcedure(
                "sp_GetCurrentdateControlling @ObjectID",
                new SqlParameter("ObjectID", SqlDbType.Int) { Value = ObjectId }
                ).ToList();

            if (Values.Any())
            {

                string relaystatus = "";
                if (_Objectstatus.RelayStatus == false)
                {
                    relaystatus = "0";
                }
                if (_Objectstatus.RelayStatus == true)
                {
                    relaystatus = "1";
                }

                var query = Values.Where(x => x.Status == relaystatus);
                string ser = JsonConvert.SerializeObject(query.ToList());
                List<CurrentDateCONTROL_SW_ReportEntity> DataModel = JsonConvert.DeserializeObject<List<CurrentDateCONTROL_SW_ReportEntity>>(ser);

                return DataModel;
            }
            else
            {
                return null;
            }
        }

    }
}
