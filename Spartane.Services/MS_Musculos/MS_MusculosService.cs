using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.MS_Musculos;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.MS_Musculos
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class MS_MusculosService : IMS_MusculosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.MS_Musculos.MS_Musculos> _MS_MusculosRepository;
        #endregion

        #region Ctor
        public MS_MusculosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.MS_Musculos.MS_Musculos> MS_MusculosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._MS_MusculosRepository = MS_MusculosRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.MS_Musculos.MS_Musculos> SelAll(bool ConRelaciones)
        {
            return this._MS_MusculosRepository.Table.ToList();
        }

        public IList<Core.Domain.MS_Musculos.MS_Musculos> SelAllComplete(bool ConRelaciones)
        {
            return this._MS_MusculosRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.MS_Musculos.MS_Musculos> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MS_MusculosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.MS_Musculos.MS_Musculos> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._MS_MusculosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.MS_Musculos.MS_Musculos> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MS_MusculosRepository.Table.ToList();
        }

        public Spartane.Core.Domain.MS_Musculos.MS_MusculosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            MS_MusculosPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.MS_Musculos.MS_Musculos> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._MS_MusculosRepository.Table.ToList();
        }

        public Spartane.Core.Domain.MS_Musculos.MS_Musculos GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.MS_Musculos.MS_Musculos result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData MS_MusculosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.MS_Musculos.MS_Musculos entity, Spartane.Core.Domain.User.GlobalData MS_MusculosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.MS_Musculos.MS_Musculos entity, Spartane.Core.Domain.User.GlobalData MS_MusculosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

