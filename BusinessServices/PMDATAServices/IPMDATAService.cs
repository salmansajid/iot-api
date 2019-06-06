using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessServices.PMDATAServices
{
    interface IPMDATAService
    {
        PMDATAEntity GetPMDATAById(int PMDATAId);
        //IEnumerable<FeatureEntity> GetFeatureByLoginId(int LoginId);
        IEnumerable<PMDATAEntity> GetAllPMDATA();
    }
}
