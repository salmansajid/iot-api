using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.FirmwareSchedulingServices
{
    public interface IFirmwareSchedulingServices
    {
        FirmwareSchedulingEntity GetById(int FSId);
        IEnumerable<FirmwareSchedulingEntity> GetFSByClientId(int ClientId);
        IEnumerable<FirmwareSchedulingEntity> GetFSByObjectId(int ObjectId);
        int CreateFS(FirmwareSchedulingEntity firmwareSchedulingEntity);
        bool DeleteFS(int fsId, FirmwareSchedulingEntity firmwareSchedulingEntity);
    }
}
