using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Presentacion;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Presentacion
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class PresentacionService : IPresentacionService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Presentacion.Presentacion> _PresentacionRepository;
        #endregion

        #region Ctor
        public PresentacionService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Presentacion.Presentacion> PresentacionRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._PresentacionRepository = PresentacionRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Presentacion.Presentacion> SelAll(bool ConRelaciones)
        {
            return this._PresentacionRepository.Table.ToList();
        }

        public IList<Core.Domain.Presentacion.Presentacion> SelAllComplete(bool ConRelaciones)
        {
            return this._PresentacionRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Presentacion.Presentacion> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._PresentacionRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Presentacion.Presentacion> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._PresentacionRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Presentacion.Presentacion> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._PresentacionRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Presentacion.PresentacionPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            PresentacionPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Presentacion.Presentacion> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._PresentacionRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Presentacion.Presentacion GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Presentacion.Presentacion result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData PresentacionInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Presentacion.Presentacion entity, Spartane.Core.Domain.User.GlobalData PresentacionInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Presentacion.Presentacion entity, Spartane.Core.Domain.User.GlobalData PresentacionInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

