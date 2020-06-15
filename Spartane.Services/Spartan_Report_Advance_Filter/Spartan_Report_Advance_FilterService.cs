using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Spartan_Report_Advance_Filter;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Report_Advance_Filter
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_Report_Advance_FilterService : ISpartan_Report_Advance_FilterService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Spartan_Report_Advance_Filter.Spartan_Report_Advance_Filter> _Spartan_Report_Advance_FilterRepository;
        #endregion

        #region Ctor
        public Spartan_Report_Advance_FilterService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Spartan_Report_Advance_Filter.Spartan_Report_Advance_Filter> Spartan_Report_Advance_FilterRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_Report_Advance_FilterRepository = Spartan_Report_Advance_FilterRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Spartan_Report_Advance_Filter.Spartan_Report_Advance_Filter> SelAll(bool ConRelaciones)
        {
            return this._Spartan_Report_Advance_FilterRepository.Table.ToList();
        }

        public IList<Core.Domain.Spartan_Report_Advance_Filter.Spartan_Report_Advance_Filter> SelAllComplete(bool ConRelaciones)
        {
            return this._Spartan_Report_Advance_FilterRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Spartan_Report_Advance_Filter.Spartan_Report_Advance_Filter> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Report_Advance_FilterRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_Report_Advance_Filter.Spartan_Report_Advance_Filter> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_Report_Advance_FilterRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_Report_Advance_Filter.Spartan_Report_Advance_Filter> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Report_Advance_FilterRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_Report_Advance_Filter.Spartan_Report_Advance_FilterPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Spartan_Report_Advance_FilterPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Spartan_Report_Advance_Filter.Spartan_Report_Advance_Filter> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_Report_Advance_FilterRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_Report_Advance_Filter.Spartan_Report_Advance_Filter GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Spartan_Report_Advance_Filter.Spartan_Report_Advance_Filter result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Spartan_Report_Advance_FilterInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Spartan_Report_Advance_Filter.Spartan_Report_Advance_Filter entity, Spartane.Core.Domain.User.GlobalData Spartan_Report_Advance_FilterInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Spartan_Report_Advance_Filter.Spartan_Report_Advance_Filter entity, Spartane.Core.Domain.User.GlobalData Spartan_Report_Advance_FilterInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

