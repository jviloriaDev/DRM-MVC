using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Tips_y_Promociones;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Tips_y_Promociones
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Tips_y_PromocionesService : ITips_y_PromocionesService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Tips_y_Promociones.Tips_y_Promociones> _Tips_y_PromocionesRepository;
        #endregion

        #region Ctor
        public Tips_y_PromocionesService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Tips_y_Promociones.Tips_y_Promociones> Tips_y_PromocionesRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Tips_y_PromocionesRepository = Tips_y_PromocionesRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Tips_y_Promociones.Tips_y_Promociones> SelAll(bool ConRelaciones)
        {
            return this._Tips_y_PromocionesRepository.Table.ToList();
        }

        public IList<Core.Domain.Tips_y_Promociones.Tips_y_Promociones> SelAllComplete(bool ConRelaciones)
        {
            return this._Tips_y_PromocionesRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Tips_y_Promociones.Tips_y_Promociones> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Tips_y_PromocionesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Tips_y_Promociones.Tips_y_Promociones> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Tips_y_PromocionesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Tips_y_Promociones.Tips_y_Promociones> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Tips_y_PromocionesRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Tips_y_Promociones.Tips_y_PromocionesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Tips_y_PromocionesPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Tips_y_Promociones.Tips_y_Promociones> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Tips_y_PromocionesRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Tips_y_Promociones.Tips_y_Promociones GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Tips_y_Promociones.Tips_y_Promociones result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Tips_y_PromocionesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Tips_y_Promociones.Tips_y_Promociones entity, Spartane.Core.Domain.User.GlobalData Tips_y_PromocionesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Tips_y_Promociones.Tips_y_Promociones entity, Spartane.Core.Domain.User.GlobalData Tips_y_PromocionesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

