using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Pacientes;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Pacientes
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class PacientesService : IPacientesService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Pacientes.Pacientes> _PacientesRepository;
        #endregion

        #region Ctor
        public PacientesService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Pacientes.Pacientes> PacientesRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._PacientesRepository = PacientesRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Pacientes.Pacientes> SelAll(bool ConRelaciones)
        {
            return this._PacientesRepository.Table.ToList();
        }

        public IList<Core.Domain.Pacientes.Pacientes> SelAllComplete(bool ConRelaciones)
        {
            return this._PacientesRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Pacientes.Pacientes> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._PacientesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Pacientes.Pacientes> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._PacientesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Pacientes.Pacientes> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._PacientesRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Pacientes.PacientesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            PacientesPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Pacientes.Pacientes> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._PacientesRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Pacientes.Pacientes GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Pacientes.Pacientes result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData PacientesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Pacientes.Pacientes entity, Spartane.Core.Domain.User.GlobalData PacientesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Pacientes.Pacientes entity, Spartane.Core.Domain.User.GlobalData PacientesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

