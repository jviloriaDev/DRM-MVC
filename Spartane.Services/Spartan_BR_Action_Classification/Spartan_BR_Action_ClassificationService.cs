using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Spartan_BR_Action_Classification;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_BR_Action_Classification
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_BR_Action_ClassificationService : ISpartan_BR_Action_ClassificationService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification> _Spartan_BR_Action_ClassificationRepository;
        #endregion

        #region Ctor
        public Spartan_BR_Action_ClassificationService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification> Spartan_BR_Action_ClassificationRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_BR_Action_ClassificationRepository = Spartan_BR_Action_ClassificationRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification> SelAll(bool ConRelaciones)
        {
            return this._Spartan_BR_Action_ClassificationRepository.Table.ToList();
        }

        public IList<Core.Domain.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification> SelAllComplete(bool ConRelaciones)
        {
            return this._Spartan_BR_Action_ClassificationRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_BR_Action_ClassificationRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_BR_Action_ClassificationRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_BR_Action_ClassificationRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_BR_Action_Classification.Spartan_BR_Action_ClassificationPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Spartan_BR_Action_ClassificationPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_BR_Action_ClassificationRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification GetByKey(short Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification result=null;
            return result;
        }

        public bool Delete(short Key, Spartane.Core.Domain.User.GlobalData Spartan_BR_Action_ClassificationInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public short Insert(Spartane.Core.Domain.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification entity, Spartane.Core.Domain.User.GlobalData Spartan_BR_Action_ClassificationInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            short rta = Convert.ToInt16("0");
            return rta;
        }

        public short Update(Spartane.Core.Domain.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification entity, Spartane.Core.Domain.User.GlobalData Spartan_BR_Action_ClassificationInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            short rta = Convert.ToInt16("0");
            return rta;
        }
        #endregion
    }
}

