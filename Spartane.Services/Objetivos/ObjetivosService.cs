using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Objetivos;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Objetivos
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class ObjetivosService : IObjetivosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Objetivos.Objetivos> _ObjetivosRepository;
        #endregion

        #region Ctor
        public ObjetivosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Objetivos.Objetivos> ObjetivosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._ObjetivosRepository = ObjetivosRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Objetivos.Objetivos> SelAll(bool ConRelaciones)
        {
            return this._ObjetivosRepository.Table.ToList();
        }

        public IList<Core.Domain.Objetivos.Objetivos> SelAllComplete(bool ConRelaciones)
        {
            return this._ObjetivosRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Objetivos.Objetivos> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._ObjetivosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Objetivos.Objetivos> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._ObjetivosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Objetivos.Objetivos> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._ObjetivosRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Objetivos.ObjetivosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            ObjetivosPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Objetivos.Objetivos> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._ObjetivosRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Objetivos.Objetivos GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Objetivos.Objetivos result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData ObjetivosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Objetivos.Objetivos entity, Spartane.Core.Domain.User.GlobalData ObjetivosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Objetivos.Objetivos entity, Spartane.Core.Domain.User.GlobalData ObjetivosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

