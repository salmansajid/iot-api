using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessServices.SensorCommandServices
{
    public interface ISensorCommandServices
    {
        
        IEnumerable<SensorCommandEntity> GetAllSensorCommands();
        IEnumerable<SensorCommandEntity> GetSensorCommandBySensorId(int SensorId);
        IEnumerable<SensorCommandEntity> GetSensorCommandByCommandId(int CommandId);
        
    }
}
