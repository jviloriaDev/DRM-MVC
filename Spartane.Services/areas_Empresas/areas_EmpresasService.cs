using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.areas_Empresas;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.areas_Empresas
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class areas_EmpresasService : Iareas_EmpresasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.areas_Empresas.areas_Empresas> _areas_EmpresasRepository;
        #endregion

        #region Ctor
        public areas_EmpresasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.areas_Empresas.areas_Empresas> areas_EmpresasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._areas_EmpresasRepository = areas_EmpresasRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.areas_Empresas.areas_Empresas> SelAll(bool ConRelaciones)
        {
            return this._areas_EmpresasRepository.Table.ToList();
        }

        public IList<Core.Domain.areas_Empresas.areas_Empresas> SelAllComplete(bool ConRelaciones)
        {
            return this._areas_EmpresasRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.areas_Empresas.areas_Empresas> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._areas_EmpresasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.areas_Empresas.areas_Empresas> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._areas_EmpresasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.areas_Empresas.areas_Empresas> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._areas_EmpresasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.areas_Empresas.areas_EmpresasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            areas_EmpresasPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.areas_Empresas.areas_Empresas> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._areas_EmpresasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.areas_Empresas.areas_Empresas GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.areas_Empresas.areas_Empresas result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData areas_EmpresasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.areas_Empresas.areas_Empresas entity, Spartane.Core.Domain.User.GlobalData areas_EmpresasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.areas_Empresas.areas_Empresas entity, Spartane.Core.Domain.User.GlobalData areas_EmpresasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

