using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Medicos;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Medicos
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class MedicosService : IMedicosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Medicos.Medicos> _MedicosRepository;
        #endregion

        #region Ctor
        public MedicosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Medicos.Medicos> MedicosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._MedicosRepository = MedicosRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Medicos.Medicos> SelAll(bool ConRelaciones)
        {
            return this._MedicosRepository.Table.ToList();
        }

        public IList<Core.Domain.Medicos.Medicos> SelAllComplete(bool ConRelaciones)
        {
            return this._MedicosRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Medicos.Medicos> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MedicosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Medicos.Medicos> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._MedicosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Medicos.Medicos> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MedicosRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Medicos.MedicosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            MedicosPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Medicos.Medicos> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._MedicosRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Medicos.Medicos GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Medicos.Medicos result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData MedicosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Medicos.Medicos entity, Spartane.Core.Domain.User.GlobalData MedicosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Medicos.Medicos entity, Spartane.Core.Domain.User.GlobalData MedicosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

