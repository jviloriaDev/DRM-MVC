using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Spartan_WorkFlow_Roles_by_State;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_WorkFlow_Roles_by_State
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_WorkFlow_Roles_by_StateService : ISpartan_WorkFlow_Roles_by_StateService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_State> _Spartan_WorkFlow_Roles_by_StateRepository;
        #endregion

        #region Ctor
        public Spartan_WorkFlow_Roles_by_StateService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_State> Spartan_WorkFlow_Roles_by_StateRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_WorkFlow_Roles_by_StateRepository = Spartan_WorkFlow_Roles_by_StateRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_State> SelAll(bool ConRelaciones)
        {
            return this._Spartan_WorkFlow_Roles_by_StateRepository.Table.ToList();
        }

        public IList<Core.Domain.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_State> SelAllComplete(bool ConRelaciones)
        {
            return this._Spartan_WorkFlow_Roles_by_StateRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_State> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_WorkFlow_Roles_by_StateRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_State> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_WorkFlow_Roles_by_StateRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_State> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_WorkFlow_Roles_by_StateRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_StatePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Spartan_WorkFlow_Roles_by_StatePagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_State> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_WorkFlow_Roles_by_StateRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_State GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_State result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Spartan_WorkFlow_Roles_by_StateInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_State entity, Spartane.Core.Domain.User.GlobalData Spartan_WorkFlow_Roles_by_StateInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_State entity, Spartane.Core.Domain.User.GlobalData Spartan_WorkFlow_Roles_by_StateInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

