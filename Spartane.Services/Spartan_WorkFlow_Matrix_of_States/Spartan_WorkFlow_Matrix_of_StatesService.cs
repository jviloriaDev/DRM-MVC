using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Spartan_WorkFlow_Matrix_of_States;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_WorkFlow_Matrix_of_States
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_WorkFlow_Matrix_of_StatesService : ISpartan_WorkFlow_Matrix_of_StatesService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_States> _Spartan_WorkFlow_Matrix_of_StatesRepository;
        #endregion

        #region Ctor
        public Spartan_WorkFlow_Matrix_of_StatesService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_States> Spartan_WorkFlow_Matrix_of_StatesRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_WorkFlow_Matrix_of_StatesRepository = Spartan_WorkFlow_Matrix_of_StatesRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_States> SelAll(bool ConRelaciones)
        {
            return this._Spartan_WorkFlow_Matrix_of_StatesRepository.Table.ToList();
        }

        public IList<Core.Domain.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_States> SelAllComplete(bool ConRelaciones)
        {
            return this._Spartan_WorkFlow_Matrix_of_StatesRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_States> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_WorkFlow_Matrix_of_StatesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_States> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_WorkFlow_Matrix_of_StatesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_States> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_WorkFlow_Matrix_of_StatesRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_StatesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Spartan_WorkFlow_Matrix_of_StatesPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_States> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_WorkFlow_Matrix_of_StatesRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_States GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_States result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Spartan_WorkFlow_Matrix_of_StatesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_States entity, Spartane.Core.Domain.User.GlobalData Spartan_WorkFlow_Matrix_of_StatesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_States entity, Spartane.Core.Domain.User.GlobalData Spartan_WorkFlow_Matrix_of_StatesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

