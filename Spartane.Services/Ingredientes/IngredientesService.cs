using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Ingredientes;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Ingredientes
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class IngredientesService : IIngredientesService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Ingredientes.Ingredientes> _IngredientesRepository;
        #endregion

        #region Ctor
        public IngredientesService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Ingredientes.Ingredientes> IngredientesRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._IngredientesRepository = IngredientesRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Ingredientes.Ingredientes> SelAll(bool ConRelaciones)
        {
            return this._IngredientesRepository.Table.ToList();
        }

        public IList<Core.Domain.Ingredientes.Ingredientes> SelAllComplete(bool ConRelaciones)
        {
            return this._IngredientesRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Ingredientes.Ingredientes> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._IngredientesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Ingredientes.Ingredientes> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._IngredientesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Ingredientes.Ingredientes> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._IngredientesRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Ingredientes.IngredientesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            IngredientesPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Ingredientes.Ingredientes> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._IngredientesRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Ingredientes.Ingredientes GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Ingredientes.Ingredientes result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData IngredientesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Ingredientes.Ingredientes entity, Spartane.Core.Domain.User.GlobalData IngredientesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Ingredientes.Ingredientes entity, Spartane.Core.Domain.User.GlobalData IngredientesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

