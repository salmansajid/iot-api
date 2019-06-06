using AutoMapper;
using BusinessEntities;
using DataModel;
using DataModel.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessServices.RoleServices
{
    public class RoleServices:IRoleServices
    {
          private readonly UnitOfWork _unitOfWork;   
         /// <summary>  
         /// Public constructor.  
         /// </summary>  
          public RoleServices()  
         {
             _unitOfWork = new UnitOfWork();  
         }
        /// <summary>  
        
        /// <summary>  
        /// Fetches all the products.  
        /// </summary>  
        /// <returns></returns>  
        public IEnumerable<RoleEntity> GetAllRoles()
        {
            var _roles = _unitOfWork.RoleRepository.GetAll().ToList();
            if (_roles.Any())
            {
                Mapper.CreateMap<Role, RoleEntity>();
                var roleModel = Mapper.Map<List<Role>, List<RoleEntity>>(_roles);
                return roleModel;
            }
            return null;
        }

    

    }
}