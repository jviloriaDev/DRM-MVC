using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Suplementos;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Suplementos
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class SuplementosService : ISuplementosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Suplementos.Suplementos> _SuplementosRepository;
        #endregion

        #region Ctor
        public SuplementosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Suplementos.Suplementos> SuplementosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._SuplementosRepository = SuplementosRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Suplementos.Suplementos> SelAll(bool ConRelaciones)
        {
            return this._SuplementosRepository.Table.ToList();
        }

        public IList<Core.Domain.Suplementos.Suplementos> SelAllComplete(bool ConRelaciones)
        {
            return this._SuplementosRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Suplementos.Suplementos> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._SuplementosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Suplementos.Suplementos> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._SuplementosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Suplementos.Suplementos> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._SuplementosRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Suplementos.SuplementosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            SuplementosPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Suplementos.Suplementos> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._SuplementosRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Suplementos.Suplementos GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Suplementos.Suplementos result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData SuplementosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Suplementos.Suplementos entity, Spartane.Core.Domain.User.GlobalData SuplementosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Suplementos.Suplementos entity, Spartane.Core.Domain.User.GlobalData SuplementosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

