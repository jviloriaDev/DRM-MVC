using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.SpartanChangePasswordAutorizationEstatus;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.SpartanChangePasswordAutorizationEstatus
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class SpartanChangePasswordAutorizationEstatusService : ISpartanChangePasswordAutorizationEstatusService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus> _SpartanChangePasswordAutorizationEstatusRepository;
        #endregion

        #region Ctor
        public SpartanChangePasswordAutorizationEstatusService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus> SpartanChangePasswordAutorizationEstatusRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._SpartanChangePasswordAutorizationEstatusRepository = SpartanChangePasswordAutorizationEstatusRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus> SelAll(bool ConRelaciones)
        {
            return this._SpartanChangePasswordAutorizationEstatusRepository.Table.ToList();
        }

        public IList<Core.Domain.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus> SelAllComplete(bool ConRelaciones)
        {
            return this._SpartanChangePasswordAutorizationEstatusRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._SpartanChangePasswordAutorizationEstatusRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._SpartanChangePasswordAutorizationEstatusRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._SpartanChangePasswordAutorizationEstatusRepository.Table.ToList();
        }

        public Spartane.Core.Domain.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatusPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            SpartanChangePasswordAutorizationEstatusPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._SpartanChangePasswordAutorizationEstatusRepository.Table.ToList();
        }

        public Spartane.Core.Domain.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData SpartanChangePasswordAutorizationEstatusInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus entity, Spartane.Core.Domain.User.GlobalData SpartanChangePasswordAutorizationEstatusInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus entity, Spartane.Core.Domain.User.GlobalData SpartanChangePasswordAutorizationEstatusInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

