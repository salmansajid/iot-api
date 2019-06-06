using BusinessEntities;
using BusinessServices.ReportService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TIOT_API.Controllers
{
    public class ReportController : ApiController
    {
        private readonly IReportService _ReportService;

            public ReportController()
        {
            _ReportService = new ReportService();
        }

        // GET api/client  
        public HttpResponseMessage Get(int objectId, DateTime startDate,DateTime endDate)
        {
            var result = _ReportService.GetConsumptionByDT(objectId, startDate, endDate);
            if (result != null)
            {
                var entities = result as List<uspGet_EquipmentConsumptionByDTModel> ?? result.ToList();
                if (entities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, entities);
            }

            return Request.CreateResponse(HttpStatusCode.OK, "[]");

        }

    }
}
