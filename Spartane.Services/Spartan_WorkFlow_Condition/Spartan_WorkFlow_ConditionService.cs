using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Spartan_WorkFlow_Condition;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_WorkFlow_Condition
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_WorkFlow_ConditionService : ISpartan_WorkFlow_ConditionService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Spartan_WorkFlow_Condition.Spartan_WorkFlow_Condition> _Spartan_WorkFlow_ConditionRepository;
        #endregion

        #region Ctor
        public Spartan_WorkFlow_ConditionService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Spartan_WorkFlow_Condition.Spartan_WorkFlow_Condition> Spartan_WorkFlow_ConditionRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_WorkFlow_ConditionRepository = Spartan_WorkFlow_ConditionRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Spartan_WorkFlow_Condition.Spartan_WorkFlow_Condition> SelAll(bool ConRelaciones)
        {
            return this._Spartan_WorkFlow_ConditionRepository.Table.ToList();
        }

        public IList<Core.Domain.Spartan_WorkFlow_Condition.Spartan_WorkFlow_Condition> SelAllComplete(bool ConRelaciones)
        {
            return this._Spartan_WorkFlow_ConditionRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Spartan_WorkFlow_Condition.Spartan_WorkFlow_Condition> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_WorkFlow_ConditionRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_WorkFlow_Condition.Spartan_WorkFlow_Condition> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_WorkFlow_ConditionRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_WorkFlow_Condition.Spartan_WorkFlow_Condition> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_WorkFlow_ConditionRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_WorkFlow_Condition.Spartan_WorkFlow_ConditionPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Spartan_WorkFlow_ConditionPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Spartan_WorkFlow_Condition.Spartan_WorkFlow_Condition> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_WorkFlow_ConditionRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_WorkFlow_Condition.Spartan_WorkFlow_Condition GetByKey(short Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Spartan_WorkFlow_Condition.Spartan_WorkFlow_Condition result=null;
            return result;
        }

        public bool Delete(short Key, Spartane.Core.Domain.User.GlobalData Spartan_WorkFlow_ConditionInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public short Insert(Spartane.Core.Domain.Spartan_WorkFlow_Condition.Spartan_WorkFlow_Condition entity, Spartane.Core.Domain.User.GlobalData Spartan_WorkFlow_ConditionInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            short rta = Convert.ToInt16("0");
            return rta;
        }

        public short Update(Spartane.Core.Domain.Spartan_WorkFlow_Condition.Spartan_WorkFlow_Condition entity, Spartane.Core.Domain.User.GlobalData Spartan_WorkFlow_ConditionInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            short rta = Convert.ToInt16("0");
            return rta;
        }
        #endregion
    }
}

