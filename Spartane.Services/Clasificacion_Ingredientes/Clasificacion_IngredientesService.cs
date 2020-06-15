using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Clasificacion_Ingredientes;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Clasificacion_Ingredientes
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Clasificacion_IngredientesService : IClasificacion_IngredientesService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Clasificacion_Ingredientes.Clasificacion_Ingredientes> _Clasificacion_IngredientesRepository;
        #endregion

        #region Ctor
        public Clasificacion_IngredientesService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Clasificacion_Ingredientes.Clasificacion_Ingredientes> Clasificacion_IngredientesRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Clasificacion_IngredientesRepository = Clasificacion_IngredientesRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Clasificacion_Ingredientes.Clasificacion_Ingredientes> SelAll(bool ConRelaciones)
        {
            return this._Clasificacion_IngredientesRepository.Table.ToList();
        }

        public IList<Core.Domain.Clasificacion_Ingredientes.Clasificacion_Ingredientes> SelAllComplete(bool ConRelaciones)
        {
            return this._Clasificacion_IngredientesRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Clasificacion_Ingredientes.Clasificacion_Ingredientes> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Clasificacion_IngredientesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Clasificacion_Ingredientes.Clasificacion_Ingredientes> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Clasificacion_IngredientesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Clasificacion_Ingredientes.Clasificacion_Ingredientes> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Clasificacion_IngredientesRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Clasificacion_Ingredientes.Clasificacion_IngredientesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Clasificacion_IngredientesPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Clasificacion_Ingredientes.Clasificacion_Ingredientes> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Clasificacion_IngredientesRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Clasificacion_Ingredientes.Clasificacion_Ingredientes GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Clasificacion_Ingredientes.Clasificacion_Ingredientes result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Clasificacion_IngredientesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Clasificacion_Ingredientes.Clasificacion_Ingredientes entity, Spartane.Core.Domain.User.GlobalData Clasificacion_IngredientesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Clasificacion_Ingredientes.Clasificacion_Ingredientes entity, Spartane.Core.Domain.User.GlobalData Clasificacion_IngredientesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

