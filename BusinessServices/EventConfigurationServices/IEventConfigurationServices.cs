using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessServices.EventConfigurationServices
{
    public interface IEventConfigurationServices
    {
        EventConfigurationEntity GetEventConfigurationById(int EventConfigID);
        IEnumerable<EventConfigurationGridEntity> GetEventConfigurationByObjectId(int ObjectId);
        IEnumerable<EventConfigurationEntity> GetEventConfiguration();
        IEnumerable<EventConfigurationLocationEntity> GetEventConfigurationLocationByObjID(int ObjectID);
        int CreateEventConfiguration(EventConfigurationEntity eventConfigurationEntity);
        bool UpdateEventConfiguration(int EventConfigID, EventConfigurationEntity eventConfigurationEntity);
        bool DeleteEventConfiguration(int EventConfigID);
    }
}
