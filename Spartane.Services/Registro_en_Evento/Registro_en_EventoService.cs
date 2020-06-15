using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Registro_en_Evento;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Registro_en_Evento
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Registro_en_EventoService : IRegistro_en_EventoService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Registro_en_Evento.Registro_en_Evento> _Registro_en_EventoRepository;
        #endregion

        #region Ctor
        public Registro_en_EventoService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Registro_en_Evento.Registro_en_Evento> Registro_en_EventoRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Registro_en_EventoRepository = Registro_en_EventoRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Registro_en_Evento.Registro_en_Evento> SelAll(bool ConRelaciones)
        {
            return this._Registro_en_EventoRepository.Table.ToList();
        }

        public IList<Core.Domain.Registro_en_Evento.Registro_en_Evento> SelAllComplete(bool ConRelaciones)
        {
            return this._Registro_en_EventoRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Registro_en_Evento.Registro_en_Evento> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Registro_en_EventoRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Registro_en_Evento.Registro_en_Evento> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Registro_en_EventoRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Registro_en_Evento.Registro_en_Evento> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Registro_en_EventoRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Registro_en_Evento.Registro_en_EventoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Registro_en_EventoPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Registro_en_Evento.Registro_en_Evento> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Registro_en_EventoRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Registro_en_Evento.Registro_en_Evento GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Registro_en_Evento.Registro_en_Evento result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Registro_en_EventoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Registro_en_Evento.Registro_en_Evento entity, Spartane.Core.Domain.User.GlobalData Registro_en_EventoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Registro_en_Evento.Registro_en_Evento entity, Spartane.Core.Domain.User.GlobalData Registro_en_EventoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

