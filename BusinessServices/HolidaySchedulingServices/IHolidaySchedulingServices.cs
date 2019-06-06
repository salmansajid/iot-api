using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessServices.HolidaySchedulingServices
{
    public interface IHolidaySchedulingServices
    {
        IEnumerable<FederalHolidayEntity> GetHolidayByGroupId(int GroupId);
        FederalHolidayEntity GetHolidayById(int HolidayId);
        IEnumerable<FederalHolidayEntity> GetHolidays();
        int CreateHoliday(FederalHolidayEntity holidayEntity);
        bool UpdateHoliday(int HolidayId, FederalHolidayEntity holidayEntity);
        bool DeleteHoliday(int HolidayID);
    }
}
