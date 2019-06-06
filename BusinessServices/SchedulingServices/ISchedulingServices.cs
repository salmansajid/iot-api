using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessServices.SchedulingServices
{
    public interface ISchedulingServices
    {
        IEnumerable<SchedulingEntity> GetScheduleByObjectId(int ObjectId, int DayID);
        SchedulingEntity GetScheduleById(int ScheduleId);
        IEnumerable<SchedulingEntity> GetSchedules();
        IEnumerable<SensorSchedulingEntity> GetScheduleByObjectIdAndDayID(int ObjectId, int DayID);
        IEnumerable<SensorSchedulingEntity> GetScheduleByObjectIdAndALLDay(int ObjectId, int DayID, int SensorId);
        int CreateScheduling(SchedulingEntity schedulingEntity);
        bool UpdateScheduling(int SchedulingID, SchedulingEntity schedulingEntity);
        bool DeleteScheduling(int ObjectID, int CommandID, int DayID);
    }
}
