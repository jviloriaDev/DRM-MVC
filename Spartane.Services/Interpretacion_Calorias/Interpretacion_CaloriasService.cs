using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Interpretacion_Calorias;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Interpretacion_Calorias
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Interpretacion_CaloriasService : IInterpretacion_CaloriasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Interpretacion_Calorias.Interpretacion_Calorias> _Interpretacion_CaloriasRepository;
        #endregion

        #region Ctor
        public Interpretacion_CaloriasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Interpretacion_Calorias.Interpretacion_Calorias> Interpretacion_CaloriasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Interpretacion_CaloriasRepository = Interpretacion_CaloriasRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Interpretacion_Calorias.Interpretacion_Calorias> SelAll(bool ConRelaciones)
        {
            return this._Interpretacion_CaloriasRepository.Table.ToList();
        }

        public IList<Core.Domain.Interpretacion_Calorias.Interpretacion_Calorias> SelAllComplete(bool ConRelaciones)
        {
            return this._Interpretacion_CaloriasRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Interpretacion_Calorias.Interpretacion_Calorias> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Interpretacion_CaloriasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Interpretacion_Calorias.Interpretacion_Calorias> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Interpretacion_CaloriasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Interpretacion_Calorias.Interpretacion_Calorias> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Interpretacion_CaloriasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Interpretacion_Calorias.Interpretacion_CaloriasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Interpretacion_CaloriasPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Interpretacion_Calorias.Interpretacion_Calorias> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Interpretacion_CaloriasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Interpretacion_Calorias.Interpretacion_Calorias GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Interpretacion_Calorias.Interpretacion_Calorias result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Interpretacion_CaloriasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Interpretacion_Calorias.Interpretacion_Calorias entity, Spartane.Core.Domain.User.GlobalData Interpretacion_CaloriasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Interpretacion_Calorias.Interpretacion_Calorias entity, Spartane.Core.Domain.User.GlobalData Interpretacion_CaloriasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

