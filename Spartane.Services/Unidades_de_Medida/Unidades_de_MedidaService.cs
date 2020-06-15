using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Unidades_de_Medida;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Unidades_de_Medida
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Unidades_de_MedidaService : IUnidades_de_MedidaService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Unidades_de_Medida.Unidades_de_Medida> _Unidades_de_MedidaRepository;
        #endregion

        #region Ctor
        public Unidades_de_MedidaService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Unidades_de_Medida.Unidades_de_Medida> Unidades_de_MedidaRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Unidades_de_MedidaRepository = Unidades_de_MedidaRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Unidades_de_Medida.Unidades_de_Medida> SelAll(bool ConRelaciones)
        {
            return this._Unidades_de_MedidaRepository.Table.ToList();
        }

        public IList<Core.Domain.Unidades_de_Medida.Unidades_de_Medida> SelAllComplete(bool ConRelaciones)
        {
            return this._Unidades_de_MedidaRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Unidades_de_Medida.Unidades_de_Medida> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Unidades_de_MedidaRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Unidades_de_Medida.Unidades_de_Medida> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Unidades_de_MedidaRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Unidades_de_Medida.Unidades_de_Medida> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Unidades_de_MedidaRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Unidades_de_Medida.Unidades_de_MedidaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Unidades_de_MedidaPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Unidades_de_Medida.Unidades_de_Medida> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Unidades_de_MedidaRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Unidades_de_Medida.Unidades_de_Medida GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Unidades_de_Medida.Unidades_de_Medida result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Unidades_de_MedidaInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Unidades_de_Medida.Unidades_de_Medida entity, Spartane.Core.Domain.User.GlobalData Unidades_de_MedidaInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Unidades_de_Medida.Unidades_de_Medida entity, Spartane.Core.Domain.User.GlobalData Unidades_de_MedidaInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

