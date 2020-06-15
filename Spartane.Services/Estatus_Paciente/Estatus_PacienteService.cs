using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Estatus_Paciente;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Estatus_Paciente
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Estatus_PacienteService : IEstatus_PacienteService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Estatus_Paciente.Estatus_Paciente> _Estatus_PacienteRepository;
        #endregion

        #region Ctor
        public Estatus_PacienteService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Estatus_Paciente.Estatus_Paciente> Estatus_PacienteRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Estatus_PacienteRepository = Estatus_PacienteRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Estatus_Paciente.Estatus_Paciente> SelAll(bool ConRelaciones)
        {
            return this._Estatus_PacienteRepository.Table.ToList();
        }

        public IList<Core.Domain.Estatus_Paciente.Estatus_Paciente> SelAllComplete(bool ConRelaciones)
        {
            return this._Estatus_PacienteRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Estatus_Paciente.Estatus_Paciente> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Estatus_PacienteRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Estatus_Paciente.Estatus_Paciente> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Estatus_PacienteRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Estatus_Paciente.Estatus_Paciente> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Estatus_PacienteRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Estatus_Paciente.Estatus_PacientePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Estatus_PacientePagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Estatus_Paciente.Estatus_Paciente> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Estatus_PacienteRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Estatus_Paciente.Estatus_Paciente GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Estatus_Paciente.Estatus_Paciente result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Estatus_PacienteInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Estatus_Paciente.Estatus_Paciente entity, Spartane.Core.Domain.User.GlobalData Estatus_PacienteInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Estatus_Paciente.Estatus_Paciente entity, Spartane.Core.Domain.User.GlobalData Estatus_PacienteInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

