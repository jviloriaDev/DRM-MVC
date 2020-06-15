using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Spartan_Report_Permissions;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Report_Permissions
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_Report_PermissionsService : ISpartan_Report_PermissionsService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Spartan_Report_Permissions.Spartan_Report_Permissions> _Spartan_Report_PermissionsRepository;
        #endregion

        #region Ctor
        public Spartan_Report_PermissionsService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Spartan_Report_Permissions.Spartan_Report_Permissions> Spartan_Report_PermissionsRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_Report_PermissionsRepository = Spartan_Report_PermissionsRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Spartan_Report_Permissions.Spartan_Report_Permissions> SelAll(bool ConRelaciones)
        {
            return this._Spartan_Report_PermissionsRepository.Table.ToList();
        }

        public IList<Core.Domain.Spartan_Report_Permissions.Spartan_Report_Permissions> SelAllComplete(bool ConRelaciones)
        {
            return this._Spartan_Report_PermissionsRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Spartan_Report_Permissions.Spartan_Report_Permissions> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Report_PermissionsRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_Report_Permissions.Spartan_Report_Permissions> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_Report_PermissionsRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_Report_Permissions.Spartan_Report_Permissions> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Report_PermissionsRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_Report_Permissions.Spartan_Report_PermissionsPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Spartan_Report_PermissionsPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Spartan_Report_Permissions.Spartan_Report_Permissions> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_Report_PermissionsRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_Report_Permissions.Spartan_Report_Permissions GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Spartan_Report_Permissions.Spartan_Report_Permissions result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Spartan_Report_PermissionsInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Spartan_Report_Permissions.Spartan_Report_Permissions entity, Spartane.Core.Domain.User.GlobalData Spartan_Report_PermissionsInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Spartan_Report_Permissions.Spartan_Report_Permissions entity, Spartane.Core.Domain.User.GlobalData Spartan_Report_PermissionsInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

