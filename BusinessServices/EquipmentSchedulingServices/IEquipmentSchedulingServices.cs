using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessServices.EquipmentSchedulingServices
{
    public interface IEquipmentSchedulingServices
    {
        EquipmentSchedulingEntity GetEquipmentSchedulingById(int EquipmentSchedulingId);
        IEnumerable<sp_EquipmentSchedulingEntity> GetEquipmentSchedulingByObjectIdAndDayId(int ObjectId, int DayId);
        IEnumerable<sp_EquipmentSchedulingEntity> GetEquipmentSchedulingByObjDayObjsIds(int ObjectId, int ObjectsensorId);
        IEnumerable<sp_EquipmentSchedulingEntity> GetEquipmentSchedulingByObjectId_DayIdAndOBJId(int ObjectId, int DayId, int ObjectSensorId);
        IEnumerable<EquipmentSchedulingEntity> GetEquipmentScheduling();
        int CreateEquipmentScheduling(EquipmentSchedulingEntity equipmentSchedulingEntity);
        bool UpdateEquipmentScheduling(int EquipmentSchedulingId, EquipmentSchedulingEntity equipmentSchedulingEntity);
        bool DeleteEquipmentScheduling(int EquipmentSchedulingId);
    }
}
