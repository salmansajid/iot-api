using BusinessEntities;
using DataModel;
using DataModel.UnitOfWork;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Transactions;

namespace BusinessServices.ObjCommandServices
{
    public class ObjCommandServices : IObjCommandServices
    {
        private readonly UnitOfWork _unitOfWork;

        public ObjCommandServices()
        {
            _unitOfWork = new UnitOfWork();
        }
      
        /// Creates a product  

        public int CreateObjCommand(ObjCommandEntity _objCommandEntity)
        {
            using (var scope = new TransactionScope())
            {
                var objectCommand = new ObjectCommand
                {
                    ObjectID = _objCommandEntity.ObjectID,
                    CommandID = _objCommandEntity.CommandID
                };

                _unitOfWork.ObjCommandRepository.Insert(objectCommand);
                _unitOfWork.Save();
                scope.Complete();
                return objectCommand.CommandsQueueID;
                
            }
        }
      


    }
}
