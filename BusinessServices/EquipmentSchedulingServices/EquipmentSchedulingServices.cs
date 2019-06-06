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

namespace BusinessServices.EquipmentSchedulingServices
{
    public class EquipmentSchedulingServices :IEquipmentSchedulingServices
    {
          private readonly UnitOfWork _unitOfWork;   
         /// <summary>  
         /// Public constructor.  
         /// </summary>  
          public EquipmentSchedulingServices()  
         {  
             _unitOfWork = new UnitOfWork();  
         }
        /// <summary>  
        /// Fetches product details by id  
        /// </summary>  
        /// <param name="productId"></param>  
        /// <returns></returns>  
          public EquipmentSchedulingEntity GetEquipmentSchedulingById(int EquipmentSchedulingId)
        {
            var Values = _unitOfWork.EquipmentSchedulingRepository.GetByID(EquipmentSchedulingId);
            if (Values != null)
            {
                Mapper.CreateMap<EquipmentScheduling, EquipmentSchedulingEntity>();
                var ValuesModel = Mapper.Map<EquipmentScheduling, EquipmentSchedulingEntity>(Values);
                return ValuesModel;
            }
            return null;
        }

        /// <summary>  
        /// Fetches all the products.  
        /// </summary>  
        /// <returns></returns>  
          public IEnumerable<EquipmentSchedulingEntity> GetEquipmentScheduling()
        {
            var Values = _unitOfWork.EquipmentSchedulingRepository.GetAll().ToList();
            if (Values.Any())
            {
                Mapper.CreateMap<EquipmentScheduling, EquipmentSchedulingEntity>();
                var ValuesModel = Mapper.Map<List<EquipmentScheduling>, List<EquipmentSchedulingEntity>>(Values.ToList());
                return ValuesModel;
            }
            return null;
        }

          public IEnumerable<sp_EquipmentSchedulingEntity> GetEquipmentSchedulingByObjectIdAndDayId(int ObjectId, int DayId)
          {
              var sp_ES = _unitOfWork.sp_EquipmentSchedulingRepository.ExecWithStoreProcedure(
                "sp_GetSchedulingByObjAndDay @ObjectId, @DayId",
                new SqlParameter("ObjectId", SqlDbType.Int) { Value = ObjectId },
                new SqlParameter("DayId", SqlDbType.Int) { Value = DayId }
                ).ToList();

              if (sp_ES.Any())
              {
                  string ser = JsonConvert.SerializeObject(sp_ES);
                  List<sp_EquipmentSchedulingEntity> sp_ESModel = JsonConvert.DeserializeObject<List<sp_EquipmentSchedulingEntity>>(ser);
                  return sp_ESModel;
              }
              else
              {
                  return null;
              }
          }

          public IEnumerable<sp_EquipmentSchedulingEntity> GetEquipmentSchedulingByObjectId_DayIdAndOBJId(int ObjectId, int DayId, int ObjectsensorId)
          {
              var sp_ES = _unitOfWork.sp_EquipmentSchedulingByObjsenRepository.ExecWithStoreProcedure(
                "sp_GetSchedulingByObjAndDayAndObS @ObjectId, @DayId , @ObjectSensorId",
                new SqlParameter("ObjectId", SqlDbType.Int) { Value = ObjectId },
                new SqlParameter("DayId", SqlDbType.Int) { Value = DayId },
                new SqlParameter("ObjectSensorId", SqlDbType.Int) { Value = ObjectsensorId }
                ).ToList();

              if (sp_ES.Any())
              {
                  string ser = JsonConvert.SerializeObject(sp_ES);
                  List<sp_EquipmentSchedulingEntity> sp_ESModel = JsonConvert.DeserializeObject<List<sp_EquipmentSchedulingEntity>>(ser);
                  return sp_ESModel;
              }
              else
              {
                  return null;
              }
          }


          public IEnumerable<sp_EquipmentSchedulingEntity> GetEquipmentSchedulingByObjDayObjsIds(int ObjectId, int ObjectSensorId)
          {
              var sp_ES = _unitOfWork.sp_EquipmentSchedulingWeeklyRepository.ExecWithStoreProcedure(
                "sp_GetSchedulingByObjAndObjSenIdForWeek @ObjectId, @ObjectSensorId",
                new SqlParameter("ObjectId", SqlDbType.Int) { Value = ObjectId },
                new SqlParameter("ObjectSensorId", SqlDbType.Int) { Value = ObjectSensorId }
                ).ToList();

              if (sp_ES.Any())
              {
                  string ser = JsonConvert.SerializeObject(sp_ES);
                  List<sp_EquipmentSchedulingEntity> sp_ESModel = JsonConvert.DeserializeObject<List<sp_EquipmentSchedulingEntity>>(ser);
                  return sp_ESModel;
              }
              else
              {
                  return null;
              }
          }

