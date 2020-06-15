using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Rutinas;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Rutinas
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class RutinasService : IRutinasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Rutinas.Rutinas> _RutinasRepository;
        #endregion

        #region Ctor
        public RutinasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Rutinas.Rutinas> RutinasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._RutinasRepository = RutinasRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Rutinas.Rutinas> SelAll(bool ConRelaciones)
        {
            return this._RutinasRepository.Table.ToList();
        }

        public IList<Core.Domain.Rutinas.Rutinas> SelAllComplete(bool ConRelaciones)
        {
            return this._RutinasRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Rutinas.Rutinas> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._RutinasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Rutinas.Rutinas> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._RutinasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Rutinas.Rutinas> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._RutinasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Rutinas.RutinasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            RutinasPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Rutinas.Rutinas> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._RutinasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Rutinas.Rutinas GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Rutinas.Rutinas result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData RutinasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Rutinas.Rutinas entity, Spartane.Core.Domain.User.GlobalData RutinasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Rutinas.Rutinas entity, Spartane.Core.Domain.User.GlobalData RutinasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

