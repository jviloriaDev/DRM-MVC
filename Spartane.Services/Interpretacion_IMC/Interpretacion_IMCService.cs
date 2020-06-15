using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Interpretacion_IMC;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Interpretacion_IMC
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Interpretacion_IMCService : IInterpretacion_IMCService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Interpretacion_IMC.Interpretacion_IMC> _Interpretacion_IMCRepository;
        #endregion

        #region Ctor
        public Interpretacion_IMCService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Interpretacion_IMC.Interpretacion_IMC> Interpretacion_IMCRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Interpretacion_IMCRepository = Interpretacion_IMCRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Interpretacion_IMC.Interpretacion_IMC> SelAll(bool ConRelaciones)
        {
            return this._Interpretacion_IMCRepository.Table.ToList();
        }

        public IList<Core.Domain.Interpretacion_IMC.Interpretacion_IMC> SelAllComplete(bool ConRelaciones)
        {
            return this._Interpretacion_IMCRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Interpretacion_IMC.Interpretacion_IMC> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Interpretacion_IMCRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Interpretacion_IMC.Interpretacion_IMC> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Interpretacion_IMCRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Interpretacion_IMC.Interpretacion_IMC> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Interpretacion_IMCRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Interpretacion_IMC.Interpretacion_IMCPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Interpretacion_IMCPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Interpretacion_IMC.Interpretacion_IMC> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Interpretacion_IMCRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Interpretacion_IMC.Interpretacion_IMC GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Interpretacion_IMC.Interpretacion_IMC result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Interpretacion_IMCInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Interpretacion_IMC.Interpretacion_IMC entity, Spartane.Core.Domain.User.GlobalData Interpretacion_IMCInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Interpretacion_IMC.Interpretacion_IMC entity, Spartane.Core.Domain.User.GlobalData Interpretacion_IMCInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

