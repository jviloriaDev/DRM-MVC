using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Titulos_Personales;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Titulos_Personales
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Titulos_PersonalesService : ITitulos_PersonalesService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Titulos_Personales.Titulos_Personales> _Titulos_PersonalesRepository;
        #endregion

        #region Ctor
        public Titulos_PersonalesService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Titulos_Personales.Titulos_Personales> Titulos_PersonalesRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Titulos_PersonalesRepository = Titulos_PersonalesRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Titulos_Personales.Titulos_Personales> SelAll(bool ConRelaciones)
        {
            return this._Titulos_PersonalesRepository.Table.ToList();
        }

        public IList<Core.Domain.Titulos_Personales.Titulos_Personales> SelAllComplete(bool ConRelaciones)
        {
            return this._Titulos_PersonalesRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Titulos_Personales.Titulos_Personales> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Titulos_PersonalesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Titulos_Personales.Titulos_Personales> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Titulos_PersonalesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Titulos_Personales.Titulos_Personales> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Titulos_PersonalesRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Titulos_Personales.Titulos_PersonalesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Titulos_PersonalesPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Titulos_Personales.Titulos_Personales> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Titulos_PersonalesRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Titulos_Personales.Titulos_Personales GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Titulos_Personales.Titulos_Personales result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Titulos_PersonalesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Titulos_Personales.Titulos_Personales entity, Spartane.Core.Domain.User.GlobalData Titulos_PersonalesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Titulos_Personales.Titulos_Personales entity, Spartane.Core.Domain.User.GlobalData Titulos_PersonalesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

