using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Spartan_WorkFlow;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_WorkFlow
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_WorkFlowService : ISpartan_WorkFlowService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Spartan_WorkFlow.Spartan_WorkFlow> _Spartan_WorkFlowRepository;
        #endregion

        #region Ctor
        public Spartan_WorkFlowService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Spartan_WorkFlow.Spartan_WorkFlow> Spartan_WorkFlowRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_WorkFlowRepository = Spartan_WorkFlowRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Spartan_WorkFlow.Spartan_WorkFlow> SelAll(bool ConRelaciones)
        {
            return this._Spartan_WorkFlowRepository.Table.ToList();
        }

        public IList<Core.Domain.Spartan_WorkFlow.Spartan_WorkFlow> SelAllComplete(bool ConRelaciones)
        {
            return this._Spartan_WorkFlowRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Spartan_WorkFlow.Spartan_WorkFlow> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_WorkFlowRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_WorkFlow.Spartan_WorkFlow> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_WorkFlowRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_WorkFlow.Spartan_WorkFlow> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_WorkFlowRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_WorkFlow.Spartan_WorkFlowPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Spartan_WorkFlowPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Spartan_WorkFlow.Spartan_WorkFlow> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_WorkFlowRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_WorkFlow.Spartan_WorkFlow GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Spartan_WorkFlow.Spartan_WorkFlow result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Spartan_WorkFlowInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Spartan_WorkFlow.Spartan_WorkFlow entity, Spartane.Core.Domain.User.GlobalData Spartan_WorkFlowInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Spartan_WorkFlow.Spartan_WorkFlow entity, Spartane.Core.Domain.User.GlobalData Spartan_WorkFlowInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

