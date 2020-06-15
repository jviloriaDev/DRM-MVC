using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Spartan_BR_Action_Result;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_BR_Action_Result
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_BR_Action_ResultService : ISpartan_BR_Action_ResultService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Spartan_BR_Action_Result.Spartan_BR_Action_Result> _Spartan_BR_Action_ResultRepository;
        #endregion

        #region Ctor
        public Spartan_BR_Action_ResultService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Spartan_BR_Action_Result.Spartan_BR_Action_Result> Spartan_BR_Action_ResultRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_BR_Action_ResultRepository = Spartan_BR_Action_ResultRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Spartan_BR_Action_Result.Spartan_BR_Action_Result> SelAll(bool ConRelaciones)
        {
            return this._Spartan_BR_Action_ResultRepository.Table.ToList();
        }

        public IList<Core.Domain.Spartan_BR_Action_Result.Spartan_BR_Action_Result> SelAllComplete(bool ConRelaciones)
        {
            return this._Spartan_BR_Action_ResultRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Spartan_BR_Action_Result.Spartan_BR_Action_Result> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_BR_Action_ResultRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_BR_Action_Result.Spartan_BR_Action_Result> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_BR_Action_ResultRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_BR_Action_Result.Spartan_BR_Action_Result> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_BR_Action_ResultRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_BR_Action_Result.Spartan_BR_Action_ResultPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Spartan_BR_Action_ResultPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Spartan_BR_Action_Result.Spartan_BR_Action_Result> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_BR_Action_ResultRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_BR_Action_Result.Spartan_BR_Action_Result GetByKey(short Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Spartan_BR_Action_Result.Spartan_BR_Action_Result result=null;
            return result;
        }

        public bool Delete(short Key, Spartane.Core.Domain.User.GlobalData Spartan_BR_Action_ResultInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public short Insert(Spartane.Core.Domain.Spartan_BR_Action_Result.Spartan_BR_Action_Result entity, Spartane.Core.Domain.User.GlobalData Spartan_BR_Action_ResultInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            short rta = Convert.ToInt16("0");
            return rta;
        }

        public short Update(Spartane.Core.Domain.Spartan_BR_Action_Result.Spartan_BR_Action_Result entity, Spartane.Core.Domain.User.GlobalData Spartan_BR_Action_ResultInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            short rta = Convert.ToInt16("0");
            return rta;
        }
        #endregion
    }
}

