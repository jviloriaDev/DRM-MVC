using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Spartan_BR_Testing;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_BR_Testing
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_BR_TestingService : ISpartan_BR_TestingService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Spartan_BR_Testing.Spartan_BR_Testing> _Spartan_BR_TestingRepository;
        #endregion

        #region Ctor
        public Spartan_BR_TestingService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Spartan_BR_Testing.Spartan_BR_Testing> Spartan_BR_TestingRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_BR_TestingRepository = Spartan_BR_TestingRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Spartan_BR_Testing.Spartan_BR_Testing> SelAll(bool ConRelaciones)
        {
            return this._Spartan_BR_TestingRepository.Table.ToList();
        }

        public IList<Core.Domain.Spartan_BR_Testing.Spartan_BR_Testing> SelAllComplete(bool ConRelaciones)
        {
            return this._Spartan_BR_TestingRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Spartan_BR_Testing.Spartan_BR_Testing> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_BR_TestingRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_BR_Testing.Spartan_BR_Testing> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_BR_TestingRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_BR_Testing.Spartan_BR_Testing> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_BR_TestingRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_BR_Testing.Spartan_BR_TestingPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Spartan_BR_TestingPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Spartan_BR_Testing.Spartan_BR_Testing> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_BR_TestingRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_BR_Testing.Spartan_BR_Testing GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Spartan_BR_Testing.Spartan_BR_Testing result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Spartan_BR_TestingInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Spartan_BR_Testing.Spartan_BR_Testing entity, Spartane.Core.Domain.User.GlobalData Spartan_BR_TestingInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Spartan_BR_Testing.Spartan_BR_Testing entity, Spartane.Core.Domain.User.GlobalData Spartan_BR_TestingInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

