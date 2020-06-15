using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.MS_Exclusion_Ingredientes_Paciente;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.MS_Exclusion_Ingredientes_Paciente
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class MS_Exclusion_Ingredientes_PacienteService : IMS_Exclusion_Ingredientes_PacienteService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente> _MS_Exclusion_Ingredientes_PacienteRepository;
        #endregion

        #region Ctor
        public MS_Exclusion_Ingredientes_PacienteService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente> MS_Exclusion_Ingredientes_PacienteRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._MS_Exclusion_Ingredientes_PacienteRepository = MS_Exclusion_Ingredientes_PacienteRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente> SelAll(bool ConRelaciones)
        {
            return this._MS_Exclusion_Ingredientes_PacienteRepository.Table.ToList();
        }

        public IList<Core.Domain.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente> SelAllComplete(bool ConRelaciones)
        {
            return this._MS_Exclusion_Ingredientes_PacienteRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MS_Exclusion_Ingredientes_PacienteRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._MS_Exclusion_Ingredientes_PacienteRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MS_Exclusion_Ingredientes_PacienteRepository.Table.ToList();
        }

        public Spartane.Core.Domain.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_PacientePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            MS_Exclusion_Ingredientes_PacientePagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._MS_Exclusion_Ingredientes_PacienteRepository.Table.ToList();
        }

        public Spartane.Core.Domain.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData MS_Exclusion_Ingredientes_PacienteInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente entity, Spartane.Core.Domain.User.GlobalData MS_Exclusion_Ingredientes_PacienteInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente entity, Spartane.Core.Domain.User.GlobalData MS_Exclusion_Ingredientes_PacienteInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

