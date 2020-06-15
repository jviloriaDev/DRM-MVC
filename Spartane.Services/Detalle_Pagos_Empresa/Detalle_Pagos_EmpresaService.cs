using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Detalle_Pagos_Empresa;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Pagos_Empresa
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Pagos_EmpresaService : IDetalle_Pagos_EmpresaService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Detalle_Pagos_Empresa.Detalle_Pagos_Empresa> _Detalle_Pagos_EmpresaRepository;
        #endregion

        #region Ctor
        public Detalle_Pagos_EmpresaService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Detalle_Pagos_Empresa.Detalle_Pagos_Empresa> Detalle_Pagos_EmpresaRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Pagos_EmpresaRepository = Detalle_Pagos_EmpresaRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Detalle_Pagos_Empresa.Detalle_Pagos_Empresa> SelAll(bool ConRelaciones)
        {
            return this._Detalle_Pagos_EmpresaRepository.Table.ToList();
        }

        public IList<Core.Domain.Detalle_Pagos_Empresa.Detalle_Pagos_Empresa> SelAllComplete(bool ConRelaciones)
        {
            return this._Detalle_Pagos_EmpresaRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Detalle_Pagos_Empresa.Detalle_Pagos_Empresa> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Pagos_EmpresaRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_Pagos_Empresa.Detalle_Pagos_Empresa> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Pagos_EmpresaRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_Pagos_Empresa.Detalle_Pagos_Empresa> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Pagos_EmpresaRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_Pagos_Empresa.Detalle_Pagos_EmpresaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Detalle_Pagos_EmpresaPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Detalle_Pagos_Empresa.Detalle_Pagos_Empresa> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Pagos_EmpresaRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_Pagos_Empresa.Detalle_Pagos_Empresa GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Detalle_Pagos_Empresa.Detalle_Pagos_Empresa result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Detalle_Pagos_EmpresaInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Detalle_Pagos_Empresa.Detalle_Pagos_Empresa entity, Spartane.Core.Domain.User.GlobalData Detalle_Pagos_EmpresaInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Detalle_Pagos_Empresa.Detalle_Pagos_Empresa entity, Spartane.Core.Domain.User.GlobalData Detalle_Pagos_EmpresaInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

