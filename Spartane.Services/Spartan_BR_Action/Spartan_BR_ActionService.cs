using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Spartan_BR_Action;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_BR_Action
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_BR_ActionService : ISpartan_BR_ActionService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Spartan_BR_Action.Spartan_BR_Action> _Spartan_BR_ActionRepository;
        #endregion

        #region Ctor
        public Spartan_BR_ActionService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Spartan_BR_Action.Spartan_BR_Action> Spartan_BR_ActionRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_BR_ActionRepository = Spartan_BR_ActionRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Spartan_BR_Action.Spartan_BR_Action> SelAll(bool ConRelaciones)
        {
            return this._Spartan_BR_ActionRepository.Table.ToList();
        }

        public IList<Core.Domain.Spartan_BR_Action.Spartan_BR_Action> SelAllComplete(bool ConRelaciones)
        {
            return this._Spartan_BR_ActionRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Spartan_BR_Action.Spartan_BR_Action> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_BR_ActionRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_BR_Action.Spartan_BR_Action> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_BR_ActionRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_BR_Action.Spartan_BR_Action> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_BR_ActionRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_BR_Action.Spartan_BR_ActionPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Spartan_BR_ActionPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Spartan_BR_Action.Spartan_BR_Action> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_BR_ActionRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_BR_Action.Spartan_BR_Action GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Spartan_BR_Action.Spartan_BR_Action result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Spartan_BR_ActionInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Spartan_BR_Action.Spartan_BR_Action entity, Spartane.Core.Domain.User.GlobalData Spartan_BR_ActionInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Spartan_BR_Action.Spartan_BR_Action entity, Spartane.Core.Domain.User.GlobalData Spartan_BR_ActionInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

