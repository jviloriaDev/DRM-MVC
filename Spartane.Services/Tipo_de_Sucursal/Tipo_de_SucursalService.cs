using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Tipo_de_Sucursal;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Tipo_de_Sucursal
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Tipo_de_SucursalService : ITipo_de_SucursalService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Tipo_de_Sucursal.Tipo_de_Sucursal> _Tipo_de_SucursalRepository;
        #endregion

        #region Ctor
        public Tipo_de_SucursalService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Tipo_de_Sucursal.Tipo_de_Sucursal> Tipo_de_SucursalRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Tipo_de_SucursalRepository = Tipo_de_SucursalRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Tipo_de_Sucursal.Tipo_de_Sucursal> SelAll(bool ConRelaciones)
        {
            return this._Tipo_de_SucursalRepository.Table.ToList();
        }

        public IList<Core.Domain.Tipo_de_Sucursal.Tipo_de_Sucursal> SelAllComplete(bool ConRelaciones)
        {
            return this._Tipo_de_SucursalRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Tipo_de_Sucursal.Tipo_de_Sucursal> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Tipo_de_SucursalRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Tipo_de_Sucursal.Tipo_de_Sucursal> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Tipo_de_SucursalRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Tipo_de_Sucursal.Tipo_de_Sucursal> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Tipo_de_SucursalRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Tipo_de_Sucursal.Tipo_de_SucursalPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Tipo_de_SucursalPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Tipo_de_Sucursal.Tipo_de_Sucursal> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Tipo_de_SucursalRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Tipo_de_Sucursal.Tipo_de_Sucursal GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Tipo_de_Sucursal.Tipo_de_Sucursal result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Tipo_de_SucursalInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Tipo_de_Sucursal.Tipo_de_Sucursal entity, Spartane.Core.Domain.User.GlobalData Tipo_de_SucursalInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Tipo_de_Sucursal.Tipo_de_Sucursal entity, Spartane.Core.Domain.User.GlobalData Tipo_de_SucursalInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

