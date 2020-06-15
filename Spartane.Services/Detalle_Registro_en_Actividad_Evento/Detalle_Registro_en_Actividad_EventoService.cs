using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Detalle_Registro_en_Actividad_Evento;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Registro_en_Actividad_Evento
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Registro_en_Actividad_EventoService : IDetalle_Registro_en_Actividad_EventoService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_Evento> _Detalle_Registro_en_Actividad_EventoRepository;
        #endregion

        #region Ctor
        public Detalle_Registro_en_Actividad_EventoService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_Evento> Detalle_Registro_en_Actividad_EventoRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Registro_en_Actividad_EventoRepository = Detalle_Registro_en_Actividad_EventoRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_Evento> SelAll(bool ConRelaciones)
        {
            return this._Detalle_Registro_en_Actividad_EventoRepository.Table.ToList();
        }

        public IList<Core.Domain.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_Evento> SelAllComplete(bool ConRelaciones)
        {
            return this._Detalle_Registro_en_Actividad_EventoRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_Evento> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Registro_en_Actividad_EventoRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_Evento> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Registro_en_Actividad_EventoRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_Evento> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Registro_en_Actividad_EventoRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_EventoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Detalle_Registro_en_Actividad_EventoPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_Evento> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Registro_en_Actividad_EventoRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_Evento GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_Evento result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Detalle_Registro_en_Actividad_EventoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_Evento entity, Spartane.Core.Domain.User.GlobalData Detalle_Registro_en_Actividad_EventoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_Evento entity, Spartane.Core.Domain.User.GlobalData Detalle_Registro_en_Actividad_EventoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

