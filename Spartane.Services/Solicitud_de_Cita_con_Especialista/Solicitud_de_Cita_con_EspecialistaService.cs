using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Solicitud_de_Cita_con_Especialista;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Solicitud_de_Cita_con_Especialista
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Solicitud_de_Cita_con_EspecialistaService : ISolicitud_de_Cita_con_EspecialistaService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_Especialista> _Solicitud_de_Cita_con_EspecialistaRepository;
        #endregion

        #region Ctor
        public Solicitud_de_Cita_con_EspecialistaService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_Especialista> Solicitud_de_Cita_con_EspecialistaRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Solicitud_de_Cita_con_EspecialistaRepository = Solicitud_de_Cita_con_EspecialistaRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_Especialista> SelAll(bool ConRelaciones)
        {
            return this._Solicitud_de_Cita_con_EspecialistaRepository.Table.ToList();
        }

        public IList<Core.Domain.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_Especialista> SelAllComplete(bool ConRelaciones)
        {
            return this._Solicitud_de_Cita_con_EspecialistaRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_Especialista> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Solicitud_de_Cita_con_EspecialistaRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_Especialista> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Solicitud_de_Cita_con_EspecialistaRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_Especialista> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Solicitud_de_Cita_con_EspecialistaRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_EspecialistaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Solicitud_de_Cita_con_EspecialistaPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_Especialista> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Solicitud_de_Cita_con_EspecialistaRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_Especialista GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_Especialista result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Solicitud_de_Cita_con_EspecialistaInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_Especialista entity, Spartane.Core.Domain.User.GlobalData Solicitud_de_Cita_con_EspecialistaInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_Especialista entity, Spartane.Core.Domain.User.GlobalData Solicitud_de_Cita_con_EspecialistaInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

