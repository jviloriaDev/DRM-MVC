using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Business_Rule_Creation;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Business_Rule_Creation
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Business_Rule_CreationService : IBusiness_Rule_CreationService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Business_Rule_Creation.Business_Rule_Creation> _Business_Rule_CreationRepository;
        #endregion

        #region Ctor
        public Business_Rule_CreationService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Business_Rule_Creation.Business_Rule_Creation> Business_Rule_CreationRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Business_Rule_CreationRepository = Business_Rule_CreationRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Business_Rule_Creation.Business_Rule_Creation> SelAll(bool ConRelaciones)
        {
            return this._Business_Rule_CreationRepository.Table.ToList();
        }

        public IList<Core.Domain.Business_Rule_Creation.Business_Rule_Creation> SelAllComplete(bool ConRelaciones)
        {
            return this._Business_Rule_CreationRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Business_Rule_Creation.Business_Rule_Creation> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Business_Rule_CreationRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Business_Rule_Creation.Business_Rule_Creation> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Business_Rule_CreationRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Business_Rule_Creation.Business_Rule_Creation> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Business_Rule_CreationRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Business_Rule_Creation.Business_Rule_CreationPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Business_Rule_CreationPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Business_Rule_Creation.Business_Rule_Creation> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Business_Rule_CreationRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Business_Rule_Creation.Business_Rule_Creation GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Business_Rule_Creation.Business_Rule_Creation result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Business_Rule_CreationInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Business_Rule_Creation.Business_Rule_Creation entity, Spartane.Core.Domain.User.GlobalData Business_Rule_CreationInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Business_Rule_Creation.Business_Rule_Creation entity, Spartane.Core.Domain.User.GlobalData Business_Rule_CreationInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

