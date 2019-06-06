using BusinessEntities;
using BusinessServices.SensorObjectGroupServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api.Controllers
{
    public class SensorObjectGroupController : ApiController
    {
         
        private readonly ISensorObjectGroup _SensorObjectGroupServices;

        public SensorObjectGroupController()
        {
            _SensorObjectGroupServices = new SensorObjectGroupServices();
        }

        public HttpResponseMessage Get()
        {
            var _sensorObjectGroups = _SensorObjectGroupServices.GetAllGetSensorObjectGroup();
            if (_sensorObjectGroups != null)
            {
                var sensorObjectGroupsEntities = _sensorObjectGroups as List<SensorObjectGroupEntity> ?? _sensorObjectGroups.ToList();
                if (sensorObjectGroupsEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, sensorObjectGroupsEntities);
            }
            return Request.CreateResponse(HttpStatusCode.OK, "[]");

        }

    }
}
