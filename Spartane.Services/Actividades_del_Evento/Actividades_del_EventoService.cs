using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Actividades_del_Evento;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Actividades_del_Evento
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Actividades_del_EventoService : IActividades_del_EventoService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Actividades_del_Evento.Actividades_del_Evento> _Actividades_del_EventoRepository;
        #endregion

        #region Ctor
        public Actividades_del_EventoService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Actividades_del_Evento.Actividades_del_Evento> Actividades_del_EventoRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Actividades_del_EventoRepository = Actividades_del_EventoRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Actividades_del_Evento.Actividades_del_Evento> SelAll(bool ConRelaciones)
        {
            return this._Actividades_del_EventoRepository.Table.ToList();
        }

        public IList<Core.Domain.Actividades_del_Evento.Actividades_del_Evento> SelAllComplete(bool ConRelaciones)
        {
            return this._Actividades_del_EventoRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Actividades_del_Evento.Actividades_del_Evento> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Actividades_del_EventoRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Actividades_del_Evento.Actividades_del_Evento> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Actividades_del_EventoRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Actividades_del_Evento.Actividades_del_Evento> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Actividades_del_EventoRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Actividades_del_Evento.Actividades_del_EventoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Actividades_del_EventoPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Actividades_del_Evento.Actividades_del_Evento> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Actividades_del_EventoRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Actividades_del_Evento.Actividades_del_Evento GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Actividades_del_Evento.Actividades_del_Evento result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Actividades_del_EventoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Actividades_del_Evento.Actividades_del_Evento entity, Spartane.Core.Domain.User.GlobalData Actividades_del_EventoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Actividades_del_Evento.Actividades_del_Evento entity, Spartane.Core.Domain.User.GlobalData Actividades_del_EventoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

