using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessServices.StatusServices
{
    public interface IStatusServices
    {
        StatusEntity GetstatusById(int StatusId);
        //IEnumerable<FeatureEntity> GetFeatureByLoginId(int LoginId);
        IEnumerable<StatusEntity> GetAllstatus();
        int CreateStatus(StatusEntity statusEntity);
        bool UpdateStatus(int StatusId, StatusEntity statusEntity);
        bool DeleteStatus(int StatusId);
    }
}
