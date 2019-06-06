using BusinessEntities;
using BusinessServices.HolidaySchedulingServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api.Controllers
{
    public class HolidaySchedulingController : ApiController
    {
        private readonly IHolidaySchedulingServices _HolidaySchedulingServices;

         public HolidaySchedulingController()
        {
            _HolidaySchedulingServices = new HolidaySchedulingServices();
        }

         public HttpResponseMessage Get(int Id)
        {
            var Holiday = _HolidaySchedulingServices.GetHolidayById(Id);
            if (Holiday != null)
                return Request.CreateResponse(HttpStatusCode.OK, Holiday);


            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }

        public HttpResponseMessage GetByGroupID(int GroupID)
        {
            var Holidays = _HolidaySchedulingServices.GetHolidayByGroupId(GroupID);
            if (Holidays != null)
            {
                var HolidayEntities = Holidays as List<FederalHolidayEntity> ?? Holidays.ToList();
                if (HolidayEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, HolidayEntities);
            }

            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }

        // GET api/login  
        public HttpResponseMessage Get()
        {
            var Holidays = _HolidaySchedulingServices.GetHolidays();

            if (Holidays != null)
            {
                var HolidayEntities = Holidays as List<FederalHolidayEntity> ?? Holidays.ToList();
                if (HolidayEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, HolidayEntities);
            }

            return Request.CreateResponse(HttpStatusCode.OK, "[]");

        }
        
        // POST api/login
        public int Post([FromBody] FederalHolidayEntity federalHolidayEntity)
        {
            int Id;
            Id = _HolidaySchedulingServices.CreateHoliday(federalHolidayEntity);
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
        public bool Put(int Id, [FromBody]FederalHolidayEntity federalHolidayEntity)
        {
            if (Id > 0)
            {
                return _HolidaySchedulingServices.UpdateHoliday(Id, federalHolidayEntity);
            }
            return false;
        }

        public bool Delete(int Id)
        {
            if (Id > 0)
                return _HolidaySchedulingServices.DeleteHoliday(Id);
            return false;
        }
    }
}
