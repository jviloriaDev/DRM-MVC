using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Dashboard_Status;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Dashboard_Status
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Dashboard_StatusService : IDashboard_StatusService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Dashboard_Status.Dashboard_Status> _Dashboard_StatusRepository;
        #endregion

        #region Ctor
        public Dashboard_StatusService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Dashboard_Status.Dashboard_Status> Dashboard_StatusRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Dashboard_StatusRepository = Dashboard_StatusRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Dashboard_Status.Dashboard_Status> SelAll(bool ConRelaciones)
        {
            return this._Dashboard_StatusRepository.Table.ToList();
        }

        public IList<Core.Domain.Dashboard_Status.Dashboard_Status> SelAllComplete(bool ConRelaciones)
        {
            return this._Dashboard_StatusRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Dashboard_Status.Dashboard_Status> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Dashboard_StatusRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Dashboard_Status.Dashboard_Status> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Dashboard_StatusRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Dashboard_Status.Dashboard_Status> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Dashboard_StatusRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Dashboard_Status.Dashboard_StatusPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Dashboard_StatusPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Dashboard_Status.Dashboard_Status> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Dashboard_StatusRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Dashboard_Status.Dashboard_Status GetByKey(short Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Dashboard_Status.Dashboard_Status result=null;
            return result;
        }

        public bool Delete(short Key, Spartane.Core.Domain.User.GlobalData Dashboard_StatusInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public short Insert(Spartane.Core.Domain.Dashboard_Status.Dashboard_Status entity, Spartane.Core.Domain.User.GlobalData Dashboard_StatusInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            short rta = Convert.ToInt16("0");
            return rta;
        }

        public short Update(Spartane.Core.Domain.Dashboard_Status.Dashboard_Status entity, Spartane.Core.Domain.User.GlobalData Dashboard_StatusInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            short rta = Convert.ToInt16("0");
            return rta;
        }
        #endregion
    }
}

