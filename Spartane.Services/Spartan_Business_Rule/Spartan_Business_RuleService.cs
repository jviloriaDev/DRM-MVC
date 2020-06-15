using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Spartan_Business_Rule;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Business_Rule
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_Business_RuleService : ISpartan_Business_RuleService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Spartan_Business_Rule.Spartan_Business_Rule> _Spartan_Business_RuleRepository;
        #endregion

        #region Ctor
        public Spartan_Business_RuleService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Spartan_Business_Rule.Spartan_Business_Rule> Spartan_Business_RuleRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_Business_RuleRepository = Spartan_Business_RuleRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Spartan_Business_Rule.Spartan_Business_Rule> SelAll(bool ConRelaciones)
        {
            return this._Spartan_Business_RuleRepository.Table.ToList();
        }

        public IList<Core.Domain.Spartan_Business_Rule.Spartan_Business_Rule> SelAllComplete(bool ConRelaciones)
        {
            return this._Spartan_Business_RuleRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Spartan_Business_Rule.Spartan_Business_Rule> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Business_RuleRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_Business_Rule.Spartan_Business_Rule> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_Business_RuleRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_Business_Rule.Spartan_Business_Rule> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Business_RuleRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_Business_Rule.Spartan_Business_RulePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Spartan_Business_RulePagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Spartan_Business_Rule.Spartan_Business_Rule> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_Business_RuleRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_Business_Rule.Spartan_Business_Rule GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Spartan_Business_Rule.Spartan_Business_Rule result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Spartan_Business_RuleInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Spartan_Business_Rule.Spartan_Business_Rule entity, Spartane.Core.Domain.User.GlobalData Spartan_Business_RuleInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Spartan_Business_Rule.Spartan_Business_Rule entity, Spartane.Core.Domain.User.GlobalData Spartan_Business_RuleInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

