using AutoMapper;
using BusinessEntities;
using BusinessServices.SensorObjectGroupServices;
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

namespace BusinessServices.ObjectSensorsServices
{
    public class ObjectSensorServices : IObjectSensorServices
    {
        private readonly UnitOfWork _unitOfWork;

        public ObjectSensorServices()
        {
            _unitOfWork = new UnitOfWork();
        }

        public ObjectSensorsEntity GetObjectSensorsById(int ObjectSensorID)
        {
            var objectsensor = _unitOfWork.ObjectSensorRepository.GetByID(ObjectSensorID);
            if (objectsensor != null)
            {
                Mapper.CreateMap<ObjectSensor, ObjectSensorsEntity>();
                var objectsensorModel = Mapper.Map<ObjectSensor, ObjectSensorsEntity>(objectsensor);
                return objectsensorModel;
            }
            return null;
        }

        public IEnumerable<ObjectSensorsGrid> GetObjectSensorsByObjectId(int ObjectID)
        {
            var objectsensors = _unitOfWork.ObjectSensorRepository.GetAll().ToList();
            var objects = _unitOfWork.ObjectRepository.GetAll().ToList();
            var sensors = _unitOfWork.SensorRepository.GetAll().ToList();
            if (objectsensors != null)
            {
                var objsenInfo = (from objsen in objectsensors
                                  join obj in objects on objsen.ObjectID equals obj.ObjectID
                                  join sensor in sensors on objsen.SensorID equals sensor.SensorID
                                  where objsen.ObjectID == ObjectID
                                  orderby objsen.ObjectSensorId descending
                                  select new
                                  {
                                      ObjectSensorId = objsen.ObjectSensorId,
                                      ObjectID = obj.ObjectID,
                                      ObjectName = obj.Name,
                                      Name = objsen.Name,
                                      Enabled = objsen.Enabled,
                                      EmailAlert = objsen.EmailAlert,
                                      SMSAlert = objsen.SMSAlert,
                                      Max = objsen.Max,
                                      Min = objsen.Min,
                                      SourceID = sensor.SourceID,
                                      SourceName = sensor.SourceName,
                                      Unit = sensor.Unit
                                  }).ToList();

                string ser = JsonConvert.SerializeObject(objsenInfo);
                List<ObjectSensorsGrid> objsensor = JsonConvert.DeserializeObject<List<ObjectSensorsGrid>>(ser);
                return objsensor;
            }
            return null;
        }

        public IEnumerable<SensorIDSourceID> GetObjectSensorsBySensorIdAndObjectId(int ObjectId, int SensorId)
        {
            
            var objectsensors = _unitOfWork.ObjectSensorRepository.GetAll().ToList();
            var Sensors = _unitOfWork.SensorRepository.GetAll().ToList();
            if (objectsensors != null)
            {

                var values = from OS in objectsensors
                             join S in Sensors on OS.SensorID equals S.SensorID
                             where OS.ObjectID == ObjectId && OS.SensorID == SensorId
                             select new
                             {
                                 SensorID = OS.SensorID,
                                 SourceID = S.SourceID,
                             }; 

                string ser = JsonConvert.SerializeObject(values);
                List<SensorIDSourceID> SensorIDSourceIDModel = JsonConvert.DeserializeObject<List<SensorIDSourceID>>(ser);
                    return SensorIDSourceIDModel;
            }
            return null;
        }

        public ObjectSensorsEntity GetObjectSensorsByObjIdAndSenIdForMobile(int ObjectId, int SensorId)
        {

            var objectsensors = _unitOfWork.ObjectSensorRepository.GetByCondition(x => x.ObjectID == ObjectId && x.SensorID == SensorId);
            if (objectsensors != null)
            {
                Mapper.CreateMap<ObjectSensor, ObjectSensorsEntity>();
                var ObjectSensorsModel = Mapper.Map<ObjectSensor, ObjectSensorsEntity>(objectsensors);
                return ObjectSensorsModel;
            }
            return null;
        }

