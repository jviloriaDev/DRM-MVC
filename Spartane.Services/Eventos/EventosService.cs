using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Eventos;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Eventos
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class EventosService : IEventosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Eventos.Eventos> _EventosRepository;
        #endregion

        #region Ctor
        public EventosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Eventos.Eventos> EventosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._EventosRepository = EventosRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Eventos.Eventos> SelAll(bool ConRelaciones)
        {
            return this._EventosRepository.Table.ToList();
        }

        public IList<Core.Domain.Eventos.Eventos> SelAllComplete(bool ConRelaciones)
        {
            return this._EventosRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Eventos.Eventos> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._EventosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Eventos.Eventos> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._EventosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Eventos.Eventos> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._EventosRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Eventos.EventosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            EventosPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Eventos.Eventos> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._EventosRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Eventos.Eventos GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Eventos.Eventos result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EventosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Eventos.Eventos entity, Spartane.Core.Domain.User.GlobalData EventosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Eventos.Eventos entity, Spartane.Core.Domain.User.GlobalData EventosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

