using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Detalle_Redes_Sociales_Especialista;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Redes_Sociales_Especialista
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Redes_Sociales_EspecialistaService : IDetalle_Redes_Sociales_EspecialistaService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Detalle_Redes_Sociales_Especialista.Detalle_Redes_Sociales_Especialista> _Detalle_Redes_Sociales_EspecialistaRepository;
        #endregion

        #region Ctor
        public Detalle_Redes_Sociales_EspecialistaService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Detalle_Redes_Sociales_Especialista.Detalle_Redes_Sociales_Especialista> Detalle_Redes_Sociales_EspecialistaRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Redes_Sociales_EspecialistaRepository = Detalle_Redes_Sociales_EspecialistaRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Detalle_Redes_Sociales_Especialista.Detalle_Redes_Sociales_Especialista> SelAll(bool ConRelaciones)
        {
            return this._Detalle_Redes_Sociales_EspecialistaRepository.Table.ToList();
        }

        public IList<Core.Domain.Detalle_Redes_Sociales_Especialista.Detalle_Redes_Sociales_Especialista> SelAllComplete(bool ConRelaciones)
        {
            return this._Detalle_Redes_Sociales_EspecialistaRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Detalle_Redes_Sociales_Especialista.Detalle_Redes_Sociales_Especialista> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Redes_Sociales_EspecialistaRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_Redes_Sociales_Especialista.Detalle_Redes_Sociales_Especialista> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Redes_Sociales_EspecialistaRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_Redes_Sociales_Especialista.Detalle_Redes_Sociales_Especialista> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Redes_Sociales_EspecialistaRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_Redes_Sociales_Especialista.Detalle_Redes_Sociales_EspecialistaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Detalle_Redes_Sociales_EspecialistaPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Detalle_Redes_Sociales_Especialista.Detalle_Redes_Sociales_Especialista> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Redes_Sociales_EspecialistaRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_Redes_Sociales_Especialista.Detalle_Redes_Sociales_Especialista GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Detalle_Redes_Sociales_Especialista.Detalle_Redes_Sociales_Especialista result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Detalle_Redes_Sociales_EspecialistaInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Detalle_Redes_Sociales_Especialista.Detalle_Redes_Sociales_Especialista entity, Spartane.Core.Domain.User.GlobalData Detalle_Redes_Sociales_EspecialistaInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Detalle_Redes_Sociales_Especialista.Detalle_Redes_Sociales_Especialista entity, Spartane.Core.Domain.User.GlobalData Detalle_Redes_Sociales_EspecialistaInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

