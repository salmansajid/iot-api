using BusinessEntities;
using BusinessServices.FirmwareSchedulingServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TIOT_API.Controllers
{
    public class FirmwareSchedulingController : ApiController
    {
        private readonly IFirmwareSchedulingServices _FirmwareSchedulingServices;
        public FirmwareSchedulingController()
        {
            _FirmwareSchedulingServices = new FirmwareSchedulingServices();
        }


        public HttpResponseMessage GetById(int id)
        {
            var obj = _FirmwareSchedulingServices.GetById(id);
            if (obj != null)
                return Request.CreateResponse(HttpStatusCode.OK, obj);
            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }

        public HttpResponseMessage GetFSByClient(int ClientId)
        {
            var obj = _FirmwareSchedulingServices.GetFSByClientId(ClientId);
            if (obj != null)
            {
                var objEntities = obj as List<FirmwareSchedulingEntity> ?? obj.ToList();
                if (objEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, objEntities);
            }

            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }

        public HttpResponseMessage GetFSByObject(int ObjectId)
        {
            var obj = _FirmwareSchedulingServices.GetFSByObjectId(ObjectId);
            if (obj != null)
            {
                var objEntities = obj as List<FirmwareSchedulingEntity> ?? obj.ToList();
                if (objEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, objEntities);
            }

            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }

        public int Post([FromBody]FirmwareSchedulingEntity firmwareSchedulingEntity)
        {
            int Id;
            Id = _FirmwareSchedulingServices.CreateFS(firmwareSchedulingEntity);
            if (Id != 0)
            {
                return Id;
            }
            else
            {
                Id = 0;
                return Id;
            }

        }



        public bool Delete(int id, [FromBody]FirmwareSchedulingEntity firmwareSchedulingEntity)
        {
            if (id > 0)
                return _FirmwareSchedulingServices.DeleteFS(id, firmwareSchedulingEntity);
            return false;
        }

    }
}
