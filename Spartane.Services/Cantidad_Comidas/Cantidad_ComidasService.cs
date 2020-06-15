using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Cantidad_Comidas;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Cantidad_Comidas
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Cantidad_ComidasService : ICantidad_ComidasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Cantidad_Comidas.Cantidad_Comidas> _Cantidad_ComidasRepository;
        #endregion

        #region Ctor
        public Cantidad_ComidasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Cantidad_Comidas.Cantidad_Comidas> Cantidad_ComidasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Cantidad_ComidasRepository = Cantidad_ComidasRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Cantidad_Comidas.Cantidad_Comidas> SelAll(bool ConRelaciones)
        {
            return this._Cantidad_ComidasRepository.Table.ToList();
        }

        public IList<Core.Domain.Cantidad_Comidas.Cantidad_Comidas> SelAllComplete(bool ConRelaciones)
        {
            return this._Cantidad_ComidasRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Cantidad_Comidas.Cantidad_Comidas> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Cantidad_ComidasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Cantidad_Comidas.Cantidad_Comidas> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Cantidad_ComidasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Cantidad_Comidas.Cantidad_Comidas> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Cantidad_ComidasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Cantidad_Comidas.Cantidad_ComidasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Cantidad_ComidasPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Cantidad_Comidas.Cantidad_Comidas> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Cantidad_ComidasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Cantidad_Comidas.Cantidad_Comidas GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Cantidad_Comidas.Cantidad_Comidas result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Cantidad_ComidasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Cantidad_Comidas.Cantidad_Comidas entity, Spartane.Core.Domain.User.GlobalData Cantidad_ComidasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Cantidad_Comidas.Cantidad_Comidas entity, Spartane.Core.Domain.User.GlobalData Cantidad_ComidasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