        /// <summary>  
        /// Creates a product  
        /// </summary>  
        /// <param name="productEntity"></param>  
        /// <returns></returns>  
          public int CreateEquipmentScheduling(EquipmentSchedulingEntity equipmentSchedulingEntity)
        {
            using (var scope = new TransactionScope())
            {
                if (equipmentSchedulingEntity.Days == 1) { equipmentSchedulingEntity.DaysName = "Monday"; }
                if (equipmentSchedulingEntity.Days == 2) { equipmentSchedulingEntity.DaysName = "Tuesday"; }
                if (equipmentSchedulingEntity.Days == 3) { equipmentSchedulingEntity.DaysName = "Wednesday"; }
                if (equipmentSchedulingEntity.Days == 4) { equipmentSchedulingEntity.DaysName = "Thursday"; }
                if (equipmentSchedulingEntity.Days == 5) { equipmentSchedulingEntity.DaysName = "Friday"; }
                if (equipmentSchedulingEntity.Days == 6) { equipmentSchedulingEntity.DaysName = "Saturday"; }
                if (equipmentSchedulingEntity.Days == 7) { equipmentSchedulingEntity.DaysName = "Sunday"; }
                var eqScheduling = new EquipmentScheduling 
                {
                    ObjectId = equipmentSchedulingEntity.ObjectId,
                    StartTime = equipmentSchedulingEntity.StartTime,
                    EndTime = equipmentSchedulingEntity.EndTime,
                    Days = equipmentSchedulingEntity.Days,
                    DaysName = equipmentSchedulingEntity.DaysName,
                    ObjectSensorId = equipmentSchedulingEntity.ObjectSensorId,
                    EnableOrDisable = equipmentSchedulingEntity.EnableOrDisable,
                };

                _unitOfWork.EquipmentSchedulingRepository.Insert(eqScheduling);
                _unitOfWork.Save();
                scope.Complete();
                return eqScheduling.SchedulingID;
            }
        }

        /// <summary>  
        /// Updates a product  
        /// </summary>  
        /// <param name="productId"></param>  
        /// <param name="productEntity"></param>  
        /// <returns></returns>  
          public bool UpdateEquipmentScheduling(int EquipmentSchedulingId, EquipmentSchedulingEntity equipmentSchedulingEntity)
        {
            var success = false;
            if (equipmentSchedulingEntity != null)
            {
                using (var scope = new TransactionScope())
                {

                    var ES = _unitOfWork.EquipmentSchedulingRepository.GetByID(EquipmentSchedulingId);
                    if (ES.Days == 1) { equipmentSchedulingEntity.DaysName = "Monday"; }
                    if (ES.Days == 2) { equipmentSchedulingEntity.DaysName = "Tuesday"; }
                    if (ES.Days == 3) { equipmentSchedulingEntity.DaysName = "Wednesday"; }
                    if (ES.Days == 4) { equipmentSchedulingEntity.DaysName = "Thursday"; }
                    if (ES.Days == 5) { equipmentSchedulingEntity.DaysName = "Friday"; }
                    if (ES.Days == 6) { equipmentSchedulingEntity.DaysName = "Saturday"; }
                    if (ES.Days == 7) { equipmentSchedulingEntity.DaysName = "Sunday"; }
                    if (ES != null)
                    {

                        ES.ObjectId = equipmentSchedulingEntity.ObjectId;
                        ES.StartTime = equipmentSchedulingEntity.StartTime;
                        ES.EndTime = equipmentSchedulingEntity.EndTime;
                        ES.Days = equipmentSchedulingEntity.Days;
                        ES.DaysName = equipmentSchedulingEntity.DaysName;
                        ES.ObjectSensorId = equipmentSchedulingEntity.ObjectSensorId;
                        ES.EnableOrDisable = equipmentSchedulingEntity.EnableOrDisable;

                        _unitOfWork.EquipmentSchedulingRepository.Update(ES);
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
          public bool DeleteEquipmentScheduling(int EquipmentSchedulingId)
        {
            var success = false;
            if (EquipmentSchedulingId > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var ES = _unitOfWork.EquipmentSchedulingRepository.GetByID(EquipmentSchedulingId);
                    if (ES != null)
                    {

                        _unitOfWork.EquipmentSchedulingRepository.Delete(ES);
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
