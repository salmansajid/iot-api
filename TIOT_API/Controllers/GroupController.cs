using BusinessEntities;
using BusinessServices.GroupServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api.Controllers
{
    public class GroupController : ApiController
    {
        private readonly IGroupServices _GroupServices;

          public GroupController()
        {
            _GroupServices = new GroupServices();
        }

          // GET api/group
        public HttpResponseMessage Get()
        {
            var groups = _GroupServices.GetAllGroups();
            if (groups != null)
            {
                var groupEntities = groups as List<Groups> ?? groups.ToList();
                if (groupEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, groupEntities);
            }

            return Request.CreateResponse(HttpStatusCode.OK, "[]");

        }

         //GET api/group/5
        public HttpResponseMessage Get(int id)
        {
            var groups = _GroupServices.GetGroupById(id);
            if (groups != null)
                return Request.CreateResponse(HttpStatusCode.OK, groups);
            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }
         //GET api/group/5
        public HttpResponseMessage Getclient(int ClientId)
        {
            var groups = _GroupServices.GetGroupByClientId(ClientId);
            if (groups != null)
            {
                var groupEntities = groups as List<Groups> ?? groups.ToList();
                if (groupEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, groupEntities);
            }

            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }

        // POST api/group
        public int Post([FromBody]GroupEntity groupEntity)
        {
            int Id;
            Id = _GroupServices.CreateGroup(groupEntity);
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

        // PUT api/group/5
        public bool Put(int id, [FromBody]GroupEntity groupEntity)
        {
            if (id > 0)
            {
                return _GroupServices.UpdateGroup(id, groupEntity);
            }
            return false;
        }

        // DELETE api/group/5
        
        public bool Delete(int id,[FromBody]GroupEntity groupEntity)
        {
            if (id > 0)
                return _GroupServices.DeleteGroup(id, groupEntity);
            return false;
        }
        
    }
}
