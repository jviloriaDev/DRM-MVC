using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Detalle_Codigos_Referidos;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Codigos_Referidos
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Codigos_ReferidosService : IDetalle_Codigos_ReferidosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Detalle_Codigos_Referidos.Detalle_Codigos_Referidos> _Detalle_Codigos_ReferidosRepository;
        #endregion

        #region Ctor
        public Detalle_Codigos_ReferidosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Detalle_Codigos_Referidos.Detalle_Codigos_Referidos> Detalle_Codigos_ReferidosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Codigos_ReferidosRepository = Detalle_Codigos_ReferidosRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Detalle_Codigos_Referidos.Detalle_Codigos_Referidos> SelAll(bool ConRelaciones)
        {
            return this._Detalle_Codigos_ReferidosRepository.Table.ToList();
        }

        public IList<Core.Domain.Detalle_Codigos_Referidos.Detalle_Codigos_Referidos> SelAllComplete(bool ConRelaciones)
        {
            return this._Detalle_Codigos_ReferidosRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Detalle_Codigos_Referidos.Detalle_Codigos_Referidos> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Codigos_ReferidosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_Codigos_Referidos.Detalle_Codigos_Referidos> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Codigos_ReferidosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_Codigos_Referidos.Detalle_Codigos_Referidos> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Codigos_ReferidosRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_Codigos_Referidos.Detalle_Codigos_ReferidosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Detalle_Codigos_ReferidosPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Detalle_Codigos_Referidos.Detalle_Codigos_Referidos> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Codigos_ReferidosRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_Codigos_Referidos.Detalle_Codigos_Referidos GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Detalle_Codigos_Referidos.Detalle_Codigos_Referidos result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Detalle_Codigos_ReferidosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Detalle_Codigos_Referidos.Detalle_Codigos_Referidos entity, Spartane.Core.Domain.User.GlobalData Detalle_Codigos_ReferidosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Detalle_Codigos_Referidos.Detalle_Codigos_Referidos entity, Spartane.Core.Domain.User.GlobalData Detalle_Codigos_ReferidosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

