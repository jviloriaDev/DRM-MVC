using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Detalle_Resultados_Consultas;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Resultados_Consultas
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Resultados_ConsultasService : IDetalle_Resultados_ConsultasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Detalle_Resultados_Consultas.Detalle_Resultados_Consultas> _Detalle_Resultados_ConsultasRepository;
        #endregion

        #region Ctor
        public Detalle_Resultados_ConsultasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Detalle_Resultados_Consultas.Detalle_Resultados_Consultas> Detalle_Resultados_ConsultasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Resultados_ConsultasRepository = Detalle_Resultados_ConsultasRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Detalle_Resultados_Consultas.Detalle_Resultados_Consultas> SelAll(bool ConRelaciones)
        {
            return this._Detalle_Resultados_ConsultasRepository.Table.ToList();
        }

        public IList<Core.Domain.Detalle_Resultados_Consultas.Detalle_Resultados_Consultas> SelAllComplete(bool ConRelaciones)
        {
            return this._Detalle_Resultados_ConsultasRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Detalle_Resultados_Consultas.Detalle_Resultados_Consultas> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Resultados_ConsultasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_Resultados_Consultas.Detalle_Resultados_Consultas> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Resultados_ConsultasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_Resultados_Consultas.Detalle_Resultados_Consultas> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Resultados_ConsultasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_Resultados_Consultas.Detalle_Resultados_ConsultasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Detalle_Resultados_ConsultasPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Detalle_Resultados_Consultas.Detalle_Resultados_Consultas> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Resultados_ConsultasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_Resultados_Consultas.Detalle_Resultados_Consultas GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Detalle_Resultados_Consultas.Detalle_Resultados_Consultas result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Detalle_Resultados_ConsultasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Detalle_Resultados_Consultas.Detalle_Resultados_Consultas entity, Spartane.Core.Domain.User.GlobalData Detalle_Resultados_ConsultasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Detalle_Resultados_Consultas.Detalle_Resultados_Consultas entity, Spartane.Core.Domain.User.GlobalData Detalle_Resultados_ConsultasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

