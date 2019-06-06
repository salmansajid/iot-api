using BusinessServices.TAVL;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TavlWeb.WebAPI.Authentication;

namespace TIOT_API.Controllers
{
    public class TavlServiceController : ApiController
    {
        TAVLService TS = new TAVLService();

        public HttpResponseMessage Get(int ClientId, int GroupId, String IPAddress, string isReverseGeocoding)
        {
            IPAddress = "http://" + IPAddress+ "/";
            var response = TS.AdminLogin(ClientId, GroupId, IPAddress, isReverseGeocoding);
            if (response != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }
    }
}
