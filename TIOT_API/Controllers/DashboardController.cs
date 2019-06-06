using BusinessEntities;
using BusinessServices.DashboardServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TIOT_API.Controllers
{
    public class DashboardController : ApiController
    {
        private readonly IDashboardServices _DashboardServices;

         public DashboardController()
        {
            _DashboardServices = new DashboardServices();
        }

         public HttpResponseMessage Get(int ObjectID)
        {
            var Relays = _DashboardServices.GetRelayStatus(ObjectID);
            if (Relays != null)
            {
                var RelaysEntities = Relays as List<DashboardEntity> ?? Relays.ToList();
                if (RelaysEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, RelaysEntities);
            }
            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }
    }
}
