using AutoMapper;
using BusinessEntities;
using DataModel;
using DataModel.UnitOfWork;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Transactions;

namespace BusinessServices.ObjectServices
{
    public class ObjectServices : IObjectServices
    {
        private readonly UnitOfWork _unitOfWork;   
         /// <summary>  
         /// Public constructor.  
         /// </summary>  
         /// 
        public ObjectServices()  
         {  
             _unitOfWork = new UnitOfWork();  
         }

        /// <summary>  
        /// Fetches product details by id  
        /// </summary>  
        /// <param name="productId"></param>  
        /// <returns></returns>  
        public ObjectEntity GetObjectById(int objectId)
        {
            var _object = _unitOfWork.ObjectRepository.GetByID(objectId);
            if (_object != null)
            {
                Mapper.CreateMap<OBJECT, ObjectEntity>();
                var objectModel = Mapper.Map<Object, ObjectEntity>(_object);
                return objectModel;
            }
            return null;
        }

        /// <summary>  
        /// Fetches all the products.  
        /// </summary>  
        /// <returns></returns>  
        public IEnumerable<Objects> GetAllObjects()
        {
            var _object = _unitOfWork.ObjectRepository.GetAll().ToList();
            var _clients = _unitOfWork.ClientRepository.GetAll();

            if (_object.Any())
            {

                var objInfo = (from obj in _object
                                 join cl in _clients on obj.ClientID equals cl.ClientID
                                 where obj.ClientID == cl.ClientID && obj.Deleted == false
                                 orderby obj.ObjectID descending
                                 select new
                                 {
                                        ObjectID = obj.ObjectID,
                                        Name = obj.Name,
                                        Address = obj.Address,
                                        LAT = obj.LAT,
                                        LONG = obj.LONG,
                                        IMEI = obj.IMEI,
                                        SimNumber = obj.SimNumber,
                                        FirmWareVersion = obj.FirmWareVersion,
                                        HardwareVersion = obj.HardwareVersion,
                                        EnableOrDisable = obj.EnableOrDisable,
                                        ClientName = cl.Name,
                                        ClientID = cl.ClientID,
                                        Contact = obj.Contact,
                                        TavlClient = obj.TavlClient,
                                        TavlGroup = obj.TavlGroup,
                                        TavlIP = obj.TavlIP,
                                        TavlStatus = obj.TavlStatus,
                                        RelayStatus = obj.RelayStatus
                                 }).ToList();

                string ser = JsonConvert.SerializeObject(objInfo);
                List<Objects> objects = JsonConvert.DeserializeObject<List<Objects>>(ser);
                return objects;
            }
           
           
           
            return null;
        }

        public IEnumerable<ObjectstatusEntity> GetObjectByGroupId(int GroupID)
        {
            var _object = _unitOfWork.ObjectRepository.GetAll().ToList();
            var _objectgroups = _unitOfWork.ObjectGroupRepository.GetAll().ToList();
            var _objectlaststatus = _unitOfWork.ObjectLastStatuRepository.GetAll().ToList();
            if (_object.Any())
            {
                //Mapper.CreateMap<OBJECT, ObjectEntity>();
                var objgpInfo = (from obj in _object
                                join objgp in _objectgroups on obj.ObjectID equals objgp.ObjectID
                                join oblast in _objectlaststatus on obj.ObjectID equals oblast.ObjectID
                                where objgp.GroupID == GroupID && obj.Deleted == false
                                 select new
                               {
                                    ObjectID = obj.ObjectID,
                                    Name =  obj.Name,
                                    Address = obj.Address,
                                    LAT = obj.LAT,
                                    LONG = obj.LONG,
                                    IMEI =  obj.IMEI,
                                    SimNumber = obj.SimNumber ,
                                    FirmWareVersion =  obj.FirmWareVersion,
                                    HardwareVersion = obj.HardwareVersion ,
                                    EnableOrDisable =  obj.EnableOrDisable ,
                                    ClientID = obj.ClientID,
                                    LastUpdated = oblast.LastRecordReceived,
                                    Contact = obj.Contact,
                                    RelayStatus = obj.RelayStatus,
                                    TavlClient = obj.TavlClient,
                                    TavlGroup = obj.TavlGroup,
                                    TavlIP = obj.TavlIP,
                                    TavlStatus = obj.TavlStatus,
                                    AttendanceClient = obj.AttendanceClient,
                                    AttendanceIP= obj.AttendanceIP,
                                    AttendanceStatus= obj.AttendanceStatus,
                                    SurveillanceIP= obj.SurveillanceIP,
                                    SurveillanceStatus= obj.SurveillanceStatus
                                    
                               }).ToList();  
                //var objectModel = Mapper.Map<List<OBJECT>, List<ObjectEntity>>(objgpInfo.ToList());
                string ser = JsonConvert.SerializeObject(objgpInfo);
                List<ObjectstatusEntity> objectModel = JsonConvert.DeserializeObject<List<ObjectstatusEntity>>(ser);
                return objectModel;
            }
            return null;
        }

