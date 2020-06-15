using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Spartan_User;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_User
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_UserService : ISpartan_UserService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Spartan_User.Spartan_User> _Spartan_UserRepository;
        #endregion

        #region Ctor
        public Spartan_UserService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Spartan_User.Spartan_User> Spartan_UserRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_UserRepository = Spartan_UserRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Spartan_User.Spartan_User> SelAll(bool ConRelaciones)
        {
            return this._Spartan_UserRepository.Table.ToList();
        }

        public IList<Core.Domain.Spartan_User.Spartan_User> SelAllComplete(bool ConRelaciones)
        {
            return this._Spartan_UserRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Spartan_User.Spartan_User> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_UserRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_User.Spartan_User> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_UserRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_User.Spartan_User> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_UserRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_User.Spartan_UserPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Spartan_UserPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Spartan_User.Spartan_User> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_UserRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_User.Spartan_User GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Spartan_User.Spartan_User result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Spartan_UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Spartan_User.Spartan_User entity, Spartane.Core.Domain.User.GlobalData Spartan_UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Spartan_User.Spartan_User entity, Spartane.Core.Domain.User.GlobalData Spartan_UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

