using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Preferencias_Sal;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Preferencias_Sal
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Preferencias_SalService : IPreferencias_SalService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Preferencias_Sal.Preferencias_Sal> _Preferencias_SalRepository;
        #endregion

        #region Ctor
        public Preferencias_SalService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Preferencias_Sal.Preferencias_Sal> Preferencias_SalRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Preferencias_SalRepository = Preferencias_SalRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Preferencias_Sal.Preferencias_Sal> SelAll(bool ConRelaciones)
        {
            return this._Preferencias_SalRepository.Table.ToList();
        }

        public IList<Core.Domain.Preferencias_Sal.Preferencias_Sal> SelAllComplete(bool ConRelaciones)
        {
            return this._Preferencias_SalRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Preferencias_Sal.Preferencias_Sal> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Preferencias_SalRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Preferencias_Sal.Preferencias_Sal> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Preferencias_SalRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Preferencias_Sal.Preferencias_Sal> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Preferencias_SalRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Preferencias_Sal.Preferencias_SalPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Preferencias_SalPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Preferencias_Sal.Preferencias_Sal> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Preferencias_SalRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Preferencias_Sal.Preferencias_Sal GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Preferencias_Sal.Preferencias_Sal result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Preferencias_SalInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Preferencias_Sal.Preferencias_Sal entity, Spartane.Core.Domain.User.GlobalData Preferencias_SalInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Preferencias_Sal.Preferencias_Sal entity, Spartane.Core.Domain.User.GlobalData Preferencias_SalInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

