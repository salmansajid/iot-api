using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessEntities;
using BusinessServices.ClientServices;

namespace api.Controllers
{
    public class ClientController : ApiController
    {
        
        private readonly  IClientServices _ClientServices;

        public ClientController()
        {
            _ClientServices = new ClientServices();
        }

        // GET api/client  
        public HttpResponseMessage Get()
        {
            var clients = _ClientServices.GetAllClients();
                var clientEntities = clients as List<ClientEntity> ?? clients.ToList();
                if (clientEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, clientEntities);
                return Request.CreateResponse(HttpStatusCode.OK, "[]");

        }

        // GET api/client/5
        public HttpResponseMessage Get(int id)
        {
            var client = _ClientServices.GetClientById(id);
            if(client!=null)
                return Request.CreateResponse(HttpStatusCode.OK, client);


            return Request.CreateResponse(HttpStatusCode.OK, "[]");
        }

        // POST api/client
        public int Post([FromBody]ClientEntity clientEntity)
        {
            int Id;
            Id =  _ClientServices.CreateClient(clientEntity);
            if (Id != null)
            {
                return Id;
            }
            else
            {
                Id = 0;
                return Id;
            }
            
        }

        // PUT api/client/5
        public bool Put(int id, [FromBody]ClientEntity clientEntity)
        {
            if (id > 0)
            {
                return _ClientServices.UpdateClient(id, clientEntity);
            }
            return false;
        }

        // DELETE api/client/5
        public bool Delete(int id)
        {
            if (id > 0)
                return _ClientServices.DeleteClient(id);
            return false;
        }
    }
}
