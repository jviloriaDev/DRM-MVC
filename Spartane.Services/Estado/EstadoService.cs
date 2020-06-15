using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Estado;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Estado
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class EstadoService : IEstadoService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Estado.Estado> _EstadoRepository;
        #endregion

        #region Ctor
        public EstadoService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Estado.Estado> EstadoRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._EstadoRepository = EstadoRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Estado.Estado> SelAll(bool ConRelaciones)
        {
            return this._EstadoRepository.Table.ToList();
        }

        public IList<Core.Domain.Estado.Estado> SelAllComplete(bool ConRelaciones)
        {
            return this._EstadoRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Estado.Estado> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._EstadoRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Estado.Estado> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._EstadoRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Estado.Estado> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._EstadoRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Estado.EstadoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            EstadoPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Estado.Estado> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._EstadoRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Estado.Estado GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Estado.Estado result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EstadoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Estado.Estado entity, Spartane.Core.Domain.User.GlobalData EstadoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Estado.Estado entity, Spartane.Core.Domain.User.GlobalData EstadoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

