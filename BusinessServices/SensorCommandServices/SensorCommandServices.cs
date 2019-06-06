using AutoMapper;
using BusinessEntities;
using DataModel;
using DataModel.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessServices.SensorCommandServices
{
    public class SensorCommandServices :ISensorCommandServices
    {
         private readonly UnitOfWork _unitOfWork;   
         /// <summary>  
         /// Public constructor.  
         /// </summary>  
         public SensorCommandServices()  
         {  
                _unitOfWork = new UnitOfWork();  
         }
        public IEnumerable<SensorCommandEntity> GetAllSensorCommands()
        {
            var _sensorCommands = _unitOfWork.SensorCommandRepository.GetAll().ToList();
            if (_sensorCommands.Any())
            {
                Mapper.CreateMap<SensorCommand, SensorCommandEntity>();
                var sensorModel = Mapper.Map<List<SensorCommand>, List<SensorCommandEntity>>(_sensorCommands.ToList());
                return sensorModel;
            }
            return null;

        }

        public IEnumerable<SensorCommandEntity> GetSensorCommandBySensorId(int SensorId)
        {
            var _sensorCommands = _unitOfWork.SensorCommandRepository.GetMany(x=> x.SensorID == SensorId).ToList();
            if (_sensorCommands != null)
            {
                Mapper.CreateMap<SensorCommand, SensorCommandEntity>();
                var sensorModel = Mapper.Map<List<SensorCommand>, List<SensorCommandEntity>>(_sensorCommands.ToList());
                return sensorModel;
            }
            return null;

        }

        public IEnumerable<SensorCommandEntity> GetSensorCommandByCommandId(int CommandId)
        {
            var _sensorCommands = _unitOfWork.SensorCommandRepository.GetMany(x => x.CommandID == CommandId).ToList();
            if (_sensorCommands != null)
            {
                Mapper.CreateMap<SensorCommand, SensorCommandEntity>();
                var sensorModel = Mapper.Map<List<SensorCommand>, List<SensorCommandEntity>>(_sensorCommands.ToList());
                return sensorModel;
            }
            return null;

        }
    }
}
