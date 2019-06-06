using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessServices.FeatureServices
{
    public interface IFeatureServices
    {
        FeatureEntity GetfeatureById(int FeatureId);
        IEnumerable<LoginFeaturesByLogins> GetLoginFeaturesByLogin(int LoginID);
        IEnumerable<FeatureEntity> GetAllFeatures();
        int CreateFeature(FeatureEntity featureEntity);
        bool UpdateFeature(int FeatureId, FeatureEntity featureEntity);
        bool DeleteFeature(int FeatureId);
    }
}
