using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Rango_Consumo_Bebidas;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Rango_Consumo_Bebidas
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Rango_Consumo_BebidasService : IRango_Consumo_BebidasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas> _Rango_Consumo_BebidasRepository;
        #endregion

        #region Ctor
        public Rango_Consumo_BebidasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas> Rango_Consumo_BebidasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Rango_Consumo_BebidasRepository = Rango_Consumo_BebidasRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas> SelAll(bool ConRelaciones)
        {
            return this._Rango_Consumo_BebidasRepository.Table.ToList();
        }

        public IList<Core.Domain.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas> SelAllComplete(bool ConRelaciones)
        {
            return this._Rango_Consumo_BebidasRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Rango_Consumo_BebidasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Rango_Consumo_BebidasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Rango_Consumo_BebidasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Rango_Consumo_Bebidas.Rango_Consumo_BebidasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Rango_Consumo_BebidasPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Rango_Consumo_BebidasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Rango_Consumo_BebidasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas entity, Spartane.Core.Domain.User.GlobalData Rango_Consumo_BebidasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas entity, Spartane.Core.Domain.User.GlobalData Rango_Consumo_BebidasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

