using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Detalle_Pagos_Especialistas;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Pagos_Especialistas
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Pagos_EspecialistasService : IDetalle_Pagos_EspecialistasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Detalle_Pagos_Especialistas.Detalle_Pagos_Especialistas> _Detalle_Pagos_EspecialistasRepository;
        #endregion

        #region Ctor
        public Detalle_Pagos_EspecialistasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Detalle_Pagos_Especialistas.Detalle_Pagos_Especialistas> Detalle_Pagos_EspecialistasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Pagos_EspecialistasRepository = Detalle_Pagos_EspecialistasRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Detalle_Pagos_Especialistas.Detalle_Pagos_Especialistas> SelAll(bool ConRelaciones)
        {
            return this._Detalle_Pagos_EspecialistasRepository.Table.ToList();
        }

        public IList<Core.Domain.Detalle_Pagos_Especialistas.Detalle_Pagos_Especialistas> SelAllComplete(bool ConRelaciones)
        {
            return this._Detalle_Pagos_EspecialistasRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Detalle_Pagos_Especialistas.Detalle_Pagos_Especialistas> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Pagos_EspecialistasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_Pagos_Especialistas.Detalle_Pagos_Especialistas> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Pagos_EspecialistasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_Pagos_Especialistas.Detalle_Pagos_Especialistas> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Pagos_EspecialistasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_Pagos_Especialistas.Detalle_Pagos_EspecialistasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Detalle_Pagos_EspecialistasPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Detalle_Pagos_Especialistas.Detalle_Pagos_Especialistas> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Pagos_EspecialistasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_Pagos_Especialistas.Detalle_Pagos_Especialistas GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Detalle_Pagos_Especialistas.Detalle_Pagos_Especialistas result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Detalle_Pagos_EspecialistasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Detalle_Pagos_Especialistas.Detalle_Pagos_Especialistas entity, Spartane.Core.Domain.User.GlobalData Detalle_Pagos_EspecialistasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Detalle_Pagos_Especialistas.Detalle_Pagos_Especialistas entity, Spartane.Core.Domain.User.GlobalData Detalle_Pagos_EspecialistasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

