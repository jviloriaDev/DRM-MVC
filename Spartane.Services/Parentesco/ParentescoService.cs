using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Parentesco;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Parentesco
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class ParentescoService : IParentescoService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Parentesco.Parentesco> _ParentescoRepository;
        #endregion

        #region Ctor
        public ParentescoService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Parentesco.Parentesco> ParentescoRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._ParentescoRepository = ParentescoRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Parentesco.Parentesco> SelAll(bool ConRelaciones)
        {
            return this._ParentescoRepository.Table.ToList();
        }

        public IList<Core.Domain.Parentesco.Parentesco> SelAllComplete(bool ConRelaciones)
        {
            return this._ParentescoRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Parentesco.Parentesco> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._ParentescoRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Parentesco.Parentesco> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._ParentescoRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Parentesco.Parentesco> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._ParentescoRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Parentesco.ParentescoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            ParentescoPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Parentesco.Parentesco> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._ParentescoRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Parentesco.Parentesco GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Parentesco.Parentesco result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData ParentescoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Parentesco.Parentesco entity, Spartane.Core.Domain.User.GlobalData ParentescoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Parentesco.Parentesco entity, Spartane.Core.Domain.User.GlobalData ParentescoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

