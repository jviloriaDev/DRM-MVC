using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Detalle_Antecedentes_No_Patologicos;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Antecedentes_No_Patologicos
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Antecedentes_No_PatologicosService : IDetalle_Antecedentes_No_PatologicosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Detalle_Antecedentes_No_Patologicos.Detalle_Antecedentes_No_Patologicos> _Detalle_Antecedentes_No_PatologicosRepository;
        #endregion

        #region Ctor
        public Detalle_Antecedentes_No_PatologicosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Detalle_Antecedentes_No_Patologicos.Detalle_Antecedentes_No_Patologicos> Detalle_Antecedentes_No_PatologicosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Antecedentes_No_PatologicosRepository = Detalle_Antecedentes_No_PatologicosRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Detalle_Antecedentes_No_Patologicos.Detalle_Antecedentes_No_Patologicos> SelAll(bool ConRelaciones)
        {
            return this._Detalle_Antecedentes_No_PatologicosRepository.Table.ToList();
        }

        public IList<Core.Domain.Detalle_Antecedentes_No_Patologicos.Detalle_Antecedentes_No_Patologicos> SelAllComplete(bool ConRelaciones)
        {
            return this._Detalle_Antecedentes_No_PatologicosRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Detalle_Antecedentes_No_Patologicos.Detalle_Antecedentes_No_Patologicos> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Antecedentes_No_PatologicosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_Antecedentes_No_Patologicos.Detalle_Antecedentes_No_Patologicos> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Antecedentes_No_PatologicosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_Antecedentes_No_Patologicos.Detalle_Antecedentes_No_Patologicos> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Antecedentes_No_PatologicosRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_Antecedentes_No_Patologicos.Detalle_Antecedentes_No_PatologicosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Detalle_Antecedentes_No_PatologicosPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Detalle_Antecedentes_No_Patologicos.Detalle_Antecedentes_No_Patologicos> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Antecedentes_No_PatologicosRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_Antecedentes_No_Patologicos.Detalle_Antecedentes_No_Patologicos GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Detalle_Antecedentes_No_Patologicos.Detalle_Antecedentes_No_Patologicos result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Detalle_Antecedentes_No_PatologicosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Detalle_Antecedentes_No_Patologicos.Detalle_Antecedentes_No_Patologicos entity, Spartane.Core.Domain.User.GlobalData Detalle_Antecedentes_No_PatologicosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Detalle_Antecedentes_No_Patologicos.Detalle_Antecedentes_No_Patologicos entity, Spartane.Core.Domain.User.GlobalData Detalle_Antecedentes_No_PatologicosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

