using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Frecuencia_Ejercicio;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Frecuencia_Ejercicio
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Frecuencia_EjercicioService : IFrecuencia_EjercicioService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Frecuencia_Ejercicio.Frecuencia_Ejercicio> _Frecuencia_EjercicioRepository;
        #endregion

        #region Ctor
        public Frecuencia_EjercicioService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Frecuencia_Ejercicio.Frecuencia_Ejercicio> Frecuencia_EjercicioRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Frecuencia_EjercicioRepository = Frecuencia_EjercicioRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Frecuencia_Ejercicio.Frecuencia_Ejercicio> SelAll(bool ConRelaciones)
        {
            return this._Frecuencia_EjercicioRepository.Table.ToList();
        }

        public IList<Core.Domain.Frecuencia_Ejercicio.Frecuencia_Ejercicio> SelAllComplete(bool ConRelaciones)
        {
            return this._Frecuencia_EjercicioRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Frecuencia_Ejercicio.Frecuencia_Ejercicio> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Frecuencia_EjercicioRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Frecuencia_Ejercicio.Frecuencia_Ejercicio> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Frecuencia_EjercicioRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Frecuencia_Ejercicio.Frecuencia_Ejercicio> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Frecuencia_EjercicioRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Frecuencia_Ejercicio.Frecuencia_EjercicioPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Frecuencia_EjercicioPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Frecuencia_Ejercicio.Frecuencia_Ejercicio> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Frecuencia_EjercicioRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Frecuencia_Ejercicio.Frecuencia_Ejercicio GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Frecuencia_Ejercicio.Frecuencia_Ejercicio result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Frecuencia_EjercicioInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Frecuencia_Ejercicio.Frecuencia_Ejercicio entity, Spartane.Core.Domain.User.GlobalData Frecuencia_EjercicioInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Frecuencia_Ejercicio.Frecuencia_Ejercicio entity, Spartane.Core.Domain.User.GlobalData Frecuencia_EjercicioInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

