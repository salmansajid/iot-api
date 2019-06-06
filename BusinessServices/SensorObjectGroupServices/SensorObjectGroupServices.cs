using AutoMapper;
using BusinessEntities;
using DataModel;
using DataModel.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessServices.SensorObjectGroupServices
{
    public class SensorObjectGroupServices : ISensorObjectGroup
    {
          
        private readonly UnitOfWork _unitOfWork;   
       
        public SensorObjectGroupServices()  
         {  
             _unitOfWork = new UnitOfWork();  
         }

        public IEnumerable<SensorObjectGroupEntity> GetAllGetSensorObjectGroup()
        {
            var values = _unitOfWork.SensorObjectGroupRepository.GetAll().ToList();
            if (values.Any())
            {
                Mapper.CreateMap<SensorObjectGroup, SensorObjectGroupEntity>();
                var categoryModel = Mapper.Map<List<SensorObjectGroup>, List<SensorObjectGroupEntity>>(values.ToList());
                return categoryModel;
            }
            return null;
        }
    }
}
