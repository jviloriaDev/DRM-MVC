using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Especialidades;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Especialidades
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class EspecialidadesService : IEspecialidadesService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Especialidades.Especialidades> _EspecialidadesRepository;
        #endregion

        #region Ctor
        public EspecialidadesService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Especialidades.Especialidades> EspecialidadesRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._EspecialidadesRepository = EspecialidadesRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Especialidades.Especialidades> SelAll(bool ConRelaciones)
        {
            return this._EspecialidadesRepository.Table.ToList();
        }

        public IList<Core.Domain.Especialidades.Especialidades> SelAllComplete(bool ConRelaciones)
        {
            return this._EspecialidadesRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Especialidades.Especialidades> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._EspecialidadesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Especialidades.Especialidades> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._EspecialidadesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Especialidades.Especialidades> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._EspecialidadesRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Especialidades.EspecialidadesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            EspecialidadesPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Especialidades.Especialidades> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._EspecialidadesRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Especialidades.Especialidades GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Especialidades.Especialidades result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EspecialidadesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Especialidades.Especialidades entity, Spartane.Core.Domain.User.GlobalData EspecialidadesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Especialidades.Especialidades entity, Spartane.Core.Domain.User.GlobalData EspecialidadesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

