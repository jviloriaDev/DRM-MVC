using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Calorias;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Calorias
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class CaloriasService : ICaloriasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Calorias.Calorias> _CaloriasRepository;
        #endregion

        #region Ctor
        public CaloriasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Calorias.Calorias> CaloriasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._CaloriasRepository = CaloriasRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Calorias.Calorias> SelAll(bool ConRelaciones)
        {
            return this._CaloriasRepository.Table.ToList();
        }

        public IList<Core.Domain.Calorias.Calorias> SelAllComplete(bool ConRelaciones)
        {
            return this._CaloriasRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Calorias.Calorias> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._CaloriasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Calorias.Calorias> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._CaloriasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Calorias.Calorias> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._CaloriasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Calorias.CaloriasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            CaloriasPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Calorias.Calorias> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._CaloriasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Calorias.Calorias GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Calorias.Calorias result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData CaloriasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Calorias.Calorias entity, Spartane.Core.Domain.User.GlobalData CaloriasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Calorias.Calorias entity, Spartane.Core.Domain.User.GlobalData CaloriasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

