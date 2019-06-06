using DataModel.GenericRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace DataModel.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        #region Private member variables...

        public TIOTEntities1 _context = null;
        private GenericRepository<Login> _loginRepository;
        private GenericRepository<Client> _clientRepository;
        private GenericRepository<Group> _groupRepository;
        private GenericRepository<OBJECT> _objectRepository;
        private GenericRepository<LoginGroup> _logingroupRepository;
        private GenericRepository<LoginFeature> _loginfeatureRepository;
        private GenericRepository<ObjectGroup> _objectgroupRepository;
        private GenericRepository<ObjectSensor> _objectsensorRepository;
        private GenericRepository<Sensor> _sensorRepository;
        private GenericRepository<Role> _roleRepository;
        private GenericRepository<Feature> _featureRepository;
        private GenericRepository<Status> _statusRepository;
        private GenericRepository<PMDATA> _pMDATARepository;
        private GenericRepository<PMessage> _pMessageRepository;
        private GenericRepository<Category> _categoryRepository;
        private GenericRepository<CommandHistory> _commandHistoryRepository;
        private GenericRepository<ObjectCommand> _objCommandRepository;
        private GenericRepository<ObjectLastStatu> _objectLastStatuRepository;
        private GenericRepository<Scheduling> _schedulingRepository;
        private GenericRepository<CommandsQueue> _commandsQueueRepository;
        private GenericRepository<FederalHoliday> _federalHolidayRepository;
        private GenericRepository<SensorCommand> _sensorCommandRepository;
        private GenericRepository<SensorObjectGroup> _sensorObjectGroupRepository;
        private GenericRepository<EventConfiguration> _eventConfigurationRepository;
        private GenericRepository<RelayNotification> _relayNotificationRepository;
        private GenericRepository<EquipmentScheduling> _equipmentSchedulingRepository;
        private GenericRepository<SwitchesReport> _switchesReportRepository;
        private GenericRepository<FirmwareScheduling> _firmwareSchedulingRepository;
        private GenericRepository<CommandLogByUserID> _commandLogByUserIDRepository;
        private GenericRepository<sp_GetNONAlertState_Result> sp_getNONAlertStateRepository;        
        private GenericRepository<sp_GetFeulLastStatus_Read_Result> _eventLogRepositorySP;
        private GenericRepository<sp_GetSchedulingByObjAndDay_Result> sp_equipmentSchedulingRepository;
        private GenericRepository<sp_GetSchedulingByObjAndDayAndObS_Result> sp_equipmentSchedulingByObjSenRepository;
        private GenericRepository<sp_GetSchedulingByObjAndObjSenIdForWeek_Result> sp_equipmentSchedulingWeeklyRepository;
        private GenericRepository<sp_GetNonAssignedObjSenForSchd_Result> sp_getNonAssignedObjSenForSchdRepository;
        private GenericRepository<sp_ObjectLastStatus_Read_UPDATED_Result> _spResultUpdated;
        private GenericRepository<sp_GetCurrentdateConsumption_Result> sp_GetCurrentdateConsumptionRepository;
        private GenericRepository<sp_GetCurrentdateControlling_Result> sp_GetCurrentdateControllingRepository;
        private GenericRepository<sp_GetConsumptionTillPackTime_Result> sp_GetConsumptionTillPackTime;
        private GenericRepository<sp_smslog_obj_sensor_Result> sp_smslog_obj_sensorRepository;
        private GenericRepository<sp_EventLogbyObjectDT_Result> sp_EventLogbyObjectDTRepository;
        private GenericRepository<sp_EventConfig_LocationByObjID_Result> sp_EventConfig_LocationByObjIDRepository;
        private GenericRepository<usp_GetObjectLastRelayStatus_Result> usp_GetObjectLastRelayStatusRepository;
        private GenericRepository<uspREPORT_DinState1_Result> uspREPORT_DinState1Repository;
        private GenericRepository<uspGET_ObjectIDNameByGroup_Result> uspGET_ObjectIDNameByGroupRepository;
        private GenericRepository<uspGet_EquipmentConsumptionByDT_Result> uspGet_EquipmentConsumptionByDTRepository;






        #endregion

        public UnitOfWork()
        {
            _context = new TIOTEntities1();
        }

        #region Public Repository Creation properties...

        public GenericRepository<Login> LoginRepository
        {
            get
            {
                if (this._loginRepository == null)
                    this._loginRepository = new GenericRepository<Login>(_context);
                return _loginRepository;
            }
        }

        public GenericRepository<Client> ClientRepository
        {
            get
            {
                if (this._clientRepository == null)
                    this._clientRepository = new GenericRepository<Client>(_context);
                return _clientRepository;
            }
        }

        public GenericRepository<Group> GroupRepository
        {
            get
            {
                if (this._groupRepository == null)
                    this._groupRepository = new GenericRepository<Group>(_context);
                return _groupRepository;
            }
        }

        public GenericRepository<OBJECT> ObjectRepository
        {
            get
            {
                if (this._objectRepository == null)
                    this._objectRepository = new GenericRepository<OBJECT>(_context);
                return _objectRepository;
            }
        }

        public GenericRepository<LoginGroup> LoginGroupRepository
        {
            get
            {
                if (this._logingroupRepository == null)
                    this._logingroupRepository = new GenericRepository<LoginGroup>(_context);
                return _logingroupRepository;
            }
        }

        public GenericRepository<LoginFeature> LoginFeatureRepository
        {
            get
            {
                if (this._loginfeatureRepository == null)
                    this._loginfeatureRepository = new GenericRepository<LoginFeature>(_context);
                return _loginfeatureRepository;
            }
        }

        public GenericRepository<ObjectGroup> ObjectGroupRepository
        {
            get
            {
                if (this._objectgroupRepository == null)
                    this._objectgroupRepository = new GenericRepository<ObjectGroup>(_context);
                return _objectgroupRepository;
            }
        }

        public GenericRepository<ObjectSensor> ObjectSensorRepository
        {
            get
            {
                if (this._objectsensorRepository == null)
                    this._objectsensorRepository = new GenericRepository<ObjectSensor>(_context);
                return _objectsensorRepository;
            }
        }

        public GenericRepository<Sensor> SensorRepository
        {
            get
            {
                if (this._sensorRepository == null)
                    this._sensorRepository = new GenericRepository<Sensor>(_context);
                return _sensorRepository;
            }
        }

        public GenericRepository<Role> RoleRepository
        {
            get
            {
                if (this._roleRepository == null)
                    this._roleRepository = new GenericRepository<Role>(_context);
                return _roleRepository;
            }
        }

        public GenericRepository<Feature> FeatureRepository
        {
            get
            {
                if (this._featureRepository == null)
                    this._featureRepository = new GenericRepository<Feature>(_context);
                return _featureRepository;
            }
        }

        public GenericRepository<Status> StatusRepository
        {
            get
            {
                if (this._statusRepository == null)
                    this._statusRepository = new GenericRepository<Status>(_context);
                return _statusRepository;
            }
        }

        public GenericRepository<PMDATA> PMDATARepository
        {
            get
            {
                if (this._pMDATARepository == null)
                    this._pMDATARepository = new GenericRepository<PMDATA>(_context);
                return _pMDATARepository;
            }
        }

        public GenericRepository<PMessage> PMessageRepository
        {
            get
            {
                if (this._pMessageRepository == null)
                    this._pMessageRepository = new GenericRepository<PMessage>(_context);
                return _pMessageRepository;
            }
        }

        public GenericRepository<Category> CategoryRepository
        {
            get
            {

                if (this._categoryRepository == null)
                    this._categoryRepository = new GenericRepository<Category>(_context);
                return _categoryRepository;
            }
        }

        public GenericRepository<ObjectCommand> ObjCommandRepository
        {
            get
            {

                if (this._objCommandRepository == null)
                    this._objCommandRepository = new GenericRepository<ObjectCommand>(_context);
                return _objCommandRepository;
            }
        }

        public GenericRepository<Scheduling> SchedulingRepository
        {
            get
            {

                if (this._schedulingRepository == null)
                    this._schedulingRepository = new GenericRepository<Scheduling>(_context);
                return _schedulingRepository;
            }
        }

        public GenericRepository<CommandsQueue> CommandsQueueRepository
        {
            get
            {

                if (this._commandsQueueRepository == null)
                    this._commandsQueueRepository = new GenericRepository<CommandsQueue>(_context);
                return _commandsQueueRepository;
            }
        }

        public GenericRepository<CommandHistory> CommandHistoryRepository
        {
            get
            {

                if (this._commandHistoryRepository == null)
                    this._commandHistoryRepository = new GenericRepository<CommandHistory>(_context);
                return _commandHistoryRepository;
            }
        }

        public GenericRepository<ObjectLastStatu> ObjectLastStatuRepository
        {
            get
            {

                if (this._objectLastStatuRepository == null)
                    this._objectLastStatuRepository = new GenericRepository<ObjectLastStatu>(_context);
                return _objectLastStatuRepository;
            }
        }
        
        public GenericRepository<FederalHoliday> FederalHolidayRepository
        {
            get
            {

                if (this._federalHolidayRepository == null)
                    this._federalHolidayRepository = new GenericRepository<FederalHoliday>(_context);
                return _federalHolidayRepository;
            }
        }

        public GenericRepository<SensorCommand> SensorCommandRepository
        {
            get
            {

                if (this._sensorCommandRepository == null)
                    this._sensorCommandRepository = new GenericRepository<SensorCommand>(_context);
                return _sensorCommandRepository;
            }
        }

        public GenericRepository<SensorObjectGroup> SensorObjectGroupRepository
        {
            get
            {

                if (this._sensorObjectGroupRepository == null)
                    this._sensorObjectGroupRepository = new GenericRepository<SensorObjectGroup>(_context);
                return _sensorObjectGroupRepository;
            }
        }

        public GenericRepository<EventConfiguration> EventConfigurationRepository
        {
            get
            {

                if (this._eventConfigurationRepository == null)
                    this._eventConfigurationRepository = new GenericRepository<EventConfiguration>(_context);
                return _eventConfigurationRepository;
            }
        }

        public GenericRepository<RelayNotification> RelayNotificationRepository
        {
            get
            {
                if (this._relayNotificationRepository == null)
                    this._relayNotificationRepository = new GenericRepository<RelayNotification>(_context);
                return _relayNotificationRepository;
            }
        }


        public GenericRepository<EquipmentScheduling> EquipmentSchedulingRepository
        {
            get
            {

                if (this._equipmentSchedulingRepository == null)
                    this._equipmentSchedulingRepository = new GenericRepository<EquipmentScheduling>(_context);
                return _equipmentSchedulingRepository;
            }
        }


        public GenericRepository<SwitchesReport> SwitchesReportRepository
        {
            get
            {

                if (this._switchesReportRepository == null)
                    this._switchesReportRepository = new GenericRepository<SwitchesReport>(_context);
                return _switchesReportRepository;
            }
        }
        public GenericRepository<FirmwareScheduling> FirmwareSchedulingRepository
        {
            get
            {

                if (this._firmwareSchedulingRepository == null)
                    this._firmwareSchedulingRepository = new GenericRepository<FirmwareScheduling>(_context);
                return _firmwareSchedulingRepository;
            }
        }

        public GenericRepository<CommandLogByUserID> CommandLogByUserIDRepository
        {
            get
            {

                if (this._commandLogByUserIDRepository == null)
                    this._commandLogByUserIDRepository = new GenericRepository<CommandLogByUserID>(_context);
                return _commandLogByUserIDRepository;
            }
        }

        
        public GenericRepository<sp_GetSchedulingByObjAndDay_Result> sp_EquipmentSchedulingRepository
        {
            get
            {

                if (this.sp_equipmentSchedulingRepository == null)
                    this.sp_equipmentSchedulingRepository = new GenericRepository<sp_GetSchedulingByObjAndDay_Result>(_context);
                return sp_equipmentSchedulingRepository;
            }
        }

        public GenericRepository<sp_GetSchedulingByObjAndDayAndObS_Result> sp_EquipmentSchedulingByObjsenRepository
        {
            get
            {

                if (this.sp_equipmentSchedulingByObjSenRepository == null)
                    this.sp_equipmentSchedulingByObjSenRepository = new GenericRepository<sp_GetSchedulingByObjAndDayAndObS_Result>(_context);
                return sp_equipmentSchedulingByObjSenRepository;
            }
        }


        public GenericRepository<sp_GetSchedulingByObjAndObjSenIdForWeek_Result> sp_EquipmentSchedulingWeeklyRepository
        {
            get
            {

                if (this.sp_equipmentSchedulingWeeklyRepository == null)
                    this.sp_equipmentSchedulingWeeklyRepository = new GenericRepository<sp_GetSchedulingByObjAndObjSenIdForWeek_Result>(_context);
                return sp_equipmentSchedulingWeeklyRepository;
            }
        }


        public GenericRepository<sp_GetNonAssignedObjSenForSchd_Result> sp_GetNonAssignedObjSenForSchdRepository
        {
            get
            {

                if (this.sp_getNonAssignedObjSenForSchdRepository == null)
                    this.sp_getNonAssignedObjSenForSchdRepository = new GenericRepository<sp_GetNonAssignedObjSenForSchd_Result>(_context);
                return sp_getNonAssignedObjSenForSchdRepository;
            }
        }

        public GenericRepository<sp_GetNONAlertState_Result> sp_GetNONAlertStateRepository
        {
            get
            {

                if (this.sp_getNONAlertStateRepository == null)
                    this.sp_getNONAlertStateRepository = new GenericRepository<sp_GetNONAlertState_Result>(_context);
                return sp_getNONAlertStateRepository;
            }
        }
    

        public GenericRepository<sp_ObjectLastStatus_Read_UPDATED_Result> SPResultUpdated
        {
            get
            {

                if (this._spResultUpdated == null)
                    this._spResultUpdated = new GenericRepository<sp_ObjectLastStatus_Read_UPDATED_Result>(_context);
                return _spResultUpdated;
            }
        }

        public GenericRepository<sp_GetCurrentdateConsumption_Result> SPGetCurrentdateConsumptionRepository
        {
            get
            {

                if (this.sp_GetCurrentdateConsumptionRepository == null)
                    this.sp_GetCurrentdateConsumptionRepository = new GenericRepository<sp_GetCurrentdateConsumption_Result>(_context);
                return sp_GetCurrentdateConsumptionRepository;
            }
        }


        public GenericRepository<sp_GetFeulLastStatus_Read_Result> SPEventLogRepository
        {
            get
            {

                if (this._eventLogRepositorySP == null)
                    this._eventLogRepositorySP = new GenericRepository<sp_GetFeulLastStatus_Read_Result>(_context);
                return _eventLogRepositorySP;
            }
        }

        public GenericRepository<sp_GetCurrentdateControlling_Result> SPGetCurrentdateControllingRepository
        {
            get
            {
                if (this.sp_GetCurrentdateControllingRepository == null)
                    this.sp_GetCurrentdateControllingRepository = new GenericRepository<sp_GetCurrentdateControlling_Result>(_context);
                return sp_GetCurrentdateControllingRepository;
            }
        }

        public GenericRepository<sp_GetConsumptionTillPackTime_Result> SPGetConsumptionTillPackTime
        {
            get
            {

                if (this.sp_GetConsumptionTillPackTime == null)
                    this.sp_GetConsumptionTillPackTime = new GenericRepository<sp_GetConsumptionTillPackTime_Result>(_context);
                return sp_GetConsumptionTillPackTime;
            }
        }


        public GenericRepository<sp_smslog_obj_sensor_Result> SP_smslog_obj_sensorRepository
        {
            get
            {

                if (this.sp_smslog_obj_sensorRepository == null)
                    this.sp_smslog_obj_sensorRepository = new GenericRepository<sp_smslog_obj_sensor_Result>(_context);
                return sp_smslog_obj_sensorRepository;
            }
        }

        public GenericRepository<sp_EventLogbyObjectDT_Result> SPEventLogbyObjectDTRepository
        {
            get
            {

                if (this.sp_EventLogbyObjectDTRepository == null)
                    this.sp_EventLogbyObjectDTRepository = new GenericRepository<sp_EventLogbyObjectDT_Result>(_context);
                return sp_EventLogbyObjectDTRepository;
            }
        }


        public GenericRepository<sp_EventConfig_LocationByObjID_Result> SPEventConfig_LocationByObjIDRepository
        {
            get
            {

                if (this.sp_EventConfig_LocationByObjIDRepository == null)
                    this.sp_EventConfig_LocationByObjIDRepository = new GenericRepository<sp_EventConfig_LocationByObjID_Result>(_context);
                return sp_EventConfig_LocationByObjIDRepository;
            }
        }



        public GenericRepository<usp_GetObjectLastRelayStatus_Result> SP_GetObjectLastRelayStatusRepository
        {
            get
            {

                if (this.usp_GetObjectLastRelayStatusRepository == null)
                    this.usp_GetObjectLastRelayStatusRepository = new GenericRepository<usp_GetObjectLastRelayStatus_Result>(_context);
                return usp_GetObjectLastRelayStatusRepository;
            }
        }

        public GenericRepository<uspREPORT_DinState1_Result> Get_uspREPORT_DinState1Repository
        {
            get
            {

                if (this.uspREPORT_DinState1Repository == null)
                    this.uspREPORT_DinState1Repository = new GenericRepository<uspREPORT_DinState1_Result>(_context);
                return uspREPORT_DinState1Repository;
            }
        }
        public GenericRepository<uspGET_ObjectIDNameByGroup_Result> GETuspGET_ObjectIDNameByGroupRepository
        {
            get
            {

                if (this.uspGET_ObjectIDNameByGroupRepository == null)
                    this.uspGET_ObjectIDNameByGroupRepository = new GenericRepository<uspGET_ObjectIDNameByGroup_Result>(_context);
                return uspGET_ObjectIDNameByGroupRepository;
            }
        }

        public GenericRepository<uspGet_EquipmentConsumptionByDT_Result> usp_Get_EquipmentConsumptionByDTRepository
        {
            get
            {

                if (this.uspGet_EquipmentConsumptionByDTRepository == null)
                    this.uspGet_EquipmentConsumptionByDTRepository = new GenericRepository<uspGet_EquipmentConsumptionByDT_Result>(_context);
                return uspGet_EquipmentConsumptionByDTRepository;
            }
        }

        #endregion

        #region Public member methods...
        /// <summary>  
        /// Save method.  
        /// </summary>  
        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {

                var outputLines = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.Add(string.Format("{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now, eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                    }
                }
                System.IO.File.AppendAllLines(@"C:\errors.txt", outputLines);

                throw e;
            }

        }

        #endregion

        #region Implementing IDiosposable...

        #region private dispose variable declaration...
        private bool disposed = false;
        #endregion

        /// <summary>  
        /// Protected Virtual Dispose method  
        /// </summary>  
        /// <param name="disposing"></param>  
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Debug.WriteLine("UnitOfWork is being disposed");
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>  
        /// Dispose method  
        /// </summary>  
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
