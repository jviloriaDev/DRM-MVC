using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Detalle_Preferencia_Bebidas;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Preferencia_Bebidas
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Preferencia_BebidasService : IDetalle_Preferencia_BebidasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Detalle_Preferencia_Bebidas.Detalle_Preferencia_Bebidas> _Detalle_Preferencia_BebidasRepository;
        #endregion

        #region Ctor
        public Detalle_Preferencia_BebidasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Detalle_Preferencia_Bebidas.Detalle_Preferencia_Bebidas> Detalle_Preferencia_BebidasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Preferencia_BebidasRepository = Detalle_Preferencia_BebidasRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Detalle_Preferencia_Bebidas.Detalle_Preferencia_Bebidas> SelAll(bool ConRelaciones)
        {
            return this._Detalle_Preferencia_BebidasRepository.Table.ToList();
        }

        public IList<Core.Domain.Detalle_Preferencia_Bebidas.Detalle_Preferencia_Bebidas> SelAllComplete(bool ConRelaciones)
        {
            return this._Detalle_Preferencia_BebidasRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Detalle_Preferencia_Bebidas.Detalle_Preferencia_Bebidas> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Preferencia_BebidasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_Preferencia_Bebidas.Detalle_Preferencia_Bebidas> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Preferencia_BebidasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_Preferencia_Bebidas.Detalle_Preferencia_Bebidas> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Preferencia_BebidasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_Preferencia_Bebidas.Detalle_Preferencia_BebidasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Detalle_Preferencia_BebidasPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Detalle_Preferencia_Bebidas.Detalle_Preferencia_Bebidas> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Preferencia_BebidasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_Preferencia_Bebidas.Detalle_Preferencia_Bebidas GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Detalle_Preferencia_Bebidas.Detalle_Preferencia_Bebidas result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Detalle_Preferencia_BebidasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Detalle_Preferencia_Bebidas.Detalle_Preferencia_Bebidas entity, Spartane.Core.Domain.User.GlobalData Detalle_Preferencia_BebidasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Detalle_Preferencia_Bebidas.Detalle_Preferencia_Bebidas entity, Spartane.Core.Domain.User.GlobalData Detalle_Preferencia_BebidasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