        public ObjNameObjSNameCateNameEntity GetObjectSensorsByObjIdAndSenIdForNotify(int ObjectId, int SensorId)
        {

            var objectsensors = _unitOfWork.ObjectSensorRepository.Get().ToList();
            var categories = _unitOfWork.CategoryRepository.Get().ToList();
            var objects = _unitOfWork.ObjectRepository.Get().ToList();
            if (objectsensors != null)
            {

                var values = from OS in objectsensors
                             join ct in categories on OS.CategoryID equals ct.CategoryID
                             join ob in objects on OS.ObjectID equals ob.ObjectID
                             where OS.ObjectID == ObjectId && OS.SensorID == SensorId
                             select new
                             {
                                 ObjectName = ob.Name,
                                 ObjectSensorName = OS.Name,
                                 CategoryName = ct.Name
                             };

                string ser = JsonConvert.SerializeObject(values);
                if (ser.Contains("["))
                {
                    string serDec = ser.Replace("[", "").Replace("]", "");
                    ObjNameObjSNameCateNameEntity ObjNameObjSNameCateNameModel = JsonConvert.DeserializeObject<ObjNameObjSNameCateNameEntity>(serDec);
                    return ObjNameObjSNameCateNameModel;
                }
                else
                {
                    ObjNameObjSNameCateNameEntity ObjNameObjSNameCateNameModel = JsonConvert.DeserializeObject<ObjNameObjSNameCateNameEntity>(ser);
                    return ObjNameObjSNameCateNameModel;
                }
                
            }
            return null;
        }

