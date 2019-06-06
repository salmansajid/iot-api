using BusinessEntities;
using BusinessServices;
using BusinessServices.SchedulingServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api.Controllers
{
    public class SchedulingController : ApiController
    {
        private readonly ISchedulingServices _schedulingServices;

        public SchedulingController()
        {
            _schedulingServices = new SchedulingServices();
        }

        public HttpResponseMessage Get(int id)
        {
            var Schedule = _schedulingServices.GetScheduleById(id);
            if (Schedule != null)
                return Request.CreateResponse(HttpStatusCode.OK, Schedule);


            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }

        public HttpResponseMessage GetByObjectID(int ObjectID, int DayID)
        {
            var Schedules = _schedulingServices.GetScheduleByObjectId(ObjectID, DayID);
            if (Schedules != null)
            {
                var scheduleEntities = Schedules as List<SchedulingEntity> ?? Schedules.ToList();
                if (scheduleEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, scheduleEntities);
            }

            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }

        public HttpResponseMessage GetByObjIDAndDayID(int ObjID, int dayID)
        {
            var Schedules = _schedulingServices.GetScheduleByObjectIdAndDayID(ObjID, dayID);
            if (Schedules != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Schedules);
            }

            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }

        public HttpResponseMessage GetByObIDAndDayALL(int ObjID, int dayID, int sensorId)
        {
            
            var Schedules = _schedulingServices.GetScheduleByObjectIdAndALLDay(ObjID, dayID, sensorId);
            if (Schedules != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Schedules);
            }

            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }

        // GET api/login  
        public HttpResponseMessage Get()
        {
            var schedules = _schedulingServices.GetSchedules();
        
            if (schedules != null)
            {
                var scheduleEntities = schedules as List<SchedulingEntity> ?? schedules.ToList();
                if (scheduleEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, scheduleEntities);
            }

            return Request.CreateResponse(HttpStatusCode.OK, "[]");

        }
        
        // POST api/login
        public int Post([FromBody] SchedulingEntity schedulingEntity)
        {
            int Id;
            Id = _schedulingServices.CreateScheduling(schedulingEntity);
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
        public bool Put(int id, [FromBody]SchedulingEntity schedulingEntity)
        {
            if (id > 0)
            {
                return _schedulingServices.UpdateScheduling(id, schedulingEntity);
            }
            return false;
        }

        public bool Delete(int ObjectID, int CommandID , int DayID)
        {
            if (ObjectID > 0)
                return _schedulingServices.DeleteScheduling(ObjectID, CommandID, DayID);
            return false;
        }
    }
}
