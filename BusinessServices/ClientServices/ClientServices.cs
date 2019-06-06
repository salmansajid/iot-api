using AutoMapper;
using BusinessEntities;
using DataModel;
using DataModel.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace BusinessServices.ClientServices
{
  public  class ClientServices:IClientServices
    {
        private readonly UnitOfWork _unitOfWork;  
      
         /// <summary>  
         /// Public constructor.  
         /// </summary>  
        public ClientServices()  
         {  
             _unitOfWork = new UnitOfWork();  
         }
        /// <summary>  
        /// Fetches product details by id  
        /// </summary>  
        /// <param name="productId"></param>  
        /// <returns></returns>  
        public ClientEntity GetClientById(int clientId)
        {
            var client = _unitOfWork.ClientRepository.GetByID(clientId);
            if (client != null)
            {
                Mapper.CreateMap<Client, ClientEntity>();
                var clientModel = Mapper.Map<Client, ClientEntity>(client);
                return clientModel;
            }
            return null;
        }

        /// <summary>  
        /// Fetches all the products.  
        /// </summary>  
        /// <returns></returns>  
        public IEnumerable<ClientEntity> GetAllClients()
        {

            var clients = _unitOfWork.ClientRepository.GetAll().ToList();
            if (clients.Any())
            {
                Mapper.CreateMap<Client, ClientEntity>();
                var clinfo = from cl in clients
                             where cl.Deleted == false
                             orderby cl.ClientID descending
                             select cl;
                var clientsModel = Mapper.Map<List<Client>, List<ClientEntity>>(clinfo.ToList());
                return clientsModel;
            }
       
            return null;
        }

        /// <summary>  
        /// Creates a product  
        /// </summary>  
        /// <param name="productEntity"></param>  
        /// <returns></returns>  
        public int CreateClient(ClientEntity clientEntity)
        {
            using (var scope = new TransactionScope())
            {
                var client = new Client
                {
                    Name = clientEntity.Name,
                    Address = clientEntity.Address,
                    OperatorID = clientEntity.OperatorID,
                    Contact = clientEntity.Contact,
                    Code = clientEntity.Code,
                    Enabled = clientEntity.Enabled,
                    Email = clientEntity.Email,
                    ExpireDate = clientEntity.ExpireDate,
                    Deleted = clientEntity.Deleted

                    
                    
                };

                _unitOfWork.ClientRepository.Insert(client);
                _unitOfWork.Save();
                scope.Complete();
                return client.ClientID;
            }
        }

        /// <summary>  
        /// Updates a product  
        /// </summary>  
        /// <param name="productId"></param>  
        /// <param name="productEntity"></param>  
        /// <returns></returns>  
        public bool UpdateClient(int clientId, ClientEntity clientEntity)
        {
            var success = false;
            if (clientEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var client = _unitOfWork.ClientRepository.GetByID(clientId);
                    if (client != null)
                    {
                        client.Name = clientEntity.Name;
                        client.Address = clientEntity.Address;
                        client.OperatorID = clientEntity.OperatorID;
                        client.Contact = clientEntity.Contact;
                        client.Code = clientEntity.Code;
                        client.Enabled = clientEntity.Enabled;
                        client.Email = clientEntity.Email;
                        client.ExpireDate = clientEntity.ExpireDate;
                        client.Deleted = clientEntity.Deleted;
                        _unitOfWork.ClientRepository.Update(client);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        /// <summary>  
        /// Deletes a particular product  
        /// </summary>  
        /// <param name="productId"></param>  
        /// <returns></returns>  
        public bool DeleteClient(int clientId)
        {
            var success = false;
            if (clientId > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var client = _unitOfWork.ClientRepository.GetByID(clientId);
                    if (client != null)
                    {

                        _unitOfWork.ClientRepository.Delete(client);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }


    }
}
