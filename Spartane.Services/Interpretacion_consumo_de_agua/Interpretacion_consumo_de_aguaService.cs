using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Interpretacion_consumo_de_agua;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Interpretacion_consumo_de_agua
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Interpretacion_consumo_de_aguaService : IInterpretacion_consumo_de_aguaService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Interpretacion_consumo_de_agua.Interpretacion_consumo_de_agua> _Interpretacion_consumo_de_aguaRepository;
        #endregion

        #region Ctor
        public Interpretacion_consumo_de_aguaService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Interpretacion_consumo_de_agua.Interpretacion_consumo_de_agua> Interpretacion_consumo_de_aguaRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Interpretacion_consumo_de_aguaRepository = Interpretacion_consumo_de_aguaRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Interpretacion_consumo_de_agua.Interpretacion_consumo_de_agua> SelAll(bool ConRelaciones)
        {
            return this._Interpretacion_consumo_de_aguaRepository.Table.ToList();
        }

        public IList<Core.Domain.Interpretacion_consumo_de_agua.Interpretacion_consumo_de_agua> SelAllComplete(bool ConRelaciones)
        {
            return this._Interpretacion_consumo_de_aguaRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Interpretacion_consumo_de_agua.Interpretacion_consumo_de_agua> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Interpretacion_consumo_de_aguaRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Interpretacion_consumo_de_agua.Interpretacion_consumo_de_agua> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Interpretacion_consumo_de_aguaRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Interpretacion_consumo_de_agua.Interpretacion_consumo_de_agua> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Interpretacion_consumo_de_aguaRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Interpretacion_consumo_de_agua.Interpretacion_consumo_de_aguaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Interpretacion_consumo_de_aguaPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Interpretacion_consumo_de_agua.Interpretacion_consumo_de_agua> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Interpretacion_consumo_de_aguaRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Interpretacion_consumo_de_agua.Interpretacion_consumo_de_agua GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Interpretacion_consumo_de_agua.Interpretacion_consumo_de_agua result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Interpretacion_consumo_de_aguaInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Interpretacion_consumo_de_agua.Interpretacion_consumo_de_agua entity, Spartane.Core.Domain.User.GlobalData Interpretacion_consumo_de_aguaInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Interpretacion_consumo_de_agua.Interpretacion_consumo_de_agua entity, Spartane.Core.Domain.User.GlobalData Interpretacion_consumo_de_aguaInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

