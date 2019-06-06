using BusinessEntities;
using BusinessServices.SwitchesReportServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace TIOT_API.Controllers
{
    public class SwitchesReportController : ApiController
    {

        private readonly ISwitchesReportServices _SwitchesReportServices;
        public SwitchesReportController()
        {
            _SwitchesReportServices = new SwitchesReportServices();
        }

        public HttpResponseMessage GetCurrentDateControlling(int ObjectID)
        {
            var Values = _SwitchesReportServices.GetCurrentDateControlling(ObjectID);
            if (Values != null)
            {
                var reportControlingEntities = Values as List<CurrentDateCONTROL_SW_ReportEntity> ?? Values.ToList();

                return Request.CreateResponse(HttpStatusCode.OK, reportControlingEntities);
            }

            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }
        public HttpResponseMessage GetCurrentDateConsumption(int ObjectID , string sensor)
        {
            var report = _SwitchesReportServices.GetCurrentDateConsumption(ObjectID,  sensor);
            if (report != null)
            {
                var reportEntities = report as List<CurrentDateCON_SW_ReportEntity> ?? report.ToList();
                if (reportEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, reportEntities);
            }

            return Request.CreateResponse(HttpStatusCode.OK, "[]");

        }
        public HttpResponseMessage GetByDate(int ObjectId, DateTime StartDateTime, DateTime EndDateTime)
        {
            var Switches = _SwitchesReportServices.GetSwitchesReportByObject(ObjectId, StartDateTime, EndDateTime);
            var SwitchesEntities = Switches as List<SwitchesReportEntity> ?? Switches.ToList();
            if (SwitchesEntities.Any())
                return Request.CreateResponse(HttpStatusCode.OK, SwitchesEntities);
                return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }
      

    }
}