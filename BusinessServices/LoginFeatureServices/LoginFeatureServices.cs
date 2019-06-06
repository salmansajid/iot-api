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

namespace BusinessServices.LoginFeatureServices
{
    public class LoginFeatureServices:ILoginFeatureServices
    {
         private readonly UnitOfWork _unitOfWork;

         public LoginFeatureServices()
        {
            _unitOfWork = new UnitOfWork();
        }


         public LoginFeatureEntity GetLoginFeatureById(int LoginFeatureID)
        {
            var loginfeature = _unitOfWork.LoginFeatureRepository.GetByID(LoginFeatureID);
            if (loginfeature != null)
            {
                Mapper.CreateMap<LoginFeature, LoginFeatureEntity>();
                var loginfeatureModel = Mapper.Map<LoginFeature, LoginFeatureEntity>(loginfeature);
                return loginfeatureModel;
            }
            return null;
        }

         public IEnumerable<LoginFeaturesUserEntity> GetLoginFeatureByLoginId(int LoginId)
         {
             var loginfeatures = _unitOfWork.LoginFeatureRepository.GetAll().ToList();
             var logins = _unitOfWork.LoginRepository.GetAll().ToList();
             var features = _unitOfWork.FeatureRepository.GetAll().ToList();
             if (loginfeatures != null)
             {
                 var loginfeaturesInfo = (from lgf in loginfeatures
                                          join lg in logins on lgf.LoginID equals lg.LoginID
                                          join ft in features on lgf.FeatureID equals ft.FeatureID
                                          where lgf.LoginID == LoginId                                           
                                          orderby lgf.LoginFeatureID descending
                                          select new
                                          {
                                              LoginFeatureID = lgf.LoginFeatureID,
                                              LoginID = lgf.LoginID,
                                              FeatureID = lgf.FeatureID,
                                              User = lg.User,
                                              Enable = lgf.Enable,
                                              Name = ft.Name,
                                              Description = ft.Description,
                                              Link = ft.Link,
                                              Class = ft.Class
                                              
                                          }).ToList();

                 string ser = JsonConvert.SerializeObject(loginfeaturesInfo);
                 List<LoginFeaturesUserEntity> lgfeatures = JsonConvert.DeserializeObject<List<LoginFeaturesUserEntity>>(ser);
                 return lgfeatures;
             }
             return null;
         }

        public IEnumerable<FeatureEntity> GetNonAssignedLoginFeatures(int LoginID)
         {
             var Features = _unitOfWork.FeatureRepository.GetAll().ToList();
             var LoginFeatures = _unitOfWork.LoginFeatureRepository.GetAll().ToList();
             if (LoginFeatures.Any())
             {

                 var LoginFeatureinfo = (from F in Features
                                         where !(from lf in LoginFeatures where lf.LoginID == LoginID select lf.FeatureID).Contains(F.FeatureID)
                                         select new
                                           {
                                               FeatureID = F.FeatureID,
                                               Name = F.Name,
                                               Description = F.Description,
                                               Link = F.Link,
                                               ParentId = F.ParentId,
                                               Class = F.Class

                                           }).ToList();


                 string ser = JsonConvert.SerializeObject(LoginFeatureinfo);
                 List<FeatureEntity> LoginFeatureModel = JsonConvert.DeserializeObject<List<FeatureEntity>>(ser);
                 return LoginFeatureModel;
             }
             return null;
         }

        public IEnumerable<LoginFeatureEntity> GetAllLoginFeatures()
        {
            var loginfeatures = _unitOfWork.LoginFeatureRepository.GetAll().ToList();
            if (loginfeatures != null)
            {
                Mapper.CreateMap<LoginFeature, LoginFeatureEntity>();
                var loginfeatureModel = Mapper.Map<List<LoginFeature>,  List<LoginFeatureEntity>>(loginfeatures);
                return loginfeatureModel;
            }
            return null;
        }

        /// Creates a product  

         public int CreateLoginFeature(LoginFeatureEntity loginfeatureEntity)
        {
            using (var scope = new TransactionScope())
            {
                var loginfeature = new LoginFeature
                {
                    FeatureID = loginfeatureEntity.FeatureID,
                    LoginID = loginfeatureEntity.LoginID,
                    Enable = loginfeatureEntity.Enable

                };

                _unitOfWork.LoginFeatureRepository.Insert(loginfeature);
                _unitOfWork.Save();
                scope.Complete();
                return loginfeature.LoginFeatureID;
            }
        }

        /// Updates a product  

         public bool UpdateLoginFeature(int loginfeatureId, LoginFeatureEntity loginfeatureEntity)
        {
            var success = false;
            if (loginfeatureEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var loginfeature = _unitOfWork.LoginFeatureRepository.GetByID(loginfeatureId);
                    if (loginfeature != null)
                    {
                        loginfeature.Enable = loginfeatureEntity.Enable;
                        _unitOfWork.LoginFeatureRepository.Update(loginfeature);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        
        /// Deletes a particular product  

         public bool DeleteLoginFeature(int loginfeatureId)
        {
            var success = false;
            if (loginfeatureId > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var loginfeature = _unitOfWork.LoginFeatureRepository.GetByID(loginfeatureId);
                    if (loginfeature != null)
                    {

                        _unitOfWork.LoginFeatureRepository.Delete(loginfeature);
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
