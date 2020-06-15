using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Detalle_Codigos_de_Referencia_Vendedores;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Codigos_de_Referencia_Vendedores
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Codigos_de_Referencia_VendedoresService : IDetalle_Codigos_de_Referencia_VendedoresService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Detalle_Codigos_de_Referencia_Vendedores.Detalle_Codigos_de_Referencia_Vendedores> _Detalle_Codigos_de_Referencia_VendedoresRepository;
        #endregion

        #region Ctor
        public Detalle_Codigos_de_Referencia_VendedoresService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Detalle_Codigos_de_Referencia_Vendedores.Detalle_Codigos_de_Referencia_Vendedores> Detalle_Codigos_de_Referencia_VendedoresRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Codigos_de_Referencia_VendedoresRepository = Detalle_Codigos_de_Referencia_VendedoresRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Detalle_Codigos_de_Referencia_Vendedores.Detalle_Codigos_de_Referencia_Vendedores> SelAll(bool ConRelaciones)
        {
            return this._Detalle_Codigos_de_Referencia_VendedoresRepository.Table.ToList();
        }

        public IList<Core.Domain.Detalle_Codigos_de_Referencia_Vendedores.Detalle_Codigos_de_Referencia_Vendedores> SelAllComplete(bool ConRelaciones)
        {
            return this._Detalle_Codigos_de_Referencia_VendedoresRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Detalle_Codigos_de_Referencia_Vendedores.Detalle_Codigos_de_Referencia_Vendedores> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Codigos_de_Referencia_VendedoresRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_Codigos_de_Referencia_Vendedores.Detalle_Codigos_de_Referencia_Vendedores> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Codigos_de_Referencia_VendedoresRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_Codigos_de_Referencia_Vendedores.Detalle_Codigos_de_Referencia_Vendedores> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Codigos_de_Referencia_VendedoresRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_Codigos_de_Referencia_Vendedores.Detalle_Codigos_de_Referencia_VendedoresPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Detalle_Codigos_de_Referencia_VendedoresPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Detalle_Codigos_de_Referencia_Vendedores.Detalle_Codigos_de_Referencia_Vendedores> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Codigos_de_Referencia_VendedoresRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_Codigos_de_Referencia_Vendedores.Detalle_Codigos_de_Referencia_Vendedores GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Detalle_Codigos_de_Referencia_Vendedores.Detalle_Codigos_de_Referencia_Vendedores result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Detalle_Codigos_de_Referencia_VendedoresInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Detalle_Codigos_de_Referencia_Vendedores.Detalle_Codigos_de_Referencia_Vendedores entity, Spartane.Core.Domain.User.GlobalData Detalle_Codigos_de_Referencia_VendedoresInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Detalle_Codigos_de_Referencia_Vendedores.Detalle_Codigos_de_Referencia_Vendedores entity, Spartane.Core.Domain.User.GlobalData Detalle_Codigos_de_Referencia_VendedoresInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

