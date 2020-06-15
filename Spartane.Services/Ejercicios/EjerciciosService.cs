using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Ejercicios;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Ejercicios
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class EjerciciosService : IEjerciciosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Ejercicios.Ejercicios> _EjerciciosRepository;
        #endregion

        #region Ctor
        public EjerciciosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Ejercicios.Ejercicios> EjerciciosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._EjerciciosRepository = EjerciciosRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Ejercicios.Ejercicios> SelAll(bool ConRelaciones)
        {
            return this._EjerciciosRepository.Table.ToList();
        }

        public IList<Core.Domain.Ejercicios.Ejercicios> SelAllComplete(bool ConRelaciones)
        {
            return this._EjerciciosRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Ejercicios.Ejercicios> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._EjerciciosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Ejercicios.Ejercicios> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._EjerciciosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Ejercicios.Ejercicios> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._EjerciciosRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Ejercicios.EjerciciosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            EjerciciosPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Ejercicios.Ejercicios> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._EjerciciosRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Ejercicios.Ejercicios GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Ejercicios.Ejercicios result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EjerciciosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Ejercicios.Ejercicios entity, Spartane.Core.Domain.User.GlobalData EjerciciosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Ejercicios.Ejercicios entity, Spartane.Core.Domain.User.GlobalData EjerciciosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