        public IEnumerable<Objects> GetObjectByClientId(int ClientId)
        {
            var _object = _unitOfWork.ObjectRepository.GetAll().ToList();
            var _clients = _unitOfWork.ClientRepository.GetAll().ToList();
            if (_object.Any())
            {
                var objgpInfo = (from obj in _object
                                join cl in _clients on obj.ClientID equals cl.ClientID
                                 where obj.ClientID == ClientId && obj.Deleted == false
                                 select new
                               {
                                    ObjectID = obj.ObjectID,
                                    Name =  obj.Name,
                                    Address = obj.Address,
                                    LAT = obj.LAT,
                                    LONG = obj.LONG,
                                    IMEI =  obj.IMEI,
                                    SimNumber = obj.SimNumber ,
                                    FirmWareVersion =  obj.FirmWareVersion,
                                    HardwareVersion = obj.HardwareVersion ,
                                    EnableOrDisable =  obj.EnableOrDisable ,
                                    ClientName =  cl.Name,
                                    ClientID = cl.ClientID,
                                    Contact = obj.Contact,
                                    RelayStatus = obj.RelayStatus,
                                    TavlClient = obj.TavlClient,
                                    TavlGroup = obj.TavlGroup,
                                    TavlIP = obj.TavlIP,
                                    TavlStatus = obj.TavlStatus,
                                    AttendanceClient = obj.AttendanceClient,
                                    AttendanceIP= obj.AttendanceIP,
                                    AttendanceStatus= obj.AttendanceStatus,
                                    SurveillanceIP= obj.SurveillanceIP,
                                    SurveillanceStatus= obj.SurveillanceStatus
                                    
                               }).ToList();                              
                string ser = JsonConvert.SerializeObject(objgpInfo);
                List<Objects> objectdts = JsonConvert.DeserializeObject<List<Objects>>(ser);
                return objectdts;
            }
            return null;
        }

        public IEnumerable<ObjectEntity> GetObjectByGroupAndLoginId(int GroupID, int LoginID)
        {
            var _object = _unitOfWork.ObjectRepository.GetAll().ToList();
            var _objectgroups = _unitOfWork.ObjectGroupRepository.GetAll().ToList();
            var _logingroups = _unitOfWork.LoginGroupRepository.GetAll().ToList();
            if (_object.Any())
            {
                Mapper.CreateMap<OBJECT, ObjectEntity>();
                var objgpInfo = from obj in _object
                                join objgp in _objectgroups on obj.ObjectID equals objgp.ObjectID
                                join lggp in _logingroups on objgp.GroupID equals lggp.GroupID
                                where objgp.GroupID == GroupID && lggp.LoginID == LoginID && obj.Deleted == false
                                select obj;
                var objectModel = Mapper.Map<List<OBJECT>, List<ObjectEntity>>(objgpInfo.ToList());
                return objectModel;
            }
            return null;
        }

