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

namespace BusinessServices.SchedulingServices
{
    public class SchedulingServices :ISchedulingServices
    {
        
        private readonly UnitOfWork _unitOfWork;   
         /// <summary>  
         /// Public constructor.  
         /// </summary>  
        public SchedulingServices()  
         {  
             _unitOfWork = new UnitOfWork();  
         }


        public SchedulingEntity GetScheduleById(int ScheduleId)
        {
            var Schedule = _unitOfWork.SchedulingRepository.GetByID(ScheduleId);
            if (Schedule != null)
            {
                Mapper.CreateMap<Scheduling, SchedulingEntity>();
                var SchedulingModel = Mapper.Map<Scheduling, SchedulingEntity>(Schedule);
                return SchedulingModel;
            }
            return null;
        }

        public IEnumerable<SchedulingEntity> GetScheduleByObjectId(int ObjectId , int DayID)
        {

            var Schedule = _unitOfWork.SchedulingRepository.GetMany(SC => SC.ObjectId == ObjectId && SC.Days == DayID);
            if (Schedule != null)
            {
                Mapper.CreateMap<Scheduling, SchedulingEntity>();
                //var ScheduleByObject = from SC in Schedule
                //                       where SC.ObjectId == ObjectId
                //                       select SC;
                var SchedulingModel = Mapper.Map<List<Scheduling>, List<SchedulingEntity>>(Schedule.ToList());
                return SchedulingModel;
            }
            return null;
        }

        public IEnumerable<SensorSchedulingEntity> GetScheduleByObjectIdAndALLDay(int ObjectId, int DayID, int sensorID)
        {
            var Schedule = _unitOfWork.SchedulingRepository.GetAll().ToList();
            var SensorCommands = _unitOfWork.SensorCommandRepository.GetAll().ToList();
            if (Schedule != null)
            {

                var ScheduleByObject = (from SC in Schedule
                                        join SCM in SensorCommands on SC.CommandID equals SCM.CommandID
                                        where SC.ObjectId == ObjectId && SC.Days == DayID && SCM.SensorID == sensorID
                                        select new
                                        {
                                            ObjectID = SC.ObjectId,
                                            CommandID = SC.CommandID,
                                            ScheduleTime = SC.ScheduleTime,
                                            EnableOrDisable = SC.EnableOrDisable,
                                            Days = SC.Days,
                                            SensorID = SCM.SensorID
                                        }).ToList();

                string ser = JsonConvert.SerializeObject(ScheduleByObject);
                List<SensorSchedulingEntity> SchedulingModel = JsonConvert.DeserializeObject<List<SensorSchedulingEntity>>(ser);
                return SchedulingModel;
            }
            return null;
        }
        
        public IEnumerable<SensorSchedulingEntity> GetScheduleByObjectIdAndDayID(int ObjectId, int DayID)
        {


            var Schedule = _unitOfWork.SchedulingRepository.GetAll().ToList();
            var SensorCommands = _unitOfWork.SensorCommandRepository.GetAll().ToList();
            var ObSen = _unitOfWork.ObjectSensorRepository.GetAll().ToList();
            if (Schedule != null)
            {

                var ScheduleByObject = (from SC in Schedule
                                        join SCM in SensorCommands on SC.CommandID equals SCM.CommandID
                                        join OS in ObSen on SCM.SensorID equals OS.SensorID
                                        where SC.ObjectId == ObjectId && OS.ObjectID == ObjectId && SC.Days == DayID
                                        orderby OS.SensorID
                                        select new
                                        {
                                            ObjectID = SC.ObjectId,
                                            CommandID = SC.CommandID,
                                            ScheduleTime = SC.ScheduleTime,
                                            EnableOrDisable = SC.EnableOrDisable,
                                            Days = SC.Days,
                                            Name = OS.Name,
                                            SensorID = OS.SensorID
                                        }).ToList();

                string ser = JsonConvert.SerializeObject(ScheduleByObject);
                List<SensorSchedulingEntity> SchedulingModel = JsonConvert.DeserializeObject<List<SensorSchedulingEntity>>(ser);
                return SchedulingModel;
            }
            return null;
        }


        /// <summary>  
        /// Fetches all the products.  
        /// </summary>  
        /// <returns></returns>  
        public IEnumerable<SchedulingEntity> GetSchedules()
        {
            var clients = _unitOfWork.SchedulingRepository.GetAll().ToList();
            if (clients.Any())
            {
                Mapper.CreateMap<Scheduling, SchedulingEntity>();
                var clientsModel = Mapper.Map<List<Scheduling>, List<SchedulingEntity>>(clients);   
                return clientsModel;
            }
            return null;
        }

        /// <summary>  
        /// Creates a product  
        /// </summary>  
        /// <param name="productEntity"></param>  
        /// <returns></returns>  
        public int CreateScheduling(SchedulingEntity schedulingEntity)
        {
            using (var scope = new TransactionScope())
            {
                var Scheduling = new Scheduling
                {
                    ObjectId = schedulingEntity.ObjectId,
                    CommandID = schedulingEntity.CommandID,
                   ScheduleTime = schedulingEntity.ScheduleTime,
                   EnableOrDisable = schedulingEntity.EnableOrDisable,
                   Days = schedulingEntity.Days
                    
                    
                };

                _unitOfWork.SchedulingRepository.Insert(Scheduling);
                _unitOfWork.Save();
                scope.Complete();
                return Scheduling.SchedulingID;
            }
        }

        /// <summary>  
        /// Updates a product  
        /// </summary>  
        /// <param name="productId"></param>  
        /// <param name="productEntity"></param>  
        /// <returns></returns>  
        public bool UpdateScheduling(int SchedulingID, SchedulingEntity schedulingEntity)
        {
            var success = false;
            if (schedulingEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var Scheduling = _unitOfWork.SchedulingRepository.GetByID(SchedulingID);
                    if (Scheduling != null)
                    {
                        Scheduling.ObjectId = schedulingEntity.ObjectId;
                        Scheduling.CommandID = schedulingEntity.CommandID;
                        Scheduling.ScheduleTime = schedulingEntity.ScheduleTime;
                        Scheduling.EnableOrDisable = schedulingEntity.EnableOrDisable;
                        Scheduling.Days = schedulingEntity.Days;
                    
                        
                        _unitOfWork.SchedulingRepository.Update(Scheduling);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }


        public bool DeleteScheduling(int ObjectID, int CommandID, int DayID)
        {
            var success = false;
            if (ObjectID > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var scheduling = _unitOfWork.SchedulingRepository.GetByCondition(SC => SC.ObjectId == ObjectID && SC.CommandID == CommandID && SC.Days == DayID);
                    if (scheduling != null)
                    {
                        //var schedule = from SC in scheduling 
                        //             where SC.ObjectId == ObjectID && SC.CommandID == CommandID
                        //             select SC;
                        _unitOfWork.SchedulingRepository.Delete(scheduling);
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