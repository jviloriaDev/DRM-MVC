using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Spartan_WorkFlow_Phases;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_WorkFlow_Phases
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_WorkFlow_PhasesService : ISpartan_WorkFlow_PhasesService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases> _Spartan_WorkFlow_PhasesRepository;
        #endregion

        #region Ctor
        public Spartan_WorkFlow_PhasesService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases> Spartan_WorkFlow_PhasesRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_WorkFlow_PhasesRepository = Spartan_WorkFlow_PhasesRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases> SelAll(bool ConRelaciones)
        {
            return this._Spartan_WorkFlow_PhasesRepository.Table.ToList();
        }

        public IList<Core.Domain.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases> SelAllComplete(bool ConRelaciones)
        {
            return this._Spartan_WorkFlow_PhasesRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_WorkFlow_PhasesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_WorkFlow_PhasesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_WorkFlow_PhasesRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_WorkFlow_Phases.Spartan_WorkFlow_PhasesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Spartan_WorkFlow_PhasesPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_WorkFlow_PhasesRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Spartan_WorkFlow_PhasesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases entity, Spartane.Core.Domain.User.GlobalData Spartan_WorkFlow_PhasesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases entity, Spartane.Core.Domain.User.GlobalData Spartan_WorkFlow_PhasesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

