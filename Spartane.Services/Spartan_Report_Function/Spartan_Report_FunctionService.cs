using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Spartan_Report_Function;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Report_Function
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_Report_FunctionService : ISpartan_Report_FunctionService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Spartan_Report_Function.Spartan_Report_Function> _Spartan_Report_FunctionRepository;
        #endregion

        #region Ctor
        public Spartan_Report_FunctionService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Spartan_Report_Function.Spartan_Report_Function> Spartan_Report_FunctionRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_Report_FunctionRepository = Spartan_Report_FunctionRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Spartan_Report_Function.Spartan_Report_Function> SelAll(bool ConRelaciones)
        {
            return this._Spartan_Report_FunctionRepository.Table.ToList();
        }

        public IList<Core.Domain.Spartan_Report_Function.Spartan_Report_Function> SelAllComplete(bool ConRelaciones)
        {
            return this._Spartan_Report_FunctionRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Spartan_Report_Function.Spartan_Report_Function> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Report_FunctionRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_Report_Function.Spartan_Report_Function> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_Report_FunctionRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_Report_Function.Spartan_Report_Function> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Report_FunctionRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_Report_Function.Spartan_Report_FunctionPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Spartan_Report_FunctionPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Spartan_Report_Function.Spartan_Report_Function> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_Report_FunctionRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_Report_Function.Spartan_Report_Function GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Spartan_Report_Function.Spartan_Report_Function result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Spartan_Report_FunctionInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Spartan_Report_Function.Spartan_Report_Function entity, Spartane.Core.Domain.User.GlobalData Spartan_Report_FunctionInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Spartan_Report_Function.Spartan_Report_Function entity, Spartane.Core.Domain.User.GlobalData Spartan_Report_FunctionInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

