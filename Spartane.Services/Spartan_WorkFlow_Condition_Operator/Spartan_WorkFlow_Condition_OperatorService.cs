using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Spartan_WorkFlow_Condition_Operator;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_WorkFlow_Condition_Operator
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_WorkFlow_Condition_OperatorService : ISpartan_WorkFlow_Condition_OperatorService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Spartan_WorkFlow_Condition_Operator.Spartan_WorkFlow_Condition_Operator> _Spartan_WorkFlow_Condition_OperatorRepository;
        #endregion

        #region Ctor
        public Spartan_WorkFlow_Condition_OperatorService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Spartan_WorkFlow_Condition_Operator.Spartan_WorkFlow_Condition_Operator> Spartan_WorkFlow_Condition_OperatorRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_WorkFlow_Condition_OperatorRepository = Spartan_WorkFlow_Condition_OperatorRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Spartan_WorkFlow_Condition_Operator.Spartan_WorkFlow_Condition_Operator> SelAll(bool ConRelaciones)
        {
            return this._Spartan_WorkFlow_Condition_OperatorRepository.Table.ToList();
        }

        public IList<Core.Domain.Spartan_WorkFlow_Condition_Operator.Spartan_WorkFlow_Condition_Operator> SelAllComplete(bool ConRelaciones)
        {
            return this._Spartan_WorkFlow_Condition_OperatorRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Spartan_WorkFlow_Condition_Operator.Spartan_WorkFlow_Condition_Operator> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_WorkFlow_Condition_OperatorRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_WorkFlow_Condition_Operator.Spartan_WorkFlow_Condition_Operator> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_WorkFlow_Condition_OperatorRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_WorkFlow_Condition_Operator.Spartan_WorkFlow_Condition_Operator> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_WorkFlow_Condition_OperatorRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_WorkFlow_Condition_Operator.Spartan_WorkFlow_Condition_OperatorPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Spartan_WorkFlow_Condition_OperatorPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Spartan_WorkFlow_Condition_Operator.Spartan_WorkFlow_Condition_Operator> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_WorkFlow_Condition_OperatorRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_WorkFlow_Condition_Operator.Spartan_WorkFlow_Condition_Operator GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Spartan_WorkFlow_Condition_Operator.Spartan_WorkFlow_Condition_Operator result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Spartan_WorkFlow_Condition_OperatorInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Spartan_WorkFlow_Condition_Operator.Spartan_WorkFlow_Condition_Operator entity, Spartane.Core.Domain.User.GlobalData Spartan_WorkFlow_Condition_OperatorInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Spartan_WorkFlow_Condition_Operator.Spartan_WorkFlow_Condition_Operator entity, Spartane.Core.Domain.User.GlobalData Spartan_WorkFlow_Condition_OperatorInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

