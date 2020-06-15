using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Duracion_Ejercicio;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Duracion_Ejercicio
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Duracion_EjercicioService : IDuracion_EjercicioService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Duracion_Ejercicio.Duracion_Ejercicio> _Duracion_EjercicioRepository;
        #endregion

        #region Ctor
        public Duracion_EjercicioService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Duracion_Ejercicio.Duracion_Ejercicio> Duracion_EjercicioRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Duracion_EjercicioRepository = Duracion_EjercicioRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Duracion_Ejercicio.Duracion_Ejercicio> SelAll(bool ConRelaciones)
        {
            return this._Duracion_EjercicioRepository.Table.ToList();
        }

        public IList<Core.Domain.Duracion_Ejercicio.Duracion_Ejercicio> SelAllComplete(bool ConRelaciones)
        {
            return this._Duracion_EjercicioRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Duracion_Ejercicio.Duracion_Ejercicio> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Duracion_EjercicioRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Duracion_Ejercicio.Duracion_Ejercicio> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Duracion_EjercicioRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Duracion_Ejercicio.Duracion_Ejercicio> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Duracion_EjercicioRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Duracion_Ejercicio.Duracion_EjercicioPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Duracion_EjercicioPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Duracion_Ejercicio.Duracion_Ejercicio> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Duracion_EjercicioRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Duracion_Ejercicio.Duracion_Ejercicio GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Duracion_Ejercicio.Duracion_Ejercicio result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Duracion_EjercicioInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Duracion_Ejercicio.Duracion_Ejercicio entity, Spartane.Core.Domain.User.GlobalData Duracion_EjercicioInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Duracion_Ejercicio.Duracion_Ejercicio entity, Spartane.Core.Domain.User.GlobalData Duracion_EjercicioInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

