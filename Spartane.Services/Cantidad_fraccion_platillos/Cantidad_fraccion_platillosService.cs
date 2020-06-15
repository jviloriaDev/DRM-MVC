using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Cantidad_fraccion_platillos;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Cantidad_fraccion_platillos
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Cantidad_fraccion_platillosService : ICantidad_fraccion_platillosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos> _Cantidad_fraccion_platillosRepository;
        #endregion

        #region Ctor
        public Cantidad_fraccion_platillosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos> Cantidad_fraccion_platillosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Cantidad_fraccion_platillosRepository = Cantidad_fraccion_platillosRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos> SelAll(bool ConRelaciones)
        {
            return this._Cantidad_fraccion_platillosRepository.Table.ToList();
        }

        public IList<Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos> SelAllComplete(bool ConRelaciones)
        {
            return this._Cantidad_fraccion_platillosRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Cantidad_fraccion_platillosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Cantidad_fraccion_platillosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Cantidad_fraccion_platillosRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Cantidad_fraccion_platillosPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Cantidad_fraccion_platillosRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Cantidad_fraccion_platillosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos entity, Spartane.Core.Domain.User.GlobalData Cantidad_fraccion_platillosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos entity, Spartane.Core.Domain.User.GlobalData Cantidad_fraccion_platillosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

