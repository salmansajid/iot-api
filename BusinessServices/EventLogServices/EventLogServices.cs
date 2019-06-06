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

namespace BusinessServices.EventLogServices
{
    public class EventLogServices :IEventLogServices
    {
        
        private readonly UnitOfWork _unitOfWork;
        
        public EventLogServices()  
         {  
             _unitOfWork = new UnitOfWork();  
         }
        
        /// Fetches product details by id  

        public EventLogEntity GetEventByObjectId(int ObjectId)
        {
            var _events = _unitOfWork.SPEventLogRepository.ExecWithStoreProcedure(
                 "sp_GetFeulLastStatus_Read @objectId",
                 new SqlParameter("objectId", SqlDbType.Int) { Value = ObjectId });
            if (_events != null)
            {
                string ser = JsonConvert.SerializeObject(_events);
                if (ser.Contains("["))
                {
                    string result = ser.Replace("[", "").Replace("]", "");
                    EventLogEntity _eventsLog = JsonConvert.DeserializeObject<EventLogEntity>(result);
                    return _eventsLog;
                }
               
            }
            return null;
        }


        public IEnumerable<Object_EventLogEntity> GetEventByObjectAndDT(int ObjectId, DateTime StartTime, DateTime EndTime)
        {
            var _events = _unitOfWork.SPEventLogbyObjectDTRepository.ExecWithStoreProcedure(
                 "sp_EventLogbyObjectDT @ObjectID, @StartTime, @EndTime",
                 new SqlParameter("ObjectID", SqlDbType.Int) { Value = ObjectId },
                new SqlParameter("StartTime", SqlDbType.DateTime) { Value = StartTime },
                new SqlParameter("EndTime", SqlDbType.DateTime) { Value = EndTime }).ToList();
                if (_events.Any())
                {
                    Mapper.CreateMap<sp_EventLogbyObjectDT_Result, Object_EventLogEntity>();
                    var _eventsModel = Mapper.Map<List<sp_EventLogbyObjectDT_Result>, List<Object_EventLogEntity>>(_events.ToList());
                    //string ser = JsonConvert.SerializeObject(_events);
                    //List<Object_EventLogEntity> _eventsModel = JsonConvert.DeserializeObject<List<Object_EventLogEntity>>(ser);
                    return _eventsModel;
                }
                else
                {
                    return null;
                }
        }
    }
}
