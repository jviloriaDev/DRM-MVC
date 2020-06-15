using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Seleccion_de_Rangos;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Seleccion_de_Rangos
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Seleccion_de_RangosService : ISeleccion_de_RangosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Seleccion_de_Rangos.Seleccion_de_Rangos> _Seleccion_de_RangosRepository;
        #endregion

        #region Ctor
        public Seleccion_de_RangosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Seleccion_de_Rangos.Seleccion_de_Rangos> Seleccion_de_RangosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Seleccion_de_RangosRepository = Seleccion_de_RangosRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Seleccion_de_Rangos.Seleccion_de_Rangos> SelAll(bool ConRelaciones)
        {
            return this._Seleccion_de_RangosRepository.Table.ToList();
        }

        public IList<Core.Domain.Seleccion_de_Rangos.Seleccion_de_Rangos> SelAllComplete(bool ConRelaciones)
        {
            return this._Seleccion_de_RangosRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Seleccion_de_Rangos.Seleccion_de_Rangos> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Seleccion_de_RangosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Seleccion_de_Rangos.Seleccion_de_Rangos> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Seleccion_de_RangosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Seleccion_de_Rangos.Seleccion_de_Rangos> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Seleccion_de_RangosRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Seleccion_de_Rangos.Seleccion_de_RangosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Seleccion_de_RangosPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Seleccion_de_Rangos.Seleccion_de_Rangos> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Seleccion_de_RangosRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Seleccion_de_Rangos.Seleccion_de_Rangos GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Seleccion_de_Rangos.Seleccion_de_Rangos result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Seleccion_de_RangosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Seleccion_de_Rangos.Seleccion_de_Rangos entity, Spartane.Core.Domain.User.GlobalData Seleccion_de_RangosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Seleccion_de_Rangos.Seleccion_de_Rangos entity, Spartane.Core.Domain.User.GlobalData Seleccion_de_RangosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

