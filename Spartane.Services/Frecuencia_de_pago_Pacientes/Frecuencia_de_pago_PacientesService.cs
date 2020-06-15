using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Frecuencia_de_pago_Pacientes;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Frecuencia_de_pago_Pacientes
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Frecuencia_de_pago_PacientesService : IFrecuencia_de_pago_PacientesService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Frecuencia_de_pago_Pacientes.Frecuencia_de_pago_Pacientes> _Frecuencia_de_pago_PacientesRepository;
        #endregion

        #region Ctor
        public Frecuencia_de_pago_PacientesService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Frecuencia_de_pago_Pacientes.Frecuencia_de_pago_Pacientes> Frecuencia_de_pago_PacientesRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Frecuencia_de_pago_PacientesRepository = Frecuencia_de_pago_PacientesRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Frecuencia_de_pago_Pacientes.Frecuencia_de_pago_Pacientes> SelAll(bool ConRelaciones)
        {
            return this._Frecuencia_de_pago_PacientesRepository.Table.ToList();
        }

        public IList<Core.Domain.Frecuencia_de_pago_Pacientes.Frecuencia_de_pago_Pacientes> SelAllComplete(bool ConRelaciones)
        {
            return this._Frecuencia_de_pago_PacientesRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Frecuencia_de_pago_Pacientes.Frecuencia_de_pago_Pacientes> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Frecuencia_de_pago_PacientesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Frecuencia_de_pago_Pacientes.Frecuencia_de_pago_Pacientes> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Frecuencia_de_pago_PacientesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Frecuencia_de_pago_Pacientes.Frecuencia_de_pago_Pacientes> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Frecuencia_de_pago_PacientesRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Frecuencia_de_pago_Pacientes.Frecuencia_de_pago_PacientesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Frecuencia_de_pago_PacientesPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Frecuencia_de_pago_Pacientes.Frecuencia_de_pago_Pacientes> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Frecuencia_de_pago_PacientesRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Frecuencia_de_pago_Pacientes.Frecuencia_de_pago_Pacientes GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Frecuencia_de_pago_Pacientes.Frecuencia_de_pago_Pacientes result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Frecuencia_de_pago_PacientesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Frecuencia_de_pago_Pacientes.Frecuencia_de_pago_Pacientes entity, Spartane.Core.Domain.User.GlobalData Frecuencia_de_pago_PacientesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Frecuencia_de_pago_Pacientes.Frecuencia_de_pago_Pacientes entity, Spartane.Core.Domain.User.GlobalData Frecuencia_de_pago_PacientesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

