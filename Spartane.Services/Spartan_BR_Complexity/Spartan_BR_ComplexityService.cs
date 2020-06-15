using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Spartan_BR_Complexity;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_BR_Complexity
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_BR_ComplexityService : ISpartan_BR_ComplexityService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Spartan_BR_Complexity.Spartan_BR_Complexity> _Spartan_BR_ComplexityRepository;
        #endregion

        #region Ctor
        public Spartan_BR_ComplexityService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Spartan_BR_Complexity.Spartan_BR_Complexity> Spartan_BR_ComplexityRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_BR_ComplexityRepository = Spartan_BR_ComplexityRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Spartan_BR_Complexity.Spartan_BR_Complexity> SelAll(bool ConRelaciones)
        {
            return this._Spartan_BR_ComplexityRepository.Table.ToList();
        }

        public IList<Core.Domain.Spartan_BR_Complexity.Spartan_BR_Complexity> SelAllComplete(bool ConRelaciones)
        {
            return this._Spartan_BR_ComplexityRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Spartan_BR_Complexity.Spartan_BR_Complexity> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_BR_ComplexityRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_BR_Complexity.Spartan_BR_Complexity> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_BR_ComplexityRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_BR_Complexity.Spartan_BR_Complexity> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_BR_ComplexityRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_BR_Complexity.Spartan_BR_ComplexityPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Spartan_BR_ComplexityPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Spartan_BR_Complexity.Spartan_BR_Complexity> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_BR_ComplexityRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_BR_Complexity.Spartan_BR_Complexity GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Spartan_BR_Complexity.Spartan_BR_Complexity result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Spartan_BR_ComplexityInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Spartan_BR_Complexity.Spartan_BR_Complexity entity, Spartane.Core.Domain.User.GlobalData Spartan_BR_ComplexityInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Spartan_BR_Complexity.Spartan_BR_Complexity entity, Spartane.Core.Domain.User.GlobalData Spartan_BR_ComplexityInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

