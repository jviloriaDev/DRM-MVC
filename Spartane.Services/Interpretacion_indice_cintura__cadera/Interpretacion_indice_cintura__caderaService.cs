using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Interpretacion_indice_cintura__cadera;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Interpretacion_indice_cintura__cadera
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Interpretacion_indice_cintura__caderaService : IInterpretacion_indice_cintura__caderaService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera> _Interpretacion_indice_cintura__caderaRepository;
        #endregion

        #region Ctor
        public Interpretacion_indice_cintura__caderaService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera> Interpretacion_indice_cintura__caderaRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Interpretacion_indice_cintura__caderaRepository = Interpretacion_indice_cintura__caderaRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera> SelAll(bool ConRelaciones)
        {
            return this._Interpretacion_indice_cintura__caderaRepository.Table.ToList();
        }

        public IList<Core.Domain.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera> SelAllComplete(bool ConRelaciones)
        {
            return this._Interpretacion_indice_cintura__caderaRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Interpretacion_indice_cintura__caderaRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Interpretacion_indice_cintura__caderaRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Interpretacion_indice_cintura__caderaRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__caderaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Interpretacion_indice_cintura__caderaPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Interpretacion_indice_cintura__caderaRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Interpretacion_indice_cintura__caderaInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera entity, Spartane.Core.Domain.User.GlobalData Interpretacion_indice_cintura__caderaInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera entity, Spartane.Core.Domain.User.GlobalData Interpretacion_indice_cintura__caderaInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

