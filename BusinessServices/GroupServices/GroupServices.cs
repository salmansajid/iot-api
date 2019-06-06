using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntities;
using DataModel.UnitOfWork;
using AutoMapper;
using DataModel;
using System.Transactions;
using Newtonsoft.Json;

namespace BusinessServices.GroupServices
{
    public class GroupServices :IGroupServices
    {
        private readonly UnitOfWork _unitOfWork;   

        public GroupServices()  
         {  
             _unitOfWork = new UnitOfWork();  
         }
        
        /// Fetches product details by id  
        public GroupEntity GetGroupById(int groupId)
        {
            var group = _unitOfWork.GroupRepository.GetByID(groupId);
            if (group != null)
            {
                Mapper.CreateMap<Group, GroupEntity>();
                var groupModel = Mapper.Map<Group, GroupEntity>(group);
                return groupModel;
            }
            return null;
        }

        public IEnumerable<Groups> GetGroupByClientId(int ClientId)
        {
            var groups = _unitOfWork.GroupRepository.GetAll().ToList();
            var clients = _unitOfWork.ClientRepository.GetAll().ToList();
            if (groups != null)
            {
                var groupInfo = (from gp in groups
                                 join cl in clients on gp.ClientID equals cl.ClientID
                                 where gp.ClientID == ClientId && gp.Deleted == false
                                 select new
                                 {
                                     GroupID = gp.GroupID,
                                     ClientID = cl.ClientID,
                                     ClientName = cl.Name,
                                     Comment = gp.Comment,
                                     Name = gp.Name,
                                     Deleted = gp.Deleted
                                 }).ToList();

                string ser = JsonConvert.SerializeObject(groupInfo);
                List<Groups> _groups = JsonConvert.DeserializeObject<List<Groups>>(ser);
                return _groups;
            }
            return null;
        }

        /// Fetches all the products.  
        public IEnumerable<Groups> GetAllGroups()
        {
            var _clients = _unitOfWork.ClientRepository.GetAll();
            var _groups = _unitOfWork.GroupRepository.GetAll();
            if (_groups.Any())
            {

                var groupInfo = (from gp in _groups
                                 join cl in _clients on gp.ClientID equals cl.ClientID
                                 where gp.ClientID == cl.ClientID && cl.Deleted == false && gp.Deleted == false
                                 orderby gp.GroupID descending
                                 select new
                                     {
                                         GroupID = gp.GroupID,
                                         ClientID = cl.ClientID,
                                         ClientName = cl.Name,
                                         Comment = gp.Comment,
                                         Name = gp.Name,
                                         Deleted  = gp.Deleted
                                     }).ToList();

                string ser = JsonConvert.SerializeObject(groupInfo);
                List<Groups> groups = JsonConvert.DeserializeObject<List<Groups>>(ser);
                return groups;

            }
            return null;

        }

        /// Creates a product  
        public int CreateGroup(GroupEntity groupEntity)
        {
            using (var scope = new TransactionScope())
            {
                var group = new Group
                {
                    ClientID =groupEntity.ClientID,
                    Name = groupEntity.Name,
                    Comment = groupEntity.Comment,
                    Deleted = false
                };

                _unitOfWork.GroupRepository.Insert(group);
                _unitOfWork.Save();
                scope.Complete();
                return group.GroupID;
            }
        }
        
        /// Updates a product         
        public bool UpdateGroup(int groupId, GroupEntity groupEntity)
        {
            var success = false;
            if (groupEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var group = _unitOfWork.GroupRepository.GetByID(groupId);
                    if (group != null)
                    {

                        group.ClientID =groupEntity.ClientID;
                        group.Comment = groupEntity.Comment;
                        group.Name = groupEntity.Name;
                        _unitOfWork.GroupRepository.Update(group);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        //delete a Product
        public bool DeleteGroup(int groupId, GroupEntity groupEntity)
        {
            var success = false;
                    using (var scope = new TransactionScope())
                {
                    var group = _unitOfWork.GroupRepository.GetByID(groupId);
                    if (group != null)
                    {

                        group.Deleted = true;
                        _unitOfWork.GroupRepository.Update(group);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                
            }
            return success;
        }



        /// <summary>  
        /// Deletes a particular product  
        /// </summary>  
        /// <param name="productId"></param>  
        /// <returns></returns>  
        //public bool DeleteGroup(int groupId)
        //{
        //    var success = false;
        //    if (groupId > 0)
        //    {
        //        using (var scope = new TransactionScope())
        //        {
        //            var group = _unitOfWork.GroupRepository.GetByID(groupId);
        //            if (group != null)
        //            {

        //                _unitOfWork.GroupRepository.Delete(group);
        //                _unitOfWork.Save();
        //                scope.Complete();
        //                success = true;
        //            }
        //        }
        //    }
        //    return success;
        //}


    }
}

 
