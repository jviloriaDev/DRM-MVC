using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Detalle_Suscripcion_Red_de_Especialistas_Proveedores;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Suscripcion_Red_de_Especialistas_Proveedores
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Suscripcion_Red_de_Especialistas_ProveedoresService : IDetalle_Suscripcion_Red_de_Especialistas_ProveedoresService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Detalle_Suscripcion_Red_de_Especialistas_Proveedores.Detalle_Suscripcion_Red_de_Especialistas_Proveedores> _Detalle_Suscripcion_Red_de_Especialistas_ProveedoresRepository;
        #endregion

        #region Ctor
        public Detalle_Suscripcion_Red_de_Especialistas_ProveedoresService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Detalle_Suscripcion_Red_de_Especialistas_Proveedores.Detalle_Suscripcion_Red_de_Especialistas_Proveedores> Detalle_Suscripcion_Red_de_Especialistas_ProveedoresRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Suscripcion_Red_de_Especialistas_ProveedoresRepository = Detalle_Suscripcion_Red_de_Especialistas_ProveedoresRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Detalle_Suscripcion_Red_de_Especialistas_Proveedores.Detalle_Suscripcion_Red_de_Especialistas_Proveedores> SelAll(bool ConRelaciones)
        {
            return this._Detalle_Suscripcion_Red_de_Especialistas_ProveedoresRepository.Table.ToList();
        }

        public IList<Core.Domain.Detalle_Suscripcion_Red_de_Especialistas_Proveedores.Detalle_Suscripcion_Red_de_Especialistas_Proveedores> SelAllComplete(bool ConRelaciones)
        {
            return this._Detalle_Suscripcion_Red_de_Especialistas_ProveedoresRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Detalle_Suscripcion_Red_de_Especialistas_Proveedores.Detalle_Suscripcion_Red_de_Especialistas_Proveedores> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Suscripcion_Red_de_Especialistas_ProveedoresRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_Suscripcion_Red_de_Especialistas_Proveedores.Detalle_Suscripcion_Red_de_Especialistas_Proveedores> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Suscripcion_Red_de_Especialistas_ProveedoresRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_Suscripcion_Red_de_Especialistas_Proveedores.Detalle_Suscripcion_Red_de_Especialistas_Proveedores> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Suscripcion_Red_de_Especialistas_ProveedoresRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_Suscripcion_Red_de_Especialistas_Proveedores.Detalle_Suscripcion_Red_de_Especialistas_ProveedoresPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Detalle_Suscripcion_Red_de_Especialistas_ProveedoresPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Detalle_Suscripcion_Red_de_Especialistas_Proveedores.Detalle_Suscripcion_Red_de_Especialistas_Proveedores> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Suscripcion_Red_de_Especialistas_ProveedoresRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_Suscripcion_Red_de_Especialistas_Proveedores.Detalle_Suscripcion_Red_de_Especialistas_Proveedores GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Detalle_Suscripcion_Red_de_Especialistas_Proveedores.Detalle_Suscripcion_Red_de_Especialistas_Proveedores result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Detalle_Suscripcion_Red_de_Especialistas_ProveedoresInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Detalle_Suscripcion_Red_de_Especialistas_Proveedores.Detalle_Suscripcion_Red_de_Especialistas_Proveedores entity, Spartane.Core.Domain.User.GlobalData Detalle_Suscripcion_Red_de_Especialistas_ProveedoresInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Detalle_Suscripcion_Red_de_Especialistas_Proveedores.Detalle_Suscripcion_Red_de_Especialistas_Proveedores entity, Spartane.Core.Domain.User.GlobalData Detalle_Suscripcion_Red_de_Especialistas_ProveedoresInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

