using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Detalle_Sucursales_Proveedores;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Sucursales_Proveedores
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Sucursales_ProveedoresService : IDetalle_Sucursales_ProveedoresService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Detalle_Sucursales_Proveedores.Detalle_Sucursales_Proveedores> _Detalle_Sucursales_ProveedoresRepository;
        #endregion

        #region Ctor
        public Detalle_Sucursales_ProveedoresService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Detalle_Sucursales_Proveedores.Detalle_Sucursales_Proveedores> Detalle_Sucursales_ProveedoresRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Sucursales_ProveedoresRepository = Detalle_Sucursales_ProveedoresRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Detalle_Sucursales_Proveedores.Detalle_Sucursales_Proveedores> SelAll(bool ConRelaciones)
        {
            return this._Detalle_Sucursales_ProveedoresRepository.Table.ToList();
        }

        public IList<Core.Domain.Detalle_Sucursales_Proveedores.Detalle_Sucursales_Proveedores> SelAllComplete(bool ConRelaciones)
        {
            return this._Detalle_Sucursales_ProveedoresRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Detalle_Sucursales_Proveedores.Detalle_Sucursales_Proveedores> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Sucursales_ProveedoresRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_Sucursales_Proveedores.Detalle_Sucursales_Proveedores> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Sucursales_ProveedoresRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_Sucursales_Proveedores.Detalle_Sucursales_Proveedores> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Sucursales_ProveedoresRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_Sucursales_Proveedores.Detalle_Sucursales_ProveedoresPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Detalle_Sucursales_ProveedoresPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Detalle_Sucursales_Proveedores.Detalle_Sucursales_Proveedores> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Sucursales_ProveedoresRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_Sucursales_Proveedores.Detalle_Sucursales_Proveedores GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Detalle_Sucursales_Proveedores.Detalle_Sucursales_Proveedores result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Detalle_Sucursales_ProveedoresInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Detalle_Sucursales_Proveedores.Detalle_Sucursales_Proveedores entity, Spartane.Core.Domain.User.GlobalData Detalle_Sucursales_ProveedoresInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Detalle_Sucursales_Proveedores.Detalle_Sucursales_Proveedores entity, Spartane.Core.Domain.User.GlobalData Detalle_Sucursales_ProveedoresInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

