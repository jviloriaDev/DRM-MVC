using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Vendedores;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Vendedores
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class VendedoresService : IVendedoresService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Vendedores.Vendedores> _VendedoresRepository;
        #endregion

        #region Ctor
        public VendedoresService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Vendedores.Vendedores> VendedoresRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._VendedoresRepository = VendedoresRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Vendedores.Vendedores> SelAll(bool ConRelaciones)
        {
            return this._VendedoresRepository.Table.ToList();
        }

        public IList<Core.Domain.Vendedores.Vendedores> SelAllComplete(bool ConRelaciones)
        {
            return this._VendedoresRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Vendedores.Vendedores> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._VendedoresRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Vendedores.Vendedores> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._VendedoresRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Vendedores.Vendedores> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._VendedoresRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Vendedores.VendedoresPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            VendedoresPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Vendedores.Vendedores> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._VendedoresRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Vendedores.Vendedores GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Vendedores.Vendedores result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData VendedoresInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Vendedores.Vendedores entity, Spartane.Core.Domain.User.GlobalData VendedoresInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Vendedores.Vendedores entity, Spartane.Core.Domain.User.GlobalData VendedoresInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

