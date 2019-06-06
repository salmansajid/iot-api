using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntities;

namespace BusinessServices.ClientServices
{
    public interface IClientServices
    {
        ClientEntity GetClientById(int ClientId);
        IEnumerable<ClientEntity> GetAllClients();
        int CreateClient(ClientEntity clientEntity);
        bool UpdateClient(int ClientId, ClientEntity clientEntity);
        bool DeleteClient(int ClientId);
    }
}
