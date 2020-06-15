using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Spartan_User_Historical_Password;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_User_Historical_Password
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_User_Historical_PasswordService : ISpartan_User_Historical_PasswordService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Spartan_User_Historical_Password.Spartan_User_Historical_Password> _Spartan_User_Historical_PasswordRepository;
        #endregion

        #region Ctor
        public Spartan_User_Historical_PasswordService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Spartan_User_Historical_Password.Spartan_User_Historical_Password> Spartan_User_Historical_PasswordRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_User_Historical_PasswordRepository = Spartan_User_Historical_PasswordRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Spartan_User_Historical_Password.Spartan_User_Historical_Password> SelAll(bool ConRelaciones)
        {
            return this._Spartan_User_Historical_PasswordRepository.Table.ToList();
        }

        public IList<Core.Domain.Spartan_User_Historical_Password.Spartan_User_Historical_Password> SelAllComplete(bool ConRelaciones)
        {
            return this._Spartan_User_Historical_PasswordRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Spartan_User_Historical_Password.Spartan_User_Historical_Password> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_User_Historical_PasswordRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_User_Historical_Password.Spartan_User_Historical_Password> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_User_Historical_PasswordRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_User_Historical_Password.Spartan_User_Historical_Password> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_User_Historical_PasswordRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_User_Historical_Password.Spartan_User_Historical_PasswordPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Spartan_User_Historical_PasswordPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Spartan_User_Historical_Password.Spartan_User_Historical_Password> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_User_Historical_PasswordRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_User_Historical_Password.Spartan_User_Historical_Password GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Spartan_User_Historical_Password.Spartan_User_Historical_Password result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Spartan_User_Historical_PasswordInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Spartan_User_Historical_Password.Spartan_User_Historical_Password entity, Spartane.Core.Domain.User.GlobalData Spartan_User_Historical_PasswordInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Spartan_User_Historical_Password.Spartan_User_Historical_Password entity, Spartane.Core.Domain.User.GlobalData Spartan_User_Historical_PasswordInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

