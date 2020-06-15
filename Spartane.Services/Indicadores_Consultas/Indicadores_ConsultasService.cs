using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Indicadores_Consultas;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Indicadores_Consultas
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Indicadores_ConsultasService : IIndicadores_ConsultasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Indicadores_Consultas.Indicadores_Consultas> _Indicadores_ConsultasRepository;
        #endregion

        #region Ctor
        public Indicadores_ConsultasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Indicadores_Consultas.Indicadores_Consultas> Indicadores_ConsultasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Indicadores_ConsultasRepository = Indicadores_ConsultasRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Indicadores_Consultas.Indicadores_Consultas> SelAll(bool ConRelaciones)
        {
            return this._Indicadores_ConsultasRepository.Table.ToList();
        }

        public IList<Core.Domain.Indicadores_Consultas.Indicadores_Consultas> SelAllComplete(bool ConRelaciones)
        {
            return this._Indicadores_ConsultasRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Indicadores_Consultas.Indicadores_Consultas> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Indicadores_ConsultasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Indicadores_Consultas.Indicadores_Consultas> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Indicadores_ConsultasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Indicadores_Consultas.Indicadores_Consultas> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Indicadores_ConsultasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Indicadores_Consultas.Indicadores_ConsultasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Indicadores_ConsultasPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Indicadores_Consultas.Indicadores_Consultas> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Indicadores_ConsultasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Indicadores_Consultas.Indicadores_Consultas GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Indicadores_Consultas.Indicadores_Consultas result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Indicadores_ConsultasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Indicadores_Consultas.Indicadores_Consultas entity, Spartane.Core.Domain.User.GlobalData Indicadores_ConsultasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Indicadores_Consultas.Indicadores_Consultas entity, Spartane.Core.Domain.User.GlobalData Indicadores_ConsultasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

