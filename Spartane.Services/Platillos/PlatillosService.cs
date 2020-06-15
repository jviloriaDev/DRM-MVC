using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Platillos;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Platillos
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class PlatillosService : IPlatillosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Platillos.Platillos> _PlatillosRepository;
        #endregion

        #region Ctor
        public PlatillosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Platillos.Platillos> PlatillosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._PlatillosRepository = PlatillosRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Platillos.Platillos> SelAll(bool ConRelaciones)
        {
            return this._PlatillosRepository.Table.ToList();
        }

        public IList<Core.Domain.Platillos.Platillos> SelAllComplete(bool ConRelaciones)
        {
            return this._PlatillosRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Platillos.Platillos> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._PlatillosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Platillos.Platillos> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._PlatillosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Platillos.Platillos> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._PlatillosRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Platillos.PlatillosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            PlatillosPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Platillos.Platillos> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._PlatillosRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Platillos.Platillos GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Platillos.Platillos result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData PlatillosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Platillos.Platillos entity, Spartane.Core.Domain.User.GlobalData PlatillosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Platillos.Platillos entity, Spartane.Core.Domain.User.GlobalData PlatillosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

