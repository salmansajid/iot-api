using BusinessEntities;
using BusinessServices.DinStateServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TIOT_API.Controllers
{
    public class DinState1Controller : ApiController
    {

        private readonly  IDinStateService _DinStateService;

        public DinState1Controller()
        {
            _DinStateService = new DinStateServices();
        }

        // GET api/client  
        public HttpResponseMessage Get(int ObjectId, DateTime Startdate, DateTime Enddate)
        {
            var res = _DinStateService.GetDinState1Today(ObjectId,Startdate,Enddate);
            var resEntities = res as List<uspReport_DinState1Entity> ?? res.ToList();
            if (resEntities.Any())
                return Request.CreateResponse(HttpStatusCode.OK, resEntities);
                return Request.CreateResponse(HttpStatusCode.OK, "[]");

        }

    }
}
