using BusinessEntities;
using BusinessServices.FirmwareSchedulingServices;
using DataModel;
using DataModel_SMSGateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace TIOT_API.Controllers
{
    public class SMSController : ApiController
    {
        // GET: SMS
        private SMSGetWayEntities db = new SMSGetWayEntities();
        private TIOTEntities1 TIOTdb = new TIOTEntities1();
        //private readonly IFirmwareSchedulingServices _FirmwareSchedulingServices;
    

        //
        // GET: /Movies/

        

        public int InsertSMS(SmsToSendEntity model)
        {

            var query = (
                           from p in TIOTdb.ObjectLastStatus where p.ObjectID == model.ObjectId 
                         select new 
                            {p.LastRecordReceived}).First();
            DateTime cdt = DateTime.Now.AddMinutes(-5);
            if (query.LastRecordReceived > cdt)
            {
                SmsToSend obj = new SmsToSend();
                FirmwareScheduling _obj = new FirmwareScheduling();
                _obj.ObjectId = model.ObjectId;
                _obj.ClientId = model.ClientId;
                _obj.Command = model.Message;
                _obj.SimNumber = model.DestinationNumber;
                _obj.ExecutionTime = model.ExecutionTime;
                _obj.DateTimeStamp = DateTime.Now;

                obj.DestinationNumber = model.DestinationNumber;
                obj.Message = new TAVLSMSGetWay_BL.SmsEncryption().encodeSMS(model.Message);
                obj.CellNetworkId = NetworkId(model.DestinationNumber);
                obj.CreatedOn = DateTime.Now;
                obj.IsEencrypted = true;

                if (obj != null)
                {
                    db.SmsToSends.Add(obj);
                    int id = db.SaveChanges();
                    if (id > 0)
                    {
                        TIOTdb.FirmwareSchedulings.Add(_obj);
                        int response = TIOTdb.SaveChanges();
                        return response;
                    }
                }
                
            }
            return 0;

            
        }

        public int NetworkId(string number)
        {
            int CellNetworkId = 0;
            if (number != null)
            {


                if (number.Contains("+92333") || number.Contains("+92331") || number.Contains("+92332") || number.Contains("+92334"))
                {
                    CellNetworkId = 2;
                }
                if (number.Contains("+92345") || number.Contains("+92346") || number.Contains("+92347") || number.Contains("+92341"))
                {
                    CellNetworkId = 1;
                }
                if (number.Contains("+92300") || number.Contains("+92302") || number.Contains("+92301") || number.Contains("+92304") || number.Contains("+92307"))
                {
                    CellNetworkId = 4;
                }
                if (number.Contains("+92321") || number.Contains("+92322") || number.Contains("+92323") || number.Contains("+92324"))
                {
                    CellNetworkId = 3;
                }
                if (number.Contains("+92312") || number.Contains("+92313") || number.Contains("+92314") || number.Contains("+92315"))
                {
                    CellNetworkId = 5;
                }
            }

            return CellNetworkId;
        }
    }

}