        public IEnumerable<OBJSIDName> GetObjectSensorForScheduling(int ObjtId)
        {
            var sp_OBS = _unitOfWork.sp_GetNonAssignedObjSenForSchdRepository.ExecWithStoreProcedure(
               "sp_GetNonAssignedObjSenForSchd @ObjectId",
               new SqlParameter("ObjectId", SqlDbType.Int) { Value = ObjtId }
               ).ToList();

            if (sp_OBS.Any())
            {
                string ser = JsonConvert.SerializeObject(sp_OBS);
                List<OBJSIDName> sp_OBSModel = JsonConvert.DeserializeObject<List<OBJSIDName>>(ser);
                return sp_OBSModel;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<ObjectSensorsEntity> GetObjectSensorNameAndSensorIDs(int ObjectId)
        {
            var routIds = new List<int>{46,47,48,49,50,51,52,53,127,128,129,130,131,132,133,134};

            var objectsensors = _unitOfWork.ObjectSensorRepository.GetAll().ToList();
            if (objectsensors != null)
            {

                var values = from OS in objectsensors
                             where OS.ObjectID == ObjectId && routIds.Contains(OS.SensorID) orderby OS.SensorID ascending
                             select new
                             {
                                 ObjectSensorId = OS.ObjectSensorId,
                                 Name = OS.Name,
                                 SensorId = OS.SensorID
                             };

                string ser = JsonConvert.SerializeObject(values);
                List<ObjectSensorsEntity> objectsensorsModel = JsonConvert.DeserializeObject<List<ObjectSensorsEntity>>(ser);
                return objectsensorsModel;
            }
            return null;
        }

        public IEnumerable<ObjectSensorsGrid> GetAllObjectSensors()
        {
            var _objectsensors = _unitOfWork.ObjectSensorRepository.GetAll().ToList();
            var _objects = _unitOfWork.ObjectRepository.GetAll();
            var _sensors = _unitOfWork.SensorRepository.GetAll();

            if (_objectsensors.Any())
            {
                var objsenInfo = (from objsen in _objectsensors
                                  join obj in _objects on objsen.ObjectID equals obj.ObjectID
                                  join sensor in _sensors on objsen.SensorID equals sensor.SensorID
                                  where objsen.ObjectID == obj.ObjectID && objsen.SensorID == sensor.SensorID
                                  orderby objsen.ObjectSensorId descending
                                  select new
                                  {
                                      ObjectSensorId = objsen.ObjectSensorId,
                                      ObjectID = obj.ObjectID,
                                      ObjectName = obj.Name,
                                      Name = objsen.Name,
                                      Enabled = objsen.Enabled,
                                      EmailAlert = objsen.EmailAlert,
                                      SMSAlert = objsen.SMSAlert,
                                      Max = objsen.Max,
                                      Min = objsen.Min,
                                      SourceID = sensor.SourceID,
                                      SourceName = sensor.SourceName,
                                      Unit = sensor.Unit
                                  }).ToList();

                string ser = JsonConvert.SerializeObject(objsenInfo);
                List<ObjectSensorsGrid> objsensor = JsonConvert.DeserializeObject<List<ObjectSensorsGrid>>(ser);
                return objsensor;
            }

            return null;
        }

        /// Creates a product  
        //private readonly ISensorObjectGroup _SensorObjectGroupServices;
        //_SensorObjectGroupServices = new SensorObjectGroupServices();

        public IEnumerable<SensorObjectGroupEntity> GetAllGetSensorObjectGroup()
        {
            var values = _unitOfWork.SensorObjectGroupRepository.GetAll().ToList();
            if (values.Any())
            {
                Mapper.CreateMap<SensorObjectGroup, SensorObjectGroupEntity>();
                var categoryModel = Mapper.Map<List<SensorObjectGroup>, List<SensorObjectGroupEntity>>(values.ToList());
                return categoryModel;
            }
            return null;
        }

        public long CreateObjectSensors(ObjectSensorsEntity objectsensorsEntity)
        {
            long retn = 0;
            var SensorObjectGroups = _unitOfWork.SensorObjectGroupRepository.GetAll();
            string result = JsonConvert.SerializeObject(SensorObjectGroups);
            List<SensorObjectGroupEntity> _SensorobjectGroups = JsonConvert.DeserializeObject<List<SensorObjectGroupEntity>>(result);
            for (int i = 0; i < _SensorobjectGroups.Count; i++)
            {
                if (objectsensorsEntity.SensorID == _SensorobjectGroups[i].ROUTCurrent || objectsensorsEntity.SensorID == _SensorobjectGroups[i].ROUTVoltage || objectsensorsEntity.SensorID == _SensorobjectGroups[i].ROUTStatus || objectsensorsEntity.SensorID == _SensorobjectGroups[i].ROUTFault)
                {
                    var objectsensors = new ObjectSensor
                    {
                        Name = objectsensorsEntity.Name,
                        Enabled = objectsensorsEntity.Enabled,
                        ObjectID = objectsensorsEntity.ObjectID,
                        SMSAlert = objectsensorsEntity.SMSAlert,
                        EmailAlert = objectsensorsEntity.EmailAlert,
                        Max = objectsensorsEntity.Max,
                        Min = objectsensorsEntity.Min,
                        CategoryID = objectsensorsEntity.CategoryID,
                        Contact = objectsensorsEntity.Contact,
                    };
                    int sensorID1 = Convert.ToInt32(_SensorobjectGroups[i].ROUTCurrent);
                    int sensorID2 = Convert.ToInt32(_SensorobjectGroups[i].ROUTVoltage);
                    int sensorID3 = Convert.ToInt32(_SensorobjectGroups[i].ROUTStatus);
                    int sensorID4 = Convert.ToInt32(_SensorobjectGroups[i].ROUTFault);
                    List<int> sensors = new List<int>();
                    sensors.Add(sensorID1);
                    sensors.Add(sensorID2);
                    sensors.Add(sensorID3);
                    sensors.Add(sensorID4);
                    for (int k = 0; k < sensors.Count; ++k)
                    {
                        using (var scope = new TransactionScope())
                        {
                            int SensorID = sensors[k];
                            objectsensors.SensorID = SensorID;
                            _unitOfWork.ObjectSensorRepository.Insert(objectsensors);
                            _unitOfWork.Save();
                            scope.Complete();
                            retn = objectsensors.ObjectSensorId;
                        }
                    }
                }
            }
            if (retn == 0)
            {
                using (var scope = new TransactionScope())
                {
                    var objectsensors = new ObjectSensor
                    {
                        Name = objectsensorsEntity.Name,
                        Enabled = objectsensorsEntity.Enabled,
                        SensorID = objectsensorsEntity.SensorID,
                        ObjectID = objectsensorsEntity.ObjectID,
                        SMSAlert = objectsensorsEntity.SMSAlert,
                        EmailAlert = objectsensorsEntity.EmailAlert,
                        Max = objectsensorsEntity.Max,
                        Min = objectsensorsEntity.Min,
                        CategoryID = objectsensorsEntity.CategoryID,
                        Contact = objectsensorsEntity.Contact,
                     
                    };
                    _unitOfWork.ObjectSensorRepository.Insert(objectsensors);
                    _unitOfWork.Save();
                    scope.Complete();
                    retn = objectsensors.ObjectSensorId;
                }
                return retn;
            }
            else
            {
                return retn;
            }
        }

        /// Updates a product  
        public bool UpdateObjectSensors(long objectSensorId, ObjectSensorsEntity objectsensorsEntity)
        {
            var success = false;
            if (objectsensorsEntity != null)
            {

                    var SensorObjectGroups = _unitOfWork.SensorObjectGroupRepository.GetAll();
                    string result = JsonConvert.SerializeObject(SensorObjectGroups);
                    List<SensorObjectGroupEntity> _SensorobjectGroups = JsonConvert.DeserializeObject<List<SensorObjectGroupEntity>>(result);
                    for (int i = 0; i < _SensorobjectGroups.Count; i++)
                    {
                        if (objectsensorsEntity.SensorID == _SensorobjectGroups[i].ROUTCurrent || objectsensorsEntity.SensorID == _SensorobjectGroups[i].ROUTVoltage || objectsensorsEntity.SensorID == _SensorobjectGroups[i].ROUTStatus || objectsensorsEntity.SensorID == _SensorobjectGroups[i].ROUTFault)
                        {
                            int sensorID1 = Convert.ToInt32(_SensorobjectGroups[i].ROUTCurrent);
                            int sensorID2 = Convert.ToInt32(_SensorobjectGroups[i].ROUTVoltage);
                            int sensorID3 = Convert.ToInt32(_SensorobjectGroups[i].ROUTStatus);
                            int sensorID4 = Convert.ToInt32(_SensorobjectGroups[i].ROUTFault);


                            //long objsID1 = Convert.ToInt64(objectsensor1.ObjectSensorId);
                            //long objsID2 = Convert.ToInt64(objectsensor2.ObjectSensorId);
                            //long objsID3 = Convert.ToInt64(objectsensor3.ObjectSensorId);
                            //long objsID4 = Convert.ToInt64(objectsensor4.ObjectSensorId);

                            List<int> sensors = new List<int>();
                            List<object> objsensors = new List<object>();

                            //List<ObjectSensorsEntity> objss = 

                            sensors.Add(sensorID1); 
                            
                            sensors.Add(sensorID2); 
                            //objsensors.Add(objectsensor1);
                            //objsensors.Add(objectsensor2);
                            //objsensors.Add(objectsensor3);
                            //objsensors.Add(objectsensor4);
                            sensors.Add(sensorID3); 
                            sensors.Add(sensorID4); 


                            for (int k = 0; k < sensors.Count; k++)
                            {
                                using (var scope = new TransactionScope())
                                {
                                    int SensorID = sensors[k];
                                    var objectsensor = _unitOfWork.ObjectSensorRepository.GetByCondition(lg => lg.ObjectID == objectsensorsEntity.ObjectID && lg.SensorID == SensorID);
                                    //var objectsensor[k] = _unitOfWork.ObjectSensorRepository.GetByCondition(lg => lg.ObjectID == objectsensorsEntity.ObjectID && lg.SensorID == sensorID2);
                                    //var objectsensor[k] = _unitOfWork.ObjectSensorRepository.GetByCondition(lg => lg.ObjectID == objectsensorsEntity.ObjectID && lg.SensorID == sensorID3);
                                    //var objectsensor[k] = _unitOfWork.ObjectSensorRepository.GetByCondition(lg => lg.ObjectID == objectsensorsEntity.ObjectID && lg.SensorID == sensorID4);
                                    //long objsensorsID = objsensors[k];
                                    objectsensor.SensorID = SensorID;
                                    objectsensor.Name = objectsensorsEntity.Name;
                                    objectsensor.Enabled = objectsensorsEntity.Enabled;
                                    objectsensor.ObjectID = objectsensorsEntity.ObjectID;
                                    objectsensor.SMSAlert = objectsensorsEntity.SMSAlert;
                                    objectsensor.EmailAlert = objectsensorsEntity.EmailAlert;
                                    objectsensor.Max = objectsensorsEntity.Max;
                                    objectsensor.Min = objectsensorsEntity.Min;
                                    objectsensor.CategoryID = objectsensorsEntity.CategoryID;
                                    objectsensor.Contact = objectsensorsEntity.Contact;
                                    _unitOfWork.ObjectSensorRepository.Update(objectsensor);
                                    _unitOfWork.Save();
                                    scope.Complete();
                                    success = true;
                                }
                            }
                        }
                    }
                    if (success == false)
                    {
                        var _objectsensor = _unitOfWork.ObjectSensorRepository.GetByID(objectSensorId);
                        if (_objectsensor != null)
                        {
                        using (var scope = new TransactionScope())
                        {

                            _objectsensor.Name = objectsensorsEntity.Name;
                            _objectsensor.Enabled = objectsensorsEntity.Enabled;
                            _objectsensor.SensorID = objectsensorsEntity.SensorID;
                            _objectsensor.ObjectID = objectsensorsEntity.ObjectID;
                            _objectsensor.SMSAlert = objectsensorsEntity.SMSAlert;
                            _objectsensor.EmailAlert = objectsensorsEntity.EmailAlert;
                            _objectsensor.Max = objectsensorsEntity.Max;
                            _objectsensor.Min = objectsensorsEntity.Min;
                            _objectsensor.CategoryID = objectsensorsEntity.CategoryID;
                            _objectsensor.Contact = objectsensorsEntity.Contact;
                            _unitOfWork.ObjectSensorRepository.Update(_objectsensor);
                            _unitOfWork.Save();
                            scope.Complete();
                            success = true;
                        }
                        return success;
                    }
                }
            }
            return success;

        }

        /// Deletes a particular product  
        public bool DeleteObjectSensors(int objectsensorId)
        {
            var success = false;
            if (objectsensorId > 0)
            {
                var objectsensor = _unitOfWork.ObjectSensorRepository.GetByID(objectsensorId);
                if (objectsensor != null)
                {
                    var SensorObjectGroups = _unitOfWork.SensorObjectGroupRepository.GetAll();
                    string result = JsonConvert.SerializeObject(SensorObjectGroups);
                    List<SensorObjectGroupEntity> _SensorobjectGroups = JsonConvert.DeserializeObject<List<SensorObjectGroupEntity>>(result);
                    for (int i = 0; i < _SensorobjectGroups.Count; i++)
                    {
                        if (objectsensor.SensorID == _SensorobjectGroups[i].ROUTCurrent || objectsensor.SensorID == _SensorobjectGroups[i].ROUTVoltage || objectsensor.SensorID == _SensorobjectGroups[i].ROUTStatus || objectsensor.SensorID == _SensorobjectGroups[i].ROUTFault)
                        {
                            int sensorID1 = Convert.ToInt32(_SensorobjectGroups[i].ROUTCurrent);
                            int sensorID2 = Convert.ToInt32(_SensorobjectGroups[i].ROUTVoltage);
                            int sensorID3 = Convert.ToInt32(_SensorobjectGroups[i].ROUTStatus);
                            int sensorID4 = Convert.ToInt32(_SensorobjectGroups[i].ROUTFault);
                            List<int> sensors = new List<int>();
                            var objectsensor1 = _unitOfWork.ObjectSensorRepository.GetByCondition(lg => lg.ObjectID == objectsensor.ObjectID && lg.SensorID == sensorID1);
                            var objectsensor2 = _unitOfWork.ObjectSensorRepository.GetByCondition(lg => lg.ObjectID == objectsensor.ObjectID && lg.SensorID == sensorID2);
                            var objectsensor3 = _unitOfWork.ObjectSensorRepository.GetByCondition(lg => lg.ObjectID == objectsensor.ObjectID && lg.SensorID == sensorID3);
                            var objectsensor4 = _unitOfWork.ObjectSensorRepository.GetByCondition(lg => lg.ObjectID == objectsensor.ObjectID && lg.SensorID == sensorID4);
                            int objsID1 = Convert.ToInt32(objectsensor1.ObjectSensorId);
                            int objsID2 = Convert.ToInt32(objectsensor2.ObjectSensorId);
                            int objsID3 = Convert.ToInt32(objectsensor3.ObjectSensorId);
                            int objsID4 = Convert.ToInt32(objectsensor4.ObjectSensorId);
                            sensors.Add(objsID1);
                            sensors.Add(objsID2);
                            sensors.Add(objsID3);
                            sensors.Add(objsID4);
                            for (int k = 0; k < sensors.Count; ++k)
                            {
                                using (var scope = new TransactionScope())
                                {
                                    _unitOfWork.ObjectSensorRepository.Delete(sensors[k]);
                                    _unitOfWork.Save();
                                    scope.Complete();
                                    success = true;
                                }
                            }
                        }
                    }
                    if (success == false)
                    {
                        using (var scope = new TransactionScope())
                        {

                            _unitOfWork.ObjectSensorRepository.Delete(objectsensor);
                            _unitOfWork.Save();
                            scope.Complete();
                            success = true;
                        }
                    }
                    return success;
                }
                return success;
            }
            return success;
        }
    }
}
//        objectsensor.Name = objectsensorsEntity.Name;
//        objectsensor.SensorID = objectsensorsEntity.SensorID;
//        objectsensor.ObjectID = objectsensorsEntity.ObjectID;
//        objectsensor.SMSAlert = objectsensorsEntity.SMSAlert;
//        objectsensor.Enabled = objectsensorsEntity.Enabled;
//        objectsensor.EmailAlert = objectsensorsEntity.EmailAlert;
//        objectsensor.Max = objectsensorsEntity.Max;
//        objectsensor.Min = objectsensorsEntity.Min;
//        objectsensor.CategoryID = objectsensorsEntity.CategoryID;
//           _unitOfWork.ObjectSensorRepository.Update(objectsensor);
//           _unitOfWork.Save();
//        scope.Complete();
//        success = true;
//    }
//}