using BusinessEntities;
using BusinessServices.SensorServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api.Controllers
{
    public class SensorController : ApiController
    {   
        private readonly ISensorServices _SensorServices;

        public SensorController()
        {
            _SensorServices = new SensorServices();
        }

        // GET api/sensor
        public HttpResponseMessage Get()
        {
            var _sensors = _SensorServices.GetAllSensors();
            if (_sensors != null)
            {
                var sensorEntities = _sensors as List<SensorEntity> ?? _sensors.ToList();
                if (sensorEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, sensorEntities);
            }
            return Request.CreateResponse(HttpStatusCode.OK, "[]");

        }

        public HttpResponseMessage GetAssignedSensor(int objectID)
        {
            var _sensors = _SensorServices.GetNonAssignedSensors(objectID);
            if (_sensors != null)
            {
                var sensorEntities = _sensors as List<SensorEntity> ?? _sensors.ToList();
                if (sensorEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, sensorEntities);
            }
            return Request.CreateResponse(HttpStatusCode.OK, "[]");

        }

        //public HttpResponseMessage GetNonAssignedSensorsForEventConfig(int _objectID)
        //{
        //    var _sensors = _SensorServices.GetNonAssignedSensorsForEventConfig(_objectID);
        //    if (_sensors != null)
        //    {
        //        var sensorEntities = _sensors as List<SensorEntity> ?? _sensors.ToList();
        //        if (sensorEntities.Any())
        //            return Request.CreateResponse(HttpStatusCode.OK, sensorEntities);
        //    }
        //    return Request.CreateResponse(HttpStatusCode.OK, "[]");

        //}

        // GET api/sensor/5
        public HttpResponseMessage Get(int id)
        {
            var _sensor = _SensorServices.GetSensorById(id);
            if (_sensor != null)
                return Request.CreateResponse(HttpStatusCode.OK, _sensor);
                return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }

        public HttpResponseMessage GetbyObjectID(int sensorId)
        {
            var _sensors = _SensorServices.GetSensorBySensorId(sensorId);
            if (_sensors != null)
                return Request.CreateResponse(HttpStatusCode.OK, _sensors);
            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }

        // POST api/sensor
        public long Post([FromBody]SensorEntity sensorEntity)
        {
            long Id;
            Id = _SensorServices.CreateSensor(sensorEntity);
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

        // PUT api/sensor/5
        public bool Put(int id, [FromBody]SensorEntity sensorEntity)
        {
            if (id > 0)
            {
                return _SensorServices.UpdateSensor(id, sensorEntity);
            }
            return false;
        }

        // DELETE api/sensor/5

        public bool Delete(int id)
        {
            if (id > 0)
                return _SensorServices.DeleteSensor(id);
            return false;
        }
        
    }
}
