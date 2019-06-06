using BusinessEntities;
using BusinessServices.CommandHistoryServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api.Controllers
{
    public class CommandHistoryController : ApiController
    {
        
        // GET api/category

        private readonly ICommandHistoryServices _CommandHistoryServices;

        public CommandHistoryController()
        {
            _CommandHistoryServices = new CommandHistoryServices();
        }

        // GET api/client  
        public HttpResponseMessage Get()
        {
            var cmdHistory = _CommandHistoryServices.GetByAlertState();
            if (cmdHistory != null)
            {
                var cmdHistoryEntities = cmdHistory as List<sp_GetNONAlertStateEntity> ?? cmdHistory.ToList();
                if (cmdHistoryEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, cmdHistoryEntities);
            }

            return Request.CreateResponse(HttpStatusCode.OK, "[]");

        }





        public bool Put(int id, [FromBody]CommandHistoryEntity commandHistoryEntity)
        {
            if (id > 0)
            {
                return _CommandHistoryServices.UpdateCommandHistory(id, commandHistoryEntity);
            }
            return false;
        }

       
    }
}