using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Calificacion;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Calificacion
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class CalificacionService : ICalificacionService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Calificacion.Calificacion> _CalificacionRepository;
        #endregion

        #region Ctor
        public CalificacionService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Calificacion.Calificacion> CalificacionRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._CalificacionRepository = CalificacionRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Calificacion.Calificacion> SelAll(bool ConRelaciones)
        {
            return this._CalificacionRepository.Table.ToList();
        }

        public IList<Core.Domain.Calificacion.Calificacion> SelAllComplete(bool ConRelaciones)
        {
            return this._CalificacionRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Calificacion.Calificacion> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._CalificacionRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Calificacion.Calificacion> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._CalificacionRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Calificacion.Calificacion> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._CalificacionRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Calificacion.CalificacionPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            CalificacionPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Calificacion.Calificacion> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._CalificacionRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Calificacion.Calificacion GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Calificacion.Calificacion result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData CalificacionInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Calificacion.Calificacion entity, Spartane.Core.Domain.User.GlobalData CalificacionInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Calificacion.Calificacion entity, Spartane.Core.Domain.User.GlobalData CalificacionInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

