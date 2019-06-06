using BusinessEntities;
using BusinessServices.LoginFeatureServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api.Controllers
{
    public class LoginFeatureController : ApiController
    {
        private readonly ILoginFeatureServices _LoginFeatureServices;

        public LoginFeatureController()
        {
            _LoginFeatureServices = new LoginFeatureServices();
        }


        // GET api/loginfeature
        public HttpResponseMessage Get()
        {
            var loginfeature = _LoginFeatureServices.GetAllLoginFeatures();
            if (loginfeature != null)
            {
                var loginfeatureEntities = loginfeature as List<LoginFeatureEntity> ?? loginfeature.ToList();
                if (loginfeatureEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, loginfeatureEntities);
            }

            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }


        // GET api/loginfeature/5        
        public HttpResponseMessage Get(int id)
        {
            var loginfeatures = _LoginFeatureServices.GetLoginFeatureById(id);
            if (loginfeatures != null)
                return Request.CreateResponse(HttpStatusCode.OK, loginfeatures);

            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }

        
        public HttpResponseMessage GetByLoginId(int LoginId)
        {
            var loginfeatures = _LoginFeatureServices.GetLoginFeatureByLoginId(LoginId);
            if (loginfeatures != null)
                return Request.CreateResponse(HttpStatusCode.OK, loginfeatures);

            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }

        public HttpResponseMessage GetFeature(int LogID)
        {
            var features = _LoginFeatureServices.GetNonAssignedLoginFeatures(LogID);
            if (features != null)
                return Request.CreateResponse(HttpStatusCode.OK, features);

            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }
        

        // POST api/loginfeature
        public int Post([FromBody]LoginFeatureEntity loginfeatureEntity)
        {
            int Id;
            Id = _LoginFeatureServices.CreateLoginFeature(loginfeatureEntity);
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


        // PUT api/loginfeature/5
        public bool Put(int id, [FromBody]LoginFeatureEntity loginfeatureEntity)
        {
            if (id > 0)
            {
                return _LoginFeatureServices.UpdateLoginFeature(id, loginfeatureEntity);
            }
            return false;
        }

        // DELETE api/loginfeature/5
        public bool Delete(int id)
        {
            if (id > 0)
                return _LoginFeatureServices.DeleteLoginFeature(id);
            return false;
        }
    }
}


 
