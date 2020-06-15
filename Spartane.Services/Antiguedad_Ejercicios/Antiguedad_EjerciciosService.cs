using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Antiguedad_Ejercicios;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Antiguedad_Ejercicios
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Antiguedad_EjerciciosService : IAntiguedad_EjerciciosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Antiguedad_Ejercicios.Antiguedad_Ejercicios> _Antiguedad_EjerciciosRepository;
        #endregion

        #region Ctor
        public Antiguedad_EjerciciosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Antiguedad_Ejercicios.Antiguedad_Ejercicios> Antiguedad_EjerciciosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Antiguedad_EjerciciosRepository = Antiguedad_EjerciciosRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Antiguedad_Ejercicios.Antiguedad_Ejercicios> SelAll(bool ConRelaciones)
        {
            return this._Antiguedad_EjerciciosRepository.Table.ToList();
        }

        public IList<Core.Domain.Antiguedad_Ejercicios.Antiguedad_Ejercicios> SelAllComplete(bool ConRelaciones)
        {
            return this._Antiguedad_EjerciciosRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Antiguedad_Ejercicios.Antiguedad_Ejercicios> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Antiguedad_EjerciciosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Antiguedad_Ejercicios.Antiguedad_Ejercicios> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Antiguedad_EjerciciosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Antiguedad_Ejercicios.Antiguedad_Ejercicios> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Antiguedad_EjerciciosRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Antiguedad_Ejercicios.Antiguedad_EjerciciosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Antiguedad_EjerciciosPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Antiguedad_Ejercicios.Antiguedad_Ejercicios> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Antiguedad_EjerciciosRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Antiguedad_Ejercicios.Antiguedad_Ejercicios GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Antiguedad_Ejercicios.Antiguedad_Ejercicios result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Antiguedad_EjerciciosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Antiguedad_Ejercicios.Antiguedad_Ejercicios entity, Spartane.Core.Domain.User.GlobalData Antiguedad_EjerciciosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Antiguedad_Ejercicios.Antiguedad_Ejercicios entity, Spartane.Core.Domain.User.GlobalData Antiguedad_EjerciciosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

