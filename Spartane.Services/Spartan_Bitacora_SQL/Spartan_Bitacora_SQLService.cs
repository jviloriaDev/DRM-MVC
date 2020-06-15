using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Spartan_Bitacora_SQL;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Bitacora_SQL
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_Bitacora_SQLService : ISpartan_Bitacora_SQLService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL> _Spartan_Bitacora_SQLRepository;
        #endregion

        #region Ctor
        public Spartan_Bitacora_SQLService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL> Spartan_Bitacora_SQLRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_Bitacora_SQLRepository = Spartan_Bitacora_SQLRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL> SelAll(bool ConRelaciones)
        {
            return this._Spartan_Bitacora_SQLRepository.Table.ToList();
        }

        public IList<Core.Domain.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL> SelAllComplete(bool ConRelaciones)
        {
            return this._Spartan_Bitacora_SQLRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Bitacora_SQLRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_Bitacora_SQLRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Bitacora_SQLRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_Bitacora_SQL.Spartan_Bitacora_SQLPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Spartan_Bitacora_SQLPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_Bitacora_SQLRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Spartan_Bitacora_SQLInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL entity, Spartane.Core.Domain.User.GlobalData Spartan_Bitacora_SQLInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL entity, Spartane.Core.Domain.User.GlobalData Spartan_Bitacora_SQLInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

