using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Spartan_BR_Rejection_Reason;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_BR_Rejection_Reason
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_BR_Rejection_ReasonService : ISpartan_BR_Rejection_ReasonService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_Reason> _Spartan_BR_Rejection_ReasonRepository;
        #endregion

        #region Ctor
        public Spartan_BR_Rejection_ReasonService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_Reason> Spartan_BR_Rejection_ReasonRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_BR_Rejection_ReasonRepository = Spartan_BR_Rejection_ReasonRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_Reason> SelAll(bool ConRelaciones)
        {
            return this._Spartan_BR_Rejection_ReasonRepository.Table.ToList();
        }

        public IList<Core.Domain.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_Reason> SelAllComplete(bool ConRelaciones)
        {
            return this._Spartan_BR_Rejection_ReasonRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_Reason> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_BR_Rejection_ReasonRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_Reason> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_BR_Rejection_ReasonRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_Reason> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_BR_Rejection_ReasonRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_ReasonPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Spartan_BR_Rejection_ReasonPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_Reason> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_BR_Rejection_ReasonRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_Reason GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_Reason result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Spartan_BR_Rejection_ReasonInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_Reason entity, Spartane.Core.Domain.User.GlobalData Spartan_BR_Rejection_ReasonInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_Reason entity, Spartane.Core.Domain.User.GlobalData Spartan_BR_Rejection_ReasonInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

