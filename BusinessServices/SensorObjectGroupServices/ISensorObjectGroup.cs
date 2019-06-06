using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessServices.SensorObjectGroupServices
{
    public interface ISensorObjectGroup
    {
        //SensorObjectGroupEntity GetSensorObjectGroupById(int ObjectSensorsId);
        //IEnumerable<SensorObjectGroupEntity> GetSensorObjectGroup(int ObjectId);
        IEnumerable<SensorObjectGroupEntity> GetAllGetSensorObjectGroup();
        //long CreateSensorObjectGroup(SensorObjectGroupEntity sensorObjectGroupEntity);
        //bool UpdateSensorObjectGroup(int SensorObjectGroupId, SensorObjectGroupEntity sensorObjectGroupEntity);
        //bool DeleteSensorObjectGroup(int SensorObjectGroupId);
    }
}
