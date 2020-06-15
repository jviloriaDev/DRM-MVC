using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Detalle_Especialistas_Pacientes;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Especialistas_Pacientes
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Especialistas_PacientesService : IDetalle_Especialistas_PacientesService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Detalle_Especialistas_Pacientes.Detalle_Especialistas_Pacientes> _Detalle_Especialistas_PacientesRepository;
        #endregion

        #region Ctor
        public Detalle_Especialistas_PacientesService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Detalle_Especialistas_Pacientes.Detalle_Especialistas_Pacientes> Detalle_Especialistas_PacientesRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Especialistas_PacientesRepository = Detalle_Especialistas_PacientesRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Detalle_Especialistas_Pacientes.Detalle_Especialistas_Pacientes> SelAll(bool ConRelaciones)
        {
            return this._Detalle_Especialistas_PacientesRepository.Table.ToList();
        }

        public IList<Core.Domain.Detalle_Especialistas_Pacientes.Detalle_Especialistas_Pacientes> SelAllComplete(bool ConRelaciones)
        {
            return this._Detalle_Especialistas_PacientesRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Detalle_Especialistas_Pacientes.Detalle_Especialistas_Pacientes> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Especialistas_PacientesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_Especialistas_Pacientes.Detalle_Especialistas_Pacientes> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Especialistas_PacientesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_Especialistas_Pacientes.Detalle_Especialistas_Pacientes> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Especialistas_PacientesRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_Especialistas_Pacientes.Detalle_Especialistas_PacientesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Detalle_Especialistas_PacientesPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Detalle_Especialistas_Pacientes.Detalle_Especialistas_Pacientes> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Especialistas_PacientesRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_Especialistas_Pacientes.Detalle_Especialistas_Pacientes GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Detalle_Especialistas_Pacientes.Detalle_Especialistas_Pacientes result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Detalle_Especialistas_PacientesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Detalle_Especialistas_Pacientes.Detalle_Especialistas_Pacientes entity, Spartane.Core.Domain.User.GlobalData Detalle_Especialistas_PacientesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Detalle_Especialistas_Pacientes.Detalle_Especialistas_Pacientes entity, Spartane.Core.Domain.User.GlobalData Detalle_Especialistas_PacientesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

