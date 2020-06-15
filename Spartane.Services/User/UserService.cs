using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.User;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;

namespace Spartane.Services.User
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class UserService: IUserService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        //private List<TTUsuario> _users;
        private readonly IRepository<TTUsuario> _usersRepository;
        #endregion

        #region Ctor
        public UserService(IDataProvider dataProvider, IDbContext dbContext, IRepository<TTUsuario> userRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._usersRepository = userRepository;
        }
        #endregion
        public GlobalData Login(string sUser, string sPassword, int Language)
        {
            var user = _dataProvider.GetParameter();
            user.ParameterName = "User";
            user.DbType = DbType.String;
            user.Value = sUser;

            var password = _dataProvider.GetParameter();
            password.ParameterName = "Password";
            password.DbType = DbType.String;
            password.Value = sPassword;

            var loginReturn = _dbContext.ExecuteStoredProcedureList<TTUsuario>(
                "spTTSecurity_LoginUser",
                user,
                password);
            if ((loginReturn == null) || (loginReturn.Count == 0))
                return null;
            else
            {
                var UserInformation = new GlobalData();
                var userLoged = loginReturn[0];
                UserInformation.UserID = userLoged.IdUsuario;
                UserInformation.UserName = userLoged.Nombre;
                UserInformation.ComputerName = ""; // context of user ¿?
                System.OperatingSystem osInfo = System.Environment.OSVersion;
                UserInformation.WindowsVersion = osInfo.VersionString;
                UserInformation.ServidorName = ""; //Context of Server
                UserInformation.ServidorNameComputer = ""; //Context of Server
                UserInformation.DatabaseName = "";//Context of database
                UserInformation.Language = (GlobalDataLanguages)Language;
                return UserInformation;
            }
        }

        public bool LogOff(GlobalData UserInformation)
        {
            //must insert into bitacora
            UserInformation = null;
            return true;
        }


        public TTUsuario GetUserByUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return null;
            var query = from c in _usersRepository.Table
                        orderby c.IdUsuario
                        where c.Clave_de_Acceso == username
                        select c;
            var user = query.FirstOrDefault();
            return user;
        }

        public GlobalData GetGlobalDataByUserName(string username)
        {
            var UserInformation = new GlobalData();
            var userLoged = GetUserByUsername(username);
            if (userLoged != null)
            {
                UserInformation.UserID = userLoged.IdUsuario;
                UserInformation.UserName = userLoged.Nombre;
                UserInformation.ComputerName = ""; // context of user ¿?
                System.OperatingSystem osInfo = System.Environment.OSVersion;
                UserInformation.WindowsVersion = osInfo.VersionString;
                UserInformation.ServidorName = ""; //Context of Server
                UserInformation.ServidorNameComputer = ""; //Context of Server
                UserInformation.DatabaseName = "";//Context of database
                UserInformation.Language = (GlobalDataLanguages)1;
            }
            return UserInformation;
        }

        #region CRUD Operations
        public int SelCount()
        {
            return this._usersRepository.Table.Count();
        }

        public IList<TTUsuario> SelAll(bool ConRelaciones)
        {
            return this._usersRepository.Table.ToList();
        }

        public IList<TTUsuario> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._usersRepository.Table.ToList();
        }

        public TTUsuario GetByKey(int? Key, bool ConRelaciones)
        {
            return this._usersRepository.Table
                .Where(v => v.IdUsuario == Key.Value)
                .SingleOrDefault();
        }

        public bool Delete(int? Key, GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            try
            {
                var entity = _usersRepository.GetById(Key);
                _usersRepository.Delete(entity);
            }
            catch (ExceptionBase ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message, ex);
            }

            return rta;
        }

        public int Insert(TTUsuario entity, GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = 0;
            try
            {
                _usersRepository.Insert(entity);
                rta = entity.IdUsuario;
            }
            catch (ExceptionBase ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message, ex);
            }

            return rta;
        }

        public int Update(TTUsuario entity, GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = 0;
            try
            {
                _usersRepository.Update(entity);
                rta = entity.IdUsuario;
            }
            catch (ExceptionBase ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message, ex);
            }

            return rta;
        }
        #endregion
    }
}
