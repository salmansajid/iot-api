using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessServices.EventLogServices
{
    public interface IEventLogServices
    {
        EventLogEntity GetEventByObjectId(int ObjectId);
        IEnumerable<Object_EventLogEntity> GetEventByObjectAndDT(int ObjectId, DateTime StartTime, DateTime EndTime);
   
        //IEnumerable<EventLogEntity> GetAllEvents();
        //int CreateFeature(FeatureEntity featureEntity);
        //bool UpdateFeature(int FeatureId, FeatureEntity featureEntity);
        //bool DeleteFeature(int FeatureId);
    }
}
