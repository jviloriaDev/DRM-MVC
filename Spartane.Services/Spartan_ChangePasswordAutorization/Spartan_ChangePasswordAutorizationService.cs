using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Spartan_ChangePasswordAutorization;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_ChangePasswordAutorization
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_ChangePasswordAutorizationService : ISpartan_ChangePasswordAutorizationService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization> _Spartan_ChangePasswordAutorizationRepository;
        #endregion

        #region Ctor
        public Spartan_ChangePasswordAutorizationService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization> Spartan_ChangePasswordAutorizationRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_ChangePasswordAutorizationRepository = Spartan_ChangePasswordAutorizationRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization> SelAll(bool ConRelaciones)
        {
            return this._Spartan_ChangePasswordAutorizationRepository.Table.ToList();
        }

        public IList<Core.Domain.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization> SelAllComplete(bool ConRelaciones)
        {
            return this._Spartan_ChangePasswordAutorizationRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_ChangePasswordAutorizationRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_ChangePasswordAutorizationRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_ChangePasswordAutorizationRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorizationPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Spartan_ChangePasswordAutorizationPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_ChangePasswordAutorizationRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Spartan_ChangePasswordAutorizationInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization entity, Spartane.Core.Domain.User.GlobalData Spartan_ChangePasswordAutorizationInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization entity, Spartane.Core.Domain.User.GlobalData Spartan_ChangePasswordAutorizationInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

