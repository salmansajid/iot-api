using BusinessEntities;
using BusinessServices.LoginGroupServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api.Controllers
{
    public class LoginGroupController : ApiController
    {
        private readonly ILoginGroupServices _LoginGroupServices;

        public LoginGroupController()
        {
            _LoginGroupServices = new LoginGroupServices();
        }

        // GET api/logingroup
        public HttpResponseMessage Get()
        {
            var logingroups = _LoginGroupServices.GetAllLoginGroups();
            if (logingroups != null)
            {
                var logingroupEntities = logingroups as List<LoginGroups> ?? logingroups.ToList();
                if (logingroupEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, logingroupEntities);
            }
            return Request.CreateResponse(HttpStatusCode.OK, "[]");

        }


        // GET api/logingroup/5
        public HttpResponseMessage Get(int id)
        {
            var logingroups = _LoginGroupServices.GetLoginGroupById(id);
            if (logingroups != null)
                return Request.CreateResponse(HttpStatusCode.OK, logingroups);

            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }
        // GET api/logingroup/5
        public HttpResponseMessage GetByLogin(int LoginId)
        {
            var logingroups = _LoginGroupServices.GetLoginGroupByLogin(LoginId);
            if (logingroups != null)
                return Request.CreateResponse(HttpStatusCode.OK, logingroups);

            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }



        // POST api/logingroup
        public int Post([FromBody]LoginGroupEntity logingroupEntity)
        {
            int Id;
            Id = _LoginGroupServices.CreateLoginGroup(logingroupEntity);
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

       

        // PUT api/logingroup/5
        public bool Put(int id, [FromBody]LoginGroupEntity logingroupEntity)
        {
            if (id > 0)
            {
                return _LoginGroupServices.UpdateLoginGroup(id, logingroupEntity);
            }
            return false;
        }

        // DELETE api/logingroup/5
        public bool Delete(int id)
        {
            if (id > 0)
                return _LoginGroupServices.DeleteLoginGroup(id);
            return false;
        }
    }
}
