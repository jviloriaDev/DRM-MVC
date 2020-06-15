using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Spartan_Settings;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Settings
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_SettingsService : ISpartan_SettingsService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Spartan_Settings.Spartan_Settings> _Spartan_SettingsRepository;
        #endregion

        #region Ctor
        public Spartan_SettingsService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Spartan_Settings.Spartan_Settings> Spartan_SettingsRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_SettingsRepository = Spartan_SettingsRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Spartan_Settings.Spartan_Settings> SelAll(bool ConRelaciones)
        {
            return this._Spartan_SettingsRepository.Table.ToList();
        }

        public IList<Core.Domain.Spartan_Settings.Spartan_Settings> SelAllComplete(bool ConRelaciones)
        {
            return this._Spartan_SettingsRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Spartan_Settings.Spartan_Settings> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_SettingsRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_Settings.Spartan_Settings> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_SettingsRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_Settings.Spartan_Settings> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_SettingsRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_Settings.Spartan_SettingsPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Spartan_SettingsPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Spartan_Settings.Spartan_Settings> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_SettingsRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_Settings.Spartan_Settings GetByKey(string Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Spartan_Settings.Spartan_Settings result=null;
            return result;
        }

        public bool Delete(string Key, Spartane.Core.Domain.User.GlobalData Spartan_SettingsInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public string Insert(Spartane.Core.Domain.Spartan_Settings.Spartan_Settings entity, Spartane.Core.Domain.User.GlobalData Spartan_SettingsInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            string rta = Convert.ToString("0");
            return rta;
        }

        public string Update(Spartane.Core.Domain.Spartan_Settings.Spartan_Settings entity, Spartane.Core.Domain.User.GlobalData Spartan_SettingsInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            string rta = Convert.ToString("0");
            return rta;
        }
        #endregion
    }
}

