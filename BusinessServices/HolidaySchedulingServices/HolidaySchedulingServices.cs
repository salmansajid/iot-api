using AutoMapper;
using BusinessEntities;
using DataModel;
using DataModel.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace BusinessServices.HolidaySchedulingServices
{
    public class HolidaySchedulingServices :IHolidaySchedulingServices
    {
        
         private readonly UnitOfWork _unitOfWork;   
         /// <summary>  
         /// Public constructor.  
         /// </summary>  
         public HolidaySchedulingServices()  
         {  
             _unitOfWork = new UnitOfWork();  
         }


        public  FederalHolidayEntity GetHolidayById(int HolidayId)
        {
            var Holiday = _unitOfWork.FederalHolidayRepository.GetByID(HolidayId);
            if (Holiday != null)
            {
                Mapper.CreateMap<FederalHoliday, FederalHolidayEntity>();
                var HolidayModel = Mapper.Map<FederalHoliday, FederalHolidayEntity>(Holiday);
                return HolidayModel;
            }
            return null;
        }

        public IEnumerable<FederalHolidayEntity> GetHolidayByGroupId(int GroupId)
        {

            var Holidays = _unitOfWork.FederalHolidayRepository.GetMany(SC => SC.GroupID == GroupId);
            if (Holidays != null)
            {
                Mapper.CreateMap<FederalHoliday, FederalHolidayEntity>();
                //var ScheduleByObject = from SC in Schedule
                //                       where SC.ObjectId == ObjectId
                //                       select SC;
                var HolidayModel = Mapper.Map<List<FederalHoliday>, List<FederalHolidayEntity>>(Holidays.ToList());
                return HolidayModel;
            }
            return null;
        }


        /// <summary>  
        /// Fetches all the products.  
        /// </summary>  
        /// <returns></returns>  
        public  IEnumerable<FederalHolidayEntity> GetHolidays()
        {
            var Holidays = _unitOfWork.FederalHolidayRepository.GetAll().ToList();
            if (Holidays.Any())
            {
                Mapper.CreateMap<FederalHoliday, FederalHolidayEntity>();
                var HolidayModel = Mapper.Map<List<FederalHoliday>, List<FederalHolidayEntity>>(Holidays);
                return HolidayModel;
            }
            return null;
        }

        /// <summary>  
        /// Creates a product  
        /// </summary>  
        /// <param name="productEntity"></param>  
        /// <returns></returns>  
        public int CreateHoliday(FederalHolidayEntity holidayEntity)
        {
            using (var scope = new TransactionScope())
            {
                var Holidays = new FederalHoliday
                {
                    Holidays = holidayEntity.Holidays,
                    FullDate = holidayEntity.FullDate,
                    Enabled = holidayEntity.Enabled,
                    GroupID = holidayEntity.GroupID,  
                };
                _unitOfWork.FederalHolidayRepository.Insert(Holidays);
                _unitOfWork.Save();
                scope.Complete();
                return Holidays.HolidaysID;
            }
        }

        /// <summary>  
        /// Updates a product  
        /// </summary>  
        /// <param name="productId"></param>  
        /// <param name="productEntity"></param>  
        /// <returns></returns>  
        public bool UpdateHoliday(int HolidayId, FederalHolidayEntity holidayEntity)
        {
            var success = false;
            if (holidayEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var Holiday = _unitOfWork.FederalHolidayRepository.GetByID(HolidayId);
                    if (Holiday != null)
                    {
                        Holiday.FullDate = holidayEntity.FullDate;
                        Holiday.Holidays = holidayEntity.Holidays;
                        Holiday.Enabled = holidayEntity.Enabled;
                        Holiday.GroupID = holidayEntity.GroupID;
                        _unitOfWork.FederalHolidayRepository.Update(Holiday);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }


        public bool DeleteHoliday(int HolidayID)
        {
            var success = false;
            if (HolidayID > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var Holiday = _unitOfWork.FederalHolidayRepository.GetByID(HolidayID);
                    if (Holiday != null)
                    {
                        _unitOfWork.FederalHolidayRepository.Delete(Holiday);
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
