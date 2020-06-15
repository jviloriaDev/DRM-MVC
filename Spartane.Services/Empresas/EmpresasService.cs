using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Empresas;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Empresas
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class EmpresasService : IEmpresasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Empresas.Empresas> _EmpresasRepository;
        #endregion

        #region Ctor
        public EmpresasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Empresas.Empresas> EmpresasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._EmpresasRepository = EmpresasRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Empresas.Empresas> SelAll(bool ConRelaciones)
        {
            return this._EmpresasRepository.Table.ToList();
        }

        public IList<Core.Domain.Empresas.Empresas> SelAllComplete(bool ConRelaciones)
        {
            return this._EmpresasRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Empresas.Empresas> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._EmpresasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Empresas.Empresas> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._EmpresasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Empresas.Empresas> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._EmpresasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Empresas.EmpresasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            EmpresasPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Empresas.Empresas> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._EmpresasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Empresas.Empresas GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Empresas.Empresas result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpresasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Empresas.Empresas entity, Spartane.Core.Domain.User.GlobalData EmpresasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Empresas.Empresas entity, Spartane.Core.Domain.User.GlobalData EmpresasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

