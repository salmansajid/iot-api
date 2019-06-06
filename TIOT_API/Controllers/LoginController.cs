using BusinessEntities;
using BusinessServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace api.Controllers
{
   
    public class LoginController : ApiController
    {

        private readonly ILoginServices _loginServices;
        public LoginController()
        {
            _loginServices = new LoginServices();
        }

        // GET api/login  
        public HttpResponseMessage Get()
        {
            var logins = _loginServices.GetAllLogins();
            var loginEntities = logins as List<Logins> ?? logins.ToList();
            if (logins != null)
            {
                if (loginEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, loginEntities);
            }

            return Request.CreateResponse(HttpStatusCode.OK, "[]");

        }

        public HttpResponseMessage GetNonAdminsLogins(string admins)
        {
            var logins = _loginServices.GetLoginsNonAdmin();
            var loginEntities = logins as List<Logins> ?? logins.ToList();
            if (logins != null)
            {
                if (loginEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, loginEntities);
            }

            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }

        public HttpResponseMessage Get(string User, string Password)
        {
            var login = _loginServices.Authenthicate(User, Password);
            if (login != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, login);

            }

            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }
        public HttpResponseMessage Get(string Code, string User, string Password)
        {
            var login = _loginServices.GetLoginByCode(Code, User, Password);
            if (login != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, login);

            }

            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }

        // GET api/product/5
        public HttpResponseMessage Get(int id)
        {
            var login = _loginServices.GetLoginById(id);
            if (login != null)
                return Request.CreateResponse(HttpStatusCode.OK, login);


            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }

        // POST api/login
        public int Post([FromBody] LoginEntity loginEntity)
        {
            int Id;
            Id = _loginServices.CreateLogin(loginEntity);
            if(Id != null)
            {
                return Id;
            }
            else
            {
                Id = 0;
                return Id;
            }
           

        }
        // PUT api/product/5
        public bool Put(int id, [FromBody]LoginEntity loginEntity)
        {
            if (id > 0)
            {
                return _loginServices.UpdateLogin(id, loginEntity);
            }
            return false;
        }
        // DELETE api/login/5

        // DELETE api/product/5
        public bool Delete(int id)
        {
            if (id > 0)
                return _loginServices.DeleteLogin(id);
            return false;
        }
    }
}
