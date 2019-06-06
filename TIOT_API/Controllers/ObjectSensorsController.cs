using BusinessEntities;
using BusinessServices.ObjectSensorsServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api.Controllers
{
    public class ObjectSensorsController : ApiController
    {
         private readonly IObjectSensorServices _ObjectSensorServices;

        public ObjectSensorsController()
        {
            _ObjectSensorServices = new ObjectSensorServices();
        }

        public HttpResponseMessage Get()
        {
            var objectsensors = _ObjectSensorServices.GetAllObjectSensors();
            if (objectsensors != null)
            {
                var objectsensorEntities = objectsensors as List<ObjectSensorsGrid> ?? objectsensors.ToList();
                if (objectsensorEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, objectsensorEntities);
            }
            return Request.CreateResponse(HttpStatusCode.OK, "[]");

        }
        
        // GET api/objectsensors/5
        public HttpResponseMessage Get(int id)
        {
            var objectsensor = _ObjectSensorServices.GetObjectSensorsById(id);
            if (objectsensor != null)
                return Request.CreateResponse(HttpStatusCode.OK, objectsensor);

            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }

        public HttpResponseMessage GetbyObjectID(int ObjectId)
        {
            var objectsensor = _ObjectSensorServices.GetObjectSensorsByObjectId(ObjectId);
            if (objectsensor != null)
                return Request.CreateResponse(HttpStatusCode.OK, objectsensor);
            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }

        public HttpResponseMessage GetbyObjIDAndSenIDForMobile(int ObjId, int SenId)
        {
            var objectsensor = _ObjectSensorServices.GetObjectSensorsByObjIdAndSenIdForMobile(ObjId, SenId);
            if (objectsensor != null)
                return Request.CreateResponse(HttpStatusCode.OK, objectsensor);
            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }

        public HttpResponseMessage GetbyObjIdAndSenIdForNotify(int Obj, int Sen)
        {
            var objectsensor = _ObjectSensorServices.GetObjectSensorsByObjIdAndSenIdForNotify(Obj, Sen);
            if (objectsensor != null)
                return Request.CreateResponse(HttpStatusCode.OK, objectsensor);
            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }

        

        public HttpResponseMessage GetbyObjIDForSchNONAssigned(int ObjtId)
        {
            var objectsensor = _ObjectSensorServices.GetObjectSensorForScheduling(ObjtId);
            if (objectsensor != null)
                return Request.CreateResponse(HttpStatusCode.OK, objectsensor);
            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }


        public HttpResponseMessage GetbyObjectIDAndSensorID(int ObjectId, int SensorId)
        {
            var objectsensor = _ObjectSensorServices.GetObjectSensorsBySensorIdAndObjectId(ObjectId, SensorId);
            if (objectsensor != null)
                return Request.CreateResponse(HttpStatusCode.OK, objectsensor);
            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }
        
        public HttpResponseMessage GetObjectSensorNameAndSensorIDs(int ObjId)
        {
            var objectsensor = _ObjectSensorServices.GetObjectSensorNameAndSensorIDs(ObjId);
            if (objectsensor != null)
                return Request.CreateResponse(HttpStatusCode.OK, objectsensor);
            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }

        // POST api/objectsensors
        public long Post([FromBody]ObjectSensorsEntity objectsensorsEntity)
        {
                long Id;
                Id = _ObjectSensorServices.CreateObjectSensors(objectsensorsEntity);
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

        // PUT api/objectsensors/5
        public bool Put(long id, [FromBody]ObjectSensorsEntity _objsEntity)
        {
            if (id > 0)
            {
                return _ObjectSensorServices.UpdateObjectSensors(id, _objsEntity);
            }
            return false;
        }

        // DELETE api/objectsensors/5

        public bool Delete(int id)
        {
            if (id > 0)
                return _ObjectSensorServices.DeleteObjectSensors(id);
            return false;
        }
        
    }
}
