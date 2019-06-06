using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.SwitchesReportServices
{
    public interface ISwitchesReportServices
    {
        IEnumerable<SwitchesReportEntity> GetSwitchesReportByObject(int ObjectId, DateTime StartDate, DateTime EndDate);
        IEnumerable<CurrentDateCON_SW_ReportEntity> GetCurrentDateConsumption(int ObjectId, string sensor);
        IEnumerable<CurrentDateCONTROL_SW_ReportEntity> GetCurrentDateControlling(int ObjectId);
        //SwitchesReportEntity GetScheduleById(int ScheduleId);
        //IEnumerable<SwitchesReportEntity> GetSchedules();
        //IEnumerable<SwitchesReportEntity> GetScheduleByObjectIdAndDayID(int ObjectId, int DayID);
        //IEnumerable<SwitchesReportEntity> GetScheduleByObjectIdAndALLDay(int ObjectId, int DayID, int SensorId);
        //int CreateScheduling(SwitchesReportEntity SwitchEntity);
        //bool UpdateScheduling(int SwitchID, SwitchesReportEntity SwitchEntity);
        //bool DeleteScheduling(int SwitchID);
    }
}
