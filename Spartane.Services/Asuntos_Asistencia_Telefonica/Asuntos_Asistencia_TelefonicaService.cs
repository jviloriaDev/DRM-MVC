using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Asuntos_Asistencia_Telefonica;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Asuntos_Asistencia_Telefonica
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Asuntos_Asistencia_TelefonicaService : IAsuntos_Asistencia_TelefonicaService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Asuntos_Asistencia_Telefonica.Asuntos_Asistencia_Telefonica> _Asuntos_Asistencia_TelefonicaRepository;
        #endregion

        #region Ctor
        public Asuntos_Asistencia_TelefonicaService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Asuntos_Asistencia_Telefonica.Asuntos_Asistencia_Telefonica> Asuntos_Asistencia_TelefonicaRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Asuntos_Asistencia_TelefonicaRepository = Asuntos_Asistencia_TelefonicaRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Asuntos_Asistencia_Telefonica.Asuntos_Asistencia_Telefonica> SelAll(bool ConRelaciones)
        {
            return this._Asuntos_Asistencia_TelefonicaRepository.Table.ToList();
        }

        public IList<Core.Domain.Asuntos_Asistencia_Telefonica.Asuntos_Asistencia_Telefonica> SelAllComplete(bool ConRelaciones)
        {
            return this._Asuntos_Asistencia_TelefonicaRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Asuntos_Asistencia_Telefonica.Asuntos_Asistencia_Telefonica> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Asuntos_Asistencia_TelefonicaRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Asuntos_Asistencia_Telefonica.Asuntos_Asistencia_Telefonica> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Asuntos_Asistencia_TelefonicaRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Asuntos_Asistencia_Telefonica.Asuntos_Asistencia_Telefonica> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Asuntos_Asistencia_TelefonicaRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Asuntos_Asistencia_Telefonica.Asuntos_Asistencia_TelefonicaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Asuntos_Asistencia_TelefonicaPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Asuntos_Asistencia_Telefonica.Asuntos_Asistencia_Telefonica> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Asuntos_Asistencia_TelefonicaRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Asuntos_Asistencia_Telefonica.Asuntos_Asistencia_Telefonica GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Asuntos_Asistencia_Telefonica.Asuntos_Asistencia_Telefonica result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Asuntos_Asistencia_TelefonicaInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Asuntos_Asistencia_Telefonica.Asuntos_Asistencia_Telefonica entity, Spartane.Core.Domain.User.GlobalData Asuntos_Asistencia_TelefonicaInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Asuntos_Asistencia_Telefonica.Asuntos_Asistencia_Telefonica entity, Spartane.Core.Domain.User.GlobalData Asuntos_Asistencia_TelefonicaInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