        public IEnumerable<ObjectDashboardEntity> GetObjectDashboardAttendance()
        {
            var _object = _unitOfWork.ObjectRepository.GetAll().ToList();
            var _client = _unitOfWork.ClientRepository.GetAll().ToList();
            var _objlast = _unitOfWork.ObjectLastStatuRepository.GetAll().ToList();
            var _objgroup = _unitOfWork.ObjectGroupRepository.GetAll().ToList();
            var _group = _unitOfWork.GroupRepository.GetAll().ToList();
            if (_objlast.Any())
            {
                var objInfo = from objlast in _objlast
                              join bg in _objgroup on objlast.ObjectID equals bg.ObjectID
                              join obj in _object on objlast.ObjectID equals obj.ObjectID
                              join cl in _client on obj.ClientID equals cl.ClientID
                              join gpp in _group on bg.GroupID equals gpp.GroupID
                              orderby objlast.LastRecordReceived descending
                              select new
                              {
                                  ObjectName = obj.Name,
                                  Address = obj.Address,
                                  Contact = obj.Contact,
                                  DeviceIP = objlast.DeviceIP,
                                  LastRecordReceived = objlast.LastRecordReceived,
                                  SimNumber = obj.SimNumber,
                                  ClientName = cl.Name,
                                  GroupName = gpp.Name,
                                  GroupID = bg.GroupID,
                              };
                string ser = JsonConvert.SerializeObject(objInfo);
                List<ObjectDashboardEntity> ObjectDashboardModel = JsonConvert.DeserializeObject<List<ObjectDashboardEntity>>(ser);
                return ObjectDashboardModel;
            }
            return null;
        }


        public IEnumerable<uspGET_ObjectIDNameByGroup_Result> GetObjIDNameByGroup(int groupID)
        {
            var objInfo = _unitOfWork.GETuspGET_ObjectIDNameByGroupRepository.ExecWithStoreProcedure(
                "uspGET_ObjectIDNameByGroup @GroupID",
                new SqlParameter("GroupID", SqlDbType.Int) { Value = groupID }).ToList();

            if (objInfo.Any())
            {
                string ser = JsonConvert.SerializeObject(objInfo);
                List<uspGET_ObjectIDNameByGroup_Result> objectdts = JsonConvert.DeserializeObject<List<uspGET_ObjectIDNameByGroup_Result>>(ser);
                return objectdts;
            }
            else
            {
                return null;
            }
        }   
        public IEnumerable<ObjectdetailsNew> GetObjectDetailNew(int ObjectId)
        {
            var objInfo = _unitOfWork.SPResultUpdated.ExecWithStoreProcedure(
                "sp_ObjectLastStatus_Read_UPDATED @objectId",
                new SqlParameter("objectId", SqlDbType.Int) { Value = ObjectId }).ToList();

            if (objInfo.Any())
            {
                string ser = JsonConvert.SerializeObject(objInfo);
                List<ObjectdetailsNew> objectdts = JsonConvert.DeserializeObject<List<ObjectdetailsNew>>(ser);
                return objectdts;
            }
            else
            {
                return null;
            }
        }   

