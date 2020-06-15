using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Caracteristicas_platillo;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Caracteristicas_platillo
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Caracteristicas_platilloService : ICaracteristicas_platilloService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Caracteristicas_platillo.Caracteristicas_platillo> _Caracteristicas_platilloRepository;
        #endregion

        #region Ctor
        public Caracteristicas_platilloService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Caracteristicas_platillo.Caracteristicas_platillo> Caracteristicas_platilloRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Caracteristicas_platilloRepository = Caracteristicas_platilloRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Caracteristicas_platillo.Caracteristicas_platillo> SelAll(bool ConRelaciones)
        {
            return this._Caracteristicas_platilloRepository.Table.ToList();
        }

        public IList<Core.Domain.Caracteristicas_platillo.Caracteristicas_platillo> SelAllComplete(bool ConRelaciones)
        {
            return this._Caracteristicas_platilloRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Caracteristicas_platillo.Caracteristicas_platillo> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Caracteristicas_platilloRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Caracteristicas_platillo.Caracteristicas_platillo> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Caracteristicas_platilloRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Caracteristicas_platillo.Caracteristicas_platillo> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Caracteristicas_platilloRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Caracteristicas_platillo.Caracteristicas_platilloPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Caracteristicas_platilloPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Caracteristicas_platillo.Caracteristicas_platillo> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Caracteristicas_platilloRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Caracteristicas_platillo.Caracteristicas_platillo GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Caracteristicas_platillo.Caracteristicas_platillo result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Caracteristicas_platilloInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Caracteristicas_platillo.Caracteristicas_platillo entity, Spartane.Core.Domain.User.GlobalData Caracteristicas_platilloInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Caracteristicas_platillo.Caracteristicas_platillo entity, Spartane.Core.Domain.User.GlobalData Caracteristicas_platilloInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

