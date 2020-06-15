using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Pantalla_Francisco;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Pantalla_Francisco
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Pantalla_FranciscoService : IPantalla_FranciscoService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Pantalla_Francisco.Pantalla_Francisco> _Pantalla_FranciscoRepository;
        #endregion

        #region Ctor
        public Pantalla_FranciscoService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Pantalla_Francisco.Pantalla_Francisco> Pantalla_FranciscoRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Pantalla_FranciscoRepository = Pantalla_FranciscoRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Pantalla_Francisco.Pantalla_Francisco> SelAll(bool ConRelaciones)
        {
            return this._Pantalla_FranciscoRepository.Table.ToList();
        }

        public IList<Core.Domain.Pantalla_Francisco.Pantalla_Francisco> SelAllComplete(bool ConRelaciones)
        {
            return this._Pantalla_FranciscoRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Pantalla_Francisco.Pantalla_Francisco> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Pantalla_FranciscoRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Pantalla_Francisco.Pantalla_Francisco> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Pantalla_FranciscoRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Pantalla_Francisco.Pantalla_Francisco> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Pantalla_FranciscoRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Pantalla_Francisco.Pantalla_FranciscoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Pantalla_FranciscoPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Pantalla_Francisco.Pantalla_Francisco> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Pantalla_FranciscoRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Pantalla_Francisco.Pantalla_Francisco GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Pantalla_Francisco.Pantalla_Francisco result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Pantalla_FranciscoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Pantalla_Francisco.Pantalla_Francisco entity, Spartane.Core.Domain.User.GlobalData Pantalla_FranciscoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Pantalla_Francisco.Pantalla_Francisco entity, Spartane.Core.Domain.User.GlobalData Pantalla_FranciscoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

