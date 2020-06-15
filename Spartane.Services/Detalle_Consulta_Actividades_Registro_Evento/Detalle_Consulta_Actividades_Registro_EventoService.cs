using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Detalle_Consulta_Actividades_Registro_Evento;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Consulta_Actividades_Registro_Evento
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Consulta_Actividades_Registro_EventoService : IDetalle_Consulta_Actividades_Registro_EventoService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Detalle_Consulta_Actividades_Registro_Evento.Detalle_Consulta_Actividades_Registro_Evento> _Detalle_Consulta_Actividades_Registro_EventoRepository;
        #endregion

        #region Ctor
        public Detalle_Consulta_Actividades_Registro_EventoService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Detalle_Consulta_Actividades_Registro_Evento.Detalle_Consulta_Actividades_Registro_Evento> Detalle_Consulta_Actividades_Registro_EventoRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Consulta_Actividades_Registro_EventoRepository = Detalle_Consulta_Actividades_Registro_EventoRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Detalle_Consulta_Actividades_Registro_Evento.Detalle_Consulta_Actividades_Registro_Evento> SelAll(bool ConRelaciones)
        {
            return this._Detalle_Consulta_Actividades_Registro_EventoRepository.Table.ToList();
        }

        public IList<Core.Domain.Detalle_Consulta_Actividades_Registro_Evento.Detalle_Consulta_Actividades_Registro_Evento> SelAllComplete(bool ConRelaciones)
        {
            return this._Detalle_Consulta_Actividades_Registro_EventoRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Detalle_Consulta_Actividades_Registro_Evento.Detalle_Consulta_Actividades_Registro_Evento> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Consulta_Actividades_Registro_EventoRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_Consulta_Actividades_Registro_Evento.Detalle_Consulta_Actividades_Registro_Evento> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Consulta_Actividades_Registro_EventoRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_Consulta_Actividades_Registro_Evento.Detalle_Consulta_Actividades_Registro_Evento> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Consulta_Actividades_Registro_EventoRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_Consulta_Actividades_Registro_Evento.Detalle_Consulta_Actividades_Registro_EventoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Detalle_Consulta_Actividades_Registro_EventoPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Detalle_Consulta_Actividades_Registro_Evento.Detalle_Consulta_Actividades_Registro_Evento> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Consulta_Actividades_Registro_EventoRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_Consulta_Actividades_Registro_Evento.Detalle_Consulta_Actividades_Registro_Evento GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Detalle_Consulta_Actividades_Registro_Evento.Detalle_Consulta_Actividades_Registro_Evento result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Detalle_Consulta_Actividades_Registro_EventoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Detalle_Consulta_Actividades_Registro_Evento.Detalle_Consulta_Actividades_Registro_Evento entity, Spartane.Core.Domain.User.GlobalData Detalle_Consulta_Actividades_Registro_EventoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Detalle_Consulta_Actividades_Registro_Evento.Detalle_Consulta_Actividades_Registro_Evento entity, Spartane.Core.Domain.User.GlobalData Detalle_Consulta_Actividades_Registro_EventoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

