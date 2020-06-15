using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Planes_de_Suscripcion_Proveedores;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Planes_de_Suscripcion_Proveedores
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Planes_de_Suscripcion_ProveedoresService : IPlanes_de_Suscripcion_ProveedoresService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores> _Planes_de_Suscripcion_ProveedoresRepository;
        #endregion

        #region Ctor
        public Planes_de_Suscripcion_ProveedoresService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores> Planes_de_Suscripcion_ProveedoresRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Planes_de_Suscripcion_ProveedoresRepository = Planes_de_Suscripcion_ProveedoresRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores> SelAll(bool ConRelaciones)
        {
            return this._Planes_de_Suscripcion_ProveedoresRepository.Table.ToList();
        }

        public IList<Core.Domain.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores> SelAllComplete(bool ConRelaciones)
        {
            return this._Planes_de_Suscripcion_ProveedoresRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Planes_de_Suscripcion_ProveedoresRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Planes_de_Suscripcion_ProveedoresRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Planes_de_Suscripcion_ProveedoresRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_ProveedoresPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Planes_de_Suscripcion_ProveedoresPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Planes_de_Suscripcion_ProveedoresRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Planes_de_Suscripcion_ProveedoresInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores entity, Spartane.Core.Domain.User.GlobalData Planes_de_Suscripcion_ProveedoresInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores entity, Spartane.Core.Domain.User.GlobalData Planes_de_Suscripcion_ProveedoresInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

