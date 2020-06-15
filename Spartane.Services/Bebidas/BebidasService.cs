using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Bebidas;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Bebidas
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class BebidasService : IBebidasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Bebidas.Bebidas> _BebidasRepository;
        #endregion

        #region Ctor
        public BebidasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Bebidas.Bebidas> BebidasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._BebidasRepository = BebidasRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Bebidas.Bebidas> SelAll(bool ConRelaciones)
        {
            return this._BebidasRepository.Table.ToList();
        }

        public IList<Core.Domain.Bebidas.Bebidas> SelAllComplete(bool ConRelaciones)
        {
            return this._BebidasRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Bebidas.Bebidas> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._BebidasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Bebidas.Bebidas> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._BebidasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Bebidas.Bebidas> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._BebidasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Bebidas.BebidasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            BebidasPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Bebidas.Bebidas> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._BebidasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Bebidas.Bebidas GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Bebidas.Bebidas result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData BebidasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Bebidas.Bebidas entity, Spartane.Core.Domain.User.GlobalData BebidasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Bebidas.Bebidas entity, Spartane.Core.Domain.User.GlobalData BebidasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

