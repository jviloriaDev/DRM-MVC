using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Aseguradoras;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Aseguradoras
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class AseguradorasService : IAseguradorasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Aseguradoras.Aseguradoras> _AseguradorasRepository;
        #endregion

        #region Ctor
        public AseguradorasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Aseguradoras.Aseguradoras> AseguradorasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._AseguradorasRepository = AseguradorasRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Aseguradoras.Aseguradoras> SelAll(bool ConRelaciones)
        {
            return this._AseguradorasRepository.Table.ToList();
        }

        public IList<Core.Domain.Aseguradoras.Aseguradoras> SelAllComplete(bool ConRelaciones)
        {
            return this._AseguradorasRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Aseguradoras.Aseguradoras> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._AseguradorasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Aseguradoras.Aseguradoras> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._AseguradorasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Aseguradoras.Aseguradoras> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._AseguradorasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Aseguradoras.AseguradorasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            AseguradorasPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Aseguradoras.Aseguradoras> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._AseguradorasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Aseguradoras.Aseguradoras GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Aseguradoras.Aseguradoras result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData AseguradorasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Aseguradoras.Aseguradoras entity, Spartane.Core.Domain.User.GlobalData AseguradorasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Aseguradoras.Aseguradoras entity, Spartane.Core.Domain.User.GlobalData AseguradorasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

