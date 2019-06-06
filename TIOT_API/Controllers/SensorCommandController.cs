using BusinessEntities;
using BusinessServices.SensorCommandServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api.Controllers
{
    public class SensorCommandController : ApiController
    {
        // GET api/category

        private readonly ISensorCommandServices _SensorCommandServices;

        public SensorCommandController()
        {
            _SensorCommandServices = new SensorCommandServices();
        }

        // GET api/client  
        public HttpResponseMessage Get()
        {
            var SC = _SensorCommandServices.GetAllSensorCommands();
            if (SC != null)
            {
                var SCEntities = SC as List<SensorCommandEntity> ?? SC.ToList();
                if (SCEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, SCEntities);
            }

            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }

        public HttpResponseMessage GetBySensorId(int SensorId)
        {
            var SC = _SensorCommandServices.GetSensorCommandBySensorId(SensorId);
            if (SC != null)
            {
                var SCEntities = SC as List<SensorCommandEntity> ?? SC.ToList();
                if (SCEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, SCEntities);
            }

            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }
        public HttpResponseMessage GetByCommandId(int CommandId)
        {
            var SC = _SensorCommandServices.GetSensorCommandByCommandId(CommandId);
            if (SC != null)
            {
                var SCEntities = SC as List<SensorCommandEntity> ?? SC.ToList();
                if (SCEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, SCEntities);
            }

            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }
    }
}
