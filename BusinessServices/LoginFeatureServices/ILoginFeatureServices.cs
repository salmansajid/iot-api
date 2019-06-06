using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessServices.LoginFeatureServices
{
    public interface ILoginFeatureServices
    {
        IEnumerable<LoginFeatureEntity> GetAllLoginFeatures();
        LoginFeatureEntity GetLoginFeatureById(int LoginFeatureId);
        IEnumerable<LoginFeaturesUserEntity> GetLoginFeatureByLoginId(int LoginId);
        
        IEnumerable<FeatureEntity> GetNonAssignedLoginFeatures(int LoginID);
        int CreateLoginFeature(LoginFeatureEntity loginfeatureEntity);
        bool UpdateLoginFeature(int LoginFeatureId, LoginFeatureEntity loginfeatureEntity);
        bool DeleteLoginFeature(int LoginFeatureId);
    }
}
