using BusinessEntities;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessServices.ObjectServices
{
    public interface IObjectServices
    {
        ObjectEntity GetObjectById(int ObjectId);
        IEnumerable<ObjectstatusEntity> GetObjectByGroupId(int GroupId);
        IEnumerable<ObjectEntity> GetObjectByGroupAndLoginId(int GroupID, int LoginID);
        IEnumerable<Objects> GetAllObjects();
        IEnumerable<uspGET_ObjectIDNameByGroup_Result> GetObjIDNameByGroup(int groupID);

        IEnumerable<ObjectdetailsNew> GetObjectDetailNew(int ObjectId);
        IEnumerable<ObjectDashboardEntity> GetObjectDashboardAttendance();
        IEnumerable<Objects> GetObjectByClientId(int clientID);
        int CreateObject(ObjectEntity objectEntity);
        bool UpdateObject(int ObjectId, ObjectEntity objectEntity);

        bool UpdateTavlIntegration(int ObjectId, TavlIntegration tavlIntegration);
        bool UpdateSurveillanceIntegration(int ObjectId, SurveillanceIntegration surveillanceIntegration);
        bool UpdateAttendanceIntegration(int ObjectId, AttendanceIntegration attendanceIntegration);

        bool UpdateTavlStatus(int ObjectId);
        bool UpdateSurveillanceStatus(int ObjectId);
        bool UpdateAttendanceStatus(int ObjectId);

        IEnumerable<TavlIntegration> GetTavlStatusByObjectId(int ObjectId);
        IEnumerable<AttendanceIntegration> GetAttendanceStatusByObjectId(int ObjectId);
        IEnumerable<SurveillanceIntegration> GetSurveillanceStatusByObjectId(int ObjectId);
        bool DeleteObject(int ObjectId);
    }
}
