using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Spartan_Traduction_Object;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_Traduction_Object
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_Traduction_ObjectService : ISpartan_Traduction_ObjectService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Spartan_Traduction_Object.Spartan_Traduction_Object> _Spartan_Traduction_ObjectRepository;
        #endregion

        #region Ctor
        public Spartan_Traduction_ObjectService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Spartan_Traduction_Object.Spartan_Traduction_Object> Spartan_Traduction_ObjectRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_Traduction_ObjectRepository = Spartan_Traduction_ObjectRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Spartan_Traduction_Object.Spartan_Traduction_Object> SelAll(bool ConRelaciones)
        {
            return this._Spartan_Traduction_ObjectRepository.Table.ToList();
        }

        public IList<Core.Domain.Spartan_Traduction_Object.Spartan_Traduction_Object> SelAllComplete(bool ConRelaciones)
        {
            return this._Spartan_Traduction_ObjectRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Spartan_Traduction_Object.Spartan_Traduction_Object> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Traduction_ObjectRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_Traduction_Object.Spartan_Traduction_Object> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_Traduction_ObjectRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_Traduction_Object.Spartan_Traduction_Object> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_Traduction_ObjectRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_Traduction_Object.Spartan_Traduction_ObjectPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Spartan_Traduction_ObjectPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Spartan_Traduction_Object.Spartan_Traduction_Object> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_Traduction_ObjectRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_Traduction_Object.Spartan_Traduction_Object GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Spartan_Traduction_Object.Spartan_Traduction_Object result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Spartan_Traduction_ObjectInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Spartan_Traduction_Object.Spartan_Traduction_Object entity, Spartane.Core.Domain.User.GlobalData Spartan_Traduction_ObjectInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Spartan_Traduction_Object.Spartan_Traduction_Object entity, Spartane.Core.Domain.User.GlobalData Spartan_Traduction_ObjectInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

