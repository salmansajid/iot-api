using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessEntities;
using DataModel.UnitOfWork;
using DataModel;
using System.Transactions;
using AutoMapper;
using Newtonsoft.Json;


namespace BusinessServices
{
    public class LoginServices :ILoginServices
    {
        private readonly UnitOfWork _unitOfWork;   
         /// <summary>  
         /// Public constructor.  
         /// </summary>  
        public LoginServices()  
         {  
             _unitOfWork = new UnitOfWork();  
         }

        /// <summary>  
        /// Fetches product details by id  
        /// </summary>  
        /// <param name="productId"></param>  
        /// <returns></returns>  
        public LoginEntity GetLoginById(int loginId)
        {
            
            var login = _unitOfWork.LoginRepository.GetByID(loginId);
            if (login != null)
            {
                Mapper.CreateMap<Login, LoginEntity>();
                var loginModel = Mapper.Map<Login, LoginEntity>(login);
                return loginModel;
            }
            return null;
        }

        public LoginEntity Authenthicate(string username, string password)
        {

            var login = _unitOfWork.LoginRepository.GetByCondition(lg =>lg.User == username && lg.Password == password);
            if (login != null)
            {
                Mapper.CreateMap<Login, LoginEntity>();
                var loginModel = Mapper.Map<Login, LoginEntity>(login);
                return loginModel;
            }
            return null;
        }

        public IEnumerable<LoginEntity> GetLoginByCode(string code, string username, string password)
        {
            var _logins = _unitOfWork.LoginRepository.GetAll().ToList();
            var _clients = _unitOfWork.ClientRepository.GetAll().ToList();
            if (_logins != null)
            {
                Mapper.CreateMap<Login, LoginEntity>();
                var loginInfo = from lg in _logins
                                join cl in _clients on lg.ClientID equals cl.ClientID
                                where cl.Code == code && lg.User == username && lg.Password == password && cl.Enabled == true
                                select lg;
                var loginModel = Mapper.Map<List<Login>, List<LoginEntity>>(loginInfo.ToList());
                return loginModel;
            }
            return null;
        }

        //select * from login as l join client as cl on cl.clientId = l.clientId where cl.Code = '" + Code + "' and l.[user] =  '" + User + "'  and l.password =  '" + Password + "' ";

        public IEnumerable<Logins> GetLoginsNonAdmin()
        {
            var _logins = _unitOfWork.LoginRepository.GetAll();
            if (_logins.Any())
            {

                var loginInfo = (from lg in _logins
                                 where lg.RoleID != -1
                                 select new
                                     {
                                         LoginID = lg.LoginID,
                                         ClientID = lg.ClientID,
                                         RoleID = lg.RoleID,
                                         Comment = lg.Comment,
                                         User = lg.User,
                                     }).ToList();

                string ser = JsonConvert.SerializeObject(loginInfo);
                List<Logins> logins = JsonConvert.DeserializeObject<List<Logins>>(ser);
                return logins;
            }
            return null;
        }



        /// <summary>  
        /// Fetches all the products.  
        /// </summary>  
        /// <returns></returns>  
        public IEnumerable<Logins> GetAllLogins()
        {
            var _logins = _unitOfWork.LoginRepository.GetAll();
            var _clients = _unitOfWork.ClientRepository.GetAll();
            var _roles = _unitOfWork.RoleRepository.GetAll();
            if (_logins.Any())
            {

                var loginInfo = (from lg in _logins
                                 join cl in _clients on lg.ClientID equals cl.ClientID 
                                 join role in _roles on lg.RoleID equals role.RoleID
                                 where lg.ClientID == cl.ClientID && lg.RoleID == role.RoleID && cl.Deleted == false && lg.RoleID != -1
                                 orderby lg.LoginID descending
                                 select new
                                     {
                                         LoginID = lg.LoginID,
                                         ClientID  = cl.ClientID,
                                         RoleID  = role.RoleID,
                                         Comment = lg.Comment,
                                         User = lg.User,
                                         Name = cl.Name,
                                         Role = role.Name,
                                     }).ToList();

                string ser = JsonConvert.SerializeObject(loginInfo);
                List<Logins> logins = JsonConvert.DeserializeObject<List<Logins>>(ser);
                return logins;
            }
            return null;
        }

        /// <summary>  
        /// Creates a product  
        /// </summary>  
        /// <param name="productEntity"></param>  
        /// <returns></returns>  
        public int CreateLogin(LoginEntity loginEntity)
        {
            using (var scope = new TransactionScope())
            {
                var login = new Login
                {
                    ClientID = loginEntity.ClientID,
                    RoleID = loginEntity.RoleID,
                    User = loginEntity.User,
                    Password = loginEntity.Password,
                    Comment = loginEntity.Comment
                };
                
                _unitOfWork.LoginRepository.Insert(login);
                _unitOfWork.Save();
                scope.Complete();
                return login.LoginID;
            }
        }

        /// <summary>  
        /// Updates a product  
        /// </summary>  
        /// <param name="productId"></param>  
        /// <param name="productEntity"></param>  
        /// <returns></returns>  
        public bool UpdateLogin(int LoginId,LoginEntity loginEntity)
        {
            var success = false;
            if (loginEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var login = _unitOfWork.LoginRepository.GetByID(LoginId);
                    if (login != null)
                    {
                        login.ClientID = loginEntity.ClientID;
                        login.RoleID = loginEntity.RoleID;
                        login.User = loginEntity.User;
                        login.Password = loginEntity.Password;
                        login.Comment = loginEntity.Comment;
                        _unitOfWork.LoginRepository.Update(login);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        /// <summary>  
        /// Deletes a particular product  
        /// </summary>  
        /// <param name="productId"></param>  
        /// <returns></returns>  
        public bool DeleteLogin(int loginId)
        {
            var success = false;
            if (loginId > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var login = _unitOfWork.LoginRepository.GetByID(loginId);
                    if (login != null)
                    {

                        _unitOfWork.LoginRepository.Delete(login);
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
