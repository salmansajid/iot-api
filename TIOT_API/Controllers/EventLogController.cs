using BusinessEntities;
using BusinessServices.EventLogServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api.Controllers
{
    public class EventLogController : ApiController
    {

        private readonly IEventLogServices _EventLogServices;

         public EventLogController()
        {
            _EventLogServices = new EventLogServices();
        }

        //// GET api/eventlog
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

         //GET api/eventlog/5
         public HttpResponseMessage GetByObjectId(int ObjectId)
        {
            var events = _EventLogServices.GetEventByObjectId(ObjectId);
            if (events != null)
            {
                var EventLogEntities = events as EventLogEntity ?? events;

                return Request.CreateResponse(HttpStatusCode.OK, EventLogEntities);
            }

            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }

         public HttpResponseMessage GetByObjectAndDT(int ObjectId, DateTime StartTime, DateTime EndTime)
        {
            var events = _EventLogServices.GetEventByObjectAndDT(ObjectId, StartTime, EndTime);
            if (events != null)
            {
                var eventsEntities = events as List<Object_EventLogEntity> ?? events.ToList();
                if (eventsEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, eventsEntities);
            }

            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }




        

        //// POST api/eventlog
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/eventlog/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/eventlog/5
        //public void Delete(int id)
        //{
        //}
    }
}
