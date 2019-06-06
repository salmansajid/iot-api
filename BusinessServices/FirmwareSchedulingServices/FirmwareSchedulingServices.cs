using AutoMapper;
using BusinessEntities;
using DataModel;
using DataModel.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BusinessServices.FirmwareSchedulingServices
{
    public class FirmwareSchedulingServices :IFirmwareSchedulingServices
    {
        private readonly UnitOfWork _unitOfWork;

        public FirmwareSchedulingServices()
        {
            _unitOfWork = new UnitOfWork();
        }
        public FirmwareSchedulingEntity GetById(int FSId)
        {
            var obj = _unitOfWork.FirmwareSchedulingRepository.GetByID(FSId);
            if (obj != null)
            {
                Mapper.CreateMap<FirmwareScheduling, FirmwareSchedulingEntity>();
                var objModel = Mapper.Map<FirmwareScheduling, FirmwareSchedulingEntity>(obj);
                return objModel;
            }
            return null;
        }

        public IEnumerable<FirmwareSchedulingEntity> GetFSByClientId(int ClientId)
        {
            var obj = _unitOfWork.FirmwareSchedulingRepository.GetMany(x => x.ClientId == ClientId).ToList();
            if (obj != null)
            {
                Mapper.CreateMap<FirmwareScheduling, FirmwareSchedulingEntity>();
                var objModel = Mapper.Map<List<FirmwareScheduling>, List<FirmwareSchedulingEntity>>(obj.ToList());
                return objModel;
            }
            return null;
        }
        public IEnumerable<FirmwareSchedulingEntity> GetFSByObjectId(int ObjectId)
        {
            var obj = _unitOfWork.FirmwareSchedulingRepository.GetMany(x => x.ObjectId == ObjectId).ToList();
            if (obj != null)
            {
                Mapper.CreateMap<FirmwareScheduling, FirmwareSchedulingEntity>();
                var objModel = Mapper.Map<List<FirmwareScheduling>, List<FirmwareSchedulingEntity>>(obj.ToList());
                return objModel;
            }
            return null;
        }
        /// Fetches all the products.  


        /// Creates a product  
        public int CreateFS(FirmwareSchedulingEntity firmwareSchedulingEntity)
        {
            using (var scope = new TransactionScope())
            {
                var obj = new FirmwareScheduling
                {
                    ClientId = firmwareSchedulingEntity.ClientId,
                    ObjectId = firmwareSchedulingEntity.ObjectId,
                    SimNumber = firmwareSchedulingEntity.SimNumber,
                    Command = firmwareSchedulingEntity.Command,
                    ExecutionTime = firmwareSchedulingEntity.ExecutionTime,
                };

                _unitOfWork.FirmwareSchedulingRepository.Insert(obj);
                _unitOfWork.Save();
                scope.Complete();
                return obj.FSID;
            }
        }



        public bool DeleteFS(int fsId, FirmwareSchedulingEntity firmwareSchedulingEntity)
        {
            var success = false;
            if (fsId > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var obj = _unitOfWork.FirmwareSchedulingRepository.GetByID(fsId);
                    if (obj != null)
                    {

                        _unitOfWork.FirmwareSchedulingRepository.Delete(obj);
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
