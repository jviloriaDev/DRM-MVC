using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Dashboard_Editor;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Dashboard_Editor
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Dashboard_EditorService : IDashboard_EditorService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Dashboard_Editor.Dashboard_Editor> _Dashboard_EditorRepository;
        #endregion

        #region Ctor
        public Dashboard_EditorService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Dashboard_Editor.Dashboard_Editor> Dashboard_EditorRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Dashboard_EditorRepository = Dashboard_EditorRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Dashboard_Editor.Dashboard_Editor> SelAll(bool ConRelaciones)
        {
            return this._Dashboard_EditorRepository.Table.ToList();
        }

        public IList<Core.Domain.Dashboard_Editor.Dashboard_Editor> SelAllComplete(bool ConRelaciones)
        {
            return this._Dashboard_EditorRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Dashboard_Editor.Dashboard_Editor> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Dashboard_EditorRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Dashboard_Editor.Dashboard_Editor> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Dashboard_EditorRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Dashboard_Editor.Dashboard_Editor> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Dashboard_EditorRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Dashboard_Editor.Dashboard_EditorPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Dashboard_EditorPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Dashboard_Editor.Dashboard_Editor> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Dashboard_EditorRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Dashboard_Editor.Dashboard_Editor GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Dashboard_Editor.Dashboard_Editor result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Dashboard_EditorInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Dashboard_Editor.Dashboard_Editor entity, Spartane.Core.Domain.User.GlobalData Dashboard_EditorInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Dashboard_Editor.Dashboard_Editor entity, Spartane.Core.Domain.User.GlobalData Dashboard_EditorInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

