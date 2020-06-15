using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Marca;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Marca
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class MarcaService : IMarcaService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Marca.Marca> _MarcaRepository;
        #endregion

        #region Ctor
        public MarcaService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Marca.Marca> MarcaRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._MarcaRepository = MarcaRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Marca.Marca> SelAll(bool ConRelaciones)
        {
            return this._MarcaRepository.Table.ToList();
        }

        public IList<Core.Domain.Marca.Marca> SelAllComplete(bool ConRelaciones)
        {
            return this._MarcaRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Marca.Marca> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MarcaRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Marca.Marca> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._MarcaRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Marca.Marca> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MarcaRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Marca.MarcaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            MarcaPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Marca.Marca> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._MarcaRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Marca.Marca GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Marca.Marca result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData MarcaInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Marca.Marca entity, Spartane.Core.Domain.User.GlobalData MarcaInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Marca.Marca entity, Spartane.Core.Domain.User.GlobalData MarcaInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

