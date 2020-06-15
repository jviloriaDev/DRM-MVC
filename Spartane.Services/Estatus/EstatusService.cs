using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Estatus;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Estatus
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class EstatusService : IEstatusService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Estatus.Estatus> _EstatusRepository;
        #endregion

        #region Ctor
        public EstatusService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Estatus.Estatus> EstatusRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._EstatusRepository = EstatusRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Estatus.Estatus> SelAll(bool ConRelaciones)
        {
            return this._EstatusRepository.Table.ToList();
        }

        public IList<Core.Domain.Estatus.Estatus> SelAllComplete(bool ConRelaciones)
        {
            return this._EstatusRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Estatus.Estatus> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._EstatusRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Estatus.Estatus> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._EstatusRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Estatus.Estatus> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._EstatusRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Estatus.EstatusPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            EstatusPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Estatus.Estatus> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._EstatusRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Estatus.Estatus GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Estatus.Estatus result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EstatusInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Estatus.Estatus entity, Spartane.Core.Domain.User.GlobalData EstatusInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Estatus.Estatus entity, Spartane.Core.Domain.User.GlobalData EstatusInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

