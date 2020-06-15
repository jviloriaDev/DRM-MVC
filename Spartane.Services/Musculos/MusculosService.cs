using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Musculos;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Musculos
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class MusculosService : IMusculosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Musculos.Musculos> _MusculosRepository;
        #endregion

        #region Ctor
        public MusculosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Musculos.Musculos> MusculosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._MusculosRepository = MusculosRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Musculos.Musculos> SelAll(bool ConRelaciones)
        {
            return this._MusculosRepository.Table.ToList();
        }

        public IList<Core.Domain.Musculos.Musculos> SelAllComplete(bool ConRelaciones)
        {
            return this._MusculosRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Musculos.Musculos> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MusculosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Musculos.Musculos> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._MusculosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Musculos.Musculos> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MusculosRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Musculos.MusculosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            MusculosPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Musculos.Musculos> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._MusculosRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Musculos.Musculos GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Musculos.Musculos result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData MusculosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Musculos.Musculos entity, Spartane.Core.Domain.User.GlobalData MusculosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Musculos.Musculos entity, Spartane.Core.Domain.User.GlobalData MusculosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

