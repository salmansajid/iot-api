using BusinessEntities;
using DataModel.UnitOfWork;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace BusinessServices.CommandHistoryServices
{
    public class CommandHistoryServices : ICommandHistoryServices
    {
        private readonly UnitOfWork _unitOfWork;

        public CommandHistoryServices()
        {
            _unitOfWork = new UnitOfWork();
        }

        public IEnumerable<sp_GetNONAlertStateEntity> GetByAlertState()
        {
            var sp_AlertState = _unitOfWork.sp_GetNONAlertStateRepository.ExecWithStoreProcedure(
               "sp_GetNONAlertState"
               ).ToList();

            if (sp_AlertState.Any())
            {
                string ser = JsonConvert.SerializeObject(sp_AlertState);
                List<sp_GetNONAlertStateEntity> sp_AlertStateModel = JsonConvert.DeserializeObject<List<sp_GetNONAlertStateEntity>>(ser);
                return sp_AlertStateModel;
            }
            else
            {
                return null;
            }
        }

        public bool UpdateCommandHistory(long CommandHistoryID, CommandHistoryEntity commandHistoryEntity)
        {
            var success = false;
            if (commandHistoryEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var cmdhistory = _unitOfWork.CommandHistoryRepository.GetByID(CommandHistoryID);
                    if (cmdhistory != null)
                    {

                        cmdhistory.AlertState = commandHistoryEntity.AlertState;
                        _unitOfWork.CommandHistoryRepository.Update(cmdhistory);
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

