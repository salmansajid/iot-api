using BusinessEntities;
using BusinessServices.EventConfigurationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api.Controllers
{
    public class EventConfigurationController : ApiController
    {
        
        private readonly IEventConfigurationServices _EventConfigurationServices;

        public EventConfigurationController()
        {
            _EventConfigurationServices = new EventConfigurationServices();
        }
        
        public HttpResponseMessage Get()
        {
            var EventConfiguration = _EventConfigurationServices.GetEventConfiguration();
            if (EventConfiguration != null)
            {
                var eventConfigurationEntities = EventConfiguration as List<EventConfigurationEntity> ?? EventConfiguration.ToList();
                if (eventConfigurationEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, eventConfigurationEntities);
            }
            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }

        public HttpResponseMessage GetByObjectId(int ObjectId)
        {
            var EventConfiguration = _EventConfigurationServices.GetEventConfigurationByObjectId(ObjectId);
            if (EventConfiguration != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, EventConfiguration);
            }
            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }

        public HttpResponseMessage GetLocationByObjectId(int ObjId)
        {
            var EventConfiguration = _EventConfigurationServices.GetEventConfigurationLocationByObjID(ObjId);
            if (EventConfiguration != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, EventConfiguration);
            }
            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }

        public HttpResponseMessage Get(int id)
        {
            var EventConfiguration = _EventConfigurationServices.GetEventConfigurationById(id);
            if (EventConfiguration != null)
                return Request.CreateResponse(HttpStatusCode.OK, EventConfiguration);
            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }

        public int Post([FromBody]EventConfigurationEntity eventConfigurationEntity)
        {
            return _EventConfigurationServices.CreateEventConfiguration(eventConfigurationEntity);
        }

        public bool Put(int id, [FromBody]EventConfigurationEntity eventConfigurationEntity)
        {
            if (id > 0)
            {
                return _EventConfigurationServices.UpdateEventConfiguration(id, eventConfigurationEntity);
            }
            return false;
        }

        public bool Delete(int id)
        {
            if (id > 0)
                return _EventConfigurationServices.DeleteEventConfiguration(id);
            return false;
        }
    }
}
