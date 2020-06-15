using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Padecimientos;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Padecimientos
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class PadecimientosService : IPadecimientosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Padecimientos.Padecimientos> _PadecimientosRepository;
        #endregion

        #region Ctor
        public PadecimientosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Padecimientos.Padecimientos> PadecimientosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._PadecimientosRepository = PadecimientosRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Padecimientos.Padecimientos> SelAll(bool ConRelaciones)
        {
            return this._PadecimientosRepository.Table.ToList();
        }

        public IList<Core.Domain.Padecimientos.Padecimientos> SelAllComplete(bool ConRelaciones)
        {
            return this._PadecimientosRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Padecimientos.Padecimientos> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._PadecimientosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Padecimientos.Padecimientos> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._PadecimientosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Padecimientos.Padecimientos> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._PadecimientosRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Padecimientos.PadecimientosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            PadecimientosPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Padecimientos.Padecimientos> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._PadecimientosRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Padecimientos.Padecimientos GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Padecimientos.Padecimientos result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData PadecimientosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Padecimientos.Padecimientos entity, Spartane.Core.Domain.User.GlobalData PadecimientosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Padecimientos.Padecimientos entity, Spartane.Core.Domain.User.GlobalData PadecimientosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

