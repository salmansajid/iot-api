using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessServices.RelayNotificationServices
{
    public interface IRelayNotificationServices
    {
        IEnumerable<RelayNotificationEntity> GetByClientId(int ClientID , DateTime LastTime);
        IEnumerable<RelayNotificationEntity> GetByGroupId(int GroupID, DateTime LastTime);
    }
}
