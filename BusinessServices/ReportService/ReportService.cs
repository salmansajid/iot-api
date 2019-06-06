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

namespace BusinessServices.ReportService
{
    public class ReportService :IReportService
    {
         private readonly UnitOfWork _unitOfWork;   
         
         public ReportService()  
         {  
             _unitOfWork = new UnitOfWork();  
         }

         public IEnumerable<uspGet_EquipmentConsumptionByDTModel> GetConsumptionByDT(int ObjectID, DateTime StartTime, DateTime EndTime)
         {
             var result = _unitOfWork.usp_Get_EquipmentConsumptionByDTRepository.ExecWithStoreProcedure("uspGet_EquipmentConsumptionByDT @ObjectID, @StartDate, @EndDate",
                 new SqlParameter("ObjectID", SqlDbType.Int) { Value = ObjectID },
                 new SqlParameter("StartDate", SqlDbType.DateTime) { Value = StartTime },
                 new SqlParameter("EndDate", SqlDbType.DateTime) { Value = EndTime }).ToList();

             if (result.Any())
             {
                 string ser = JsonConvert.SerializeObject(result);
                 List<uspGet_EquipmentConsumptionByDTModel> data = JsonConvert.DeserializeObject<List<uspGet_EquipmentConsumptionByDTModel>>(ser);
                 return data;
             }
             else
             {
                 return null;
             }
         }
    }
}