        /// <summary>  
        /// Creates a product  
        /// </summary>  
        /// <param name="productEntity"></param>  
        /// <returns></returns>  
        public int CreateObject(ObjectEntity objectEntity)
        {
            using (var scope = new TransactionScope())
            {
                var _object = new OBJECT
                {
                    Name = objectEntity.Name,
                    Address = objectEntity.Address,
                    LAT = objectEntity.LAT,
                    LONG = objectEntity.LONG,
                    IMEI= objectEntity.IMEI,
                    SimNumber = objectEntity.SimNumber,
                    FirmWareVersion = objectEntity.FirmWareVersion,
                    HardwareVersion = objectEntity.HardwareVersion,
                    EnableOrDisable = objectEntity.EnableOrDisable,
                    ClientID = objectEntity.ClientID,
                    Deleted = false,
                    Contact = objectEntity.Contact,
                    TavlClient = 0,
                    TavlGroup = 0,
                    TavlStatus = false,
                    TavlIP = "000.00.000.000",
                    RelayStatus = objectEntity.RelayStatus,
                    AttendanceClient = 0,
                    AttendanceIP = "000.00.000.000",
                    AttendanceStatus = false,
                    SurveillanceIP = "000.00.000.000,00",
                    SurveillanceStatus = false,
                };
                _unitOfWork.ObjectRepository.Insert(_object);
                _unitOfWork.Save();
                scope.Complete();
                return _object.ObjectID;
            }
        }

