using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Spartan_Report;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Report
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_ReportService : ISpartan_ReportService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Spartan_Report.Spartan_Report> _Spartan_ReportRepository;
        #endregion

        #region Ctor
        public Spartan_ReportService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Spartan_Report.Spartan_Report> Spartan_ReportRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_ReportRepository = Spartan_ReportRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Spartan_Report.Spartan_Report> SelAll(bool ConRelaciones)
        {
            return this._Spartan_ReportRepository.Table.ToList();
        }

        public IList<Core.Domain.Spartan_Report.Spartan_Report> SelAllComplete(bool ConRelaciones)
        {
            return this._Spartan_ReportRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Spartan_Report.Spartan_Report> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_ReportRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_Report.Spartan_Report> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_ReportRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_Report.Spartan_Report> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_ReportRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_Report.Spartan_ReportPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Spartan_ReportPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Spartan_Report.Spartan_Report> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_ReportRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_Report.Spartan_Report GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Spartan_Report.Spartan_Report result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Spartan_ReportInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Spartan_Report.Spartan_Report entity, Spartane.Core.Domain.User.GlobalData Spartan_ReportInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Spartan_Report.Spartan_Report entity, Spartane.Core.Domain.User.GlobalData Spartan_ReportInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

