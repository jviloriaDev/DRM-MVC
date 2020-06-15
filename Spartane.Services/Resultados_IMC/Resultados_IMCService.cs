using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Resultados_IMC;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Resultados_IMC
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Resultados_IMCService : IResultados_IMCService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Resultados_IMC.Resultados_IMC> _Resultados_IMCRepository;
        #endregion

        #region Ctor
        public Resultados_IMCService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Resultados_IMC.Resultados_IMC> Resultados_IMCRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Resultados_IMCRepository = Resultados_IMCRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Resultados_IMC.Resultados_IMC> SelAll(bool ConRelaciones)
        {
            return this._Resultados_IMCRepository.Table.ToList();
        }

        public IList<Core.Domain.Resultados_IMC.Resultados_IMC> SelAllComplete(bool ConRelaciones)
        {
            return this._Resultados_IMCRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Resultados_IMC.Resultados_IMC> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Resultados_IMCRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Resultados_IMC.Resultados_IMC> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Resultados_IMCRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Resultados_IMC.Resultados_IMC> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Resultados_IMCRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Resultados_IMC.Resultados_IMCPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Resultados_IMCPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Resultados_IMC.Resultados_IMC> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Resultados_IMCRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Resultados_IMC.Resultados_IMC GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Resultados_IMC.Resultados_IMC result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Resultados_IMCInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Resultados_IMC.Resultados_IMC entity, Spartane.Core.Domain.User.GlobalData Resultados_IMCInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Resultados_IMC.Resultados_IMC entity, Spartane.Core.Domain.User.GlobalData Resultados_IMCInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

