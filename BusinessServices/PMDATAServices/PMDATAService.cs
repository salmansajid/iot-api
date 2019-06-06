using AutoMapper;
using BusinessEntities;
using DataModel;
using DataModel.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessServices.PMDATAServices
{
    public class PMDATAService : IPMDATAService
    {
          private readonly UnitOfWork _unitOfWork;   
         /// <summary>  
         /// Public constructor.  
         /// </summary>  
          public PMDATAService()  
         {  
             _unitOfWork = new UnitOfWork();  
         }

          public PMDATAEntity GetPMDATAById(int PMDATAId)
        {
            var _PMDATA = _unitOfWork.PMDATARepository.GetByID(PMDATAId);
            if (_PMDATA != null)
            {
                Mapper.CreateMap<PMDATA, PMDATAEntity>();
                var PMDATAModel = Mapper.Map<PMDATA, PMDATAEntity>(_PMDATA);
                return PMDATAModel;
            }
            return null;
        }

        /// Fetches all the products.  
          public IEnumerable<PMDATAEntity> GetAllPMDATA()
          {
              var _PMDATA = _unitOfWork.PMDATARepository.GetAll().ToList();
              if (_PMDATA != null)
              {
                  Mapper.CreateMap<PMDATA, PMDATAEntity>();
                  var PMDATAModel = Mapper.Map<List<PMDATA>, List<PMDATAEntity>>(_PMDATA);
                  return PMDATAModel;
              }
              return null;
          }


    }
}
