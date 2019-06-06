using BusinessEntities;
using BusinessServices.ObjectServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api.Controllers
{
    public class ObjectController : ApiController
    {
        private readonly IObjectServices _ObjectServices;

        public ObjectController()
        {
            _ObjectServices = new ObjectServices();
        }

        public HttpResponseMessage Get()
        {
            var objects = _ObjectServices.GetAllObjects();
            if (objects != null)
            {
                var objectEntities = objects as List<Objects> ?? objects.ToList();
                if (objectEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, objectEntities);
            }
            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }

        public HttpResponseMessage Get(int id)
        {
            var _object = _ObjectServices.GetObjectById(id);
            if (_object != null)
                return Request.CreateResponse(HttpStatusCode.OK, _object);
            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }

        public HttpResponseMessage GetbyClient(int Clientid)
        {
            var _object = _ObjectServices.GetObjectByClientId(Clientid);
            if (_object != null)
                return Request.CreateResponse(HttpStatusCode.OK, _object);

            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }

        public HttpResponseMessage GetObjectdtNew(int ObjId)
        {
            var objects = _ObjectServices.GetObjectDetailNew(ObjId);
            if (objects != null)
            {
                var objectEntities = objects as List<ObjectdetailsNew> ?? objects.ToList();

                return Request.CreateResponse(HttpStatusCode.OK, objectEntities);
            }

            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }

        public HttpResponseMessage Getbygroup(int GroupId)
        {
            var _objects = _ObjectServices.GetObjectByGroupId(GroupId);
            if (_objects != null)
                return Request.CreateResponse(HttpStatusCode.OK, _objects);
            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }

        public HttpResponseMessage GetbygroupAndLogin(int GroupId, int LoginId)
        {
            var _objects = _ObjectServices.GetObjectByGroupAndLoginId(GroupId, LoginId);
            if (_objects != null)
                return Request.CreateResponse(HttpStatusCode.OK, _objects);

            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }

        public HttpResponseMessage GetbyClientIdForDashboard(int clId)
        {
            var _objects = _ObjectServices.GetObjectDashboardAttendance();
            if (_objects != null)
                return Request.CreateResponse(HttpStatusCode.OK, _objects);

            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }

        public HttpResponseMessage GetObjIDNameByGroup(int group_Id)
        {
            var _objects = _ObjectServices.GetObjIDNameByGroup(group_Id);
            if (_objects != null)
                return Request.CreateResponse(HttpStatusCode.OK, _objects);

            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }
        

        public int Post([FromBody]ObjectEntity objectEntity)
        {
            int Id;
            Id = _ObjectServices.CreateObject(objectEntity);
            if (Id != null)
            {
                return Id;
            }
            else
            {
                Id = 0;
                return Id;
            }

        }
        public bool Put(int id, [FromBody]ObjectEntity objectEntity)
        {
            if (id > 0)
            {
                return _ObjectServices.UpdateObject(id, objectEntity);
            }
            return false;
        }




        public HttpResponseMessage GetTavl(int TavlId)
        {
            var _object = _ObjectServices.GetTavlStatusByObjectId(TavlId);
            if (_object != null)
                return Request.CreateResponse(HttpStatusCode.OK, _object);
            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }
        public bool PutTavl(int Objtavlid, [FromBody]TavlIntegration tavlIntegration)
        {
            if (Objtavlid > 0)
            {
                return _ObjectServices.UpdateTavlIntegration(Objtavlid, tavlIntegration);
            }
            return false;
        }
        public bool PutTavlStatus(int ObjectIdTavl)
        {
            if (ObjectIdTavl > 0)
            {
                return _ObjectServices.UpdateTavlStatus(ObjectIdTavl);
            }
            return false;
        }



        public HttpResponseMessage GetAttendance(int AttendanceId)
        {
            var _object = _ObjectServices.GetAttendanceStatusByObjectId(AttendanceId);
            if (_object != null)
                return Request.CreateResponse(HttpStatusCode.OK, _object);
            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }
        public bool PutAttendance(int Objattendanceid, [FromBody]AttendanceIntegration attendanceIntegration)
        {
            if (Objattendanceid > 0)
            {
                return _ObjectServices.UpdateAttendanceIntegration(Objattendanceid, attendanceIntegration);
            }
            return false;
        }
        public bool PutAttendanceStatus(int ObjectIdAttendance)
        {
            if (ObjectIdAttendance > 0)
            {
                return _ObjectServices.UpdateAttendanceStatus(ObjectIdAttendance);
            }
            return false;
        }


        public HttpResponseMessage GetSurveillance(int SurveillanceId)
        {
            var _object = _ObjectServices.GetSurveillanceStatusByObjectId(SurveillanceId);
            if (_object != null)
                return Request.CreateResponse(HttpStatusCode.OK, _object);
            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }
        public bool PutSurveillance(int ObjSurid, [FromBody]SurveillanceIntegration SurveillanceIntegration)
        {
            if (ObjSurid > 0)
            {
                return _ObjectServices.UpdateSurveillanceIntegration(ObjSurid, SurveillanceIntegration);
            }
            return false;
        }
        public bool PutSurveillanceStatus(int ObjectIdSurveillance)
        {
            if (ObjectIdSurveillance > 0)
            {
                return _ObjectServices.UpdateSurveillanceStatus(ObjectIdSurveillance);
            }
            return false;
        }

        public bool Delete(int id)
        {
            if (id > 0)
                return _ObjectServices.DeleteObject(id);
            return false;
        }

    }
}
