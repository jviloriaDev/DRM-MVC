using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Proveedores;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Proveedores
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class ProveedoresService : IProveedoresService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Proveedores.Proveedores> _ProveedoresRepository;
        #endregion

        #region Ctor
        public ProveedoresService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Proveedores.Proveedores> ProveedoresRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._ProveedoresRepository = ProveedoresRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Proveedores.Proveedores> SelAll(bool ConRelaciones)
        {
            return this._ProveedoresRepository.Table.ToList();
        }

        public IList<Core.Domain.Proveedores.Proveedores> SelAllComplete(bool ConRelaciones)
        {
            return this._ProveedoresRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Proveedores.Proveedores> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._ProveedoresRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Proveedores.Proveedores> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._ProveedoresRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Proveedores.Proveedores> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._ProveedoresRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Proveedores.ProveedoresPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            ProveedoresPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Proveedores.Proveedores> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._ProveedoresRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Proveedores.Proveedores GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Proveedores.Proveedores result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData ProveedoresInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Proveedores.Proveedores entity, Spartane.Core.Domain.User.GlobalData ProveedoresInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Proveedores.Proveedores entity, Spartane.Core.Domain.User.GlobalData ProveedoresInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

