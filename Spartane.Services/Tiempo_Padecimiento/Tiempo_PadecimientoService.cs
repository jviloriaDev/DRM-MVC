using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Tiempo_Padecimiento;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Tiempo_Padecimiento
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Tiempo_PadecimientoService : ITiempo_PadecimientoService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Tiempo_Padecimiento.Tiempo_Padecimiento> _Tiempo_PadecimientoRepository;
        #endregion

        #region Ctor
        public Tiempo_PadecimientoService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Tiempo_Padecimiento.Tiempo_Padecimiento> Tiempo_PadecimientoRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Tiempo_PadecimientoRepository = Tiempo_PadecimientoRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Tiempo_Padecimiento.Tiempo_Padecimiento> SelAll(bool ConRelaciones)
        {
            return this._Tiempo_PadecimientoRepository.Table.ToList();
        }

        public IList<Core.Domain.Tiempo_Padecimiento.Tiempo_Padecimiento> SelAllComplete(bool ConRelaciones)
        {
            return this._Tiempo_PadecimientoRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Tiempo_Padecimiento.Tiempo_Padecimiento> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Tiempo_PadecimientoRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Tiempo_Padecimiento.Tiempo_Padecimiento> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Tiempo_PadecimientoRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Tiempo_Padecimiento.Tiempo_Padecimiento> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Tiempo_PadecimientoRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Tiempo_Padecimiento.Tiempo_PadecimientoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Tiempo_PadecimientoPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Tiempo_Padecimiento.Tiempo_Padecimiento> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Tiempo_PadecimientoRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Tiempo_Padecimiento.Tiempo_Padecimiento GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Tiempo_Padecimiento.Tiempo_Padecimiento result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Tiempo_PadecimientoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Tiempo_Padecimiento.Tiempo_Padecimiento entity, Spartane.Core.Domain.User.GlobalData Tiempo_PadecimientoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Tiempo_Padecimiento.Tiempo_Padecimiento entity, Spartane.Core.Domain.User.GlobalData Tiempo_PadecimientoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

