using BusinessEntities;
using BusinessServices.StoreProcedures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api.Controllers
{
    public class StoreProcedureController : ApiController
    {
        // GET api/category

        private readonly IStoreProcedureServices _StoreProcedureServices;

        public StoreProcedureController()
        {
            _StoreProcedureServices = new StoreProcedureServices();
        }

        public HttpResponseMessage GetbyObjCurVol(int ObjectID, int CurrentID, int VoltageID)
        {
            var Values = _StoreProcedureServices.GetRouteValuesbyPKT(ObjectID, CurrentID, VoltageID);
            if (Values != null)
            {
                var ValuesEntities = Values as List<sp_GetConsumptionTillPackTime> ?? Values.ToList();
                if (ValuesEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, ValuesEntities);
            }
            return Request.CreateResponse(HttpStatusCode.OK, "[]");

        }

        public HttpResponseMessage GetbyObjId_SenIdSMSLOG(int ObjectID, int ObjectSensorID, DateTime StartTime, DateTime EndTime)
        {
            var Values = _StoreProcedureServices.GetSMSLogbyObj_SEN(ObjectID, ObjectSensorID, StartTime, EndTime);
            if (Values != null)
            {
                var ValuesEntities = Values as List<sp_SMSLOGEntity> ?? Values.ToList();
                if (ValuesEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, ValuesEntities);
            }
            return Request.CreateResponse(HttpStatusCode.OK, "[]");

        }

    }
}
