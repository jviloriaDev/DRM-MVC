using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.MS_Suscripciones_Codigos_Referidos_Especialista;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.MS_Suscripciones_Codigos_Referidos_Especialista
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class MS_Suscripciones_Codigos_Referidos_EspecialistaService : IMS_Suscripciones_Codigos_Referidos_EspecialistaService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.MS_Suscripciones_Codigos_Referidos_Especialista.MS_Suscripciones_Codigos_Referidos_Especialista> _MS_Suscripciones_Codigos_Referidos_EspecialistaRepository;
        #endregion

        #region Ctor
        public MS_Suscripciones_Codigos_Referidos_EspecialistaService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.MS_Suscripciones_Codigos_Referidos_Especialista.MS_Suscripciones_Codigos_Referidos_Especialista> MS_Suscripciones_Codigos_Referidos_EspecialistaRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._MS_Suscripciones_Codigos_Referidos_EspecialistaRepository = MS_Suscripciones_Codigos_Referidos_EspecialistaRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.MS_Suscripciones_Codigos_Referidos_Especialista.MS_Suscripciones_Codigos_Referidos_Especialista> SelAll(bool ConRelaciones)
        {
            return this._MS_Suscripciones_Codigos_Referidos_EspecialistaRepository.Table.ToList();
        }

        public IList<Core.Domain.MS_Suscripciones_Codigos_Referidos_Especialista.MS_Suscripciones_Codigos_Referidos_Especialista> SelAllComplete(bool ConRelaciones)
        {
            return this._MS_Suscripciones_Codigos_Referidos_EspecialistaRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.MS_Suscripciones_Codigos_Referidos_Especialista.MS_Suscripciones_Codigos_Referidos_Especialista> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MS_Suscripciones_Codigos_Referidos_EspecialistaRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.MS_Suscripciones_Codigos_Referidos_Especialista.MS_Suscripciones_Codigos_Referidos_Especialista> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._MS_Suscripciones_Codigos_Referidos_EspecialistaRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.MS_Suscripciones_Codigos_Referidos_Especialista.MS_Suscripciones_Codigos_Referidos_Especialista> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MS_Suscripciones_Codigos_Referidos_EspecialistaRepository.Table.ToList();
        }

        public Spartane.Core.Domain.MS_Suscripciones_Codigos_Referidos_Especialista.MS_Suscripciones_Codigos_Referidos_EspecialistaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            MS_Suscripciones_Codigos_Referidos_EspecialistaPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.MS_Suscripciones_Codigos_Referidos_Especialista.MS_Suscripciones_Codigos_Referidos_Especialista> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._MS_Suscripciones_Codigos_Referidos_EspecialistaRepository.Table.ToList();
        }

        public Spartane.Core.Domain.MS_Suscripciones_Codigos_Referidos_Especialista.MS_Suscripciones_Codigos_Referidos_Especialista GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.MS_Suscripciones_Codigos_Referidos_Especialista.MS_Suscripciones_Codigos_Referidos_Especialista result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData MS_Suscripciones_Codigos_Referidos_EspecialistaInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.MS_Suscripciones_Codigos_Referidos_Especialista.MS_Suscripciones_Codigos_Referidos_Especialista entity, Spartane.Core.Domain.User.GlobalData MS_Suscripciones_Codigos_Referidos_EspecialistaInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.MS_Suscripciones_Codigos_Referidos_Especialista.MS_Suscripciones_Codigos_Referidos_Especialista entity, Spartane.Core.Domain.User.GlobalData MS_Suscripciones_Codigos_Referidos_EspecialistaInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

