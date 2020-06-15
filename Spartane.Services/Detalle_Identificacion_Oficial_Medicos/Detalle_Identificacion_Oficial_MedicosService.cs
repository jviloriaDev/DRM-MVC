using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Detalle_Identificacion_Oficial_Medicos;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Identificacion_Oficial_Medicos
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Identificacion_Oficial_MedicosService : IDetalle_Identificacion_Oficial_MedicosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Detalle_Identificacion_Oficial_Medicos.Detalle_Identificacion_Oficial_Medicos> _Detalle_Identificacion_Oficial_MedicosRepository;
        #endregion

        #region Ctor
        public Detalle_Identificacion_Oficial_MedicosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Detalle_Identificacion_Oficial_Medicos.Detalle_Identificacion_Oficial_Medicos> Detalle_Identificacion_Oficial_MedicosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Identificacion_Oficial_MedicosRepository = Detalle_Identificacion_Oficial_MedicosRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Detalle_Identificacion_Oficial_Medicos.Detalle_Identificacion_Oficial_Medicos> SelAll(bool ConRelaciones)
        {
            return this._Detalle_Identificacion_Oficial_MedicosRepository.Table.ToList();
        }

        public IList<Core.Domain.Detalle_Identificacion_Oficial_Medicos.Detalle_Identificacion_Oficial_Medicos> SelAllComplete(bool ConRelaciones)
        {
            return this._Detalle_Identificacion_Oficial_MedicosRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Detalle_Identificacion_Oficial_Medicos.Detalle_Identificacion_Oficial_Medicos> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Identificacion_Oficial_MedicosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_Identificacion_Oficial_Medicos.Detalle_Identificacion_Oficial_Medicos> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Identificacion_Oficial_MedicosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_Identificacion_Oficial_Medicos.Detalle_Identificacion_Oficial_Medicos> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Identificacion_Oficial_MedicosRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_Identificacion_Oficial_Medicos.Detalle_Identificacion_Oficial_MedicosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Detalle_Identificacion_Oficial_MedicosPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Detalle_Identificacion_Oficial_Medicos.Detalle_Identificacion_Oficial_Medicos> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Identificacion_Oficial_MedicosRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_Identificacion_Oficial_Medicos.Detalle_Identificacion_Oficial_Medicos GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Detalle_Identificacion_Oficial_Medicos.Detalle_Identificacion_Oficial_Medicos result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Detalle_Identificacion_Oficial_MedicosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Detalle_Identificacion_Oficial_Medicos.Detalle_Identificacion_Oficial_Medicos entity, Spartane.Core.Domain.User.GlobalData Detalle_Identificacion_Oficial_MedicosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Detalle_Identificacion_Oficial_Medicos.Detalle_Identificacion_Oficial_Medicos entity, Spartane.Core.Domain.User.GlobalData Detalle_Identificacion_Oficial_MedicosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

