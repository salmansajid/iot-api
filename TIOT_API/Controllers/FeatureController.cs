
using BusinessEntities;
using BusinessServices.FeatureServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api.Controllers
{
    public class FeatureController : ApiController
    {

         private readonly IFeatureServices _FeatureServices;

         public FeatureController()
        {
            _FeatureServices = new FeatureServices();
        }

          // GET api/feature
        public HttpResponseMessage Get()
        {
            var features = _FeatureServices.GetAllFeatures();
            if (features != null)
            {
                var featureEntities = features as List<FeatureEntity> ?? features.ToList();
                if (featureEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, featureEntities);
            }

            return Request.CreateResponse(HttpStatusCode.OK, "[]");

        }

         // GET api/feature/5
        public HttpResponseMessage Get(int featureId)
        {
            var features = _FeatureServices.GetfeatureById(featureId);
            if (features != null)
                return Request.CreateResponse(HttpStatusCode.OK, features);

            return Request.CreateResponse(HttpStatusCode.OK, "[]");
                
        }

        public HttpResponseMessage GetByLogin(int loginId)
        {
            var features = _FeatureServices.GetLoginFeaturesByLogin(loginId);
            if (features != null)
                return Request.CreateResponse(HttpStatusCode.OK, features);

            return Request.CreateResponse(HttpStatusCode.OK, "[]");

        }
      
         // POST api/feature
        public int Post([FromBody]FeatureEntity featureEntity)
        {
            int Id;
            Id = _FeatureServices.CreateFeature(featureEntity);
            if (Id != null)
            {
                return Id;
            }
            else
            {
                Id = 0;
                return Id;
            }
            
        }

        // PUT api/feature/5
        public bool Put(int id, [FromBody]FeatureEntity featureEntity)
        {
            if (id > 0)
            {
                return _FeatureServices.UpdateFeature(id, featureEntity);
            }
            return false;
        }

        // DELETE api/feature/5
        
        public bool Delete(int id)
        {
            if (id > 0)
                return _FeatureServices.DeleteFeature(id);
            return false;
        }
        
    }
}