using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Spartan_Format_Permissions;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Format_Permissions
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_Format_PermissionsService : ISpartan_Format_PermissionsService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Spartan_Format_Permissions.Spartan_Format_Permissions> _Spartan_Format_PermissionsRepository;
        #endregion

        #region Ctor
        public Spartan_Format_PermissionsService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Spartan_Format_Permissions.Spartan_Format_Permissions> Spartan_Format_PermissionsRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_Format_PermissionsRepository = Spartan_Format_PermissionsRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Spartan_Format_Permissions.Spartan_Format_Permissions> SelAll(bool ConRelaciones)
        {
            return this._Spartan_Format_PermissionsRepository.Table.ToList();
        }

        public IList<Core.Domain.Spartan_Format_Permissions.Spartan_Format_Permissions> SelAllComplete(bool ConRelaciones)
        {
            return this._Spartan_Format_PermissionsRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Spartan_Format_Permissions.Spartan_Format_Permissions> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Format_PermissionsRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_Format_Permissions.Spartan_Format_Permissions> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_Format_PermissionsRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_Format_Permissions.Spartan_Format_Permissions> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Format_PermissionsRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_Format_Permissions.Spartan_Format_PermissionsPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Spartan_Format_PermissionsPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Spartan_Format_Permissions.Spartan_Format_Permissions> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_Format_PermissionsRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_Format_Permissions.Spartan_Format_Permissions GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Spartan_Format_Permissions.Spartan_Format_Permissions result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Spartan_Format_PermissionsInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Spartan_Format_Permissions.Spartan_Format_Permissions entity, Spartane.Core.Domain.User.GlobalData Spartan_Format_PermissionsInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Spartan_Format_Permissions.Spartan_Format_Permissions entity, Spartane.Core.Domain.User.GlobalData Spartan_Format_PermissionsInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

