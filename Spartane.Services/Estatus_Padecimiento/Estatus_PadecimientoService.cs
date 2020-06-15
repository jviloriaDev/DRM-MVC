using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Estatus_Padecimiento;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Estatus_Padecimiento
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Estatus_PadecimientoService : IEstatus_PadecimientoService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Estatus_Padecimiento.Estatus_Padecimiento> _Estatus_PadecimientoRepository;
        #endregion

        #region Ctor
        public Estatus_PadecimientoService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Estatus_Padecimiento.Estatus_Padecimiento> Estatus_PadecimientoRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Estatus_PadecimientoRepository = Estatus_PadecimientoRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Estatus_Padecimiento.Estatus_Padecimiento> SelAll(bool ConRelaciones)
        {
            return this._Estatus_PadecimientoRepository.Table.ToList();
        }

        public IList<Core.Domain.Estatus_Padecimiento.Estatus_Padecimiento> SelAllComplete(bool ConRelaciones)
        {
            return this._Estatus_PadecimientoRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Estatus_Padecimiento.Estatus_Padecimiento> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Estatus_PadecimientoRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Estatus_Padecimiento.Estatus_Padecimiento> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Estatus_PadecimientoRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Estatus_Padecimiento.Estatus_Padecimiento> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Estatus_PadecimientoRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Estatus_Padecimiento.Estatus_PadecimientoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Estatus_PadecimientoPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Estatus_Padecimiento.Estatus_Padecimiento> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Estatus_PadecimientoRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Estatus_Padecimiento.Estatus_Padecimiento GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Estatus_Padecimiento.Estatus_Padecimiento result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Estatus_PadecimientoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Estatus_Padecimiento.Estatus_Padecimiento entity, Spartane.Core.Domain.User.GlobalData Estatus_PadecimientoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Estatus_Padecimiento.Estatus_Padecimiento entity, Spartane.Core.Domain.User.GlobalData Estatus_PadecimientoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

