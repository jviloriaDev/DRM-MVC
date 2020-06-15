using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Frecuencia_Sustancias;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Frecuencia_Sustancias
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Frecuencia_SustanciasService : IFrecuencia_SustanciasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Frecuencia_Sustancias.Frecuencia_Sustancias> _Frecuencia_SustanciasRepository;
        #endregion

        #region Ctor
        public Frecuencia_SustanciasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Frecuencia_Sustancias.Frecuencia_Sustancias> Frecuencia_SustanciasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Frecuencia_SustanciasRepository = Frecuencia_SustanciasRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Frecuencia_Sustancias.Frecuencia_Sustancias> SelAll(bool ConRelaciones)
        {
            return this._Frecuencia_SustanciasRepository.Table.ToList();
        }

        public IList<Core.Domain.Frecuencia_Sustancias.Frecuencia_Sustancias> SelAllComplete(bool ConRelaciones)
        {
            return this._Frecuencia_SustanciasRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Frecuencia_Sustancias.Frecuencia_Sustancias> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Frecuencia_SustanciasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Frecuencia_Sustancias.Frecuencia_Sustancias> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Frecuencia_SustanciasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Frecuencia_Sustancias.Frecuencia_Sustancias> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Frecuencia_SustanciasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Frecuencia_Sustancias.Frecuencia_SustanciasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Frecuencia_SustanciasPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Frecuencia_Sustancias.Frecuencia_Sustancias> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Frecuencia_SustanciasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Frecuencia_Sustancias.Frecuencia_Sustancias GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Frecuencia_Sustancias.Frecuencia_Sustancias result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Frecuencia_SustanciasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Frecuencia_Sustancias.Frecuencia_Sustancias entity, Spartane.Core.Domain.User.GlobalData Frecuencia_SustanciasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Frecuencia_Sustancias.Frecuencia_Sustancias entity, Spartane.Core.Domain.User.GlobalData Frecuencia_SustanciasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

