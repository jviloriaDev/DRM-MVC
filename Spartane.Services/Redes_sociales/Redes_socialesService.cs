using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Redes_sociales;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Redes_sociales
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Redes_socialesService : IRedes_socialesService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Redes_sociales.Redes_sociales> _Redes_socialesRepository;
        #endregion

        #region Ctor
        public Redes_socialesService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Redes_sociales.Redes_sociales> Redes_socialesRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Redes_socialesRepository = Redes_socialesRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Redes_sociales.Redes_sociales> SelAll(bool ConRelaciones)
        {
            return this._Redes_socialesRepository.Table.ToList();
        }

        public IList<Core.Domain.Redes_sociales.Redes_sociales> SelAllComplete(bool ConRelaciones)
        {
            return this._Redes_socialesRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Redes_sociales.Redes_sociales> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Redes_socialesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Redes_sociales.Redes_sociales> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Redes_socialesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Redes_sociales.Redes_sociales> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Redes_socialesRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Redes_sociales.Redes_socialesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Redes_socialesPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Redes_sociales.Redes_sociales> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Redes_socialesRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Redes_sociales.Redes_sociales GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Redes_sociales.Redes_sociales result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Redes_socialesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Redes_sociales.Redes_sociales entity, Spartane.Core.Domain.User.GlobalData Redes_socialesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Redes_sociales.Redes_sociales entity, Spartane.Core.Domain.User.GlobalData Redes_socialesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

