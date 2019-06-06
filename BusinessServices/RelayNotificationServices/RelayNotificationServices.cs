using AutoMapper;
using BusinessEntities;
using DataModel;
using DataModel.UnitOfWork;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessServices.RelayNotificationServices
{
   public class RelayNotificationServices : IRelayNotificationServices
    {
           private readonly UnitOfWork _unitOfWork;   
         /// <summary>  
         /// Public constructor.  
         /// </summary>  
           public RelayNotificationServices()  
         {  
             _unitOfWork = new UnitOfWork();  
         }

           public IEnumerable<RelayNotificationEntity> GetByClientId(int ClientID, DateTime LastTime)
           {
               var values = _unitOfWork.RelayNotificationRepository.GetAll().ToList();
               if (values != null)
               {
                   var re = from sc in values
                            where sc.ClientID == ClientID && sc.DateTime > LastTime
                            orderby sc.DateTime descending
                            select sc;
                   string st = JsonConvert.SerializeObject(re);
                   List<RelayNotificationEntity> RelayModel = JsonConvert.DeserializeObject<List<RelayNotificationEntity>>(st);
                   return RelayModel;
               }
               return null;
           }

           public IEnumerable<RelayNotificationEntity> GetByGroupId(int GroupID, DateTime LastTime)
           {
               var values = _unitOfWork.RelayNotificationRepository.GetAll().ToList();
               if (values != null)
               {
                   var re = from sc in values
                            where sc.GroupID == GroupID && sc.DateTime > LastTime
                            orderby sc.DateTime descending 
                            select sc;
                   string st = JsonConvert.SerializeObject(re);
                   List<RelayNotificationEntity> RelayModel = JsonConvert.DeserializeObject<List<RelayNotificationEntity>>(st);
                   return RelayModel;
               }
               return null;
           }
    }
}
