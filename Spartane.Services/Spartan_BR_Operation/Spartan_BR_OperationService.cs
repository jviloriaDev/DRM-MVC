using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Spartan_BR_Operation;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_BR_Operation
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_BR_OperationService : ISpartan_BR_OperationService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Spartan_BR_Operation.Spartan_BR_Operation> _Spartan_BR_OperationRepository;
        #endregion

        #region Ctor
        public Spartan_BR_OperationService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Spartan_BR_Operation.Spartan_BR_Operation> Spartan_BR_OperationRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_BR_OperationRepository = Spartan_BR_OperationRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Spartan_BR_Operation.Spartan_BR_Operation> SelAll(bool ConRelaciones)
        {
            return this._Spartan_BR_OperationRepository.Table.ToList();
        }

        public IList<Core.Domain.Spartan_BR_Operation.Spartan_BR_Operation> SelAllComplete(bool ConRelaciones)
        {
            return this._Spartan_BR_OperationRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Spartan_BR_Operation.Spartan_BR_Operation> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_BR_OperationRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_BR_Operation.Spartan_BR_Operation> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_BR_OperationRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_BR_Operation.Spartan_BR_Operation> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_BR_OperationRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_BR_Operation.Spartan_BR_OperationPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Spartan_BR_OperationPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Spartan_BR_Operation.Spartan_BR_Operation> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_BR_OperationRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_BR_Operation.Spartan_BR_Operation GetByKey(short Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Spartan_BR_Operation.Spartan_BR_Operation result=null;
            return result;
        }

        public bool Delete(short Key, Spartane.Core.Domain.User.GlobalData Spartan_BR_OperationInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public short Insert(Spartane.Core.Domain.Spartan_BR_Operation.Spartan_BR_Operation entity, Spartane.Core.Domain.User.GlobalData Spartan_BR_OperationInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            short rta = Convert.ToInt16("0");
            return rta;
        }

        public short Update(Spartane.Core.Domain.Spartan_BR_Operation.Spartan_BR_Operation entity, Spartane.Core.Domain.User.GlobalData Spartan_BR_OperationInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            short rta = Convert.ToInt16("0");
            return rta;
        }
        #endregion
    }
}

