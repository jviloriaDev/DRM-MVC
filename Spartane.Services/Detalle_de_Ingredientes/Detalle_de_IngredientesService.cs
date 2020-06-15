using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Detalle_de_Ingredientes;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_de_Ingredientes
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_de_IngredientesService : IDetalle_de_IngredientesService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Detalle_de_Ingredientes.Detalle_de_Ingredientes> _Detalle_de_IngredientesRepository;
        #endregion

        #region Ctor
        public Detalle_de_IngredientesService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Detalle_de_Ingredientes.Detalle_de_Ingredientes> Detalle_de_IngredientesRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_de_IngredientesRepository = Detalle_de_IngredientesRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Detalle_de_Ingredientes.Detalle_de_Ingredientes> SelAll(bool ConRelaciones)
        {
            return this._Detalle_de_IngredientesRepository.Table.ToList();
        }

        public IList<Core.Domain.Detalle_de_Ingredientes.Detalle_de_Ingredientes> SelAllComplete(bool ConRelaciones)
        {
            return this._Detalle_de_IngredientesRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Detalle_de_Ingredientes.Detalle_de_Ingredientes> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_de_IngredientesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_de_Ingredientes.Detalle_de_Ingredientes> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_de_IngredientesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_de_Ingredientes.Detalle_de_Ingredientes> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_de_IngredientesRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_de_Ingredientes.Detalle_de_IngredientesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Detalle_de_IngredientesPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Detalle_de_Ingredientes.Detalle_de_Ingredientes> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_de_IngredientesRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_de_Ingredientes.Detalle_de_Ingredientes GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Detalle_de_Ingredientes.Detalle_de_Ingredientes result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Detalle_de_IngredientesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Detalle_de_Ingredientes.Detalle_de_Ingredientes entity, Spartane.Core.Domain.User.GlobalData Detalle_de_IngredientesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Detalle_de_Ingredientes.Detalle_de_Ingredientes entity, Spartane.Core.Domain.User.GlobalData Detalle_de_IngredientesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

