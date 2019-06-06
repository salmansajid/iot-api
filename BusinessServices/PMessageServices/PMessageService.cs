using AutoMapper;
using BusinessEntities;
using DataModel;
using DataModel.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessServices.PMessageServices
{
    public class PMessageService :IPMessageService
    {
          private readonly UnitOfWork _unitOfWork;   
         /// <summary>  
         /// Public constructor.  
         /// </summary>  
          public PMessageService()  
         {  
             _unitOfWork = new UnitOfWork();  
         }
          public PMessageEntity GetPMessageById(int PMessageId)
        {
            var PMessage = _unitOfWork.PMessageRepository.GetByID(PMessageId);
            if (PMessage != null)
            {
                Mapper.CreateMap<PMessage, PMessageEntity>();
                var PMessageModel = Mapper.Map<PMessage, PMessageEntity>(PMessage);
                return PMessageModel;
            }
            return null;
        }

        /// Fetches all the products.  

          public IEnumerable<PMessageEntity> GetAllPMessages()
          {
              var PMessages = _unitOfWork.PMessageRepository.GetAll().ToList();
              if (PMessages != null)
              {
                  Mapper.CreateMap<PMessage, PMessageEntity>();
                  var PMessageModel = Mapper.Map <List<PMessage>, List<PMessageEntity>>(PMessages);
                  return PMessageModel;
              }
              return null;
          }
    }
}
