using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Estatus_Actividades_Evento;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Estatus_Actividades_Evento
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Estatus_Actividades_EventoService : IEstatus_Actividades_EventoService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Estatus_Actividades_Evento.Estatus_Actividades_Evento> _Estatus_Actividades_EventoRepository;
        #endregion

        #region Ctor
        public Estatus_Actividades_EventoService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Estatus_Actividades_Evento.Estatus_Actividades_Evento> Estatus_Actividades_EventoRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Estatus_Actividades_EventoRepository = Estatus_Actividades_EventoRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Estatus_Actividades_Evento.Estatus_Actividades_Evento> SelAll(bool ConRelaciones)
        {
            return this._Estatus_Actividades_EventoRepository.Table.ToList();
        }

        public IList<Core.Domain.Estatus_Actividades_Evento.Estatus_Actividades_Evento> SelAllComplete(bool ConRelaciones)
        {
            return this._Estatus_Actividades_EventoRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Estatus_Actividades_Evento.Estatus_Actividades_Evento> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Estatus_Actividades_EventoRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Estatus_Actividades_Evento.Estatus_Actividades_Evento> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Estatus_Actividades_EventoRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Estatus_Actividades_Evento.Estatus_Actividades_Evento> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Estatus_Actividades_EventoRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Estatus_Actividades_Evento.Estatus_Actividades_EventoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Estatus_Actividades_EventoPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Estatus_Actividades_Evento.Estatus_Actividades_Evento> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Estatus_Actividades_EventoRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Estatus_Actividades_Evento.Estatus_Actividades_Evento GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Estatus_Actividades_Evento.Estatus_Actividades_Evento result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Estatus_Actividades_EventoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Estatus_Actividades_Evento.Estatus_Actividades_Evento entity, Spartane.Core.Domain.User.GlobalData Estatus_Actividades_EventoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Estatus_Actividades_Evento.Estatus_Actividades_Evento entity, Spartane.Core.Domain.User.GlobalData Estatus_Actividades_EventoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

