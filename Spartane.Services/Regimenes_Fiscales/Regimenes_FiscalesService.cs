using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Regimenes_Fiscales;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Regimenes_Fiscales
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Regimenes_FiscalesService : IRegimenes_FiscalesService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Regimenes_Fiscales.Regimenes_Fiscales> _Regimenes_FiscalesRepository;
        #endregion

        #region Ctor
        public Regimenes_FiscalesService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Regimenes_Fiscales.Regimenes_Fiscales> Regimenes_FiscalesRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Regimenes_FiscalesRepository = Regimenes_FiscalesRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Regimenes_Fiscales.Regimenes_Fiscales> SelAll(bool ConRelaciones)
        {
            return this._Regimenes_FiscalesRepository.Table.ToList();
        }

        public IList<Core.Domain.Regimenes_Fiscales.Regimenes_Fiscales> SelAllComplete(bool ConRelaciones)
        {
            return this._Regimenes_FiscalesRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Regimenes_Fiscales.Regimenes_Fiscales> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Regimenes_FiscalesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Regimenes_Fiscales.Regimenes_Fiscales> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Regimenes_FiscalesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Regimenes_Fiscales.Regimenes_Fiscales> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Regimenes_FiscalesRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Regimenes_Fiscales.Regimenes_FiscalesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Regimenes_FiscalesPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Regimenes_Fiscales.Regimenes_Fiscales> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Regimenes_FiscalesRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Regimenes_Fiscales.Regimenes_Fiscales GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Regimenes_Fiscales.Regimenes_Fiscales result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Regimenes_FiscalesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Regimenes_Fiscales.Regimenes_Fiscales entity, Spartane.Core.Domain.User.GlobalData Regimenes_FiscalesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Regimenes_Fiscales.Regimenes_Fiscales entity, Spartane.Core.Domain.User.GlobalData Regimenes_FiscalesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

