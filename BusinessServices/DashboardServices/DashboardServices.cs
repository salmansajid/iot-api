using BusinessEntities;
using DataModel.UnitOfWork;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.DashboardServices
{
    public class DashboardServices : IDashboardServices
    {
        private readonly UnitOfWork _unitOfWork;

        public DashboardServices()
        {
            _unitOfWork = new UnitOfWork();
        }

        public IEnumerable<DashboardEntity> GetRelayStatus(int ObjectId)
        {
            var objInfo = _unitOfWork.SP_GetObjectLastRelayStatusRepository.ExecWithStoreProcedure(
                 "usp_GetObjectLastRelayStatus @ObjectID",
                 new SqlParameter("ObjectID", SqlDbType.Int) { Value = ObjectId }).ToList();
            if (objInfo.Any())
            {

                string ser = JsonConvert.SerializeObject(objInfo);
                List<DashboardEntity> objectdts = JsonConvert.DeserializeObject<List<DashboardEntity>>(ser);
                return objectdts;
            }
            else
            {
                return null;
            }
        }
    }
}
