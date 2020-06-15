using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Estatus_Reservaciones_Actividad;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Estatus_Reservaciones_Actividad
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Estatus_Reservaciones_ActividadService : IEstatus_Reservaciones_ActividadService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad> _Estatus_Reservaciones_ActividadRepository;
        #endregion

        #region Ctor
        public Estatus_Reservaciones_ActividadService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad> Estatus_Reservaciones_ActividadRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Estatus_Reservaciones_ActividadRepository = Estatus_Reservaciones_ActividadRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad> SelAll(bool ConRelaciones)
        {
            return this._Estatus_Reservaciones_ActividadRepository.Table.ToList();
        }

        public IList<Core.Domain.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad> SelAllComplete(bool ConRelaciones)
        {
            return this._Estatus_Reservaciones_ActividadRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Estatus_Reservaciones_ActividadRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Estatus_Reservaciones_ActividadRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Estatus_Reservaciones_ActividadRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_ActividadPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Estatus_Reservaciones_ActividadPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Estatus_Reservaciones_ActividadRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Estatus_Reservaciones_ActividadInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad entity, Spartane.Core.Domain.User.GlobalData Estatus_Reservaciones_ActividadInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad entity, Spartane.Core.Domain.User.GlobalData Estatus_Reservaciones_ActividadInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

