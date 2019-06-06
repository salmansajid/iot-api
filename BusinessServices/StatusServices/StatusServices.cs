using AutoMapper;
using BusinessEntities;
using DataModel;
using DataModel.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace BusinessServices.StatusServices
{
    public class StatusServices : IStatusServices
    {
        private readonly UnitOfWork _unitOfWork;
        public StatusServices()  
         {  
             _unitOfWork = new UnitOfWork();  
         }
        
        /// Fetches product details by id  



        public StatusEntity GetstatusById(int StatusId)
        {
            var status = _unitOfWork.StatusRepository.GetByID(StatusId);
            if (status != null)
            {
                Mapper.CreateMap<Status, StatusEntity>();
                var statusModel = Mapper.Map<Status, StatusEntity>(status);
                return statusModel;
            }
            return null;
        }
        
        /// Fetches all the products.  

        public IEnumerable<StatusEntity> GetAllstatus()
        {
            var status = _unitOfWork.StatusRepository.GetAll().ToList();
            if (status.Any())
            {

                Mapper.CreateMap<Status, StatusEntity>();
                var statusModel = Mapper.Map<List<Status>, List<StatusEntity>>(status);
                return statusModel;

            }
            return null;

        }
        /// Creates a product  

        public int CreateStatus(StatusEntity statusEntity)
        {
            using (var scope = new TransactionScope())
            {
                var status = new Status
                {
                    Name = statusEntity.Name
                    
                };

                _unitOfWork.StatusRepository.Insert(status);
                _unitOfWork.Save();
                scope.Complete();
                return status.StatusId;
            }
        }

        
        /// Updates a product  

        public bool UpdateStatus(int statusId, StatusEntity statusEntity)
        {
            var success = false;
            if (statusEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var status = _unitOfWork.StatusRepository.GetByID(statusId);
                    if (status != null)
                    {

                        status.Name = statusEntity.Name;
                        _unitOfWork.StatusRepository.Update(status);
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
        public bool DeleteStatus(int statusId)
        {
            var success = false;
            if (statusId > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var status = _unitOfWork.StatusRepository.GetByID(statusId);
                    if (status != null)
                    {
                        _unitOfWork.StatusRepository.Delete(status);
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