using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Estatus_Llamadas;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Estatus_Llamadas
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Estatus_LlamadasService : IEstatus_LlamadasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Estatus_Llamadas.Estatus_Llamadas> _Estatus_LlamadasRepository;
        #endregion

        #region Ctor
        public Estatus_LlamadasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Estatus_Llamadas.Estatus_Llamadas> Estatus_LlamadasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Estatus_LlamadasRepository = Estatus_LlamadasRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Estatus_Llamadas.Estatus_Llamadas> SelAll(bool ConRelaciones)
        {
            return this._Estatus_LlamadasRepository.Table.ToList();
        }

        public IList<Core.Domain.Estatus_Llamadas.Estatus_Llamadas> SelAllComplete(bool ConRelaciones)
        {
            return this._Estatus_LlamadasRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Estatus_Llamadas.Estatus_Llamadas> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Estatus_LlamadasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Estatus_Llamadas.Estatus_Llamadas> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Estatus_LlamadasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Estatus_Llamadas.Estatus_Llamadas> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Estatus_LlamadasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Estatus_Llamadas.Estatus_LlamadasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Estatus_LlamadasPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Estatus_Llamadas.Estatus_Llamadas> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Estatus_LlamadasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Estatus_Llamadas.Estatus_Llamadas GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Estatus_Llamadas.Estatus_Llamadas result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Estatus_LlamadasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Estatus_Llamadas.Estatus_Llamadas entity, Spartane.Core.Domain.User.GlobalData Estatus_LlamadasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Estatus_Llamadas.Estatus_Llamadas entity, Spartane.Core.Domain.User.GlobalData Estatus_LlamadasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

