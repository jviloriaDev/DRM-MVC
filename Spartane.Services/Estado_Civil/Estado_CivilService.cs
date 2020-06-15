using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Estado_Civil;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Estado_Civil
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Estado_CivilService : IEstado_CivilService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Estado_Civil.Estado_Civil> _Estado_CivilRepository;
        #endregion

        #region Ctor
        public Estado_CivilService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Estado_Civil.Estado_Civil> Estado_CivilRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Estado_CivilRepository = Estado_CivilRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Estado_Civil.Estado_Civil> SelAll(bool ConRelaciones)
        {
            return this._Estado_CivilRepository.Table.ToList();
        }

        public IList<Core.Domain.Estado_Civil.Estado_Civil> SelAllComplete(bool ConRelaciones)
        {
            return this._Estado_CivilRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Estado_Civil.Estado_Civil> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Estado_CivilRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Estado_Civil.Estado_Civil> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Estado_CivilRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Estado_Civil.Estado_Civil> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Estado_CivilRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Estado_Civil.Estado_CivilPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Estado_CivilPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Estado_Civil.Estado_Civil> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Estado_CivilRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Estado_Civil.Estado_Civil GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Estado_Civil.Estado_Civil result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Estado_CivilInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Estado_Civil.Estado_Civil entity, Spartane.Core.Domain.User.GlobalData Estado_CivilInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Estado_Civil.Estado_Civil entity, Spartane.Core.Domain.User.GlobalData Estado_CivilInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

