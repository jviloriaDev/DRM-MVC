using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Detalle_Platillos;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Platillos
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_PlatillosService : IDetalle_PlatillosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Detalle_Platillos.Detalle_Platillos> _Detalle_PlatillosRepository;
        #endregion

        #region Ctor
        public Detalle_PlatillosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Detalle_Platillos.Detalle_Platillos> Detalle_PlatillosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_PlatillosRepository = Detalle_PlatillosRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Detalle_Platillos.Detalle_Platillos> SelAll(bool ConRelaciones)
        {
            return this._Detalle_PlatillosRepository.Table.ToList();
        }

        public IList<Core.Domain.Detalle_Platillos.Detalle_Platillos> SelAllComplete(bool ConRelaciones)
        {
            return this._Detalle_PlatillosRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Detalle_Platillos.Detalle_Platillos> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_PlatillosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_Platillos.Detalle_Platillos> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_PlatillosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_Platillos.Detalle_Platillos> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_PlatillosRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_Platillos.Detalle_PlatillosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Detalle_PlatillosPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Detalle_Platillos.Detalle_Platillos> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_PlatillosRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_Platillos.Detalle_Platillos GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Detalle_Platillos.Detalle_Platillos result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Detalle_PlatillosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Detalle_Platillos.Detalle_Platillos entity, Spartane.Core.Domain.User.GlobalData Detalle_PlatillosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Detalle_Platillos.Detalle_Platillos entity, Spartane.Core.Domain.User.GlobalData Detalle_PlatillosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

