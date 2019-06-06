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

namespace BusinessServices.FeatureServices
{
    public class FeatureServices :IFeatureServices
    {
        private readonly UnitOfWork _unitOfWork;
        public FeatureServices()  
         {  
             _unitOfWork = new UnitOfWork();  
         }
        
        /// Fetches product details by id  

        public FeatureEntity GetfeatureById(int FeatureId)
        {
            var feature= _unitOfWork.FeatureRepository.GetByID(FeatureId);
            if (feature != null)
            {
                Mapper.CreateMap<Feature, FeatureEntity>();
                var featureModel = Mapper.Map<Feature, FeatureEntity>(feature);
                return featureModel;
            }
            return null;
        }

        public IEnumerable<LoginFeaturesByLogins> GetLoginFeaturesByLogin(int LoginID)
        {
            var Logins = _unitOfWork.LoginRepository.GetAll();
            var Loginft = _unitOfWork.LoginFeatureRepository.GetAll();
            var features = _unitOfWork.FeatureRepository.GetAll();
            if (Logins != null && Loginft != null)
            {                    
                var lgf = (from lg in Logins
                                 join lf in Loginft on lg.LoginID equals lf.LoginID
                                 join Feat  in features on lf.FeatureID equals Feat.FeatureID
                                 where lg.LoginID == LoginID orderby Feat.ParentId
                                 select new
                                 {
                                     RoleId = lg.RoleID,
                                     LoginID = lf.LoginID,
                                     Name = Feat.Name,
                                     Link = Feat.Link,
                                     Class = Feat.Class,
                                     FeatureId = Feat.FeatureID,
                                     ParentID = Feat.ParentId
                                 }).ToList();

                string ser = JsonConvert.SerializeObject(lgf);
                List<LoginFeaturesByLogins> data = JsonConvert.DeserializeObject<List<LoginFeaturesByLogins>>(ser);
                return data;
            }
            return null;
        }

        
        /// Fetches all the products.  

        public IEnumerable<FeatureEntity> GetAllFeatures()
        {
            var feature = _unitOfWork.FeatureRepository.GetAll().ToList();
            if (feature.Any())
            {

                Mapper.CreateMap<Feature, FeatureEntity>();

                var featinfo = from ft in feature
                               orderby ft.FeatureID descending
                             select ft;
                var featureModel = Mapper.Map<List<Feature>, List<FeatureEntity>>(featinfo.ToList());
                return featureModel;

            }
            return null;

        }
        /// Creates a product  

        public int CreateFeature(FeatureEntity featureEntity)
        {
            using (var scope = new TransactionScope())
            {
                var feature = new Feature
                {
                      Description = featureEntity.Description,
                      Name = featureEntity.Name
                    
                };

                _unitOfWork.FeatureRepository.Insert(feature);
                _unitOfWork.Save();
                scope.Complete();
                return feature.FeatureID;
            }
        }

        
        /// Updates a product  

        public bool UpdateFeature(int featureId, FeatureEntity featureEntity)
        {
            var success = false;
            if (featureEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var feature = _unitOfWork.FeatureRepository.GetByID(featureId);
                    if (feature != null)
                    {

                        feature.Description = featureEntity.Description;
                        feature.Name = featureEntity.Name;
                        _unitOfWork.FeatureRepository.Update(feature);
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
        public bool DeleteFeature(int featureId)
        {
            var success = false;
            if (featureId > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var group = _unitOfWork.FeatureRepository.GetByID(featureId);
                    if (group != null)
                    {
                        _unitOfWork.FeatureRepository.Delete(group);
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