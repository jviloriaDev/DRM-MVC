using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Spartan_User_Role_Status;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_User_Role_Status
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_User_Role_StatusService : ISpartan_User_Role_StatusService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Spartan_User_Role_Status.Spartan_User_Role_Status> _Spartan_User_Role_StatusRepository;
        #endregion

        #region Ctor
        public Spartan_User_Role_StatusService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Spartan_User_Role_Status.Spartan_User_Role_Status> Spartan_User_Role_StatusRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_User_Role_StatusRepository = Spartan_User_Role_StatusRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Spartan_User_Role_Status.Spartan_User_Role_Status> SelAll(bool ConRelaciones)
        {
            return this._Spartan_User_Role_StatusRepository.Table.ToList();
        }

        public IList<Core.Domain.Spartan_User_Role_Status.Spartan_User_Role_Status> SelAllComplete(bool ConRelaciones)
        {
            return this._Spartan_User_Role_StatusRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Spartan_User_Role_Status.Spartan_User_Role_Status> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_User_Role_StatusRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_User_Role_Status.Spartan_User_Role_Status> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_User_Role_StatusRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_User_Role_Status.Spartan_User_Role_Status> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_User_Role_StatusRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_User_Role_Status.Spartan_User_Role_StatusPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Spartan_User_Role_StatusPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Spartan_User_Role_Status.Spartan_User_Role_Status> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_User_Role_StatusRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_User_Role_Status.Spartan_User_Role_Status GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Spartan_User_Role_Status.Spartan_User_Role_Status result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Spartan_User_Role_StatusInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Spartan_User_Role_Status.Spartan_User_Role_Status entity, Spartane.Core.Domain.User.GlobalData Spartan_User_Role_StatusInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Spartan_User_Role_Status.Spartan_User_Role_Status entity, Spartane.Core.Domain.User.GlobalData Spartan_User_Role_StatusInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

