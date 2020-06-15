using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Sexo;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Sexo
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class SexoService : ISexoService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Sexo.Sexo> _SexoRepository;
        #endregion

        #region Ctor
        public SexoService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Sexo.Sexo> SexoRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._SexoRepository = SexoRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Sexo.Sexo> SelAll(bool ConRelaciones)
        {
            return this._SexoRepository.Table.ToList();
        }

        public IList<Core.Domain.Sexo.Sexo> SelAllComplete(bool ConRelaciones)
        {
            return this._SexoRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Sexo.Sexo> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._SexoRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Sexo.Sexo> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._SexoRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Sexo.Sexo> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._SexoRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Sexo.SexoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            SexoPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Sexo.Sexo> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._SexoRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Sexo.Sexo GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Sexo.Sexo result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData SexoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Sexo.Sexo entity, Spartane.Core.Domain.User.GlobalData SexoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Sexo.Sexo entity, Spartane.Core.Domain.User.GlobalData SexoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

