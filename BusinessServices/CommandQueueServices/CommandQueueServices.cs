using BusinessEntities;
using DataModel;
using DataModel.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Transactions;

namespace BusinessServices.CommandQueueServices
{
    public class CommandQueueServices : ICommandQueueServices
    {
        private readonly UnitOfWork _unitOfWork;

        public CommandQueueServices()
        {
            _unitOfWork = new UnitOfWork();
        }

        /// Creates a product  

        public int CreateCommandQueue(CommandQueueEntity _commandQueueEntity)
        {
            using (var scope = new TransactionScope())
            {
                var commandsQueue = new CommandsQueue
                {
                    ObjectID = _commandQueueEntity.ObjectID,
                    CommandID = _commandQueueEntity.CommandID,
                    CreatedDate = DateTime.Now,
                    UnderProcess = false,
                    UpdatedDate = DateTime.Now

                };
                _unitOfWork.CommandsQueueRepository.Insert(commandsQueue);
                _unitOfWork.Save();
                scope.Complete();
                int res = commandsQueue.CommandsQueueID;
                if (res != 0)
                {
                    using (var scope1 = new TransactionScope())
                    {
                        var commandLogByUserID = new CommandLogByUserID
                        {
                            ObjectID = _commandQueueEntity.ObjectID,
                            CommandID = _commandQueueEntity.CommandID,
                            SensorID = _commandQueueEntity.SensorID,
                            UserID = _commandQueueEntity.UserID,
                            DateTimeStamp = DateTime.Now
                        };

                        _unitOfWork.CommandLogByUserIDRepository.Insert(commandLogByUserID);
                        _unitOfWork.Save();
                        scope1.Complete();
                    }
                    return res;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
    

