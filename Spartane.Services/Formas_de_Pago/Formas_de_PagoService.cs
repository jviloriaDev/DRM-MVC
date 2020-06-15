using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Formas_de_Pago;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Formas_de_Pago
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Formas_de_PagoService : IFormas_de_PagoService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Formas_de_Pago.Formas_de_Pago> _Formas_de_PagoRepository;
        #endregion

        #region Ctor
        public Formas_de_PagoService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Formas_de_Pago.Formas_de_Pago> Formas_de_PagoRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Formas_de_PagoRepository = Formas_de_PagoRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Formas_de_Pago.Formas_de_Pago> SelAll(bool ConRelaciones)
        {
            return this._Formas_de_PagoRepository.Table.ToList();
        }

        public IList<Core.Domain.Formas_de_Pago.Formas_de_Pago> SelAllComplete(bool ConRelaciones)
        {
            return this._Formas_de_PagoRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Formas_de_Pago.Formas_de_Pago> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Formas_de_PagoRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Formas_de_Pago.Formas_de_Pago> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Formas_de_PagoRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Formas_de_Pago.Formas_de_Pago> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Formas_de_PagoRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Formas_de_Pago.Formas_de_PagoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Formas_de_PagoPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Formas_de_Pago.Formas_de_Pago> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Formas_de_PagoRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Formas_de_Pago.Formas_de_Pago GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Formas_de_Pago.Formas_de_Pago result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Formas_de_PagoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Formas_de_Pago.Formas_de_Pago entity, Spartane.Core.Domain.User.GlobalData Formas_de_PagoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Formas_de_Pago.Formas_de_Pago entity, Spartane.Core.Domain.User.GlobalData Formas_de_PagoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

