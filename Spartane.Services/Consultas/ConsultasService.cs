using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Consultas;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Consultas
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class ConsultasService : IConsultasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Consultas.Consultas> _ConsultasRepository;
        #endregion

        #region Ctor
        public ConsultasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Consultas.Consultas> ConsultasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._ConsultasRepository = ConsultasRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Consultas.Consultas> SelAll(bool ConRelaciones)
        {
            return this._ConsultasRepository.Table.ToList();
        }

        public IList<Core.Domain.Consultas.Consultas> SelAllComplete(bool ConRelaciones)
        {
            return this._ConsultasRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Consultas.Consultas> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._ConsultasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Consultas.Consultas> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._ConsultasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Consultas.Consultas> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._ConsultasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Consultas.ConsultasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            ConsultasPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Consultas.Consultas> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._ConsultasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Consultas.Consultas GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Consultas.Consultas result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData ConsultasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Consultas.Consultas entity, Spartane.Core.Domain.User.GlobalData ConsultasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Consultas.Consultas entity, Spartane.Core.Domain.User.GlobalData ConsultasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

