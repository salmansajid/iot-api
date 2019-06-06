using BusinessEntities;
using BusinessServices.EquipmentSchedulingServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api.Controllers
{
    public class EquipmentSchedulingController : ApiController
    {
        private readonly IEquipmentSchedulingServices _EquipmentSchedulingServices;

        public EquipmentSchedulingController()
        {
            _EquipmentSchedulingServices = new EquipmentSchedulingServices();
        }

        public HttpResponseMessage Get()
        {
            var EquipmentScheduling = _EquipmentSchedulingServices.GetEquipmentScheduling();
            if (EquipmentScheduling != null)
            {
                var EquipmentSchedulingEntities = EquipmentScheduling as List<EquipmentSchedulingEntity> ?? EquipmentScheduling.ToList();
                if (EquipmentSchedulingEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, EquipmentSchedulingEntities);
            }
            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }

        public HttpResponseMessage GetByObjectIdAndDayId(int ObjectId, int DayId)
        {
            var EquipmentScheduling = _EquipmentSchedulingServices.GetEquipmentSchedulingByObjectIdAndDayId(ObjectId, DayId);
            if (EquipmentScheduling != null)
            {
                var EquipmentSchedulingEntities = EquipmentScheduling as List<sp_EquipmentSchedulingEntity> ?? EquipmentScheduling.ToList();
                if (EquipmentSchedulingEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, EquipmentSchedulingEntities);
            }
            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }

        public HttpResponseMessage GetByObjDayOBJSIdsforWeek(int ObjId, int ObjSensorId)
        {
            var EquipmentScheduling = _EquipmentSchedulingServices.GetEquipmentSchedulingByObjDayObjsIds(ObjId, ObjSensorId);
            if (EquipmentScheduling != null)
            {
                var EquipmentSchedulingEntities = EquipmentScheduling as List<sp_EquipmentSchedulingEntity> ?? EquipmentScheduling.ToList();
                if (EquipmentSchedulingEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, EquipmentSchedulingEntities);
            }
            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }


        public HttpResponseMessage GetByObjectIdDayIdAndOBJSId(int ObjectId, int DayId, int ObjectSensorId)
        {
            var EquipmentScheduling = _EquipmentSchedulingServices.GetEquipmentSchedulingByObjectId_DayIdAndOBJId(ObjectId, DayId, ObjectSensorId);
            if (EquipmentScheduling != null)
            {
                var EquipmentSchedulingEntities = EquipmentScheduling as List<sp_EquipmentSchedulingEntity> ?? EquipmentScheduling.ToList();
                if (EquipmentSchedulingEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, EquipmentSchedulingEntities);
            }
            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }

        public HttpResponseMessage Get(int id)
        {
            var EquipmentScheduling = _EquipmentSchedulingServices.GetEquipmentSchedulingById(id);
            if (EquipmentScheduling != null)
                return Request.CreateResponse(HttpStatusCode.OK, EquipmentScheduling);
            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }

        public int Post([FromBody]EquipmentSchedulingEntity equipmentSchedulingEntity)
        {
            return _EquipmentSchedulingServices.CreateEquipmentScheduling(equipmentSchedulingEntity);
        }

        public bool Put(int id, [FromBody]EquipmentSchedulingEntity equipmentSchedulingEntity)
        {
            if (id > 0)
            {
                return _EquipmentSchedulingServices.UpdateEquipmentScheduling(id, equipmentSchedulingEntity);
            }
            return false;
        }

        public bool Delete(int id)
        {
            if (id > 0)
                return _EquipmentSchedulingServices.DeleteEquipmentScheduling(id);
            return false;
        }
    }
}
