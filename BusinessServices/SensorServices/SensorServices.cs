using AutoMapper;
using BusinessEntities;
using DataModel;
using DataModel.UnitOfWork;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace BusinessServices.SensorServices
{
    public class SensorServices :ISensorServices
    {
        private readonly UnitOfWork _unitOfWork;   

         /// <summary>  
         /// Public constructor.  
         /// </summary>  
        public SensorServices()  
         {  
             _unitOfWork = new UnitOfWork();  
         }

        /// <summary>  
        /// Fetches product details by id  
        /// </summary>  
        /// <param name="productId"></param>  
        /// <returns></returns>  
        public SensorEntity GetSensorById(int SensorId)
        {
            var _sensor = _unitOfWork.SensorRepository.GetByID(SensorId);
            if (_sensor != null)
            {
                Mapper.CreateMap<Sensor, SensorEntity>();
                var sensorModel = Mapper.Map<Sensor, SensorEntity>(_sensor);
                return sensorModel;
            }
            return null;
        }

        /// <summary>  
        /// Fetches all the products.  
        /// </summary>  
        /// <returns></returns>  
        public IEnumerable<SensorEntity> GetAllSensors()
        {
            var _sensors = _unitOfWork.SensorRepository.GetAll().ToList();
            if (_sensors.Any())
            {
                Mapper.CreateMap<Sensor, SensorEntity>();
                var _sensorsinfo = from sen in _sensors
                                   orderby sen.SensorID descending
                                   select sen;
                var sensorModel = Mapper.Map<List<Sensor>, List<SensorEntity>>(_sensorsinfo.ToList());
                return sensorModel;
            }
            return null;
        }

        public IEnumerable<SensorEntity> GetNonAssignedSensors(int _ObjectID)
        {
            var _sensors = _unitOfWork.SensorRepository.GetAll().ToList();
            var _objsensors = _unitOfWork.ObjectSensorRepository.GetAll().ToList();
            if (_sensors.Any())
            {
                //Mapper.CreateMap<Sensor, SensorEntity>();

                var _sensorsinfo = (from item in _sensors
                                   where !(from obj in _objsensors where obj.ObjectID == _ObjectID select obj.SensorID).Contains(item.SensorID)
                                   select new
                                     {
                                         SensorID = item.SensorID,
                                         SourceID = item.SourceID,
                                         SourceName  = item.SourceName,
                                         Unit = item.Unit,
                                         EnableOrDisable = item.EnableOrDisable,
                                     }).ToList();
                //var _sensorsinfo = from sen in _sensors
                //                   orderby sen.SensorID descending    
                //                   select sen;

                string ser = JsonConvert.SerializeObject(_sensorsinfo);
                List<SensorEntity> sensorModel = JsonConvert.DeserializeObject<List<SensorEntity>>(ser);
                //var sensorModel = Mapper.Map<List<Sensor>, List<SensorEntity>>(_sensorsinfo.ToList());
                return sensorModel;
            }
            return null;
        }

        //public IEnumerable<SensorEntity> GetNonAssignedSensorsForEventConfig(int ObjectID)
        //{
        //    var _sensors = _unitOfWork.SensorRepository.GetAll().ToList();
        //    var _EC = _unitOfWork.EventConfigurationRepository.GetAll().ToList();
        //    if (_sensors.Any())
        //    {
        //        //Mapper.CreateMap<Sensor, SensorEntity>();

        //        var _sensorsinfo = (from item in _sensors
        //                            where !(from EC in _EC where EC.ObjectID == ObjectID select EC.SensorID).Contains(item.SensorID)
        //                            select new
        //                            {
        //                                SensorID = item.SensorID,
        //                                SourceID = item.SourceID,
        //                                SourceName = item.SourceName,
        //                                Unit = item.Unit,
        //                                EnableOrDisable = item.EnableOrDisable,
        //                            }).ToList();                
        //        string ser = JsonConvert.SerializeObject(_sensorsinfo);
        //        List<SensorEntity> sensorModel = JsonConvert.DeserializeObject<List<SensorEntity>>(ser);
        //        //var sensorModel = Mapper.Map<List<Sensor>, List<SensorEntity>>(_sensorsinfo.ToList());
        //        return sensorModel;
        //    }
        //    return null;
        //}

        public IEnumerable<SensorEntity> GetSensorBySensorId(int SensorID)
        {
            var _sensors = _unitOfWork.SensorRepository.GetAll().ToList();
            var _objectsensors = _unitOfWork.ObjectSensorRepository.GetAll().ToList();
            if (_sensors.Any())
            {
                Mapper.CreateMap<Sensor, SensorEntity>();
                var objsensors = from sensors in _sensors
                                join objsensor in _objectsensors on sensors.SensorID equals objsensor.SensorID
                                where sensors.SensorID == SensorID
                                select sensors;
                var sensorModel = Mapper.Map<List<Sensor>, List<SensorEntity>>(objsensors.ToList());
                return sensorModel;
            }
            return null;
        }

        //public IEnumerable<ObjectEntity> GetObjectByGroupAndLoginId(int GroupID, int LoginID)
        //{
        //    var _object = _unitOfWork.ObjectRepository.GetAll().ToList();
        //    var _objectgroups = _unitOfWork.ObjectGroupRepository.GetAll().ToList();
        //    var _logingroups = _unitOfWork.LoginGroupRepository.GetAll().ToList();
        //    if (_object.Any())
        //    {
        //        Mapper.CreateMap<OBJECT, ObjectEntity>();
        //        var objgpInfo = from obj in _object
        //                        join objgp in _objectgroups on obj.ObjectID equals objgp.ObjectID
        //                        join lggp in _logingroups on objgp.GroupID equals lggp.GroupID
        //                        where objgp.GroupID == GroupID && lggp.LoginID == LoginID
        //                        select obj;
        //        var objectModel = Mapper.Map<List<OBJECT>, List<ObjectEntity>>(objgpInfo.ToList());
        //        return objectModel;
        //    }
        //    return null;
        //}

        /// <summary>  
        /// Creates a product  
        /// </summary>  
        /// <param name="productEntity"></param>  
        /// <returns></returns>  
        public int CreateSensor(SensorEntity sensorEntity)
        {
            using (var scope = new TransactionScope())
            {
                var _sensor = new Sensor
                {
                    
                    SourceID = sensorEntity.SourceID,
                    SourceName = sensorEntity.SourceName,
                    Unit = sensorEntity.Unit,
                    EnableOrDisable = sensorEntity.EnableOrDisable

                };

                _unitOfWork.SensorRepository.Insert(_sensor);
                _unitOfWork.Save();
                scope.Complete();
                return _sensor.SensorID;
            }
        }

        /// <summary>  
        /// Updates a product  
        /// </summary>  
        /// <param name="productId"></param>  
        /// <param name="productEntity"></param>  
        /// <returns></returns>  
        public bool UpdateSensor(int SensorId, SensorEntity sensorEntity)
        {
            var success = false;
            if (sensorEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var Sensor = _unitOfWork.SensorRepository.GetByID(SensorId);
                    if (Sensor != null)
                    {
                        Sensor.SourceID = sensorEntity.SourceID;
                        Sensor.SourceName = sensorEntity.SourceName;
                        Sensor.Unit = sensorEntity.Unit;
                        Sensor.EnableOrDisable = sensorEntity.EnableOrDisable;
                        _unitOfWork.SensorRepository.Update(Sensor);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        /// <summary>  
        /// Deletes a particular product  
        /// </summary>  
        /// <param name="productId"></param>  
        /// <returns></returns>  
        public bool DeleteSensor(int sensorId)
        {
            var success = false;
            if (sensorId > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var sensor = _unitOfWork.SensorRepository.GetByID(sensorId);
                    if (sensor != null)
                    {
                        _unitOfWork.SensorRepository.Delete(sensor);
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