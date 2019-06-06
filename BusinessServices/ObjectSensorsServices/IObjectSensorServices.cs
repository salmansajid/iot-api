using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessServices.ObjectSensorsServices
{
    public interface IObjectSensorServices
    {
        ObjectSensorsEntity GetObjectSensorsById(int ObjectSensorsId);
        IEnumerable<ObjectSensorsGrid> GetObjectSensorsByObjectId(int ObjectId);
        IEnumerable<SensorIDSourceID> GetObjectSensorsBySensorIdAndObjectId(int ObjectId, int SensorId);
        IEnumerable<ObjectSensorsEntity> GetObjectSensorNameAndSensorIDs(int ObjectId);
        IEnumerable<OBJSIDName> GetObjectSensorForScheduling(int ObjtId);
        IEnumerable<ObjectSensorsGrid> GetAllObjectSensors();
        long CreateObjectSensors(ObjectSensorsEntity objectsensorsEntity);
        bool UpdateObjectSensors(long ObjectSensorsId, ObjectSensorsEntity objectsensorsEntity);
        bool DeleteObjectSensors(int ObjectSensorsId);
        IEnumerable<SensorObjectGroupEntity> GetAllGetSensorObjectGroup();
        ObjectSensorsEntity GetObjectSensorsByObjIdAndSenIdForMobile(int ObjectId, int SensorId);
        ObjNameObjSNameCateNameEntity GetObjectSensorsByObjIdAndSenIdForNotify(int ObjectId, int SensorId);
    }
}
