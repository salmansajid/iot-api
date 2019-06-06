using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessServices.CommandHistoryServices
{
    public interface ICommandHistoryServices
    {
        IEnumerable<sp_GetNONAlertStateEntity> GetByAlertState();
        bool UpdateCommandHistory(long CommandHistoryID, CommandHistoryEntity commandHistoryEntity);
    }
}
