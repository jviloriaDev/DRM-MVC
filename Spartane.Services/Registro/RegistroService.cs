using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Registro;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Registro
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class RegistroService : IRegistroService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Registro.Registro> _RegistroRepository;
        #endregion

        #region Ctor
        public RegistroService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Registro.Registro> RegistroRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._RegistroRepository = RegistroRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Registro.Registro> SelAll(bool ConRelaciones)
        {
            return this._RegistroRepository.Table.ToList();
        }

        public IList<Core.Domain.Registro.Registro> SelAllComplete(bool ConRelaciones)
        {
            return this._RegistroRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Registro.Registro> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._RegistroRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Registro.Registro> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._RegistroRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Registro.Registro> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._RegistroRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Registro.RegistroPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            RegistroPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Registro.Registro> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._RegistroRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Registro.Registro GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Registro.Registro result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData RegistroInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Registro.Registro entity, Spartane.Core.Domain.User.GlobalData RegistroInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Registro.Registro entity, Spartane.Core.Domain.User.GlobalData RegistroInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

