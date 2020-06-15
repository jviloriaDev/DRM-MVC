using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Planes_de_Suscripcion_Especialistas;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Planes_de_Suscripcion_Especialistas
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Planes_de_Suscripcion_EspecialistasService : IPlanes_de_Suscripcion_EspecialistasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Planes_de_Suscripcion_Especialistas.Planes_de_Suscripcion_Especialistas> _Planes_de_Suscripcion_EspecialistasRepository;
        #endregion

        #region Ctor
        public Planes_de_Suscripcion_EspecialistasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Planes_de_Suscripcion_Especialistas.Planes_de_Suscripcion_Especialistas> Planes_de_Suscripcion_EspecialistasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Planes_de_Suscripcion_EspecialistasRepository = Planes_de_Suscripcion_EspecialistasRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Planes_de_Suscripcion_Especialistas.Planes_de_Suscripcion_Especialistas> SelAll(bool ConRelaciones)
        {
            return this._Planes_de_Suscripcion_EspecialistasRepository.Table.ToList();
        }

        public IList<Core.Domain.Planes_de_Suscripcion_Especialistas.Planes_de_Suscripcion_Especialistas> SelAllComplete(bool ConRelaciones)
        {
            return this._Planes_de_Suscripcion_EspecialistasRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Planes_de_Suscripcion_Especialistas.Planes_de_Suscripcion_Especialistas> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Planes_de_Suscripcion_EspecialistasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Planes_de_Suscripcion_Especialistas.Planes_de_Suscripcion_Especialistas> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Planes_de_Suscripcion_EspecialistasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Planes_de_Suscripcion_Especialistas.Planes_de_Suscripcion_Especialistas> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Planes_de_Suscripcion_EspecialistasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Planes_de_Suscripcion_Especialistas.Planes_de_Suscripcion_EspecialistasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Planes_de_Suscripcion_EspecialistasPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Planes_de_Suscripcion_Especialistas.Planes_de_Suscripcion_Especialistas> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Planes_de_Suscripcion_EspecialistasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Planes_de_Suscripcion_Especialistas.Planes_de_Suscripcion_Especialistas GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Planes_de_Suscripcion_Especialistas.Planes_de_Suscripcion_Especialistas result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Planes_de_Suscripcion_EspecialistasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Planes_de_Suscripcion_Especialistas.Planes_de_Suscripcion_Especialistas entity, Spartane.Core.Domain.User.GlobalData Planes_de_Suscripcion_EspecialistasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Planes_de_Suscripcion_Especialistas.Planes_de_Suscripcion_Especialistas entity, Spartane.Core.Domain.User.GlobalData Planes_de_Suscripcion_EspecialistasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

