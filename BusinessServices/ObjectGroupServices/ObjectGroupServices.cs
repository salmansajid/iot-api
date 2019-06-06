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

namespace BusinessServices.ObjectGroupServices
{
    public class ObjectGroupServices:IObjectGroupServices
    {
     private readonly UnitOfWork _unitOfWork;

     public ObjectGroupServices()
        {
            _unitOfWork = new UnitOfWork();
        }

     public ObjectGroupEntity GetObjectGroupById(int ObjectGroupID)
        {
            var objectgroup = _unitOfWork.ObjectGroupRepository.GetByID(ObjectGroupID);
            if (objectgroup != null)
            {
                Mapper.CreateMap<ObjectGroup, ObjectGroupEntity>();
                var objectgroupModel = Mapper.Map<ObjectGroup, ObjectGroupEntity>(objectgroup);
                return objectgroupModel;
            }
            return null;
        }


     public IEnumerable<ObjectGroups> GetAllObjectGroups()
        {
            var objectgroups = _unitOfWork.ObjectGroupRepository.GetAll().ToList();
            var _objects = _unitOfWork.ObjectRepository.GetAll();
            var _groups = _unitOfWork.GroupRepository.GetAll();

            if (objectgroups.Any())
            {

                var objgpInfo = (from objgp in objectgroups
                                 join obj in _objects on objgp.ObjectID equals obj.ObjectID
                                 join gp in _groups on objgp.GroupID equals gp.GroupID
                                 where objgp.ObjectID == obj.ObjectID && objgp.GroupID == gp.GroupID orderby objgp.ObjectGroupID descending
                                 select new
                                 {
                                     ObjectGroupID = objgp.ObjectGroupID,
                                     GroupName = gp.Name,
                                     ObjectName = obj.Name,
                                     ObjectID  = obj.ObjectID,
                                     GroupID = gp.GroupID
                                 }).ToList();

                string ser = JsonConvert.SerializeObject(objgpInfo);
                List<ObjectGroups> ObjGroups = JsonConvert.DeserializeObject<List<ObjectGroups>>(ser);
                return ObjGroups;
            }
            return null;
            
        }

     public IEnumerable<ObjectGroups> GetAllObjectGroupbyObjectId(int ObjectId)
     {
         var objectgroups = _unitOfWork.ObjectGroupRepository.GetAll().ToList();
         var _objects = _unitOfWork.ObjectRepository.GetAll();
         var _groups = _unitOfWork.GroupRepository.GetAll();

         if (objectgroups.Any())
         {

             var objgpInfo = (from objgp in objectgroups
                              join obj in _objects on objgp.ObjectID equals obj.ObjectID
                              join gp in _groups on objgp.GroupID equals gp.GroupID
                              where objgp.ObjectID == obj.ObjectID && objgp.GroupID == gp.GroupID && objgp.ObjectID == ObjectId
                              orderby objgp.ObjectGroupID descending
                              select new
                              {
                                  ObjectGroupID = objgp.ObjectGroupID,
                                  GroupName = gp.Name,
                                  ObjectName = obj.Name,
                                  ObjectID = obj.ObjectID,
                                  GroupID = gp.GroupID
                              }).ToList();

             string ser = JsonConvert.SerializeObject(objgpInfo);
             List<ObjectGroups> ObjGroups = JsonConvert.DeserializeObject<List<ObjectGroups>>(ser);
             return ObjGroups;
         }
         return null;
    }


        /// Creates a product  

     public int CreateObjectGroup(ObjectGroupEntity objectgroupEntity)
        {
            using (var scope = new TransactionScope())
            {
                var objectgroup = new ObjectGroup
                {

                    GroupID = objectgroupEntity.GroupID,
                    ObjectID = objectgroupEntity.ObjectID,

                };

                _unitOfWork.ObjectGroupRepository.Insert(objectgroup);
                _unitOfWork.Save();
                scope.Complete();
                return objectgroup.ObjectGroupID;
            }
        }

        /// Updates a product  

     public bool UpdateObjectGroup(int objectgroupId, ObjectGroupEntity objectgroupEntity)
        {
            var success = false;
            if (objectgroupEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var objectgroup = _unitOfWork.ObjectGroupRepository.GetByID(objectgroupId);
                    if (objectgroup != null)
                    {

                        objectgroup.GroupID = objectgroupEntity.GroupID;
                        objectgroup.ObjectID = objectgroupEntity.ObjectID;
                        _unitOfWork.ObjectGroupRepository.Update(objectgroup);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        
        /// Deletes a particular product  

        public bool DeleteObjectGroup(int objectgroupId)
        {
            var success = false;
            if (objectgroupId > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var objectgroup = _unitOfWork.ObjectGroupRepository.GetByID(objectgroupId);
                    if (objectgroup != null)
                    {
                        _unitOfWork.ObjectGroupRepository.Delete(objectgroup);
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
