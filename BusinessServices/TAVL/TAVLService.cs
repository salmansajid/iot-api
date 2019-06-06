using AutoMapper;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TavlWeb.WebAPI.Authentication;

namespace BusinessServices.TAVL
{
    public class TAVLService
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(TAVLService));
        public IEnumerable<tavlObjectList> AdminLogin(int clientId, int groupId, string ServiceIPAddress, string isReverseGeocoding)
        {
            string Username = "";
            string Secretkey = "";
            if (ServiceIPAddress == "http://124.29.205.150/")
            {
                 Username = "admin@";
                 Secretkey = (new HttpCaller()).GetUserSecret("admiN125");
            }
            if (ServiceIPAddress == "http://124.29.205.149/" || ServiceIPAddress == "http://124.29.205.146/")
            {
                Username = "din2@";
                Secretkey = (new HttpCaller()).GetUserSecret("dIn9060");
            }

            ServiceResponse _ServiceResponse = GetAdvanceLandMarkUrl(_log, Username,ServiceIPAddress, clientId, groupId, isReverseGeocoding, Secretkey);
            List<tavlObjectList> res = JsonConvert.DeserializeObject<List<tavlObjectList>>(_ServiceResponse.Content);
            return res;
        }

        public ServiceResponse GetAdvanceLandMarkUrl(log4net.ILog LOG, string Username, string ServiceIPAddress, int clientId, int groupId, string isReverseGeocoding, string SecretKey)
        {

            string URL = string.Format("{0}WebAPI/api/AdvanceLandMark?clientId={1}&groupId={2}&isReverseGeocoding={3}", ServiceIPAddress, clientId, groupId, isReverseGeocoding);
            return callServiceByURL(URL, LOG, Username, SecretKey, ServiceIPAddress);
        }

        public ServiceResponse callServiceByURL(string URL, log4net.ILog LOG, string Username,  string Secretkey, string ServiceIPAddress)
        {
            ServiceResponse _serviceResponse = null;

            try
            {
                LOG.InfoFormat("IPAddress : {0}, Service Call URL : {1} .", ServiceIPAddress , URL);
                _serviceResponse = (new HttpCaller()).ExecuteGetHttpWebRequest(Username, Secretkey, URL, "");
            }
            catch (Exception e)
            {
                _serviceResponse = new ServiceResponse()
                {
                    ResponseCode = -4,
                    Content = e.Message,
                    Exception = e.StackTrace
                };

            }
            
            LOG.InfoFormat("IPAddress : {0}, Service Call Response :  ResponseCode : {1}, \n ResponseContent : {2}, \n ResponseExpection : {3}",
                ServiceIPAddress, _serviceResponse.ResponseCode, _serviceResponse.Content, _serviceResponse.Exception);
            return _serviceResponse;
        }

    }
    public class tavlObjectList
    {
        public string gpsSortableTime { get; set; }
        public string number { get; set; }
        public string unitId { get; set; }
        public string gpsTime { get; set; }
        public string landMarksValue { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string angle { get; set; }
        public string speed { get; set; }
        public string satellites { get; set; }
        public string numberStr { get; set; }
        public string clientName { get; set; }
        public string groupName { get; set; }
        public string gpsFormattedTime { get; set; }

        public string messageId { get; set; }
        public string date { get; set; }
        public string time { get; set; }

        public string updateColorStr { get; set; }
        public string engineStatusStr { get; set; }
        public string objectStatusStr { get; set; }

        public string isEngineOn { get; set; }

        public string comment { get; set; }

        public string imageCode { get; set; }
        public string simCardId { get; set; }
        public string imei { get; set; }
        public string phoneNumber { get; set; }
        public string id { get; set; }
        public string landMark { get; set; }
        public string altitude { get; set; }
        public string objectId { get; set; }
    }
}
