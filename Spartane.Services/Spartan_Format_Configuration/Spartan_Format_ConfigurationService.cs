using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Spartan_Format_Configuration;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Format_Configuration
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_Format_ConfigurationService : ISpartan_Format_ConfigurationService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Spartan_Format_Configuration.Spartan_Format_Configuration> _Spartan_Format_ConfigurationRepository;
        #endregion

        #region Ctor
        public Spartan_Format_ConfigurationService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Spartan_Format_Configuration.Spartan_Format_Configuration> Spartan_Format_ConfigurationRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_Format_ConfigurationRepository = Spartan_Format_ConfigurationRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Spartan_Format_Configuration.Spartan_Format_Configuration> SelAll(bool ConRelaciones)
        {
            return this._Spartan_Format_ConfigurationRepository.Table.ToList();
        }

        public IList<Core.Domain.Spartan_Format_Configuration.Spartan_Format_Configuration> SelAllComplete(bool ConRelaciones)
        {
            return this._Spartan_Format_ConfigurationRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Spartan_Format_Configuration.Spartan_Format_Configuration> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Format_ConfigurationRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_Format_Configuration.Spartan_Format_Configuration> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_Format_ConfigurationRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_Format_Configuration.Spartan_Format_Configuration> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Format_ConfigurationRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_Format_Configuration.Spartan_Format_ConfigurationPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Spartan_Format_ConfigurationPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Spartan_Format_Configuration.Spartan_Format_Configuration> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_Format_ConfigurationRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_Format_Configuration.Spartan_Format_Configuration GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Spartan_Format_Configuration.Spartan_Format_Configuration result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Spartan_Format_ConfigurationInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Spartan_Format_Configuration.Spartan_Format_Configuration entity, Spartane.Core.Domain.User.GlobalData Spartan_Format_ConfigurationInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Spartan_Format_Configuration.Spartan_Format_Configuration entity, Spartane.Core.Domain.User.GlobalData Spartan_Format_ConfigurationInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

