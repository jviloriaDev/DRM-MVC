using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Frecuencia_de_pago_Empresas;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Frecuencia_de_pago_Empresas
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Frecuencia_de_pago_EmpresasService : IFrecuencia_de_pago_EmpresasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas> _Frecuencia_de_pago_EmpresasRepository;
        #endregion

        #region Ctor
        public Frecuencia_de_pago_EmpresasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas> Frecuencia_de_pago_EmpresasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Frecuencia_de_pago_EmpresasRepository = Frecuencia_de_pago_EmpresasRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas> SelAll(bool ConRelaciones)
        {
            return this._Frecuencia_de_pago_EmpresasRepository.Table.ToList();
        }

        public IList<Core.Domain.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas> SelAllComplete(bool ConRelaciones)
        {
            return this._Frecuencia_de_pago_EmpresasRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Frecuencia_de_pago_EmpresasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Frecuencia_de_pago_EmpresasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Frecuencia_de_pago_EmpresasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_EmpresasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Frecuencia_de_pago_EmpresasPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Frecuencia_de_pago_EmpresasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Frecuencia_de_pago_EmpresasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas entity, Spartane.Core.Domain.User.GlobalData Frecuencia_de_pago_EmpresasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Frecuencia_de_pago_Empresas.Frecuencia_de_pago_Empresas entity, Spartane.Core.Domain.User.GlobalData Frecuencia_de_pago_EmpresasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

