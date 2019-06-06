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

namespace BusinessServices.LoginGroupServices
{
    public class LoginGroupServices :ILoginGroupServices
    {
        private readonly UnitOfWork _unitOfWork;

        public LoginGroupServices()
        {
            _unitOfWork = new UnitOfWork();
        }

        public LoginGroupEntity GetLoginGroupById(int LoginGroupID)
        {
            var logingroup = _unitOfWork.LoginGroupRepository.GetByID(LoginGroupID);
            if (logingroup != null)
            {
                Mapper.CreateMap<LoginGroup,LoginGroupEntity>();
                var logingroupModel = Mapper.Map<LoginGroup, LoginGroupEntity>(logingroup);
                return logingroupModel;
            }
            return null;
        }

       
        

        public LoginGroupEntity GetLoginGroupByLogin(int LoginId)
        {
            var logingroup = _unitOfWork.LoginGroupRepository.GetByCondition(lg => lg.LoginID == LoginId);
            if (logingroup != null)
            {
                Mapper.CreateMap<LoginGroup, LoginGroupEntity>();
                var logingroupModel = Mapper.Map<LoginGroup, LoginGroupEntity>(logingroup);
                return logingroupModel;
            }
            return null;
        }


        public IEnumerable<LoginGroups> GetAllLoginGroups()
        {
            var logingroups = _unitOfWork.LoginGroupRepository.GetAll();
            var _logins = _unitOfWork.LoginRepository.GetAll();
            var _groups = _unitOfWork.GroupRepository.GetAll();

            if (logingroups.Any())
            {

                var logingpInfo = (from lgngp in logingroups
                                   join lg in _logins on lgngp.LoginID equals lg.LoginID
                                   join gp in _groups on lgngp.GroupID equals gp.GroupID
                                   where lgngp.LoginID == lg.LoginID && lgngp.GroupID == gp.GroupID orderby lgngp.LoginGroupID descending
                                 select new
                                 {
                                     LoginGroupID = lgngp.LoginGroupID,
                                     GroupName = gp.Name,
                                     LoginName = lg.User,
                                     GroupID = gp.GroupID,
                                     LoginID = lg.LoginID
                                 }).ToList();

                string ser = JsonConvert.SerializeObject(logingpInfo);
                List<LoginGroups> LoginGroups = JsonConvert.DeserializeObject<List<LoginGroups>>(ser);
                return LoginGroups;
            }
            return null;
        }

       
        /// Creates a product  

        public int CreateLoginGroup(LoginGroupEntity logingroupEntity)
        {
            using (var scope = new TransactionScope())
            {
                var logingroup = new LoginGroup
                {
                    GroupID = logingroupEntity.GroupID,
                    LoginID = logingroupEntity.LoginID

                };

                _unitOfWork.LoginGroupRepository.Insert(logingroup);
                _unitOfWork.Save();
                scope.Complete();
                return logingroup.LoginGroupID;
            }
        }

        /// Updates a product  

        public bool UpdateLoginGroup(int logingroupId, LoginGroupEntity logingroupEntity)
        {
            var success = false;
            if (logingroupEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var logingroup = _unitOfWork.LoginGroupRepository.GetByID(logingroupId);
                    if (logingroup != null)
                    {

                        logingroup.GroupID = logingroupEntity.GroupID;
                        logingroup.LoginID = logingroupEntity.LoginID;
                        _unitOfWork.LoginGroupRepository.Update(logingroup);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        
        /// Deletes a particular product  

        public bool DeleteLoginGroup(int LoginGroupId)
        {
            var success = false;
            if (LoginGroupId > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var logingroup = _unitOfWork.LoginGroupRepository.GetByID(LoginGroupId);
                    if (logingroup != null)
                    {

                        _unitOfWork.LoginGroupRepository.Delete(logingroup);
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
