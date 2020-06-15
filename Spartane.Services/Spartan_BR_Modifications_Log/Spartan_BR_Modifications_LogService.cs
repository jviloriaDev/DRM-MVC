using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Spartan_BR_Modifications_Log;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_BR_Modifications_Log
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_BR_Modifications_LogService : ISpartan_BR_Modifications_LogService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_Log> _Spartan_BR_Modifications_LogRepository;
        #endregion

        #region Ctor
        public Spartan_BR_Modifications_LogService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_Log> Spartan_BR_Modifications_LogRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_BR_Modifications_LogRepository = Spartan_BR_Modifications_LogRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_Log> SelAll(bool ConRelaciones)
        {
            return this._Spartan_BR_Modifications_LogRepository.Table.ToList();
        }

        public IList<Core.Domain.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_Log> SelAllComplete(bool ConRelaciones)
        {
            return this._Spartan_BR_Modifications_LogRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_Log> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_BR_Modifications_LogRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_Log> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_BR_Modifications_LogRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_Log> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_BR_Modifications_LogRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_LogPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Spartan_BR_Modifications_LogPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_Log> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_BR_Modifications_LogRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_Log GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_Log result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Spartan_BR_Modifications_LogInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_Log entity, Spartane.Core.Domain.User.GlobalData Spartan_BR_Modifications_LogInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_Log entity, Spartane.Core.Domain.User.GlobalData Spartan_BR_Modifications_LogInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

