using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessServices.PMessageServices
{
    public interface IPMessageService
    {
        PMessageEntity GetPMessageById(int PMessageId);
        //IEnumerable<FeatureEntity> GetFeatureByLoginId(int LoginId);
        IEnumerable<PMessageEntity> GetAllPMessages();
    }
}
