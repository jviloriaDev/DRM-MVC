using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Estatus_Facturas;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Estatus_Facturas
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Estatus_FacturasService : IEstatus_FacturasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Estatus_Facturas.Estatus_Facturas> _Estatus_FacturasRepository;
        #endregion

        #region Ctor
        public Estatus_FacturasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Estatus_Facturas.Estatus_Facturas> Estatus_FacturasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Estatus_FacturasRepository = Estatus_FacturasRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Estatus_Facturas.Estatus_Facturas> SelAll(bool ConRelaciones)
        {
            return this._Estatus_FacturasRepository.Table.ToList();
        }

        public IList<Core.Domain.Estatus_Facturas.Estatus_Facturas> SelAllComplete(bool ConRelaciones)
        {
            return this._Estatus_FacturasRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Estatus_Facturas.Estatus_Facturas> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Estatus_FacturasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Estatus_Facturas.Estatus_Facturas> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Estatus_FacturasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Estatus_Facturas.Estatus_Facturas> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Estatus_FacturasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Estatus_Facturas.Estatus_FacturasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Estatus_FacturasPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Estatus_Facturas.Estatus_Facturas> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Estatus_FacturasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Estatus_Facturas.Estatus_Facturas GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Estatus_Facturas.Estatus_Facturas result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Estatus_FacturasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Estatus_Facturas.Estatus_Facturas entity, Spartane.Core.Domain.User.GlobalData Estatus_FacturasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Estatus_Facturas.Estatus_Facturas entity, Spartane.Core.Domain.User.GlobalData Estatus_FacturasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

