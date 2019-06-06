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

namespace BusinessServices.DinStateServices
{
    public class DinStateServices :IDinStateService
    {
        private readonly UnitOfWork _unitOfWork;   
         /// <summary>  
         /// Public constructor.  
         /// </summary>  
        public DinStateServices()  
         {  
             _unitOfWork = new UnitOfWork();  
         }

        public IEnumerable<uspReport_DinState1Entity> GetDinState1Today(int ObjectId, DateTime Startdate, DateTime Enddate)
        {
            var result = _unitOfWork.Get_uspREPORT_DinState1Repository.ExecWithStoreProcedure("uspREPORT_DinState1 @ObjectID, @Startdate, @Enddate",
                new SqlParameter("ObjectID", SqlDbType.Int) { Value = ObjectId },
                new SqlParameter("Startdate", SqlDbType.DateTime) { Value = Startdate },
                    new SqlParameter("Enddate", SqlDbType.DateTime) { Value = Enddate }
                ).ToList();


            if (result.Any())
            {
                
                string ser = JsonConvert.SerializeObject(result);
                List<uspReport_DinState1Entity> data = JsonConvert.DeserializeObject<List<uspReport_DinState1Entity>>(ser);
                //List<uspReport_DinStateEntity> parsedata = new List<uspReport_DinStateEntity>().ToList();
                for (int i = 0; i < data.Count; i++)
                {
                    //uspReport_DinStateEntity dt = new uspReport_DinStateEntity();
                    //dt.ObjectsensorID = data[i].ObjectsensorID;
                    //dt.Name = data[i].Name;
                    if(data[i].Status == "1")
                    {
                        data[i].Status = "ON"; 
                    }
                    if(data[i].Status == "0")
                    {
                        data[i].Status = "OFF"; 

                    }
                //    dt.StartTime = data[i].StartTime;
                //    dt.EndTime = data[i].EndTime;
                //    dt.TotalTime = Convert.ToDateTime(data[i].TotalTime);
                //    parsedata.Add(dt);
                }
                return data;
            }
            else
            {
                return null;
            }
        }


    }
}
