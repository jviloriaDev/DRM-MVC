using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Detalle_Caracteristicas_Ingrediente;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Caracteristicas_Ingrediente
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Caracteristicas_IngredienteService : IDetalle_Caracteristicas_IngredienteService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente> _Detalle_Caracteristicas_IngredienteRepository;
        #endregion

        #region Ctor
        public Detalle_Caracteristicas_IngredienteService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente> Detalle_Caracteristicas_IngredienteRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Caracteristicas_IngredienteRepository = Detalle_Caracteristicas_IngredienteRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente> SelAll(bool ConRelaciones)
        {
            return this._Detalle_Caracteristicas_IngredienteRepository.Table.ToList();
        }

        public IList<Core.Domain.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente> SelAllComplete(bool ConRelaciones)
        {
            return this._Detalle_Caracteristicas_IngredienteRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Caracteristicas_IngredienteRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Caracteristicas_IngredienteRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Caracteristicas_IngredienteRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_IngredientePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Detalle_Caracteristicas_IngredientePagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Caracteristicas_IngredienteRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Detalle_Caracteristicas_IngredienteInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente entity, Spartane.Core.Domain.User.GlobalData Detalle_Caracteristicas_IngredienteInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Detalle_Caracteristicas_Ingrediente.Detalle_Caracteristicas_Ingrediente entity, Spartane.Core.Domain.User.GlobalData Detalle_Caracteristicas_IngredienteInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

