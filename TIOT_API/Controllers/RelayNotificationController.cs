using BusinessEntities;
using BusinessServices.RelayNotificationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api.Controllers
{
    public class RelayNotificationController : ApiController
    {
        private readonly IRelayNotificationServices _RelayNotificationServices;

         public RelayNotificationController()
        {
            _RelayNotificationServices = new RelayNotificationServices();
        }

        // GET api/client  
        public HttpResponseMessage GetByClientId(int ClientID, DateTime lastTime)
        {
            var Notify = _RelayNotificationServices.GetByClientId(ClientID, lastTime);
            var RelayNotification = Notify as List<RelayNotificationEntity> ?? Notify.ToList();
            if (RelayNotification.Any())
                return Request.CreateResponse(HttpStatusCode.OK, RelayNotification);
                return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }

        public HttpResponseMessage GetByGroupId(int GroupID, DateTime lastTime)
        {
            var Notify = _RelayNotificationServices.GetByGroupId(GroupID, lastTime);
            var RelayNotification = Notify as List<RelayNotificationEntity> ?? Notify.ToList();
            if (RelayNotification.Any())
                return Request.CreateResponse(HttpStatusCode.OK, RelayNotification);
            return Request.CreateResponse(HttpStatusCode.OK, "[]");

        }
    }
}
