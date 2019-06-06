using BusinessEntities;
using BusinessServices.ObjectGroupServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api.Controllers
{
    public class ObjectGroupController : ApiController
    {
        private readonly IObjectGroupServices _ObjectGroupServices;

        public ObjectGroupController()
        {
            _ObjectGroupServices = new ObjectGroupServices();
        }

        // GET api/objectgroup
        public HttpResponseMessage Get()
        {
            var objectgroups = _ObjectGroupServices.GetAllObjectGroups();
            if (objectgroups != null)
            {
                var objectgroupEntities = objectgroups as List<ObjectGroups> ?? objectgroups.ToList();
                //if (objectgroupEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, objectgroupEntities);
            }
            return Request.CreateResponse(HttpStatusCode.OK, "[]");

        }

        // GET api/objectgroup/5
        public HttpResponseMessage Get(int id)
        {
            var objectgroup = _ObjectGroupServices.GetObjectGroupById(id);
            if (objectgroup != null)
                return Request.CreateResponse(HttpStatusCode.OK, objectgroup);
            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }

        public HttpResponseMessage GetbyObjectId(int ObjectId)
        {
            var objectgroup = _ObjectGroupServices.GetAllObjectGroupbyObjectId(ObjectId);
            if (objectgroup != null)
                return Request.CreateResponse(HttpStatusCode.OK, objectgroup);
            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }
        
        // POST api/objectgroup        
        public int Post([FromBody]ObjectGroupEntity objectgroupEntity)
        {
            int Id;
            Id = _ObjectGroupServices.CreateObjectGroup(objectgroupEntity);
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

        // PUT api/objectgroup/5
        public bool Put(int id, [FromBody]ObjectGroupEntity objectgroupEntity)
        {
            if (id > 0)
            {
                return _ObjectGroupServices.UpdateObjectGroup(id, objectgroupEntity);
            }
            return false;
        }

        // DELETE api/objectgroup/5

        public bool Delete(int id)
        {
            if (id > 0)
                return _ObjectGroupServices.DeleteObjectGroup(id);
            return false;
        }
        
    }
}
