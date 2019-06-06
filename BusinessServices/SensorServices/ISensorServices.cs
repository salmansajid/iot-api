using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessServices.SensorServices
{
    public interface ISensorServices
    {
        SensorEntity GetSensorById(int SensorId);
        IEnumerable<SensorEntity> GetSensorBySensorId(int SensorId);
        //IEnumerable<SensorEntity> GetObjectByGroupAndLoginId(int GroupID, int LoginID);
        IEnumerable<SensorEntity> GetAllSensors();
        IEnumerable<SensorEntity> GetNonAssignedSensors(int ObjectID);
        //IEnumerable<SensorEntity> GetNonAssignedSensorsForEventConfig(int ObjectID);
        int CreateSensor(SensorEntity sensorEntity);
        bool UpdateSensor(int SensorId, SensorEntity sensorEntity);
        bool DeleteSensor(int SensorId);
    }
}
