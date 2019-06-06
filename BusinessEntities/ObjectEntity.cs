
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
    public class ObjectEntity
    {       
        public int ObjectID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double LAT { get; set; }
        public double LONG { get; set; }
        public long IMEI { get; set; }
        public long SimNumber { get; set; }
        public string FirmWareVersion { get; set; }
        public string HardwareVersion { get; set; }
        public bool EnableOrDisable { get; set; }
        public Nullable<int> ClientID { get; set; }
        public Nullable<bool> Deleted { get; set; }
        public Nullable<System.DateTime> DeleteDateTime { get; set; }
        public string Contact { get; set; }
        public Nullable<bool> RelayStatus { get; set; }
        public Nullable<int> TavlClient { get; set; }
        public Nullable<int> TavlGroup { get; set; }
        public string TavlIP { get; set; }
        public Nullable<bool> TavlStatus { get; set; }
        public Nullable<int> AttendanceClient { get; set; }
        public string AttendanceIP { get; set; }
        public Nullable<bool> AttendanceStatus { get; set; }
        public string SurveillanceIP { get; set; }
        public Nullable<bool> SurveillanceStatus { get; set; }
    }
    public class ObjectstatusEntity
    {
        public int ObjectID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double LAT { get; set; }
        public double LONG { get; set; }
        public long IMEI { get; set; }
        public long SimNumber { get; set; }
        public string FirmWareVersion { get; set; }
        public string HardwareVersion { get; set; }
        public bool EnableOrDisable { get; set; }
        public Nullable<int> ClientID { get; set; }
        public DateTime LastUpdated { get; set; }
        
        public Nullable<bool> Deleted { get; set; }
        public Nullable<System.DateTime> DeleteDateTime { get; set; }
        public string Contact { get; set; }
        public Nullable<bool> RelayStatus { get; set; }
        public Nullable<int> TavlClient { get; set; }
        public Nullable<int> TavlGroup { get; set; }
        public string TavlIP { get; set; }
        public Nullable<bool> TavlStatus { get; set; }
        public Nullable<int> AttendanceClient { get; set; }
        public string AttendanceIP { get; set; }
        public Nullable<bool> AttendanceStatus { get; set; }
        public string SurveillanceIP { get; set; }
        public Nullable<bool> SurveillanceStatus { get; set; }
    }
    public class Objects
    {
        public int ObjectID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double LAT { get; set; }
        public double LONG { get; set; }
        public long IMEI { get; set; }
        public long SimNumber { get; set; }
        public string FirmWareVersion { get; set; }
        public string HardwareVersion { get; set; }
        public bool EnableOrDisable { get; set; }
        public Nullable<int> ClientID { get; set; }
        public Nullable<System.DateTime> DeleteDateTime { get; set; }
        public string ClientName { get; set; }
        public string ContactNo_1 { get; set; }
        public string ContactNo_2 { get; set; }
        public string ContactNo_3 { get; set; }
        public string EmailNo_1 { get; set; }
        public string EmailNo_2 { get; set; }
        public string EmailNo_3 { get; set; }
        public bool RelayStatus { get; set; }
   
    }

    public class Objectdetails
    {

        public Nullable<int> ObjectID { get; set; }
        public long pmid { get; set; }
        public System.DateTime ReceivedDateTimeStamp { get; set; }
        public System.DateTime DeviceDateTime { get; set; }
        public string VALUE { get; set; }
        public string SensorName { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public string Address { get; set; }
    }
    public class ObjectdetailsNew
    {
        public Nullable<int> ObjectID { get; set; }
        public long pmid { get; set; }
        public System.DateTime ReceivedDateTimeStamp { get; set; }
        public System.DateTime DeviceDateTime { get; set; }
        public string VALUE { get; set; }
        public string SensorName { get; set; }
        public string SourceName { get; set; }
        public string Unit { get; set; }
        public string CategoryName { get; set; }
        public string Address { get; set; }
        public Nullable<int> SensorID { get; set; }
        public bool RelayStatus { get; set; }
        public Nullable<int> TavlClient { get; set; }
        public Nullable<int> TavlGroup { get; set; }
        public string TavlIP { get; set; }
        public Nullable<bool> TavlStatus { get; set; }
    }
    public class ObjectDashboardEntity
    {

        public string ObjectName { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string DeviceIP { get; set; }
        public string SimNumber { get; set; }
        public DateTime LastRecordReceived { get; set; }
        public string ClientName { get; set; }
        public string GroupName { get; set; }
        public int GroupID { get; set; }
                                   
    }
    public class TavlIntegration
    {
        public int ObjectID { get; set; }
        public Nullable<int> TavlClient { get; set; }
        public Nullable<int> TavlGroup { get; set; }
        public string TavlIP { get; set; }
        public Nullable<bool> TavlStatus { get; set; }
    }
    public class AttendanceIntegration
    {
        public int ObjectID { get; set; }
        public Nullable<int> AttendanceClient { get; set; }
        public string AttendanceIP { get; set; }
        public Nullable<bool> AttendanceStatus { get; set; }

    }
    public class SurveillanceIntegration
    {
        public int ObjectID { get; set; }
        public string SurveillanceIP { get; set; }
        public Nullable<bool> SurveillanceStatus { get; set; }

    }
}
