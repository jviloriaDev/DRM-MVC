using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Spartan_BR_Conditions_Detail;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Spartan_BR_Conditions_Detail
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Spartan_BR_Conditions_DetailService : ISpartan_BR_Conditions_DetailService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Spartan_BR_Conditions_Detail.Spartan_BR_Conditions_Detail> _Spartan_BR_Conditions_DetailRepository;
        #endregion

        #region Ctor
        public Spartan_BR_Conditions_DetailService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Spartan_BR_Conditions_Detail.Spartan_BR_Conditions_Detail> Spartan_BR_Conditions_DetailRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Spartan_BR_Conditions_DetailRepository = Spartan_BR_Conditions_DetailRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Spartan_BR_Conditions_Detail.Spartan_BR_Conditions_Detail> SelAll(bool ConRelaciones)
        {
            return this._Spartan_BR_Conditions_DetailRepository.Table.ToList();
        }

        public IList<Core.Domain.Spartan_BR_Conditions_Detail.Spartan_BR_Conditions_Detail> SelAllComplete(bool ConRelaciones)
        {
            return this._Spartan_BR_Conditions_DetailRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Spartan_BR_Conditions_Detail.Spartan_BR_Conditions_Detail> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_BR_Conditions_DetailRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_BR_Conditions_Detail.Spartan_BR_Conditions_Detail> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Spartan_BR_Conditions_DetailRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Spartan_BR_Conditions_Detail.Spartan_BR_Conditions_Detail> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Spartan_BR_Conditions_DetailRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_BR_Conditions_Detail.Spartan_BR_Conditions_DetailPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Spartan_BR_Conditions_DetailPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Spartan_BR_Conditions_Detail.Spartan_BR_Conditions_Detail> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Spartan_BR_Conditions_DetailRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Spartan_BR_Conditions_Detail.Spartan_BR_Conditions_Detail GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Spartan_BR_Conditions_Detail.Spartan_BR_Conditions_Detail result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Spartan_BR_Conditions_DetailInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Spartan_BR_Conditions_Detail.Spartan_BR_Conditions_Detail entity, Spartane.Core.Domain.User.GlobalData Spartan_BR_Conditions_DetailInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Spartan_BR_Conditions_Detail.Spartan_BR_Conditions_Detail entity, Spartane.Core.Domain.User.GlobalData Spartan_BR_Conditions_DetailInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

