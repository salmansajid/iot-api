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
using System.Transactions;

namespace BusinessServices.EventConfigurationServices
{
    public class EventConfigurationServices : IEventConfigurationServices
    {
        private readonly UnitOfWork _unitOfWork;   
         
        public EventConfigurationServices()  
         {  
             _unitOfWork = new UnitOfWork();  
         }

        public EventConfigurationEntity GetEventConfigurationById(int EventConfigID)
        {
            var EventConfig = _unitOfWork.EventConfigurationRepository.GetByID(EventConfigID);
            if (EventConfig != null)
            {
                Mapper.CreateMap<EventConfiguration, EventConfigurationEntity>();
                var EventConfigModel = Mapper.Map<EventConfiguration, EventConfigurationEntity>(EventConfig);
                return EventConfigModel;
            }
            return null;
        }

        public IEnumerable<EventConfigurationGridEntity> GetEventConfigurationByObjectId(int ObjectId)
        {
            var EventConfig = _unitOfWork.EventConfigurationRepository.GetAll().ToList();
            var ObjectSensors = _unitOfWork.ObjectSensorRepository.GetAll().ToList();
            var Sensors = _unitOfWork.SensorRepository.GetAll().ToList();
            if (EventConfig != null)
            {
                
                    var Result = (from EC in EventConfig
                                     join OS in ObjectSensors on EC.ObjectSensorID equals OS.ObjectSensorId
                                     join Sen in Sensors on OS.SensorID equals Sen.SensorID
                                     where EC.ObjectID == ObjectId
                                     select new
                                   {
                                       EventConfigID = EC.EventConfigID,
                                       ObjectSensorID = EC.ObjectSensorID,
                                       ObjectID = EC.ObjectID,                                       
                                       SensorID = Sen.SensorID,
                                       MIN = EC.Min,
                                       MAX = EC.MAX,
                                       Contact = EC.Contact,
                                       Condition = EC.Condition,
                                       Name = OS.Name,
                                       SensorName = Sen.SourceID,
                                       EnableOrDisable = Sen.EnableOrDisable,

                                   }).ToList();
                    string ser = JsonConvert.SerializeObject(Result);
                    List<EventConfigurationGridEntity> objects = JsonConvert.DeserializeObject<List<EventConfigurationGridEntity>>(ser);
                    return objects;
            }
            return null;
        }
   
        public IEnumerable<EventConfigurationEntity> GetEventConfiguration()
        {
            var EventConfig = _unitOfWork.EventConfigurationRepository.GetAll().ToList();
            if (EventConfig.Any())
            {
                Mapper.CreateMap<EventConfiguration, EventConfigurationEntity>();
                var EventConfigInfo = from EC in EventConfig
                                        orderby EC.EventConfigID descending
                                        select EC;
                var EventConfigModel = Mapper.Map<List<EventConfiguration>, List<EventConfigurationEntity>>(EventConfigInfo.ToList());
                return EventConfigModel;
            }
            return null;
        }

        public IEnumerable<EventConfigurationLocationEntity> GetEventConfigurationLocationByObjID(int ObjectID)
        {
            var _events = _unitOfWork.SPEventConfig_LocationByObjIDRepository.ExecWithStoreProcedure(
                 "sp_EventConfig_LocationByObjID @ObjectID",
                 new SqlParameter("ObjectID", SqlDbType.Int) { Value = ObjectID }).ToList();
            if (_events.Any())
            {
                Mapper.CreateMap<sp_EventConfig_LocationByObjID_Result, EventConfigurationLocationEntity>();
                var _eventsModel = Mapper.Map<List<sp_EventConfig_LocationByObjID_Result>, List<EventConfigurationLocationEntity>>(_events.ToList());
                return _eventsModel;
            }
            else
            {
                return null;
            }
        }
   
        public int  CreateEventConfiguration(EventConfigurationEntity eventConfigurationEntity)
        {
            using (var scope = new TransactionScope())
            {
                var _EventConfig = new EventConfiguration
                {
                    ObjectSensorID = eventConfigurationEntity.ObjectSensorID,
                    ObjectID = eventConfigurationEntity.ObjectID,
                    Min = eventConfigurationEntity.Min,
                    MAX = eventConfigurationEntity.MAX,
                    Condition = eventConfigurationEntity.Condition,
                    A0 = eventConfigurationEntity.A0,
                    A1 = eventConfigurationEntity.A1,
                    Contact = eventConfigurationEntity.Contact,
                    Units = eventConfigurationEntity.Units,
                    Format = eventConfigurationEntity.Format,
                    EnableOrDisable = eventConfigurationEntity.EnableOrDisable

                };

                _unitOfWork.EventConfigurationRepository.Insert(_EventConfig);
                _unitOfWork.Save();
                scope.Complete();
                return _EventConfig.EventConfigID;
            }
        }
  
        public bool UpdateEventConfiguration(int EventConfigID, EventConfigurationEntity eventConfigurationEntity)
        {
            var success = false;
            if (eventConfigurationEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var _EventConfig = _unitOfWork.EventConfigurationRepository.GetByID(EventConfigID);
                    if (_EventConfig != null)
                    {
                    _EventConfig.ObjectSensorID = eventConfigurationEntity.ObjectSensorID;
                    _EventConfig.ObjectID = eventConfigurationEntity.ObjectID;
                    _EventConfig.Min = eventConfigurationEntity.Min;
                    _EventConfig.MAX = eventConfigurationEntity.MAX;
                    _EventConfig.Condition = eventConfigurationEntity.Condition;
                    _EventConfig.Contact = eventConfigurationEntity.Contact;
                    _EventConfig.EnableOrDisable = eventConfigurationEntity.EnableOrDisable;
                    _unitOfWork.EventConfigurationRepository.Update(_EventConfig);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }
   
        public bool DeleteEventConfiguration(int EventConfigID)
        {
            var success = false;
            if (EventConfigID > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var EventConfig = _unitOfWork.EventConfigurationRepository.GetByID(EventConfigID);
                    if (EventConfig != null)
                    {
                        _unitOfWork.EventConfigurationRepository.Delete(EventConfig);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }


    }
}
