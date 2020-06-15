using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Detalle_Antecedentes_Familiares;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Antecedentes_Familiares
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Antecedentes_FamiliaresService : IDetalle_Antecedentes_FamiliaresService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Detalle_Antecedentes_Familiares.Detalle_Antecedentes_Familiares> _Detalle_Antecedentes_FamiliaresRepository;
        #endregion

        #region Ctor
        public Detalle_Antecedentes_FamiliaresService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Detalle_Antecedentes_Familiares.Detalle_Antecedentes_Familiares> Detalle_Antecedentes_FamiliaresRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Antecedentes_FamiliaresRepository = Detalle_Antecedentes_FamiliaresRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Detalle_Antecedentes_Familiares.Detalle_Antecedentes_Familiares> SelAll(bool ConRelaciones)
        {
            return this._Detalle_Antecedentes_FamiliaresRepository.Table.ToList();
        }

        public IList<Core.Domain.Detalle_Antecedentes_Familiares.Detalle_Antecedentes_Familiares> SelAllComplete(bool ConRelaciones)
        {
            return this._Detalle_Antecedentes_FamiliaresRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Detalle_Antecedentes_Familiares.Detalle_Antecedentes_Familiares> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Antecedentes_FamiliaresRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_Antecedentes_Familiares.Detalle_Antecedentes_Familiares> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Antecedentes_FamiliaresRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_Antecedentes_Familiares.Detalle_Antecedentes_Familiares> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Antecedentes_FamiliaresRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_Antecedentes_Familiares.Detalle_Antecedentes_FamiliaresPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Detalle_Antecedentes_FamiliaresPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Detalle_Antecedentes_Familiares.Detalle_Antecedentes_Familiares> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Antecedentes_FamiliaresRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_Antecedentes_Familiares.Detalle_Antecedentes_Familiares GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Detalle_Antecedentes_Familiares.Detalle_Antecedentes_Familiares result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Detalle_Antecedentes_FamiliaresInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Detalle_Antecedentes_Familiares.Detalle_Antecedentes_Familiares entity, Spartane.Core.Domain.User.GlobalData Detalle_Antecedentes_FamiliaresInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Detalle_Antecedentes_Familiares.Detalle_Antecedentes_Familiares entity, Spartane.Core.Domain.User.GlobalData Detalle_Antecedentes_FamiliaresInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

