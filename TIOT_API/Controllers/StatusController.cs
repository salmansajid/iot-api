using BusinessEntities;
using BusinessServices.StatusServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api.Controllers
{
    public class StatusController : ApiController
    {

        private readonly IStatusServices _StatusServices;

         public StatusController()
        {
            _StatusServices = new StatusServices();
        }

           //GET api/status
        public HttpResponseMessage Get()
        {
            var status = _StatusServices.GetAllstatus();
            if (status != null)
            {
                var statusEntities = status as List<StatusEntity> ?? status.ToList();
                if (statusEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, statusEntities);
            }
            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }
    
         // GET api/status/5
        public HttpResponseMessage Get(int id)
        {
            var status = _StatusServices.GetstatusById(id);
            if (status != null)
                return Request.CreateResponse(HttpStatusCode.OK, status);
            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }
      
         // POST api/status
        public int Post([FromBody]StatusEntity statusEntity)
        {
            int Id;
            Id = _StatusServices.CreateStatus(statusEntity);
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

        // PUT api/status/5
        public bool Put(int id, [FromBody]StatusEntity statusEntity)
        {
            if (id > 0)
            {
                return _StatusServices.UpdateStatus(id, statusEntity);
            }
            return false;
        }

        // DELETE api/status/5
        
        public bool Delete(int id)
        {
            if (id > 0)
                return _StatusServices.DeleteStatus(id);
            return false;
        }
        
    }
}