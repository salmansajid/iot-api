using BusinessEntities;
using BusinessServices.CommandQueueServices;
using BusinessServices.ObjCommandServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api.Controllers
{
    public class CommandQueueController : ApiController
    {
        private readonly ICommandQueueServices _CommandQueueServices;

         public CommandQueueController()
        {
            _CommandQueueServices = new CommandQueueServices();
        }
        // POST api/
         public int Post([FromBody]CommandQueueEntity _commandQueueEntity)
        {
            return _CommandQueueServices.CreateCommandQueue(_commandQueueEntity);
        }

    }
}
