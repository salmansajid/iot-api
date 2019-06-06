using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessServices.CommandQueueServices
{
    public interface ICommandQueueServices
    {
        int CreateCommandQueue(CommandQueueEntity _commandQueueEntity);
    }
}
