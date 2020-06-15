using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Enfermedades;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Enfermedades
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class EnfermedadesService : IEnfermedadesService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Enfermedades.Enfermedades> _EnfermedadesRepository;
        #endregion

        #region Ctor
        public EnfermedadesService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Enfermedades.Enfermedades> EnfermedadesRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._EnfermedadesRepository = EnfermedadesRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Enfermedades.Enfermedades> SelAll(bool ConRelaciones)
        {
            return this._EnfermedadesRepository.Table.ToList();
        }

        public IList<Core.Domain.Enfermedades.Enfermedades> SelAllComplete(bool ConRelaciones)
        {
            return this._EnfermedadesRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Enfermedades.Enfermedades> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._EnfermedadesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Enfermedades.Enfermedades> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._EnfermedadesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Enfermedades.Enfermedades> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._EnfermedadesRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Enfermedades.EnfermedadesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            EnfermedadesPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Enfermedades.Enfermedades> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._EnfermedadesRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Enfermedades.Enfermedades GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Enfermedades.Enfermedades result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EnfermedadesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Enfermedades.Enfermedades entity, Spartane.Core.Domain.User.GlobalData EnfermedadesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Enfermedades.Enfermedades entity, Spartane.Core.Domain.User.GlobalData EnfermedadesInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