        /// <summary>  
        /// Updates a product  
        /// </summary>  
        /// <param name="productId"></param>  
        /// <param name="productEntity"></param>  
        /// <returns></returns>  
        public bool UpdateObject(int ObjectId,ObjectEntity objectEntity)
        {
            var success = false;
            if (objectEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var _object = _unitOfWork.ObjectRepository.GetByID(ObjectId);
                    if (_object != null)
                    {
                        _object.Name = objectEntity.Name;
                        _object.Address = objectEntity.Address;
                        _object.LAT = objectEntity.LAT;
                        _object.LONG = objectEntity.LONG;
                        _object.IMEI= objectEntity.IMEI;
                        _object.SimNumber = objectEntity.SimNumber;
                        _object.FirmWareVersion = objectEntity.FirmWareVersion;
                        _object.HardwareVersion = objectEntity.HardwareVersion;
                        _object.EnableOrDisable = objectEntity.EnableOrDisable;
                        _object.ClientID = objectEntity.ClientID;
                        _object.Contact = objectEntity.Contact;
                        _object.RelayStatus = objectEntity.RelayStatus;
                        _object.Deleted = false;
                        _unitOfWork.ObjectRepository.Update(_object);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        public bool UpdateTavlIntegration(int ObjectId, TavlIntegration tavlIntegration)
        {
            var success = false;
            if (tavlIntegration != null)
            {
                using (var scope = new TransactionScope())
                {
                    var _object = _unitOfWork.ObjectRepository.GetByID(ObjectId);
                    if (_object != null)
                    {
                        _object.TavlClient = tavlIntegration.TavlClient;
                        _object.TavlGroup = tavlIntegration.TavlGroup;
                        _object.TavlIP = tavlIntegration.TavlIP;
                        _object.TavlStatus = tavlIntegration.TavlStatus;
                        _unitOfWork.ObjectRepository.Update(_object);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        public bool UpdateAttendanceIntegration(int ObjectId, AttendanceIntegration attendanceIntegration)
        {
            var success = false;
            if (attendanceIntegration != null)
            {
                using (var scope = new TransactionScope())
                {
                    var _object = _unitOfWork.ObjectRepository.GetByID(ObjectId);
                    if (_object != null)
                    {
                        _object.AttendanceClient = attendanceIntegration.AttendanceClient;
                        _object.AttendanceIP = attendanceIntegration.AttendanceIP;
                        _object.AttendanceStatus = attendanceIntegration.AttendanceStatus;
                        _unitOfWork.ObjectRepository.Update(_object);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        public bool UpdateSurveillanceIntegration(int ObjectId, SurveillanceIntegration surveillanceIntegration)
        {
            var success = false;
            if (surveillanceIntegration != null)
            {
                using (var scope = new TransactionScope())
                {
                    var _object = _unitOfWork.ObjectRepository.GetByID(ObjectId);
                    if (_object != null)
                    {
                        _object.SurveillanceIP = surveillanceIntegration.SurveillanceIP;
                        _object.SurveillanceStatus = surveillanceIntegration.SurveillanceStatus;
                        _unitOfWork.ObjectRepository.Update(_object);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        public bool UpdateTavlStatus(int ObjectId)
        {
            var success = false;
                using (var scope = new TransactionScope())
                {
                    var _object = _unitOfWork.ObjectRepository.GetByID(ObjectId);
                    if (_object != null)
                    {
                        _object.TavlStatus = false;
                        _unitOfWork.ObjectRepository.Update(_object);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            return success;
        }

        public bool UpdateAttendanceStatus(int ObjectId)
        {
            var success = false;
                using (var scope = new TransactionScope())
                {
                    var _object = _unitOfWork.ObjectRepository.GetByID(ObjectId);
                    if (_object != null)
                    {
                        _object.AttendanceStatus = false;
                        _unitOfWork.ObjectRepository.Update(_object);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            
            return success;
        }

        public bool UpdateSurveillanceStatus(int ObjectId)
        {
            var success = false;
            using (var scope = new TransactionScope())
            {
                var _object = _unitOfWork.ObjectRepository.GetByID(ObjectId);
                if (_object != null)
                {
                    _object.SurveillanceStatus = false;
                    _unitOfWork.ObjectRepository.Update(_object);
                    _unitOfWork.Save();
                    scope.Complete();
                    success = true;
                }
            }
            return success;
        }

        public IEnumerable<TavlIntegration> GetTavlStatusByObjectId(int ObjectId)
        {
            var _object = _unitOfWork.ObjectRepository.GetMany(x => x.ObjectID ==ObjectId && x.TavlStatus == true).ToList();
            if (_object.Any())
            {
       
                var _obj = (from obj in _object select new {ObjectID = obj.ObjectID,TavlClient = obj.TavlClient,TavlGroup = obj.TavlGroup,TavlIP = obj.TavlIP,TavlStatus = obj.TavlStatus}).ToList();
                string ser = JsonConvert.SerializeObject(_obj);
                List<TavlIntegration> objectdts = JsonConvert.DeserializeObject<List<TavlIntegration>>(ser);
                return objectdts;
            }
            return null;
        }

        public IEnumerable<AttendanceIntegration> GetAttendanceStatusByObjectId(int ObjectId)
        {
            var _object = _unitOfWork.ObjectRepository.GetMany(x => x.AttendanceStatus == true).ToList();
            if (_object.Any())
            {

                var _obj = (from obj in _object select new { ObjectID = obj.ObjectID, AttendanceClient = obj.AttendanceClient,
                                                             AttendanceIP = obj.AttendanceIP,
                                                             AttendanceStatus = obj.AttendanceStatus
                }).ToList();
                string ser = JsonConvert.SerializeObject(_obj);
                List<AttendanceIntegration> objectdts = JsonConvert.DeserializeObject<List<AttendanceIntegration>>(ser);
                return objectdts;
            }
            return null;
        }

        public IEnumerable<SurveillanceIntegration> GetSurveillanceStatusByObjectId(int ObjectId)
        {
            var _object = _unitOfWork.ObjectRepository.GetMany(x => x.SurveillanceStatus == true).ToList();
            if (_object.Any())
            {

                var _obj = (from obj in _object select new { ObjectID = obj.ObjectID,
                                                             SurveillanceIP = obj.SurveillanceIP,
                                                             SurveillanceStatus = obj.SurveillanceStatus
                }).ToList();
                string ser = JsonConvert.SerializeObject(_obj);
                List<SurveillanceIntegration> objectdts = JsonConvert.DeserializeObject<List<SurveillanceIntegration>>(ser);
                return objectdts;
            }
            return null;
        }

        /// <summary>  
        /// Deletes a particular product  
        /// </summary>  
        /// <param name="productId"></param>  
        /// <returns></returns>  
        public bool DeleteObject(int objectId)
        {
            var success = false;
            if (objectId > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var _object = _unitOfWork.ObjectRepository.GetByID(objectId);
                    if (_object != null)
                    {
                        _unitOfWork.ObjectRepository.Delete(_object);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }


    }
}